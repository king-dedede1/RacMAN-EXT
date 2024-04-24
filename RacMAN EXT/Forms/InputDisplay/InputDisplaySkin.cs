using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RacMAN.Forms.InputDisplay;
public class InputDisplaySkin
{
    public string ImageFilename { get; set; }
    public Dictionary<string, InputPlot> Buttons {  get; set; }
    public int AnalogPitch {  get; set; }

    [JsonIgnore]
    public Image? Image;

    public static InputDisplaySkin Load(string folderPath)
    {
        var text = File.ReadAllText(Path.Join(folderPath, "plot.json"));
        InputDisplaySkin skin = JsonSerializer.Deserialize<InputDisplaySkin>(text);
        skin.Image = Image.FromFile(Path.Join(folderPath, skin.ImageFilename));
        return skin;
    }
}
