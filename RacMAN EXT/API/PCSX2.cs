using RacMAN.Forms;
using System.Diagnostics;
using System.Text;

namespace RacMAN.API;

public class PCSX2 : MemoryAPI
{
    PineClient client;
    MemSubHelper MemSubHelper;

    public PCSX2(ushort slot)
    {
        client = new(slot);
        MemSubHelper = new(this);
    }

    public override void Disconnect()
    {
        client.Close();
    }

    public override int FreezeMemory(uint addr, byte[] value)
    {
        return MemSubHelper.FreezeMemory(addr, value);
    }

    public override string GetGameTitle()
    {
        return client.GameTitle();
    }

    public override string GetGameTitleID()
    {
        return client.GameID().Replace("-","");
    }

    public override void Notify(string text)
    {
        
    }

    public override byte[] ReadMemory(uint addr, uint size)
    {
        return client.Read(addr, size);
    }

    public override void ReleaseSubID(int id)
    {
        MemSubHelper.ReleaseSubID(id);
    }

    public override int SubMemory(uint addr, uint size, Action<byte[]> callback)
    {
        return MemSubHelper.SubMemory(addr, size, callback);
    }

    public override void WriteMemory(uint addr, byte[] bytes)
    {
        client.Write(addr, bytes);
    }
}
