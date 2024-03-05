using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Handle = RacMAN.Forms.Handle;

namespace RacMAN.Forms;
public partial class TrainerEditorForm : Form
{
    Trainer trainer;

    Control? selectedControl = null;
    Point rightClickPoint;
    Point draggedControlPoint;

    internal event EventHandler SelectedControlChanged;

    public TrainerEditorForm(Trainer trainer)
    {
        InitializeComponent();

        this.trainer = trainer;


        // add controls from JSON file
        SuspendLayout();

        foreach (var label in trainer.Labels) Controls.Add(ConstructLabel(label));
        foreach (var button in trainer.Buttons) Controls.Add(ConstructButton(button));
        foreach (var textbox in trainer.TextBoxes) Controls.Add(ConstructTextBox(textbox));
        foreach (var checkbox in trainer.CheckBoxes) Controls.Add(ConstructCheckBox(checkbox));
        foreach (var combobox in trainer.Dropdowns) Controls.Add(ConstructComboBox(combobox));

        ResumeLayout();
    }

    private void ControlMouseClick(object? sender, MouseEventArgs e)
    {
        selectedControl = sender as Control;
        SelectedControlChanged?.Invoke(this, new EventArgs());
        Refresh();
    }

    private Label ConstructLabel(DefineLabel define)
    {
        Label label = new Label();
        label.Text = define.Text;
        label.Name = define.Name;
        label.Location = define.Position;
        label.AutoSize = true;
        label.MouseClick += ControlMouseClick;
        label.Tag = define;
        return label;
    }

    private Button ConstructButton(DefineButton define)
    {
        Button button = new Button();
        button.Name = define.Name;
        button.Location = define.Position;
        button.Text = define.Text;
        button.Enabled = define.Enabled;
        button.Size = define.Size;
        button.Tag = define; // so Click event knows what event to run
        button.MouseClick += ControlMouseClick;
        SelectedControlChanged += (s, e) =>
        {
            if (selectedControl == button && button.Controls.Count == 0)
            {
                RacMAN.Forms.Handle.MakeSidesCornersAndCenter(button);
            }
            else
            {
                button.Controls.Clear();
            }
        };
        return button;
    }

    private TextBox ConstructTextBox(DefineTextBox define)
    {
        TextBox textBox = new TextBox();
        textBox.Name = define.Name;
        textBox.Location = define.Position;
        textBox.Text = define.Text;
        textBox.Enabled = define.Enabled;
        textBox.Tag = define;
        textBox.MouseClick += ControlMouseClick;
        return textBox;
    }

    private CheckBox ConstructCheckBox(DefineCheckBox define)
    {
        CheckBox checkBox = new CheckBox();
        checkBox.Name = define.Name;
        checkBox.Enabled = define.Enabled;
        checkBox.Text = define.Text;
        checkBox.CheckState = define.CheckState;
        checkBox.Location = define.Position;
        checkBox.ThreeState = define.AllowIndeterminate;
        checkBox.Tag = define;
        checkBox.MouseClick += ControlMouseClick;
        return checkBox;
    }

    private ComboBox ConstructComboBox(DefineDropdown define)
    {
        ComboBox comboBox = new ComboBox();
        comboBox.Name = define.Name;
        comboBox.Enabled = define.Enabled;
        comboBox.Location = define.Position;
        comboBox.Size = define.Size;
        comboBox.Items.AddRange(define.Options);
        comboBox.SelectedIndex = define.Index;
        comboBox.Tag = define;
        comboBox.MouseClick += ControlMouseClick;
        return comboBox;
    }

    private void TrainerEditorForm_Paint(object sender, PaintEventArgs e)
    {
        /*if (selectedControl != null)
        {
            var g = e.Graphics;
            g.Clear(BackColor);
            var b = new SolidBrush(Color.FromArgb(128, 255, 0, 0));
            var rect = selectedControl.Bounds;
            rect.Inflate(2,2);
            g.FillRectangle(b, rect);
        }*/
    }
}
