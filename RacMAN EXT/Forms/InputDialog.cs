using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RacMAN.Forms;
public partial class InputDialog : Form
{
    public string ReturnValue => textBox1.Text;

    public InputDialog(string labelText, string defaultValue = "", bool multiline = false)
    {
        InitializeComponent();

        label1.Text = labelText;
        textBox1.Text = defaultValue;
        textBox1.Multiline = multiline;
    }

    private void textBox1_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter && !textBox1.Multiline)
        {
            Hide();
        }
    }

    private void submitButton_Click(object sender, EventArgs e)
    {
        Hide();
    }

    public static string ShowInputDialog(string labelText, string defaultValue = "", bool multiline = false)
    {
        var dialog = new InputDialog(labelText, defaultValue, multiline);
        dialog.ShowDialog();
        return dialog.ReturnValue;
    }
}
