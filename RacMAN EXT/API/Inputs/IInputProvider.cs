using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RacMAN.API.Inputs;
public interface IInputProvider
{
    InputState Inputs { get; }
}
