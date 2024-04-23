using NLua;
using System.Text.Json.Serialization;

using ButtonState = RacMAN.API.Inputs.ButtonState;

namespace RacMAN.ControllerCombos;
public class ControllerCombo
{
    public string Name { get; set; } = "";
    public string Description { get; set; } = "";
    public bool IsControllerCombo {  get; set; }
    public bool IsHotkey {  get; set; }
    public bool Enabled {  get; set; }

    // Hotkey stuff
    public Keys HotkeyKey { get; set; }
    public bool IsHotkeyGlobal { get; set; }

    // Controller stuff
    public ButtonState ComboButtonState { get; set; }

    // Action stuff
    public string LuaActionString { get; set; } = "";

    // Precompile lua code to save time, only needs to be done once.
    [JsonIgnore]
    public LuaFunction? LuaAction {  get; set; }
}
