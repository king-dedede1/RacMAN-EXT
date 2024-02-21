using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using NLua;
using NLua.Exceptions;
using RacMAN.API;

namespace RacMAN;
public class Racman
{
    public IMemoryAPI api;
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
                this.api = new RatchetronClient(form.ipAddress);
                break;
            case APIType.RPCS3:
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

        OnAPIConnect();
        InitLuaState();
    }

    // maybe move this somewhere else?
    public static byte[] ReverseArray(byte[] arr)
    {
        return arr.Reverse().ToArray();
    }

    void InitLuaState()
    {
        lua = new Lua();

        // TODO add the interop functions here I think
        lua.LoadCLRPackage();
        lua.RegisterFunction("TableToByteArray", typeof(LuaFunctions).GetMethod("LuaTableToByteArray"));
        lua.RegisterFunction("IntToBytes", typeof(BitConverter).GetMethod("GetBytes", new Type[] { typeof(int) }));
        lua.RegisterFunction("FloatToBytes", typeof(BitConverter).GetMethod("GetBytes", new Type[] { typeof(float) }));
        lua.RegisterFunction("ReverseArray", typeof(Racman).GetMethod("ReverseArray"));
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
                // TODO replace with lua console
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
