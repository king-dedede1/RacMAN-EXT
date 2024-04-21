using RacMAN.Autosplitters;
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
public partial class AutosplittersForm : Form
{
    public AutosplittersForm()
    {
        InitializeComponent();
    }

    private void AutosplittersForm_Load(object sender, EventArgs e)
    {
        foreach (Autosplitter a in Program.state.Autosplitters)
        {
            checkedListBox1.Items.Add(a.Name);
        }
    }

    private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
    {
        if (e.NewValue == CheckState.Checked)
        {
            Program.state.Autosplitters[e.Index].Start();
        }
        else
        {
            Program.state.Autosplitters[e.Index].Stop();
        }
    }

    private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        label1.Text = Program.state.Autosplitters[checkedListBox1.SelectedIndex].Name;
        textBox1.Text = Program.state.Autosplitters[checkedListBox1.SelectedIndex].Description;
    }
}
