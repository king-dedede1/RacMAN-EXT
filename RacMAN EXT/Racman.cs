using NLua;
using NLua.Exceptions;
using RacMAN.API;
using RacMAN.API.Inputs;
using RacMAN.Autosplitters;
using RacMAN.ControllerCombos;
using RacMAN.Forms;
using System.Net;
using System.Reflection;
using System.Text.Json;

namespace RacMAN;
public class Racman
{
    public MemoryAPI? API { get; private set; }
    public APIType APIType { get; private set; }

    private IInputProvider? _inputprovider;
    public IInputProvider? InputProvider
    {
        get => _inputprovider;
        internal set {
            _inputprovider = value;
            InputProviderChanged?.Invoke();
        }
    }

    public bool Connected { get; private set; }
    public string GameTitleID { get; private set; }
    public MainForm MainForm { get; private set; }
    public ControllerCombosForm? CombosForm { get; set; }
    public LuaConsoleForm ConsoleForm { get; private set; }
    public Game? Game { get; private set; }
    public List<Autosplitter> Autosplitters { get; private set; } = [];
    internal ControllerComboManager? ControllerComboManager { get; set; }
    internal UserSettings Settings { get; }

    private Mutex luaMut = new();

    internal event Action APIConnected;
    internal event Action InputProviderChanged;

    private const string settingsPath = "data/common/user/settings.json";
    private readonly JsonSerializerOptions o = new() { WriteIndented = true, Converters = { new ColorJsonConverter() } };

    public static Lua lua; // maybe shouldnt be static?

    internal Racman()
    {
        if (File.Exists(settingsPath))
        {
            Settings = JsonSerializer.Deserialize<UserSettings>(File.ReadAllText(settingsPath), o) ?? new UserSettings();
        }
        else
        {
            Settings = new UserSettings();
        }

        MainForm = new MainForm(this);
        Connected = false;
        API = null;
        ConsoleForm = new LuaConsoleForm(this);


        // Create the window so logging can still happen if the window isn't shown
        // For some reason, this works.
        var _ = ConsoleForm.Handle;
        _ = MainForm.Handle;

        GameTitleID = "NONE00000";

    }

    internal void ShowConnectDialog()
    {
        AttachGameForm form = new AttachGameForm(this);
        form.ShowDialog();

        APIType = form.apiType;

        if (API != null) API.Disconnect();

        switch (form.apiType)
        {
            case APIType.PS3:
                this.API = new Ratchetron(form.BoxText, (int) Settings.SocketTimeoutInterval);
                Settings.RatchetronIP = form.BoxText;
                break;
            case APIType.RPCS3:
                {
                    var slot = UInt16.Parse(form.BoxText);
                    Settings.RPCS3Slot = slot;
                    this.API = new RPCS3(slot, (int) Settings.SocketTimeoutInterval);
                    break;
                }
            case APIType.PCSX2:
                {
                    var slot = UInt16.Parse(form.BoxText);
                    Settings.PCSX2Slot = slot;
                    this.API = new PCSX2(slot, (int) Settings.SocketTimeoutInterval);
                    break;
                }
            case APIType.None:
                this.API = null;
                break;
        }

        if (this.API == null)
        {
            this.Connected = false;
            MainForm.Text = $"RaCMAN {Assembly.GetEntryAssembly().GetName().Version} (Not Connected)";
            Game = null;
        }
        else
        {
            this.Connected = true;
            this.GameTitleID = this.API.GetGameTitleID();
            var gameTitle = API.GetGameTitle();
            MainForm.Text = $"RaCMAN {Assembly.GetEntryAssembly().GetName().Version} - {this.GameTitleID} - {gameTitle}";
            // load game from disk
            Game = new(GameTitleID, gameTitle);
            if (API is IInputProvider input)
            {
                InputProvider = input;
            }
            else
            {
                InputProvider = null;
            }
        }


        InitLuaState();
        if (Game != null && InputProvider != null)
            ControllerComboManager = new(this, Game.ControllerCombos);
        APIConnected?.Invoke();
    }

