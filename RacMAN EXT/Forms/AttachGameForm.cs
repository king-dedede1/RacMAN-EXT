using System.Net;
using System.Reflection;
using RacMAN.API;

namespace RacMAN.Forms;
public partial class AttachGameForm : Form
{
    Racman state;
    public APIType apiType = APIType.None;
    public string BoxText => textBox1.Text;

    public AttachGameForm(Racman state)
    {
        InitializeComponent();
        versionLabel.Text = $"v{Assembly.GetEntryAssembly()!.GetName().Version}";
        this.state = state;
        comboBox1.SelectedIndex = state.Settings.DefaultAPIDropdownIndex ?? 0;

        
    }

    private void continueButton_Click(object sender, EventArgs e)
    {
        this.apiType = APIType.None;

        this.Hide();
    }

    private void attachButton_Click(object sender, EventArgs e)
    {
        Connect();
    }

    private void Connect()
    {
        state.Settings.DefaultAPIDropdownIndex = comboBox1.SelectedIndex;
        switch (this.comboBox1.SelectedIndex)
        {
            case 0:
                this.apiType = APIType.PS3;
                break;
            case 1:
                this.apiType = APIType.RPCS3;
                break;
            case 2:
                this.apiType = APIType.PCSX2;
                break;
        }

        this.Hide();
    }

    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        switch (comboBox1.SelectedIndex)
        {
            case 0:
                textBox1.Text = state.Settings.RatchetronIP;
                label3.Text = "IP Address:";
                break;
            case 1:
                textBox1.Text = state.Settings.RPCS3Slot.ToString();
                label3.Text = "PINE Slot:";
                break;
            case 2:
                textBox1.Text = state.Settings.PCSX2Slot.ToString();
                label3.Text = "PINE Slot:";
                break;
        }

    }

    private void textBox1_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            Connect();
        }
    }

    private void AttachGameForm_Shown(object sender, EventArgs e)
    {
        if ((bool) state.Settings.AutoConnect!) Connect();
    }
}
