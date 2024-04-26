using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RacMAN.Forms;
public partial class SettingsForm : Form
{
    Racman state;
    UserSettings settings;

    public SettingsForm(Racman state)
    {
        InitializeComponent();
        this.state = state;
        this.settings = state.Settings;

        ipTextbox.Text = settings.RatchetronIP ?? "";
        rpcs3slotTextbox.Text = settings.RPCS3Slot?.ToString() ?? "";
        pcsx2slotTextbox.Text = settings.PCSX2Slot?.ToString() ?? "";
        apiComboBox.SelectedIndex = settings.DefaultAPIDropdownIndex ?? 0;
        autoconnectCheckbox.Checked = settings.AutoConnect ?? false;
        timeoutTextbox.Text = settings.SocketTimeoutInterval.ToString() ?? "";

        UpdateSkinsComboBox();
        
        borderlessCheckbox.Checked = settings.InputDisplayBorderless ?? false;
        keyColorButton.BackColor = settings.InputDisplayBackColor ?? Color.Purple;

        globalHotkeysCheckbox.Checked = settings.GlobalHotkeysEnabled ?? false;

        controllerCombosCheckbox.Checked = settings.TriggerCombosOnButtonRelease ?? false;

        backColorButton.BackColor = settings.ConsoleBackColor ?? Color.Black;
        textColorButton.BackColor = settings.ConsoleTextColor ?? Color.White;
        fontLabel.Text = $"Font: {settings.ConsoleTextFontName}  {settings.ConsoleTextFontSize}pt";

        sampleTextBox.Font = new Font((string) settings.ConsoleTextFontName, (float) settings.ConsoleTextFontSize, (FontStyle) settings.ConsoleTextFontStyle);
        sampleTextBox.ForeColor = settings.ConsoleTextColor ?? Color.White;
        sampleTextBox.BackColor = settings.ConsoleBackColor ?? Color.Black;
    }

    private void UpdateSkinsComboBox()
    {
        var skins = Directory.GetDirectories("data/common/inputdisplay/").Select(e => Path.GetFileName(e)).ToArray();
        controllerSkinComboBox.Items.Clear();
        controllerSkinComboBox.Items.AddRange(skins);
        if (settings.InputDisplaySkin != null) controllerSkinComboBox.SelectedIndex = Array.IndexOf(skins, settings.InputDisplaySkin);
    }

    private void ipTextbox_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            if (IPAddress.TryParse(ipTextbox.Text, out _))
            {
                settings.RatchetronIP = ipTextbox.Text;
            }
            else
            {
                MessageBox.Show("Couldn't parse IP address");
            }
        }
    }

    private void rpcs3slotTextbox_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            if (UInt16.TryParse(rpcs3slotTextbox.Text, out UInt16 slot))
            {
                settings.RPCS3Slot = slot;
            }
            else
            {
                MessageBox.Show("Couldn't parse number");
            }
        }
    }

    private void pcsx2slotTextbox_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            if (UInt16.TryParse(pcsx2slotTextbox.Text, out UInt16 slot))
            {
                settings.PCSX2Slot = slot;
            }
            else
            {
                MessageBox.Show("Couldn't parse number");
            }
        }
    }

    private void timeoutTextbox_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            if (int.TryParse(timeoutTextbox.Text, out int timeout))
            {
                settings.SocketTimeoutInterval = timeout;
                MessageBox.Show("Please reconnect the API or restart racman for the changes to take effect.");
            }
            else
            {
                MessageBox.Show("Couldn't parse number");
            }
        }
    }

    private void apiComboBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        settings.DefaultAPIDropdownIndex = apiComboBox.SelectedIndex;
    }

    private void autoconnectCheckbox_CheckedChanged(object sender, EventArgs e)
    {
        settings.AutoConnect = autoconnectCheckbox.Checked;
    }

    private void globalHotkeysCheckbox_CheckedChanged(object sender, EventArgs e)
    {
        settings.GlobalHotkeysEnabled = globalHotkeysCheckbox.Checked;
    }

    private void controllerCombosCheckbox_CheckedChanged(object sender, EventArgs e)
    {
        settings.TriggerCombosOnButtonRelease = controllerCombosCheckbox.Checked;
    }

    private void controllerSkinComboBox_SelectedValueChanged(object sender, EventArgs e)
    {
        settings.InputDisplaySkin = (string?) controllerSkinComboBox.Items[controllerSkinComboBox.SelectedIndex];
    }

    private void importSkinButton_Click(object sender, EventArgs e)
    {
        if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
        {
            var newFolder = $"data/common/inputdisplay/{Path.GetFileName(folderBrowserDialog1.SelectedPath)}/";
            Directory.CreateDirectory(newFolder);
            foreach (var filepath in Directory.GetFiles(folderBrowserDialog1.SelectedPath))
            {
                File.Copy(filepath, Path.Combine(newFolder, Path.GetFileName(filepath)));
            }
            UpdateSkinsComboBox();
        }
    }

    private void borderlessCheckbox_CheckedChanged(object sender, EventArgs e)
    {
        settings.InputDisplayBorderless = borderlessCheckbox.Checked;
    }

    private void keyColorButton_Click(object sender, EventArgs e)
    {
        if (colorDialog1.ShowDialog() == DialogResult.OK)
        {
            settings.InputDisplayBackColor = colorDialog1.Color;
            keyColorButton.BackColor = colorDialog1.Color;
        }
    }

    private void backColorButton_Click(object sender, EventArgs e)
    {
        if (colorDialog1.ShowDialog() == DialogResult.OK)
        {
            settings.ConsoleBackColor = colorDialog1.Color;
            backColorButton.BackColor = colorDialog1.Color;
            sampleTextBox.BackColor = colorDialog1.Color;
            state.ConsoleForm.UpdateColors();
        }
    }

    private void textColorButton_Click(object sender, EventArgs e)
    {
        if (colorDialog1.ShowDialog() == DialogResult.OK)
        {
            settings.ConsoleTextColor = colorDialog1.Color;
            textColorButton.BackColor = colorDialog1.Color;
            sampleTextBox.ForeColor = colorDialog1.Color;
            state.ConsoleForm.UpdateColors();
        }
    }

    private void fontButton_Click(object sender, EventArgs e)
    {
        if (fontDialog1.ShowDialog() == DialogResult.OK)
        {
            var font = fontDialog1.Font;

            settings.ConsoleTextFontName = font.Name;
            settings.ConsoleTextFontStyle = font.Style;
            settings.ConsoleTextFontSize = font.Size;
            sampleTextBox.Font = font;
            fontLabel.Text = $"Font: {font.Name} {font.SizeInPoints}pt";
            state.ConsoleForm.UpdateColors();
        }
    }
}
