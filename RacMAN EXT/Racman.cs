using NLua;
using NLua.Exceptions;
using System.Reflection;
using RacMAN.API;
using RacMAN.Forms;
using System.Net;
using RacMAN.Autosplitters;

namespace RacMAN;
public class Racman
{
    public MemoryAPI? API { get; private set; }
    public APIType APIType { get; private set; }
    public bool Connected { get; private set; }
    public string GameTitleID { get; private set; }
    public MainForm MainForm { get; private set; }
    public LuaConsoleForm ConsoleForm { get; private set; }
    public Game? Game { get; private set; }
    public List<Autosplitter> Autosplitters { get; private set; } = [];

    private Mutex luaMut = new();

    internal event Action OnAPIConnect;

    public static Lua lua; // maybe shouldnt be static?

    public Racman()
    {
        MainForm = new MainForm(this);
        Connected = false;
        API = null;
        ConsoleForm = new LuaConsoleForm();

        // Create the window so logging can still happen if the window isn't shown
        // For some reason, this works.
        var _ = ConsoleForm.Handle;

        GameTitleID = "NONE00000";

    }

    public void ShowConnectDialog()
    {
        AttachGameForm form = new AttachGameForm();
        form.ShowDialog();

        APIType = form.apiType;

        switch (form.apiType)
        {
            case APIType.PS3:
                this.API = new Ratchetron(IPAddress.Parse(form.BoxText));
                break;
            case APIType.RPCS3:
                this.API = new RPCS3(UInt16.Parse(form.BoxText));
                break;
            case APIType.PCSX2:
                this.API = new PCSX2(UInt16.Parse(form.BoxText));
                break;
        }

        if (this.API == null)
        {
            this.Connected = false;
            MainForm.Text = $"RaCMAN {Assembly.GetEntryAssembly().GetName().Version} (Not Connected)";
        }
        else
        {
            this.Connected = true;
            this.GameTitleID = this.API.GetGameTitleID();
            MainForm.Text = $"RaCMAN {Assembly.GetEntryAssembly().GetName().Version} - {this.GameTitleID} - {API.GetGameTitle()}";
            // load game from disk
            Game = new(GameTitleID);
        }


        InitLuaState();
        OnAPIConnect?.Invoke();
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

    public object[]? EvalLua(string code)
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

    public object[]? EvalLua(LuaFunction func, params object[]? param)
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
                LuaConsoleForm.instance.Error(e.ToString());
            }
            luaMut.ReleaseMutex();
        }
        return returnVal;
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
        ConsoleForm.BeginInvoke(ConsoleForm.Warn, msg);
    }
}
