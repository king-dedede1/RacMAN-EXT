using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RacMAN.ControllerCombos;
public class ControllerComboGroup
{
    public string Name { get; set; } = "";
    public string Description { get; set; } = "";
    public List<ControllerComboGroup> SubGroups { get; set; } = [];
    public List<ControllerCombo> Combos { get; set; } = [];
}
