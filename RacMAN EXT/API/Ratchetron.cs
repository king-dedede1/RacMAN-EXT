using System.Net;
using System.Net.Sockets;
using System.Text;

namespace RacMAN.API;

/// <summary>
/// Represents a client used to communicate with a PS3 console over Ratchetron API.
/// Needs to be cleaned up, theres a bunch of unused some and performance issues.
/// </summary>
public class Ratchetron : MemoryAPI
{
    public string ip { get; set; }

    private int port = 9671;

    private TcpClient? client;
    private UdpClient? udpClient;
    private NetworkStream? stream;
    private bool connected = false;

    private IPEndPoint? remoteEndpoint;

    private Dictionary<int, Action<byte[]>> memSubCallbacks = [];
    private Dictionary<int, uint> memSubTickUpdates = [];
    private Dictionary<int, UInt32> frozenAddresses = [];

    private static Mutex writeLock = new();

    public Ratchetron(string ip)
    {
        this.ip = ip;
        Connect();
    }

    // idk
    public Ratchetron(IPAddress ip)
    {
        this.ip = ip.ToString();
        Connect();
    }

    public bool Connect()
    {
        try
        {
            this.client = new TcpClient(this.ip, this.port);
            this.client.NoDelay = true;

            this.stream = client.GetStream();

            byte[] connMsg = new byte[6];
            stream.Read(connMsg, 0, 6);

            uint apiRev = BitConverter.ToUInt32(connMsg.Skip(2).Take(4).Reverse().ToArray(), 0);

            if (apiRev < 2)
            {
                MessageBox.Show("The Ratchetron module loaded on your PS3 is too old, you need to restart your PS3 to load the new version.");
                return false;
            }

            if (connMsg[0] == 0x01)
            {
                this.remoteEndpoint = new IPEndPoint(IPAddress.Parse(this.ip), 0);

                this.connected = true;

#if DEBUG
                this.EnableDebugMessages();
#endif

                return true;
            }
        }
        catch (SocketException)
        {
            return false;
        }
        catch (Exception)
        {
            // who cares about error handling anyway?
            return false;
        }

        return false;
    }

    public override void Disconnect()
    {
        this.connected = false;
        this.udpClient.Close();
        this.client.Close();
    }

    public override int FreezeMemory(uint addr, byte[] value)
    {
        return FreezeMemory(getCurrentPID(), addr, (uint)value.Length, MemoryCondition.Changed, value);
    }

    public override string GetGameTitle()
    {
        // I think the server code has a function for this but it's not implemented in the client
        // just using webman for now
        return WebMAN.GetGameTitle(this.ip);
    }

    public override string GetGameTitleID()
    {
        if (!connected)
        {
            throw new Exception("I ain't connected");
        }

        byte[] cmd = { 0x06 };

        WriteStream(cmd, 0, 1);

        byte[] titleIdBuf = new byte[16];
        stream.Read(titleIdBuf, 0, 16);

        return Encoding.Default.GetString(titleIdBuf).Replace("\0", string.Empty);
    }

    public override void Notify(string text)
    {
        var cmdBuf = new List<byte>();
        cmdBuf.Add(0x02);
        cmdBuf.AddRange(BitConverter.GetBytes((UInt32) text.Length).Reverse());
        cmdBuf.AddRange(Encoding.ASCII.GetBytes(text));

        this.WriteStream(cmdBuf.ToArray(), 0, cmdBuf.Count);
    }

    public override byte[] ReadMemory(uint addr, uint size)
    {
        // calling getCurrentPID every read/write request is probably unnescessary
        // fix this later
        return ReadMemory(getCurrentPID(), addr, size);
    }

    public override void ReleaseSubID(int id)
    {
        var cmdBuf = new List<byte>();
        cmdBuf.Add(0x0c);
        cmdBuf.AddRange(BitConverter.GetBytes((UInt32) id).Reverse());

        this.WriteStream(cmdBuf.ToArray(), 0, cmdBuf.Count);

        byte[] resultBuf = new byte[1];

        int n_bytes = 0;
        while (n_bytes < 1)
        {
            n_bytes += stream.Read(resultBuf, 0, 1);
        }

        this.memSubCallbacks.Remove(id);
        this.memSubTickUpdates.Remove(id);
        this.frozenAddresses.Remove(id);

        Console.WriteLine($"Released memory subscription ID {id}");

        // we're ignoring the results because yolo
    }

