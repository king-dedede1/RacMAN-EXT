using NLua;
using NLua.Exceptions;
using System.Reflection;
using RacMAN.API;
using RacMAN.Forms;

namespace RacMAN;
public class Racman
{
    public MemoryAPI? api;
    public APIType apiType;
    internal bool connected;
    public string gameTitleID;
    public LuaConsoleForm consoleForm;

    public MainForm MainForm { get; set; }
    internal event Action OnAPIConnect;

    public static Lua lua; // maybe shouldnt be static?

    public Racman()
    {
        MainForm = new MainForm(this);
        connected = false;
        api = null;
        consoleForm = new LuaConsoleForm();
    }

    public void ShowConnectDialog()
    {
        AttachGameForm form = new AttachGameForm();
        form.ShowDialog();

        apiType = form.apiType;

        switch (form.apiType)
        {
            case APIType.PS3:
                this.api = new Ratchetron(form.ipAddress);
                break;
            case APIType.RPCS3:
                this.api = new RPCS3();
                break;
            case APIType.PCSX2: break;
        }

        if (this.api == null)
        {
            this.connected = false;
            MainForm.Text = $"RaCMAN {Assembly.GetEntryAssembly().GetName().Version} (Not Connected)";
        }
        else
        {
            this.connected = true;
            this.gameTitleID = this.api.GetGameTitleID();
            MainForm.Text = $"RaCMAN {Assembly.GetEntryAssembly().GetName().Version} - {this.gameTitleID} - {api.GetGameTitle()}";
        }

        InitLuaState();
        OnAPIConnect();
    }

    // maybe move this somewhere else?


    internal void InitLuaState()
    {
        lua = new Lua();

        // Allow loading .NET assemblies.
        lua.LoadCLRPackage();

        EvalLua("Convert = {}");

        // Putting these functions here because calling them directly from lua doesn't seem to be possible.
        lua.RegisterFunction("Convert.TableToByteArray", typeof(LuaFunctions).GetMethod("LuaTableToByteArray"));
        lua.RegisterFunction("Convert.IntToByteArray", typeof(LuaFunctions).GetMethod("IntToByteArray"));
        lua.RegisterFunction("Convert.FloatToByteArray", typeof(BitConverter).GetMethod("GetBytes", new Type[] { typeof(float) }));
        lua.RegisterFunction("Convert.ReverseArray", typeof(LuaFunctions).GetMethod("ReverseArray"));
        lua["API"] = api;
        lua["Racman"] = this;

        // if a game script and racman script have the same name for some reason, the racman script will be prioritized.
        EvalLua($"package.path = \"scripts/racman/?.lua;scripts/racman/?;scripts/game/{gameTitleID ?? ""}/?;scripts/game/{gameTitleID ?? ""}/?.lua\"");

        // Load racman common scripts
        foreach (string filePath in Directory.EnumerateFiles("scripts/racman/"))
        {
            LuaConsoleForm.instance.Log($"Loading script {filePath}");
            // using require instead of DoFile prevents running the same file twice
            EvalLua($"require '{Path.GetFileNameWithoutExtension(filePath)}'");
        }

        // Prevent user scripts from loading .NET assemblies for security
        // If there's something that can only be done by loading an assembly, it should
        // probably be included in the racman scripts anyway
        EvalLua("import = function() end");

        // Load game libraries/scripts
        if (connected && gameTitleID != null)
        {
            if (Directory.Exists($"scripts/game/{gameTitleID}/"))
            {
                foreach (string filePath in Directory.EnumerateFiles($"scripts/game/{gameTitleID}/"))
                {
                    LuaConsoleForm.instance.Log($"Loading script {filePath}");
                    EvalLua($"require '{Path.GetFileNameWithoutExtension(filePath)}'");
                }
            }
            else
            {
                // this game doesn't have a directory for scripts, so make one
                Directory.CreateDirectory($"scripts/game/{gameTitleID}/");
            }
        }
    }

    public static object[] EvalLua(string code)
    {
        if (lua != null)
        {
            try
            {
                return lua.DoString(code);
            }
            catch (LuaException e)
            {
                LuaConsoleForm.instance.Error(e.ToString());
                return null;
            }
        }
        else
        {
            return null;
        }
    }
}
