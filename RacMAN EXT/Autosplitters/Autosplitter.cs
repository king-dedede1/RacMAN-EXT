using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLua;

namespace RacMAN.Autosplitters;
public class Autosplitter
{
    public string GameID { get; set; }
    public string GameName { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    public LivesplitController Controller { get; set; }

    public LuaFunction StartFunction { get; set; }
    public LuaFunction UpdateFunction { get; set; }
    public LuaFunction StopFunction { get; set; }

    public bool Running;

    public Autosplitter(string name, string description, LuaFunction startFunction, LuaFunction updateFunction, LuaFunction stopFunction)
    {
        Name = name;
        Description = description;
        StartFunction = startFunction;
        UpdateFunction = updateFunction;
        StopFunction = stopFunction;

        GameID = Program.state.gameTitleID;
        GameName = Program.state.api.GetGameTitle();
        Controller = new();
    }

    public static void Create(string name, string description, LuaFunction start, LuaFunction update, LuaFunction stop)
    {
        Program.state.autosplitters.Add(new Autosplitter(name, description, start, update, stop));
    }

    public void Start()
    {
        Running = true;
        Controller = new LivesplitController();
        new Thread(UpdateThread).Start();
    }

    public void Stop()
    {
        Running = false;
    }

    public void UpdateThread()
    {
        StartFunction.Call();
        while (Running)
        {
            UpdateFunction.Call(Controller);
            Thread.Sleep(16);
        }
        StopFunction.Call();
    }
}
