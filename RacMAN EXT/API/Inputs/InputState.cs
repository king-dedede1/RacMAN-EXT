using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RacMAN.API.Inputs;
public struct InputState
{
    public ButtonState Buttons { get; set; }

    public float LX { get; set; }
    public float LY { get; set; }
    public float RX { get; set; }
    public float RY { get; set;}

    // Not worrying about pressure sensitive buttons or analog triggers right now
}

public struct ButtonState
{
    public bool Cross { get; set;}
    public bool Circle { get; set;}
    public bool Square { get; set;}
    public bool Triangle { get; set;}
    public bool DUp { get; set;}
    public bool DDown { get; set;}
    public bool DLeft { get; set;}
    public bool DRight { get; set;}
    public bool L1 { get; set; }
    public bool L2 { get; set;}
    public bool L3 { get; set;}
    public bool R1 { get; set;}
    public bool R2 { get; set;}
    public bool R3 { get; set;}
    public bool Start { get; set;}
    public bool Select { get; set;}
}
