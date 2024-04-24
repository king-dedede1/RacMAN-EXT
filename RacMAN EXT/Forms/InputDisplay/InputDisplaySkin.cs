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
        if (File.Exists(Path.Join(folderPath, "/plot.json")))
        {
            var text = File.ReadAllText(Path.Join(folderPath, "/plot.json"));
            InputDisplaySkin skin = JsonSerializer.Deserialize<InputDisplaySkin>(text);
            skin.Image = Image.FromFile(Path.Join(folderPath, skin.ImageFilename));
            return skin;
        }
        else if (File.Exists(Path.Join(folderPath, "/skin.txt")))
        {
            var skin =  LoadTXT(folderPath);
            File.WriteAllText(Path.Join(folderPath, "/plot.json"), JsonSerializer.Serialize(skin));

            return skin;
        }
        throw new FileNotFoundException("could't find plot.json or skin.txt");
    }

    public static InputDisplaySkin LoadTXT(string skinPath)
    {
        var skin = new InputDisplaySkin();
        skin.ImageFilename = "skin.png";
        skin.Buttons = new Dictionary<string, InputPlot>();

        var config = File.ReadAllText(skinPath + "\\skin.txt");

        foreach (var line in config.Split('\n'))
        {
            if (line.Length < 2 || line[0] == '#')
            {
                continue;
            }

            var components = line.Split(':');
            if (components.Length < 2)
            {
                continue;
            }

            string buttonName = components[0];

            if (buttonName == "imageName")
            {
                skin.ImageFilename = components[1].Trim();
                skin.Image = Image.FromFile(skinPath + "\\" + components[1].Trim());
                continue;
            }

            if (buttonName == "analogPitch")
            {
                skin.AnalogPitch = int.Parse(components[1].Trim());
                continue;
            }

            var plot = components[1].Split(',').Select(thing => int.Parse(thing.Trim())).ToArray();

            if (plot.Length < 6)
            {
                continue;
            }


            var inputPlot = new InputPlot();
            inputPlot.drawX = plot[0];
            inputPlot.drawY = plot[1];
            inputPlot.spriteX = plot[2];
            inputPlot.spriteY = plot[3];
            inputPlot.spriteWidth = plot[4];
            inputPlot.spriteHeight = plot[5];

            skin.Buttons[buttonName] = inputPlot;
        }

        return skin;
    }
}
