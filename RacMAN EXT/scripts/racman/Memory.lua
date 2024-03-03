-- Helper methods to make working with the API easier.
require 'Convert'

Memory = {}

-- Write an int to memory
Memory.WriteInt = function(addr, int)
    API:WriteMemory(addr, Convert.IntToByteArray(int, 4))
end

-- Read an int to memory.
Memory.ReadInt = function(addr)
    return Convert.ByteArrayToInt(API:ReadMemory(addr, 4))
end

Memory.ReadByte = function(addr)
    return Convert.ByteArrayToInt(API:ReadMemory(addr, 1))
end

Memory.WriteFloat = function(addr, float)
    API:WriteMemory(addr, Convert.FloatToByteArray(float))
end

Memory.WriteByte = function(addr, byte)
    API:WriteMemory(addr, Convert.TableToByteArray({byte}))
end

Memory.WriteTable = function(addr, table)
    API:WriteMemory(addr, Convert.TableToByteArray(table))
end