using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Pipes;

namespace RacMAN.Autosplitters;
public class LivesplitController
{
    NamedPipeClientStream pipe;

    internal LivesplitController()
    {
        pipe = new("LiveSplit");

        try
        {
            pipe.Connect(1);
        }
        catch
        {
            MessageBox.Show("Could not connect to LiveSplit server");
        }
    }

    ~LivesplitController()
    {
        pipe.Close();
    }

    public void DoCommand(string command)
    {
        if (pipe.IsConnected)
        {
            byte[] commandBytes = [.. Encoding.ASCII.GetBytes(command), 0x0d, 0x0a];
            pipe.Write(commandBytes, 0, commandBytes.Length);
        }
    }

    public void Start() => DoCommand("starttimer");

    public void StartOrSplit() => DoCommand("startorsplit");

    public void Split() => DoCommand("split");

    public void Reset() => DoCommand("reset");

    public void PauseGameTime() => DoCommand("pausegametime");

    public void UnpauseGameTime() => DoCommand("unpausegametime");
}
