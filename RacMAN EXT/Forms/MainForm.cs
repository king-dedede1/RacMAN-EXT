using RacMAN.API;
using RacMAN.Forms.InputDisplay;
using System.IO.Compression;
using System.Text.Json;

namespace RacMAN.Forms;
public partial class MainForm : Form
{
    internal Racman state;
    public TrainerPanel? TrainerPanel { get; set; }
    public Trainer Trainer { get; set; }
    public InputDisplayForm? InputDisplay { get; set; }

    public MainForm(Racman state)
    {
        InitializeComponent();
        this.state = state;
        state.APIConnected += ReloadGameSpecificStuff;
        state.InputProviderChanged += CheckForInputProvider;
    }

    private void ReloadGameSpecificStuff()
    {
        LoadTrainer();

        if (state.APIType == APIType.PS3)
        {
            pS3ToolStripMenuItem.Enabled = true;
        }
        else
        {
            pS3ToolStripMenuItem.Enabled = false;
        }
    }

    internal void LoadTrainer()
    {
        if (TrainerPanel != null)
        {
            TrainerPanel.CallOnUnloadEvent();
            this.Controls.Remove(TrainerPanel);
            TrainerPanel = null;
        }
        if (state.Game != null)
        {
            LuaConsoleForm.instance.Log("Loading trainer...");
            var trainer = state.Game.Trainer;
            TrainerPanel panel = new TrainerPanel(trainer);
            this.Controls.Add(panel);
            this.TrainerPanel = panel;
            this.Trainer = trainer;
            panel.CallOnLoadEvent();
            LuaConsoleForm.instance.Log($"Done loading trainer for {trainer.TitleID}");
        }
        trainerMenuItem.Enabled = TrainerPanel != null;
    }

    private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
    {
        state.ControllerComboManager?.Close();
        if (TrainerPanel != null)
        {
            TrainerPanel.CallOnUnloadEvent();
        }
        state.Game?.SaveEverything();
        state.SaveSettings();
        state.API?.Disconnect();
    }

    private void aboutRaCMANToolStripMenuItem_Click(object sender, EventArgs e)
    {
        new AboutBox().ShowDialog();
    }

    private void reconnectToolStripMenuItem_Click(object sender, EventArgs e)
    {
        this.Hide();
        state.ShowConnectDialog();
        this.Show();
    }

    private void MainForm_Shown(object sender, EventArgs e)
    {
        if (state.InputProvider == null)
        {
            MessageBox.Show("No controller input provider was found. Input display is not available and controller combos will not be triggered.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

    private void CheckForInputProvider()
    {
        if (state.InputProvider == null && state.Connected)
        {
            inputDisplayToolStripMenuItem.Enabled = false;
        }
        else
        {
            inputDisplayToolStripMenuItem.Enabled = true;
        }
    }

    private void luaConsoleToolStripMenuItem_Click(object sender, EventArgs e)
    {
        state.ConsoleForm.Show();
    }

    private void reloadLuaStateToolStripMenuItem_Click(object sender, EventArgs e)
    {
        state.InitLuaState();
        LoadTrainer();
    }

    private void reloadToolStripMenuItem_Click(object sender, EventArgs e)
    {
        LoadTrainer();
    }

    private void openDesignerToolStripMenuItem_Click(object sender, EventArgs e)
    {
        new TrainerEditorForm(Trainer).ShowDialog();
        LoadTrainer();
    }

    // maybe add an option to install a zip of multiple packages?
    // also there should be some error checking if the zip file has a name that isn't a valid title ID
    // also there should be an option to update an existing package
    private void installGamePackageToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (openFileDialog1.ShowDialog() == DialogResult.OK)
        {
            var path = openFileDialog1.FileName;
            try
            {
                File.Copy(path, $"data/game/PACKAGE.ZIP");
                ZipFile.ExtractToDirectory("data/game/PACKAGE.ZIP", $"data/game/");
                MessageBox.Show($"Installed package {Path.GetFileNameWithoutExtension(path)}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Couldn't extract package ({ex.Message})", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                File.Delete("data/game/PACKAGE.ZIP");
            }
        }
    }

    private void autosplittersToolStripMenuItem_Click(object sender, EventArgs e)
    {
        new AutosplittersForm().Show();
    }

    private void combosHotkeysToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (state.CombosForm == null || state.CombosForm.IsDisposed)
        {
            state.CombosForm = new(state.Game.ControllerCombos, state);
        }
        state.CombosForm.Show();
    }

    private void inputDisplayToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (InputDisplay == null || InputDisplay.IsDisposed) InputDisplay = new(state);
        InputDisplay.Show();
    }

    private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
    {
        new SettingsForm(state).Show();
    }
}