using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Xml;

namespace RacMAN.API;
internal class PineClient
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

    public enum EmulatorStatus
    {
        RUNNING = 0,
        PAUSED = 1,
        SHUTDOWN = 2
    }

    TcpClient client;
    NetworkStream stream;
    BinaryReader reader;

    public PineClient(UInt16 slot)
    {
        // This will have to be changed for platforms other than windows
        client = new TcpClient();
        client.Connect(IPAddress.Parse("127.0.0.1"), slot);
        stream = client.GetStream();
        reader = new BinaryReader(stream);
    }

    public void Close()
    {
        client.Close();
        stream.Close();
        reader.Close();
    }

    ~PineClient()
    {
        Close();
    }

    private byte[] mkcmd(byte opcode, params byte[] args)
    {
        List<byte> cmdList = [opcode, ..args];
        byte[] cmdbuf = [.. BitConverter.GetBytes(cmdList.Count+4), .. cmdList];
        return cmdbuf;
    }

    private void runcmd(byte[] cmd)
    {
        stream.Write(cmd, 0, cmd.Length);
    }

    private (int length, byte returnCode) readHeader()
    {
        var len = reader.ReadInt32();
        var ret = reader.ReadByte();
        return (len, ret);
    } 

    public byte Read8(uint address)
    {
        var cmd = mkcmd(OP_READ8, BitConverter.GetBytes(address));
        runcmd(cmd);
        if (readHeader().returnCode != 0)
        {
            throw new IOException();
        }
        var val = reader.ReadByte();
        return val;
    }

    public short Read16(uint address)
    {
        var cmd = mkcmd(OP_READ16, BitConverter.GetBytes(address));
        runcmd(cmd);
        if (readHeader().returnCode != 0)
        {
            throw new IOException();
        }
        var val = reader.ReadInt16();
        return val;
    }

    public int Read32(uint address)
    {
        var cmd = mkcmd(OP_READ32, BitConverter.GetBytes(address));
        runcmd(cmd);
        if (readHeader().returnCode != 0)
        {
            throw new IOException();
        }
        var val = reader.ReadInt32();
        return val;
    }

    public long Read64(uint address)
    {
        var cmd = mkcmd(OP_READ64, BitConverter.GetBytes(address));
        runcmd(cmd);
        if (readHeader().returnCode != 0)
        {
            throw new IOException();
        }
        var val = reader.ReadInt64();
        return val;
    }

    public void Write8(uint address, byte value)
    {
        var cmd = mkcmd(OP_WRITE8, [..BitConverter.GetBytes(address), value]);
        runcmd(cmd);
        if (readHeader().returnCode != 0)
        {
            throw new IOException();
        }
    }

    public void Write16(uint address, short value)
    {
        var cmd = mkcmd(OP_WRITE16, [.. BitConverter.GetBytes(address), ..BitConverter.GetBytes(value)]);
        runcmd(cmd);
        if (readHeader().returnCode != 0)
        {
            throw new IOException();
        }
    }

    public void Write32(uint address, int value)
    {
        var cmd = mkcmd(OP_WRITE32, [.. BitConverter.GetBytes(address), .. BitConverter.GetBytes(value)]);
        runcmd(cmd);
        if (readHeader().returnCode != 0)
        {
            throw new IOException();
        }
    }

    public void Write64(uint address, long value)
    {
        var cmd = mkcmd(OP_WRITE64, [.. BitConverter.GetBytes(address), .. BitConverter.GetBytes(value)]);
        runcmd(cmd);
        if (readHeader().returnCode != 0)
        {
            throw new IOException();
        }
    }

    public string ServerVersion()
    {
        var cmd = mkcmd(OP_VERSION);
        runcmd(cmd);
        if (readHeader().returnCode != 0) { throw new IOException(); }
        int strlen = reader.ReadInt32();
        char[] chars = reader.ReadChars(strlen);
        return new string(chars).Remove(strlen - 1);
    }

    public void SaveState(byte state)
    {
        var cmd = mkcmd(OP_SAVESTATE, state);
        runcmd(cmd);
        if (readHeader().returnCode != 0) { throw new IOException(); }
    }

    public void LoadState(byte state)
    {
        var cmd = mkcmd(OP_LOADSTATE, state);
        runcmd(cmd);
        if (readHeader().returnCode != 0) { throw new IOException(); }
    }

    public string GameTitle()
    {
        var cmd = mkcmd(OP_GAMETITLE);
        runcmd(cmd);
        if (readHeader().returnCode != 0) { throw new IOException(); }
        int strlen = reader.ReadInt32();

        /* if there's a special character in the game title,
         strlen can be wrong and that messes stuff up, which
        is why I do this */
        List<char> chars = [];
        while (stream.DataAvailable) chars.Add(reader.ReadChar());
        return new string(chars.ToArray()).Remove(chars.Count - 1);
    }

    public string GameID()
    {
        var cmd = mkcmd(OP_GAMEID);
        runcmd(cmd);
        if (readHeader().returnCode != 0) { throw new IOException(); }
        int strlen = reader.ReadInt32();
        char[] chars = reader.ReadChars(strlen);
        return new string(chars).Remove(strlen - 1);
    }

    public string GameUUID()
    {
        var cmd = mkcmd(OP_GAMEUUID);
        runcmd(cmd);
        if (readHeader().returnCode != 0) { throw new IOException(); }
        int strlen = reader.ReadInt32();
        char[] chars = reader.ReadChars(strlen);
        return new string(chars).Remove(strlen - 1);
    }

    public string GameVersion()
    {
        var cmd = mkcmd(OP_GAMEVERSION);
        runcmd(cmd);
        if (readHeader().returnCode != 0) { throw new IOException(); }
        int strlen = reader.ReadInt32();
        char[] chars = reader.ReadChars(strlen);
        return new string(chars).Remove(strlen - 1);
    }

    public EmulatorStatus Status()
    {
        var cmd = mkcmd(OP_EMUSTATUS);
        runcmd(cmd);
        if (readHeader().returnCode != 0)
        {
            throw new IOException();
        }
        var val = reader.ReadInt32();
        return (EmulatorStatus) val;
    }

    public byte[] Read(uint address,  uint size)
    {
        List<byte> cmdlist = [];
        for (int i = 0; i < size; i++)
        {
            cmdlist.Add(OP_READ8);
            cmdlist.AddRange(BitConverter.GetBytes((int) address + i));
        }
        byte[] cmdBuf = [.. BitConverter.GetBytes(cmdlist.Count + 4), .. cmdlist];
        runcmd(cmdBuf);
        readHeader();
        return reader.ReadBytes((int)size);
    }

    public void Write(uint address, byte[] bytes)
    {
        List<byte> cmdlist = [];
        for (int i = 0; i < bytes.Length; i++)
        {
            cmdlist.Add(OP_WRITE8);
            cmdlist.AddRange(BitConverter.GetBytes((int) address + i));
            cmdlist.Add(bytes[i]);
        }
        byte[] cmdBuf = [.. BitConverter.GetBytes(cmdlist.Count+4), .. cmdlist];
        runcmd(cmdBuf);
        readHeader();
    }
}
