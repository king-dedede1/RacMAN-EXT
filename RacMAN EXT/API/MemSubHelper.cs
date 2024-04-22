using RacMAN.Forms;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RacMAN.API;
internal class MemSubHelper
{
    private MemoryAPI api;
    private bool workerRunning;
    private List<MemSub> memSubs = [];

    private class MemSub
    {
        //MemSub's state
        public uint address;
        public MemSubType type;
        public uint size;
        public Action<byte[]>? callback;
        public byte[]? freezeValue;

        // for checking if value has changed
        public byte[]? oldValue;

        // to be written by application and read by worker thread
        public bool released;

    }

    public MemSubHelper(MemoryAPI api)
    {
        this.api = api;
        new Thread(MemSubWorkerThread).Start();
        workerRunning = true;
    }

    internal void Stop()
    {
        workerRunning = false;
    }

    private enum MemSubType
    {
        SUBSCRIBE,
        FREEZE
    }

    public int FreezeMemory(uint addr, byte[] value)
    {
        var memsub = new MemSub()
        {
            address = addr,
            type = MemSubType.FREEZE,
            size = (uint) value.Length,
            released = false,
            freezeValue = value
        };
        memSubs.Add(memsub);
        return memSubs.Count - 1;
    }

    public void ReleaseSubID(int id)
    {
        if (id >= 0 && id < memSubs.Count)
        {
            memSubs[id].released = true;
        }
        else
        {
            LuaConsoleForm.instance.Warn($"Tried to release sub ID {id} but it doesn't exist!");
        }
    }

    public int SubMemory(uint addr, uint size, Action<byte[]> callback)
    {
        var memsub = new MemSub()
        {
            address = addr,
            size = size,
            callback = callback,
            type = MemSubType.SUBSCRIBE,
        };
        memSubs.Add(memsub);
        return memSubs.Count - 1;
    }

    // not really thread safe
    private void MemSubWorkerThread()
    {
        while (workerRunning)
        {
            foreach (var memsub in memSubs)
            {
                if (memsub.released) continue;
                switch (memsub.type)
                {
                    case MemSubType.SUBSCRIBE:
                        var newValue = api.ReadMemory(memsub.address, memsub.size);
                        if (memsub.oldValue == null || !newValue.SequenceEqual(memsub.oldValue))
                        {
                            Program.state.MainForm.BeginInvoke(() => memsub.callback!(newValue));
                            // callback is set by SubMemory and shouldn't be null

                            memsub.oldValue = newValue;
                        }
                        break;

                    case MemSubType.FREEZE:
                        api.WriteMemory(memsub.address, memsub.freezeValue!);
                        break;
                }
            }

            Thread.Sleep(1000 / 120);
        }
    }
}
