using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace RacMAN.API;

/// <summary>
/// Dumping all the kernel32 imports here
/// </summary>
internal static class Win32
{
    [DllImport("kernel32.dll", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool ReadProcessMemory(nint hProcess, nint lpBaseAddress, [Out] byte[] lpBuffer,
    nuint nSize, out nuint lpNumberOfBytesRead);

    [DllImport("kernel32.dll", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool WriteProcessMemory(nint hProcess, nint lpBaseAddress, byte[] lpBuffer,
    nuint nSize, out nuint lpNumberOfBytesWritten);

    [DllImport("kernel32.dll")]
    [return: MarshalAs(UnmanagedType.U4)]
    public static extern uint GetLastError();

    [DllImport("kernel32.dll", SetLastError = true)]
    public static extern nint VirtualAllocEx(nint hProcess, nint lpAddress, nuint dwSize, AllocationType flAllocationType, Protect flProtect);

    [DllImport("kernel32.dll", SetLastError = true)]
    public static extern bool VirtualFreeEx(nint hProcess, nint lpAddress, nuint dwSize, FreeType dwFreeType);

    [DllImport("kernel32.dll", SetLastError = true)]
    public static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);

    [DllImport("kernel32.dll", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool CloseHandle(IntPtr hObject);

    [DllImport("kernel32.dll", SetLastError = true)]
    public static extern nint GetProcAddress(nint hModule, string lpProcName);

    [DllImport("kernel32.dll")]
    public static extern nint GetModuleHandleA(string lpModuleName);

    public static readonly int PROCESS_ALL_ACCESS = 0x1F0FFF;

    // these next things are used to get window titles because c# standard library doesnt have that for some reason :(

    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    public static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

    [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
    public static extern int GetWindowTextLength(IntPtr hWnd);

    [DllImport("user32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool EnumWindows(EnumWindowsProc lpEnumFunc, IntPtr lParam);

    public delegate bool EnumWindowsProc(IntPtr hWnd, IntPtr lParam);

    [DllImport("user32.dll", SetLastError = true)]
    public static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);

    [Flags]
    public enum AllocationType : int
    {
        MEM_COMMIT = 0x00001000,
        MEM_RESERVE = 0x00002000,
        MEM_RESET = 0x00080000,
        MEM_RESET_UNDO = 0x10000000,
        MEM_LARGE_PAGES = 0x20000000,
        MEM_PHYSICAL = 0x00400000,
        MEM_TOP_DOWN = 0x00100000
    }

    [Flags]
    public enum Protect : int
    {
        PAGE_EXECUTE = 0x10,
        PAGE_EXECUTE_READ = 0x20,
        PAGE_EXECUTE_READWRITE = 0x40,
        PAGE_EXECUTE_WRITECOPY = 0x80,
        PAGE_NOACCESS = 0x1,
        PAGE_READONLY = 0x2,
        PAGE_READWRITE = 0x4,
        PAGE_WRITECOPY = 0x8,
        PAGE_TARGETS_INVALID = 0x40000000,
        PAGE_TARGETS_NO_UPDATE = 0x40000000,
        PAGE_GUARD = 0x100,
        PAGE_NOCACHE = 0x200,
        PAGE_WRITECOMBINE = 0x400
    }

    [Flags]
    public enum FreeType : int
    {
        MEM_DECOMMIT = 0x00004000,
        MEM_RELEASE = 0x00008000,
        MEM_COALESCE_PLACEHOLDERS = 0x00000001,
        MEM_PRESERVE_PLACEHOLDER = 0x00000002
    }
}
