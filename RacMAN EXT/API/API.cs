using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RacMAN.API;
public abstract class API
{
    public abstract string GetGameTitleID();

    public abstract string GetGameTitle();

    public abstract byte[] ReadMemory(uint addr, uint size);

    public abstract void WriteMemory(uint addr, byte[] bytes);

    public abstract int SubMemory(uint addr, uint size, Action<byte[]> callback);

    public abstract int FreezeMemory(uint addr, byte[] value);

    public abstract void ReleaseSubID(int id);

    public abstract void Notify(string text);

    public abstract void Disconnect();
}
