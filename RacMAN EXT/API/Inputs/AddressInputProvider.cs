using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RacMAN.API.Inputs;

/// <summary>
/// Provides inputs by reading them from an address in game memory.
/// </summary>
internal class AddressInputProvider : IInputProvider
{
    public InputState Inputs => new InputState
    {
        Buttons = _buttons,
        RX = rx,
        RY = ry,
        LX = lx,
        LY = ly
    };
    
    public AddressInputProvider(MemoryAPI API, uint buttonAddress, uint analogAddress)
    {
        API.SubMemory(buttonAddress, 4, button);
        API.SubMemory(analogAddress, 8, bytes =>
        {
            // I thought endianness didn't apply to floats, but I was wrong.
            bytes = LuaFunctions.ReverseArray(bytes);
            ry = BitConverter.ToSingle(bytes, 0);
            rx = BitConverter.ToSingle(bytes, 4);
        });
        API.SubMemory(analogAddress + 8, 8, bytes =>
        {
            bytes = LuaFunctions.ReverseArray(bytes);
            ly = BitConverter.ToSingle(bytes, 0);
            lx = BitConverter.ToSingle(bytes, 4);
        });
    }

    private ButtonState _buttons;
    private float rx, ry, lx, ly;

    private void button(byte[] bytes)
    {
        bytes = LuaFunctions.ReverseArray(bytes);
        int b = BitConverter.ToInt32(bytes);

        this._buttons = new ButtonState()
        {
            L2 = ( b & 0x1) != 0,
            R2 = (b & 0x2) != 0,
            L1 = (b & 0x4) != 0,
            R1 = (b & 0x8) != 0,
            Triangle = (b & 0x10) != 0,
            Circle = (b & 0x20) != 0,
            Cross = (b & 0x40) != 0,
            Square = (b & 0x80) != 0,
            Select = (b & 0x100) != 0,
            L3 = (b & 0x200) != 0,
            R3 = (b & 0x400) != 0,
            Start = (b & 0x800) != 0,
            DUp = (b & 0x1000) != 0,
            DRight = (b & 0x2000) != 0,
            DDown = (b & 0x4000) != 0,
            DLeft = (b & 0x8000) != 0,
        };

        Program.state.Log("button function called");
    }
}
