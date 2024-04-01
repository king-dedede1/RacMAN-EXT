using RacMAN.Forms;
using System.Diagnostics;
using System.Text;

namespace RacMAN.API;
public class PCSX2 : MemoryAPI
{
    const string PROCCESS_NAME = "pcsx2-qt";
    const nint EEMEM_PTR = 0x1696560;
    const int TITLEID_PTR = 0xDE93D8;

    Process process;
    int pid;
    nint handle;
    nint eemem;
    nint exe;

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

    public PCSX2()
    {
        var processList = Process.GetProcessesByName(PROCCESS_NAME);

        if (processList.Length == 0)
        {
            throw new Exception("Couldn't find emulator process, did you open the emulator yet?");
        }

        process = processList[0];
        pid = process.Id;
        handle = Win32.OpenProcess(Win32.PROCESS_ALL_ACCESS, false, pid);

        if (handle == 0)
        {
            throw new Exception("Couldn't open process handle!");
        }

        exe = process.MainModule!.BaseAddress;

        byte[] buffer = new byte[8];
        Win32.ReadProcessMemory(handle, exe + EEMEM_PTR, buffer, 8, out _);
        eemem = (nint) BitConverter.ToInt64(buffer);

        new Thread(MemSubWorkerThread).Start();
        workerRunning = true;
    }

    public override void Disconnect()
    {
        workerRunning = false;
        Win32.CloseHandle(handle);
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
        return memSubs.Count - 1;
    }

    public override string GetGameTitle()
    {
        var titles = RPCS3.GetWindowTitles(pid); // just gonna hope this works
        string[] otherTitles = ["", "Temp Window", "Default IME", "MSCTFIME UI", PROCCESS_NAME];
        foreach (var title in titles)
        {
            if ( !otherTitles.Contains(title))
            {
                return title;
            }
        }
        return "";
    }

    public override string GetGameTitleID()
    {
        var address = exe + TITLEID_PTR;

        byte[] buffer = new byte[10];
        Win32.ReadProcessMemory(handle, address, buffer, 10, out _);

        var str = Encoding.ASCII.GetString(buffer);

        // the string has a dash after the first 4 letters, so remove it
        return str.Remove(4,1);
    }

    public override void Notify(string text)
    {
        LuaConsoleForm.instance.Log(text);
    }

    public override byte[] ReadMemory(uint addr, uint size)
    {
        byte[] buffer = new byte[size];
        if (!Win32.ReadProcessMemory(handle, (nint) (eemem + addr), buffer, size, out _))
        {
            throw new Exception($"Error reading memory 0x{Win32.GetLastError():X}");
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
        return memSubs.Count - 1;
    }

    public override void WriteMemory(uint addr, byte[] bytes)
    {
        if (!Win32.WriteProcessMemory(handle, (nint) (eemem + addr), bytes, (nuint) bytes.Length, out _))
        {
            throw new Exception(Win32.GetLastError().ToString());
        }
    }

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
                        if (memsub.oldValue == null || !newValue.SequenceEqual(memsub.oldValue))
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
