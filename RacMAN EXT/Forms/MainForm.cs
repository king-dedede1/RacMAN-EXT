using RacMAN.API;
using System.IO.Compression;
using System.Text.Json;

namespace RacMAN.Forms;
public partial class MainForm : Form
{
    internal Racman state;
    public TrainerPanel? TrainerPanel { get; set; }
    public Trainer Trainer { get; set; }

    public MainForm(Racman state)
    {
        InitializeComponent();
        this.state = state;
        state.OnAPIConnect += ReloadGameSpecificStuff;
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
        if (TrainerPanel != null)
        {
            TrainerPanel.CallOnUnloadEvent();
        }
        state.Game.SaveEverything();
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
}