using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RacMAN.API;
public class Ratchetron : API
{
    public override void Disconnect()
    {
        throw new NotImplementedException();
    }

    public override int FreezeMemory(uint addr, byte[] value)
    {
        throw new NotImplementedException();
    }

    public override string GetGameTitle()
    {
        throw new NotImplementedException();
    }

    public override string GetGameTitleID()
    {
        throw new NotImplementedException();
    }

    public override void Notify(string text)
    {
        throw new NotImplementedException();
    }

    public override byte[] ReadMemory(uint addr, uint size)
    {
        throw new NotImplementedException();
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
        throw new NotImplementedException();
    }
}
