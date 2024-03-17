using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.DirectoryServices.ActiveDirectory;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RacMAN.Forms;
public partial class InputDialog : Form
{
    public string ReturnValue => textBox1.Text;
    private bool shouldSave = false;

    public InputDialog(string labelText, string defaultValue = "", bool multiline = false)
    {
        InitializeComponent();

        label1.Text = labelText;
        textBox1.Text = defaultValue;
        textBox1.Multiline = multiline;

        if (multiline)
        {
            this.FormBorderStyle = FormBorderStyle.Sizable;
            textBox1.ScrollBars = ScrollBars.Vertical;
            textBox1.WordWrap = false;
            this.Size = new(340, 280);
            textBox1.Size = new(300, 200);
            textBox1.Font = new Font("Consolas", 9);
            textBox1.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom | AnchorStyles.Top;
            submitButton.Top = 0;
        }
        else
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }
    }

    private void textBox1_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter && !textBox1.Multiline)
        {
            shouldSave = true;
            Hide();
        }
    }

    private void submitButton_Click(object sender, EventArgs e)
    {
        shouldSave = true;
        Hide();
    }

    public static string ShowInputDialog(string labelText, string defaultValue = "", bool multiline = false)
    {
        var dialog = new InputDialog(labelText, defaultValue, multiline);
        dialog.ShowDialog();
        return dialog.shouldSave? dialog.ReturnValue : defaultValue;
    }
}
