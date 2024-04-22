using NLua;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RacMAN.API.Inputs;

/// <summary>
/// For getting inputs from a lua function, not sure if this is useful
/// </summary>
public class LuaInputProvider : IInputProvider
{
    public InputState Inputs
    {
        get
        {
            if (state.EvalLua(func)?[0] is InputState inputstate)
            {
                return inputstate;
            }
            else
            {
                state.Warn("Lua input provider returned bad input state!");
                return new InputState();
            }
        }
    }

    LuaFunction func;
    Racman state;

    public LuaInputProvider(LuaFunction func, Racman state)
    {
        this.func = func;
        this.state = state;
    }
}
