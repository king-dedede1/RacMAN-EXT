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
public partial class LuaConsoleForm : Form
{
    public static LuaConsoleForm instance;

    public LuaConsoleForm()
    {
        InitializeComponent();
        console.Text = string.Empty;
        instance = this;
    }

    public void Log(string msg)
    {
        console.AppendText($"\n[INFO]  {msg}");
    }

    public void Warn(string msg)
    {
        console.AppendText($"\n[WARN]  {msg}", Color.Gold);
    }

    public void Error(string msg)
    {
        console.AppendText($"\n[ERROR] {msg}", Color.Salmon);
    }

    private void ExecuteCommand()
    {
        if (commandBox.Text != "")
        {
            console.AppendText($"\n> {commandBox.Text}");
            var luaResult = Racman.EvalLua($"return {commandBox.Text}");
            if (luaResult != null)
            {
                if (luaResult.Length > 0)
                {
                    // not worrying about multiple return values right now
                    console.AppendText($"\n< {luaResult[0]}");
                }
                else
                {
                    console.AppendText("\n< undefined");
                }
            }

        }
    }



    private void commandBox_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            ExecuteCommand();
            commandBox.Text = string.Empty;
        }
    }

    private void submitButton_Click(object sender, EventArgs e)
    {
        ExecuteCommand();
        commandBox.Text = string.Empty;
    }

    private void console_TextChanged(object sender, EventArgs e)
    {
        console.SelectionStart = console.Text.Length;
        console.ScrollToCaret();
    }

    // Prevent this form from getting garbage collected when the X is clicked
    // Maybe not the best way to do this? Idk
    private void LuaConsoleForm_FormClosing(object sender, FormClosingEventArgs e)
    {
        e.Cancel = true;
        Hide();
    }
}

public static class RichTextBoxExtensions
{
    // from stackoverflow
    public static void AppendText(this RichTextBox box, string text, Color color)
    {
        box.SelectionStart = box.TextLength;
        box.SelectionLength = 0;

        box.SelectionColor = color;
        box.AppendText(text);
        box.SelectionColor = box.ForeColor;
    }
}