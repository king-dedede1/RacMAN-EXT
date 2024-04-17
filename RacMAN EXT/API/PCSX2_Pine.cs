using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace RacMAN.API;
internal class PCSX2_Pine : MemoryAPI
{
    // PINE standard opcodes
    const byte OP_READ8 = 0,
        OP_READ16 = 1,
        OP_READ32 = 2,
        OP_READ64 = 3,
        OP_WRITE8 = 4,
        OP_WRITE16 = 5,
        OP_WRITE32 = 6,
        OP_WRITE64 = 7,
        OP_VERSION = 8,
        OP_SAVESTATE = 9,
        OP_LOADSTATE = 10,
        OP_GAMETITLE = 11,
        OP_GAMEID = 12,
        OP_GAMEUUID = 13,
        OP_GAMEVERSION = 14,
        OP_EMUSTATUS = 15;

    TcpClient client;
    NetworkStream stream;
    BinaryReader reader;
    MemSubHelper memsub;

    private void print(string msg)
    {
        Program.state.consoleForm.Log(msg);
    }

    public PCSX2_Pine(UInt16 slot)
    {
        client = new();
        client.Connect(IPAddress.Parse("127.0.0.1"), slot);
        stream = client.GetStream();
        reader = new(stream);
        memsub = new(this);
    }

    public override void Disconnect()
    {
        client.Close();
        stream.Close();
        reader.Close();
        memsub.Stop();
    }

    public override int FreezeMemory(uint addr, byte[] value)
    {
        return memsub.FreezeMemory(addr, value);
    }

    public override string GetGameTitle()
    {
        stream.Write([5, 0, 0, 0, OP_GAMETITLE]);
        int messageSize = reader.ReadInt32();
        var result = reader.ReadByte();
        if (result == 0)
        {
            int strlen = reader.ReadInt32();
            char[] chars = reader.ReadChars(strlen);
            var str = new string(chars);
            str = str.Replace("\0", "");
            return str;
        }
        else throw new Exception("io error");
    }

    public override string GetGameTitleID()
    {
        stream.Write([5, 0, 0, 0, OP_GAMEID]);
        int messageSize = reader.ReadInt32();
        var result = reader.ReadByte();
        if (result == 0)
        {
            int strlen = reader.ReadInt32();
            char[] chars = reader.ReadChars(strlen);
            var str = new string(chars);
            str = str.Replace("\0", "").Replace("-", "");
            return str;
        }
        else throw new Exception("io error");
    }

    public override void Notify(string text)
    {
        print(text);
    }

    public override byte[] ReadMemory(uint addr, uint size)
    {
        byte[] buffer = new byte[size];
        for (int  i = 0; i < size; i++)
        {
            byte[] cmd = [9, 0, 0, 0, OP_READ8, .. BitConverter.GetBytes((int) addr + i)];
            stream.Write(cmd, 0, cmd.Length);
            stream.Read(new byte[5], 0, 5);
            buffer[i] = reader.ReadByte();
        }
        return buffer;
    }

    public override void ReleaseSubID(int id)
    {
        memsub.ReleaseSubID(id);
    }

    public override int SubMemory(uint addr, uint size, Action<byte[]> callback)
    {
        return memsub.SubMemory(addr, size, callback);
    }

    public override void WriteMemory(uint addr, byte[] bytes)
    {
        // just send a bunch of packets because who cares!
        for (int i = 0; i < bytes.Length; i++)
        {
            byte[] cmd = [10, 0, 0, 0, OP_WRITE8, ..BitConverter.GetBytes((int)addr+i), bytes[i]];
            stream.Write(cmd, 0, cmd.Length);
            stream.Read(new byte[5], 0, 5);
        }

    }
}
