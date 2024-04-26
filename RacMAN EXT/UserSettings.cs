using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RacMAN;
internal class UserSettings
{
    // API settings
    public string? RatchetronIP { get; set; }
    public ushort? RPCS3Slot { get; set; } = 28012;
    public ushort? PCSX2Slot { get; set; } = 28011;
    public int? DefaultAPIDropdownIndex { get; set; } = 0;
    public bool? AutoConnect { get; set; } = false;
    public int? SocketTimeoutInterval { get; set; } = 1000;

    // Input display settings
    public string? InputDisplaySkin { get; set; } = "Compact";
    public bool? InputDisplayBorderless { get; set; } = false;
    public Color? InputDisplayBackColor { get; set; } = Color.Purple;

    // Hotkey settings
    public bool? GlobalHotkeysEnabled { get; set; } = true;

    // Combo settings
    public bool? TriggerCombosOnButtonRelease { get; set; } = false;

    // Text settings
    public Color? ConsoleBackColor { get; set; } = Color.Black;
    public Color? ConsoleTextColor { get; set; } = Color.White;
    public string? ConsoleTextFontName { get; set; } = "Consolas";
    public FontStyle? ConsoleTextFontStyle { get; set; } = FontStyle.Bold;
    public float? ConsoleTextFontSize { get; set; } = 9.75f;
}
