using System.Diagnostics;
using System.Runtime.InteropServices;

namespace TrilogyMoneyTrainer;

public static class MemoryHelper
{

    [DllImport("kernel32.dll")]
    private static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);

    [DllImport("kernel32.dll", SetLastError = true)]
    internal static extern bool ReadProcessMemory(IntPtr process, IntPtr address, byte[] buffer, IntPtr size, ref IntPtr bytesRead);

    [DllImport("kernel32.dll", SetLastError = true)]
    internal static extern bool WriteProcessMemory(IntPtr process, IntPtr address, byte[] buffer, IntPtr size, ref IntPtr bytesWritten);

    public static OpenedProcess OpenProcess(ProcessOpenAccess access, string name)
    {
        Process process = Process.GetProcessesByName(name)[0];
        return new OpenedProcess()
        {
            Handle = OpenProcess((int)access, false, process.Id),
            BaseAddress = process.MainModule!.BaseAddress,
        };
    }}