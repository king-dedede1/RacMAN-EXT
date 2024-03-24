using RacMAN.API;

namespace RacMAN;
public static class LuaFunctions
{
    public static byte[] LuaTableToByteArray(object table)
    {
        List<byte> bytes = [];

        foreach (var value in ((NLua.LuaTable) table).Values)
        {
            bytes.Add((byte) (long) value);
        }

        return bytes.ToArray();
    }

    public static byte[] ReverseArray(byte[] arr)
    {
        return arr.Reverse().ToArray();
    }

    public static uint ByteArrayToInt(byte[] bytes)
    {
        if (bytes.Length == 1)
        {
            return bytes[0];
        }

        if (bytes.Length == 2)
        {
            return BitConverter.ToUInt16(bytes.Reverse().ToArray(), 0);
        }

        return BitConverter.ToUInt32(bytes.Reverse().ToArray(), 0);
    }

    public static byte[] IntToByteArray(int num, int size, bool bigEndian = true)
    {
        //return BitConverter.GetBytes(num).Take(size).Reverse().ToArray();
        var bytes = BitConverter.GetBytes(num).Take(size);
        if (bigEndian)
        {
            bytes = bytes.Reverse();
        }
        return bytes.ToArray();
    }
}
