using RacMAN.Forms.PropertyEditor;
using System.Text.Json;

namespace RacMAN.Forms;
public partial class TrainerEditorForm : Form
{
    Trainer trainer;

    Control? selectedControl = null;
    Control? SelectedControl
    {
        get => selectedControl;
        set
        {
            selectedControl = value;
            SelectedControlChanged?.Invoke(this, EventArgs.Empty);
        }
    }
    Point rightClickPoint;
    Point draggedControlPoint;

    private static readonly JsonSerializerOptions jsonSerializerOptions = new JsonSerializerOptions()
    {
        WriteIndented = true
    };

    internal event EventHandler SelectedControlChanged;

    public TrainerEditorForm(Trainer trainer)
    {
        InitializeComponent();

        //TODO copy instead of passing by reference!
        // this is really bad!!!!
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
        SelectedControl = sender as Control;

        if (e.Button == MouseButtons.Right)
        {
            rightClickPoint = PointToClient(Cursor.Position);

            // these five should only be selectable when you right click a control
            contextMenuStrip1.Items[0].Enabled = true;
            contextMenuStrip1.Items[1].Enabled = SelectedControl is not ComboBox;
            contextMenuStrip1.Items[2].Enabled = true;
            contextMenuStrip1.Items[3].Enabled = true;
            contextMenuStrip1.Items[4].Enabled = true;

            contextMenuStrip1.Show(Cursor.Position);
        }
        Refresh();
    }

    private Label ConstructLabel(DefineLabel define)
    {
        Label label = new Label();
        label.Text = define.Text;
        label.Name = define.Name;
        label.Location = define.Position;
        label.AutoSize = true;
        label.MouseUp += ControlMouseClick;
        label.Tag = define;
        SelectedControlChanged += (s, e) =>
        {
            if (SelectedControl == label && label.Controls.Count == 0)
            {
                RacMAN.Forms.Handle.MakeCenter(label);
            }
            else
            {
                label.Controls.Clear();
            }
        };
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
        button.MouseUp += ControlMouseClick;
        SelectedControlChanged += (s, e) =>
        {
            if (SelectedControl == button && button.Controls.Count == 0)
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
        textBox.MouseUp += ControlMouseClick;
        SelectedControlChanged += (s, e) =>
        {
            if (SelectedControl == textBox && textBox.Controls.Count == 0)
            {
                RacMAN.Forms.Handle.MakeLeftRightCenter(textBox);
            }
            else
            {
                textBox.Controls.Clear();
            }
        };
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
        checkBox.MouseUp += ControlMouseClick;
        SelectedControlChanged += (s, e) =>
        {
            if (SelectedControl == checkBox && checkBox.Controls.Count == 0)
            {
                RacMAN.Forms.Handle.MakeCenter(checkBox);
            }
            else
            {
                checkBox.Controls.Clear();
            }
        };
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
        comboBox.MouseUp += ControlMouseClick;
        SelectedControlChanged += (s, e) =>
        {
            if (SelectedControl == comboBox && comboBox.Controls.Count == 0)
            {
                RacMAN.Forms.Handle.MakeLeftRightCenter(comboBox);
            }
            else
            {
                comboBox.Controls.Clear();
            }
        };
        return comboBox;
    }

    private void TrainerEditorForm_Paint(object sender, PaintEventArgs e)
    {
        if (SelectedControl != null)
        {
            var g = e.Graphics;
            g.Clear(BackColor);
            var b = new SolidBrush(Color.FromArgb(128, 255, 0, 0));
            var rect = SelectedControl.Bounds;
            rect.Inflate(2, 2);
            g.FillRectangle(b, rect);
        }
    }

    private void TrainerEditorForm_FormClosing(object sender, FormClosingEventArgs e)
    {
        var result = MessageBox.Show("Do you want to save your changes?", "Save?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

        if (result == DialogResult.Yes)
        {
            // this is bad
            var state = ((MainForm) Application.OpenForms["MainForm"]).state;
            state.Game.Trainer = trainer;
            state.Game.SaveEverything();
        }
    }

    private void repaintTimer_Tick(object sender, EventArgs e)
    {
        Refresh();
    }

    private void TrainerEditorForm_MouseClick(object sender, MouseEventArgs e)
    {
        SelectedControl = null;
        if (e.Button == MouseButtons.Right)
        {
            rightClickPoint = PointToClient(Cursor.Position);

            // these five should only be selectable when you right click a control
            contextMenuStrip1.Items[0].Enabled = false;
            contextMenuStrip1.Items[1].Enabled = false;
            contextMenuStrip1.Items[2].Enabled = false;
            contextMenuStrip1.Items[3].Enabled = false;
            contextMenuStrip1.Items[4].Enabled = false;


            contextMenuStrip1.Show(Cursor.Position);
        }
    }

    private void labelToolStripMenuItem_Click(object sender, EventArgs e)
    {
        DefineLabel def = new()
        {
            Position = rightClickPoint,
            Text = "New Label",
            Name = ""
        };
        var control = ConstructLabel(def);
        Controls.Add(control);
        SelectedControl = control;
        trainer.Labels.Add(def);
    }

    private void buttonToolStripMenuItem_Click(object sender, EventArgs e)
    {
        DefineButton def = new()
        {
            Position = rightClickPoint,
            Text = "New Button",
            Name = "",
            OnClick = "",
            Size = new Size(80, 20),
            Enabled = true
        };
        var control = ConstructButton(def);
        Controls.Add(control);
        SelectedControl = control;
        trainer.Buttons.Add(def);
    }

    private void textBoxToolStripMenuItem_Click(object sender, EventArgs e)
    {
        DefineTextBox def = new()
        {
            Position = rightClickPoint,
            Text = "",
            Name = "",
            OnEnter = "",
            Enabled = true
        };
        var control = ConstructTextBox(def);
        Controls.Add(control);
        SelectedControl = control;
        trainer.TextBoxes.Add(def);
    }

    private void checkBoxToolStripMenuItem_Click(object sender, EventArgs e)
    {
        DefineCheckBox def = new()
        {
            Position = rightClickPoint,
            Text = "Check Box",
            Name = "",
            CheckState = CheckState.Unchecked,
            AllowIndeterminate = false,
            OnCheck = "",
            Enabled = true
        };
        var control = ConstructCheckBox(def);
        Controls.Add(control);
        SelectedControl = control;
        trainer.CheckBoxes.Add(def);
    }

    private void dropdownMenuToolStripMenuItem_Click(object sender, EventArgs e)
    {
        DefineDropdown def = new()
        {
            Position = rightClickPoint,
            Size = new Size(80, 20),
            Enabled = true,
            Options = ["Dropdown"],
            Index = 0,
            OnItemSelected = "",
            Name = ""
        };
        var control = ConstructComboBox(def);
        Controls.Add(control);
        SelectedControl = control;
        trainer.Dropdowns.Add(def);
    }

    private void propertiesToolStripMenuItem_Click(object sender, EventArgs e)
    {
        new PropertyEditorForm(SelectedControl.Tag).ShowDialog();
    }

    private void textToolStripMenuItem_Click(object sender, EventArgs e)
    {
        var tag = SelectedControl.Tag as dynamic;
        tag.Text = InputDialog.ShowInputDialog("Name", tag.Text);
        SelectedControl.Text = tag.Text;
    }
}
