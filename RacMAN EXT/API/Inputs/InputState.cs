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

    public static bool operator ==(ButtonState a, ButtonState b)
    {
        return a.Cross == b.Cross
            && a.Circle == b.Circle
            && a.Square == b.Square
            && a.Triangle == b.Triangle
            && a.DUp == b.DUp
            && a.DDown == b.DDown
            && a.DLeft == b.DLeft
            && a.DRight == b.DRight
            && a.Start == b.Start
            && a.Select == b.Select
            && a.L1 == b.L1
            && a.L2 == b.L2
            && a.L3 == b.L3
            && a.R1 == b.R1
            && a.R2 == b.R2
            && a.R3 == b.R3;
    }

    public static bool operator !=(ButtonState a, ButtonState b)
    {
        return !(a == b);
    }

    [System.Text.Json.Serialization.JsonIgnore]
    public readonly bool IsEmpty => this == new ButtonState();

    /// <summary>
    /// I don't think this code is going to win me the nobel prize
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        StringBuilder sb = new();
        List<string> terms = [];
        if (L1) terms.Add("L1");
        if (L2) terms.Add("L2");
        if (R1) terms.Add("R1");
        if (R2) terms.Add("R2");
        if (Cross) terms.Add("Cross");
        if (Circle) terms.Add("Circle");
        if (Square) terms.Add("Square");
        if (Triangle) terms.Add("Triangle");
        if (DUp) terms.Add("D-Pad Up");
        if (DDown) terms.Add("D-Pad Down");
        if (DLeft) terms.Add("D-Pad Left");
        if (DRight) terms.Add("D-Pad Right");
        if (Start) terms.Add("Start");
        if (Select) terms.Add("Select");
        if (L3) terms.Add("L3");
        if (R3) terms.Add("R3");

        for (int i = 0; i < terms.Count; i++)
        {
            sb.Append(terms[i]);
            if (i + 1 < terms.Count) sb.Append('+');
        }

        return sb.Length == 0? "(empty)" : sb.ToString();
    }
}