    public override int SubMemory(uint addr, uint size, Action<byte[]> callback)
    {
        // idk what the 5th param is
        return SubMemory(getCurrentPID(), addr, size, MemoryCondition.Changed, new byte[size], callback);
    }

    public override void WriteMemory(uint addr, byte[] bytes)
    {
        WriteMemory(getCurrentPID(), addr, (uint)bytes.Length, bytes);
    }

    public int[] GetPIDList()
    {
        if (!connected)
        {
            throw new Exception("I ain't connected");
        }

        byte[] cmd = { 0x03 };

        WriteStream(cmd, 0, 1);

        byte[] pidListBuf = new byte[64];

        int n_bytes = 0;
        while (n_bytes < 64)
        {
            n_bytes += stream.Read(pidListBuf, 0, 64);
        }

        int[] pids = new int[16];

        for (int i = 0; i < 64; i += 4)
        {
            byte[] bytes = pidListBuf.Skip(i).Take(4).ToArray();

            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(bytes);
            }

            pids[i / 4] = BitConverter.ToInt32(bytes, 0);
        }

        return pids;
    }

    public void EnableDebugMessages()
    {
        byte[] cmd = { 0x0d };

        WriteStream(cmd, 0, 1);
    }

    public int getCurrentPID()
    {
        return this.GetPIDList()[2];
    }

    private void WriteStream(byte[] array, int offset, int count)
    {
        writeLock.WaitOne();

        if (this.stream.CanWrite)
        {
            this.stream.Write(array, offset, count);
        }

        writeLock.ReleaseMutex();
    }

    public void WriteMemory(int pid, uint address, uint size, byte[] memory)
    {
        var cmdBuf = new List<byte>();
        cmdBuf.Add(0x05);
        cmdBuf.AddRange(BitConverter.GetBytes((UInt32) pid).Reverse());
        cmdBuf.AddRange(BitConverter.GetBytes((UInt32) address).Reverse());
        cmdBuf.AddRange(BitConverter.GetBytes((UInt32) size).Reverse());
        cmdBuf.AddRange(memory);


        this.WriteStream(cmdBuf.ToArray(), 0, cmdBuf.Count);
    }

    public byte[] ReadMemory(int pid, uint address, uint size)
    {
        var cmdBuf = new List<byte>();
        cmdBuf.Add(0x04);
        cmdBuf.AddRange(BitConverter.GetBytes((UInt32) pid).Reverse());
        cmdBuf.AddRange(BitConverter.GetBytes((UInt32) address).Reverse());
        cmdBuf.AddRange(BitConverter.GetBytes((UInt32) size).Reverse());

        this.WriteStream(cmdBuf.ToArray(), 0, cmdBuf.Count);

        byte[] memory = new byte[size];

        int n_bytes = 0;
        while (n_bytes < size)
        {
            n_bytes += stream.Read(memory, 0, (int) size);
        }

        return memory.Take((int) size).ToArray();
    }

    private void DataChannelReceive()
    {
        IPEndPoint end = new IPEndPoint(IPAddress.Any, 0);

        while (this.connected)
        {
            try
            {
                byte[] cmdBuf = this.udpClient.Receive(ref end);
                byte command = cmdBuf.Take(1).ToArray()[0];

                switch (command)
                {
                    case 0x06:
                        {
                            UInt32 memSubID = BitConverter.ToUInt32(cmdBuf.Skip(1).Take(4).Reverse().ToArray(), 0);
                            UInt32 size = BitConverter.ToUInt32(cmdBuf.Skip(5).Take(4).Reverse().ToArray(), 0);
                            uint tickUpdated = BitConverter.ToUInt32(cmdBuf.Skip(9).Take(4).Reverse().ToArray(), 0);
                            var value = cmdBuf.Skip(13).Take((int) size).Reverse().ToArray();

                            if (this.memSubTickUpdates.ContainsKey((int) memSubID) && this.memSubTickUpdates[(int) memSubID] != tickUpdated)
                            {
                                this.memSubTickUpdates[(int) memSubID] = tickUpdated;
                                this.memSubCallbacks[(int) memSubID](value);
                            }

                            break;
                        }
                }
            }
            catch (SocketException)
            {
                // Who gives a shit
            }
        }
    }

    public void OpenDataChannel()
    {
        byte[] data = new byte[1024];
        int port = 4000;
        bool udpStarted = false;
        while (!udpStarted)
        {
            try
            {
                IPEndPoint ipep = new IPEndPoint(IPAddress.Any, port);
                this.udpClient = new UdpClient(ipep);
                udpStarted = true;
            }
            catch (SocketException)
            {
                if (port++ > 5000)
                {
                    MessageBox.Show("Tried to open data connection on all ports between 4000 and 5000, but that failed. Did you deny RaCMAN firewall access?");
                    return;
                }
            }
        }

        var assignedPort = ((IPEndPoint) this.udpClient.Client.LocalEndPoint).Port;

        var cmdBuf = new List<byte>();
        cmdBuf.Add(0x09);
        cmdBuf.AddRange(BitConverter.GetBytes((UInt32) assignedPort).Reverse());

        this.WriteStream(cmdBuf.ToArray(), 0, cmdBuf.Count);

        byte[] returnValue = new byte[1];

        int n_bytes = 0;
        while (n_bytes < 1)
        {
            n_bytes += stream.Read(returnValue, 0, 1);
        }

        if (returnValue[0] == 128)
        {
            Console.WriteLine("Waiting for connection on port " + assignedPort);

            //this.udpClient.Send(new byte[] { 0x01 }, 1, remoteEndpoint);

            Thread dataThread = new Thread(this.DataChannelReceive);
            dataThread.Start();
        }
        else if (returnValue[0] == 2)
        {
            Console.WriteLine("Tried to open data channel, but server says we already have one open.");
            udpClient.Close();
        }
        else
        {
            Console.WriteLine("Server error trying to open data channel.");
            udpClient.Close();
        }
    }

    public int SubMemory(int pid, uint address, uint size, MemoryCondition condition, byte[] memory, Action<byte[]> callback)
    {
        var cmdBuf = new List<byte>();
        cmdBuf.Add(0x0a);
        cmdBuf.AddRange(BitConverter.GetBytes((UInt32) pid).Reverse());
        cmdBuf.AddRange(BitConverter.GetBytes((UInt32) address).Reverse());
        cmdBuf.AddRange(BitConverter.GetBytes((UInt32) size).Reverse());
        cmdBuf.AddRange(new byte[] { (byte) condition });
        cmdBuf.AddRange(memory);

        this.WriteStream(cmdBuf.ToArray(), 0, cmdBuf.Count);

        byte[] memSubIDBuf = new byte[4];

        int n_bytes = 0;
        while (n_bytes < 4)
        {
            n_bytes += stream.Read(memSubIDBuf, 0, 4);
        }

        var memSubID = (int) BitConverter.ToInt32(memSubIDBuf.Take(4).Reverse().ToArray(), 0);

        this.memSubCallbacks[memSubID] = callback;
        this.memSubTickUpdates[memSubID] = 0;

        Console.WriteLine($"Subscribed to address {address.ToString("X")} with subscription ID {memSubID}");

        return memSubID;
    }

    public int FreezeMemory(int pid, uint address, uint size, MemoryCondition condition, byte[] memory)
    {
        var cmdBuf = new List<byte>();
        cmdBuf.Add(0x0b);
        cmdBuf.AddRange(BitConverter.GetBytes((UInt32) pid).Reverse());
        cmdBuf.AddRange(BitConverter.GetBytes((UInt32) address).Reverse());
        cmdBuf.AddRange(BitConverter.GetBytes((UInt32) size).Reverse());
        cmdBuf.AddRange(new byte[] { (byte) condition });
        cmdBuf.AddRange(memory);

        this.WriteStream(cmdBuf.ToArray(), 0, cmdBuf.Count);

        byte[] memSubIDBuf = new byte[4];

        int n_bytes = 0;
        while (n_bytes < 4)
        {
            n_bytes += stream.Read(memSubIDBuf, 0, 4);
        }

        var memSubID = (int) BitConverter.ToInt32(memSubIDBuf.Take(4).Reverse().ToArray(), 0);

        Console.WriteLine($"Froze address {address.ToString("X")} with subscription ID {memSubID}");

        frozenAddresses[memSubID] = address;

        return memSubID;
    }

    public int MemSubIDForAddress(uint address)
    {
        foreach (KeyValuePair<int, uint> entry in frozenAddresses)
        {
            if (address == entry.Value)
            {
                return entry.Key;
            }
        }
        return -1;
    }

    /// <summary>
    /// Any blasts the data channel with values all the time
    /// Changed only sends data when the value changes
    /// The other things do other things thanks for reading my Ted talk
    /// </summary>
    public enum MemoryCondition : byte
    {
        Any = 1,
        Changed = 2,
        Above = 3,
        Below = 4,
        Equal = 5,  // equal and not equal are not really useful for freezing
        NotEqual = 6
    }
}
