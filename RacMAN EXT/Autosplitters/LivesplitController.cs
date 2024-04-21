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

    /*TODO change this so that there's one pipe among all livesplit controllers, even if there's
     * more than 1 livesplit controller having more than 1 pipe is unnecessary.
     * 
     * ALSO autosplitter shouldnt get a livesplit controller until it is actually started,
     * this is bad
     */

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
