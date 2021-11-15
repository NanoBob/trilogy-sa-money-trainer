namespace TrilogyMoneyTrainer;

public struct OpenedProcess
{
    public IntPtr Handle { get; init; }
    public IntPtr BaseAddress { get; init; }

    public byte[]? Read(long offset, long length)
    {
        byte[] buffer = new byte[length];
        IntPtr bytesRead = new();
        MemoryHelper.ReadProcessMemory(this.Handle, new(this.BaseAddress.ToInt64() + offset), buffer, new(length), ref bytesRead);
        return buffer;
    }

    public bool Write(long offset, byte[] data)
    {
        IntPtr bytesWritten = new();
        return MemoryHelper.WriteProcessMemory(this.Handle, new(this.BaseAddress.ToInt64() + offset), data, new(data.Length), ref bytesWritten);
    }

    public bool Write(Offsets offset, byte[] data) => Write((long)offset, data);
}