    internal void InitLuaState()
    {
        LuaConsoleForm.instance.Log("Initializing lua state...");

        lua = new Lua();

        // Allow loading .NET assemblies.
        lua.LoadCLRPackage();

        EvalLua("Convert = {}");
        EvalLua("Autosplitter = {}");

        // Putting these functions here because calling them directly from lua doesn't seem to be possible.
        lua.RegisterFunction("Convert.TableToByteArray", typeof(LuaFunctions).GetMethod("LuaTableToByteArray"));
        lua.RegisterFunction("Convert.IntToByteArray", typeof(LuaFunctions).GetMethod("IntToByteArray"));
        lua.RegisterFunction("Convert.FloatToByteArray", typeof(BitConverter).GetMethod("GetBytes", [typeof(float)]));
        lua.RegisterFunction("Convert.ReverseArray", typeof(LuaFunctions).GetMethod("ReverseArray"));
        lua.RegisterFunction("Autosplitter.Create", typeof(Autosplitter).GetMethod("Create"));
        lua["API"] = API;
        lua["Racman"] = this;

        // if a game script and racman script have the same name for some reason, the racman script will be prioritized.
        EvalLua($"package.path = 'data/common/scripts/?;data/common/scripts/?.lua;{Game?.ScriptFolderPath ?? ""}?;{Game?.ScriptFolderPath ?? ""}?.lua'");

        // Load racman common scripts
        foreach (string filePath in Directory.EnumerateFiles("data/common/scripts/"))
        {
            LuaConsoleForm.instance.Log($"Loading script {filePath}");
            // using require instead of DoFile prevents running the same file twice
            EvalLua($"require '{Path.GetFileNameWithoutExtension(filePath)}'");
        }

        // Prevent user scripts from loading .NET assemblies for security
        // If there's something that can only be done by loading an assembly, it should
        // probably be included in the racman scripts anyway
        EvalLua("import = function() end");

        // Load game scripts (if they exist)
        if (Game?.ScriptFolderPath != null)
        {
            foreach (var path in Directory.EnumerateFiles(Game.ScriptFolderPath))
            {
                ConsoleForm.Log($"Loading game script {path}");
                EvalLua($"require '{Path.GetFileNameWithoutExtension(path)}'");
            }
        }

        LuaConsoleForm.instance.Log("Lua done initializing");
    }

    internal object[]? EvalLua(string code)
    {
        object[]? returnVal = null;
        if (lua != null)
        {
            luaMut.WaitOne();
            try
            {
                returnVal = lua.DoString(code);
            }
            catch (LuaException e)
            {
                LuaConsoleForm.instance.Error(e.ToString());
            }
            luaMut.ReleaseMutex();
        }
        return returnVal;
    }

    internal object[]? EvalLua(LuaFunction func, params object?[]? param)
    {
        object[]? returnVal = null;
        if (lua != null)
        {
            luaMut.WaitOne();
            try
            {
                returnVal = func.Call(param);
            }
            catch (LuaException e)
            {
                Error(e.ToString());
            }
            luaMut.ReleaseMutex();
        }
        return returnVal;
    }

    internal LuaFunction? CompileLuaFunction(string code)
    {
        string funcCode = $"""
            local function myFunction()
                {code}
            end
            return myFunction
            """;
        var returnval = EvalLua(funcCode);
        return (LuaFunction?) returnval?[0];
    }

    public void Log(string msg)
    {
        ConsoleForm.BeginInvoke(ConsoleForm.Log, msg);
    }

    public void Warn(string msg)
    {
        ConsoleForm.BeginInvoke(ConsoleForm.Warn, msg);
    }

    public void Error(string msg)
    {
        ConsoleForm.BeginInvoke(ConsoleForm.Error, msg);
    }

    public void MakeAddressInputProviderIfNull(uint buttonAddress, uint analogAddress)
    {
        if (API == null)
        {
            Error("Can't set input provider because API is null");
            return;
        }
        if (InputProvider == null)
        {
            InputProvider = new AddressInputProvider(API, buttonAddress, analogAddress);
            Log($"Using address input provider (buttons = 0x{buttonAddress:X8}, analog = 0x{analogAddress:X8})");
        }
        else
        {
            Log("Not switching input provider as one is already in use.");
        }
    }

    internal void SaveSettings()
    {
        
        File.WriteAllText(settingsPath, JsonSerializer.Serialize(Settings, o));
    }
}
