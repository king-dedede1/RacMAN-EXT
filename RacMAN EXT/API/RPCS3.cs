using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RacMAN.API;
public class RPCS3 : MemoryAPI
{
    nint hProcess;
    const string PROCESS_NAME = "";

    public RPCS3()
    {
        var processList = Process.GetProcessesByName(PROCESS_NAME);
        if (processList.Length == 0)
        {
            throw new Exception("Couldn't locate process to connect to. Did you start the game yet?");
        }
        Process process = Process.GetProcessesByName("rpcs3")[0];
        hProcess = Win32.OpenProcess(Win32.PROCESS_ALL_ACCESS, false, process.Id);
        if (hProcess == IntPtr.Zero)
        {
            throw new Exception($"Invalid handle ({hProcess:X})");
        }
    }

    public override void Disconnect()
    {
        Win32.CloseHandle(hProcess);
    }

    public override int FreezeMemory(uint addr, byte[] value)
    {
        throw new NotImplementedException();
    }

    public override string GetGameTitle()
    {
        var titles = GetWindowTitles();

        foreach (var title in titles)
        {
            if (title.Contains('['))
            {
                var e = title.IndexOf('[');
                var s = e;
                for (; title[s] != '|'; s--) ;
                return title.Substring(s + 2, (e - 2)-s);
            }
        }
        return "Unknown RPCS3 Game";
    }

    public override string GetGameTitleID()
    {
        var titles = GetWindowTitles();

        foreach (var title in titles)
        {
            if (title.Contains('['))
            {
                return title.Substring(title.IndexOf('[') + 1, 9);
            }
        }
        return "UNKNOWN00";
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
        throw new NotImplementedException();
    }

    public override int SubMemory(uint addr, uint size, Action<byte[]> callback)
    {
        throw new NotImplementedException();
    }

    public override void WriteMemory(uint addr, byte[] bytes)
    {
        if (!Win32.WriteProcessMemory(hProcess, (nint)(addr + 0x300000000), bytes, (nuint)bytes.Length, out _))
        {
            throw new IOException($"Unable to write memory (Error code 0x{Win32.GetLastError():X})");
        }
    }

    private static List<string> GetWindowTitles()
    {
        List<string> titles = new List<string>();
        // WHY?!?!? why does it only work if you open the process again????
        uint processId = (uint) Process.GetProcessesByName("rpcs3")[0].Id;

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
}

