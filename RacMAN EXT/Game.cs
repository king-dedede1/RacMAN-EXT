using RacMAN.ControllerCombos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace RacMAN;

/// <summary>
/// Capabilities for the current connected game, to be loaded from its respective folder on disk
/// Not to be inherited from
/// </summary>
public class Game
{
    private static readonly JsonSerializerOptions jso = new JsonSerializerOptions()
    {
        WriteIndented = true
    };

    public Trainer Trainer { get; internal set; }
    public ControllerComboGroup ControllerCombos { get; internal set; }
    public string? ScriptFolderPath { get; }

    private string folderPath;
    private string trainerPath;
    private string combosPath;

    /*
    to be added:

    components
    mods



    */

    /// <summary>
    /// Load a `game` object from a game folder
    /// </summary>
    public Game(string titleID, string gameName)
    {
        folderPath = $"data/game/{titleID}/";
        if (!Directory.Exists(folderPath))
        {
            Directory.CreateDirectory(folderPath);
        }

        trainerPath = Path.Combine(folderPath, "trainer.json");
        if (File.Exists(trainerPath))
        {
            Trainer = JsonSerializer.Deserialize<Trainer>(File.ReadAllText(trainerPath)) ?? new Trainer(titleID);
        }
        else
        {
            File.Create(trainerPath).Close();
            Trainer = new Trainer(titleID);
            File.WriteAllText(trainerPath, JsonSerializer.Serialize(Trainer, jso));
        }

        combosPath = Path.Combine(folderPath, "combos.json");
        if (File.Exists(combosPath))
        {
            ControllerCombos = JsonSerializer.Deserialize<ControllerComboGroup>(File.ReadAllText(combosPath));
        }
        else
        {
            ControllerCombos = new ControllerComboGroup()
            {
                Name = $"{gameName} ({titleID})"
            };
            SaveCombos();
        }

        // ScriptFolderPath should be the path to the game's scripts folder if it exists, otherwise, it should be null.
        ScriptFolderPath = $"data/game/{titleID}/scripts/";
        if (!Directory.Exists(ScriptFolderPath)) ScriptFolderPath = null;
    }

    public void SaveTrainer()
    {
        File.WriteAllText(trainerPath, JsonSerializer.Serialize(Trainer, jso));

    }

    public void SaveCombos()
    {

        File.WriteAllText(combosPath, JsonSerializer.Serialize(ControllerCombos, jso));
    }

    public void SaveEverything()
    {
        SaveTrainer();
        SaveCombos();
    }
}
