using RacMAN.Forms;
using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;

namespace RacMAN.API;
public class RPCS3 : MemoryAPI
{
    const string PROCESS_NAME = "rpcs3";

    private nint hProcess;
    private int pid;
    private bool workerRunning;
    private List<MemSub> memSubs = [];

    private class MemSub
    {
        //MemSub's state
        public uint address;
        public MemSubType type;
        public uint size;
        public Action<byte[]>? callback;
        public byte[]? freezeValue;

        // for checking if value has changed
        public byte[]? oldValue;

        // to be written by application and read by worker thread
        public bool released;
        
    }

    private enum MemSubType
    {
        SUBSCRIBE,
        FREEZE
    }

    public RPCS3()
    {
        var processList = Process.GetProcessesByName(PROCESS_NAME);
        if (processList.Length == 0)
        {
            throw new Exception("Couldn't locate process to connect to. Did you start the game yet?");
        }
        Process process = processList[0];
        pid = process.Id;
        hProcess = Win32.OpenProcess(Win32.PROCESS_ALL_ACCESS, false, pid);
        if (hProcess == IntPtr.Zero)
        {
            throw new Exception($"Invalid handle ({hProcess:X})");
        }

        // start mem sub worker thread
        new Thread(MemSubWorkerThread).Start();
        workerRunning = true;
    }

    public override void Disconnect()
    {
        workerRunning = false;
        Win32.CloseHandle(hProcess);
    }

    public override int FreezeMemory(uint addr, byte[] value)
    {
        var memsub = new MemSub()
        {
            address = addr,
            type = MemSubType.FREEZE,
            size = (uint) value.Length,
            released = false,
            freezeValue = value
        };
        memSubs.Add(memsub);
        return memSubs.Count-1;
    }

    public override string GetGameTitle()
    {
        var title = GetGameWindowTitle(pid);

        var match = Regex.Match(title, "(?<=(.*\\|.*){3})([^|[]+)"); // it works i guess

        if (match.Success)
        {
            // fun fact i spent like 20 minutes trying to trim the whitespace with regex not knowing there was a method for it
            return match.Value.Trim();
        }
        else
        {
            throw new Exception("Couldn't get game title");
        }
    }

    public override string GetGameTitleID()
    {
        var title = GetGameWindowTitle(pid);

        var match = Regex.Match(title, "([A-Z]{4})(\\d{5})");

        if (match.Success)
        {
            return match.Value;
        }
        else
        {
            throw new Exception("Couldn't get game title ID");
        }
    }

    public override void Notify(string text)
    {
        MessageBox.Show(text);
    }

    public override byte[] ReadMemory(uint addr, uint size)
    {
        byte[] buffer = new byte[size];
        if (!Win32.ReadProcessMemory(hProcess, (nint) (addr + 0x300000000), buffer, size, out _))
        {
            throw new IOException($"Unable to read memory (Error code 0x{Win32.GetLastError():X})");
        }
        return buffer;
    }

    public override void ReleaseSubID(int id)
    {
        if (id >= 0 && id < memSubs.Count)
        {
            memSubs[id].released = true;
        }
        else
        {
            LuaConsoleForm.instance.Warn($"Tried to release sub ID {id} but it doesn't exist!");
        }
    }

    public override int SubMemory(uint addr, uint size, Action<byte[]> callback)
    {
        var memsub = new MemSub()
        {
            address = addr,
            size = size,
            callback = callback,
            type = MemSubType.SUBSCRIBE,
        };
        memSubs.Add(memsub);
        return memSubs.Count-1;
    }

    public override void WriteMemory(uint addr, byte[] bytes)
    {
        if (!Win32.WriteProcessMemory(hProcess, (nint)(addr + 0x300000000), bytes, (nuint)bytes.Length, out _))
        {
            throw new IOException($"Unable to write memory (Error code 0x{Win32.GetLastError():X})");
        }
    }

    private static string GetGameWindowTitle(int processId)
    {
        // fix later
        foreach (string s in GetWindowTitles(processId)) if (s.Contains('[')) return s;
        return "";
    }

    internal static List<string> GetWindowTitles(int processId)
    {
        List<string> titles = new List<string>();

        Win32.EnumWindows((hWnd, lParam) =>
        {
            uint windowProcessId;
            Win32.GetWindowThreadProcessId(hWnd, out windowProcessId);

            if (windowProcessId == processId)
            {
                int length = Win32.GetWindowTextLength(hWnd);
                StringBuilder sb = new StringBuilder(length + 1);
                Win32.GetWindowText(hWnd, sb, sb.Capacity);
                titles.Add(sb.ToString());
            }

            return true;  // Continue enumeration
        }, IntPtr.Zero);

        return titles;
    }

    // not really thread safe
    private void MemSubWorkerThread()
    {
        while (workerRunning)
        {
            foreach (var memsub in memSubs)
            {
                if (memsub.released) continue;
                switch (memsub.type)
                {
                    case MemSubType.SUBSCRIBE:
                        var newValue = ReadMemory(memsub.address, memsub.size);
                        if (memsub.oldValue == null || newValue.SequenceEqual(memsub.oldValue.Reverse().ToArray()))
                        {
                            Program.state.MainForm.BeginInvoke(() => memsub.callback!(newValue));
                            // callback is set by SubMemory and shouldn't be null

                            memsub.oldValue = newValue;
                        }
                        break;

                    case MemSubType.FREEZE:
                        WriteMemory(memsub.address, memsub.freezeValue!);
                        break;
                }
            }

            Thread.Sleep(1000 / 120);
        }
    }
}

