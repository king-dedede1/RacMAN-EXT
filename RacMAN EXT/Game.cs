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
    public string? ScriptFolderPath { get; }

    private string folderPath;
    private string trainerPath;

    /*
    to be added:

    components
    mods
    scripts
    hotkeys/combos
    autosplitters
    */

    /// <summary>
    /// Load a `game` object from a game folder
    /// </summary>
    public Game(string titleID)
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
            
        }

        // ScriptFolderPath should be the path to the game's scripts folder if it exists, otherwise, it should be null.
        ScriptFolderPath = $"data/game/{titleID}/scripts/";
        if (!Directory.Exists(ScriptFolderPath)) ScriptFolderPath = null;
    }

    public void SaveEverything()
    {
        File.WriteAllText(trainerPath, JsonSerializer.Serialize(Trainer, jso));
    }
}
