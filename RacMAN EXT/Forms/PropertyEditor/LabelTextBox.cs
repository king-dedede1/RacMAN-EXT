using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RacMAN.Forms.PropertyEditor;
public partial class LabelTextBox : UserControl
{
    public LabelTextBox()
    {
        InitializeComponent();
    }

    public LabelTextBox(string str1,  string str2, bool multiline = false) : this()
    {
        label1.Text = str1;
        textBox1.Text = str2; 
        textBox1.Multiline = multiline;
    }

    public string LabelText => label1.Text;
    public string BoxText => textBox1.Text;
}
