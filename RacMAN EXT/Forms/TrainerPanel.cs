namespace RacMAN.Forms;
public class TrainerPanel : Panel
{
    #region designer generated code
    private ContextMenuStrip AddStuffMenu;
    private ToolStripMenuItem toolStripMenuItem1;
    private ToolStripMenuItem label;
    private ToolStripMenuItem button;
    private ToolStripMenuItem textbox;
    private ToolStripMenuItem checkbox;
    private ToolStripMenuItem dropdown;
    private ToolStripMenuItem deleteEverything;
    private ToolStripMenuItem save;
    private System.ComponentModel.IContainer components;

    private void InitializeComponent()
    {
        this.components = new System.ComponentModel.Container();
        this.AddStuffMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
        this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
        this.label = new System.Windows.Forms.ToolStripMenuItem();
        this.button = new System.Windows.Forms.ToolStripMenuItem();
        this.textbox = new System.Windows.Forms.ToolStripMenuItem();
        this.checkbox = new System.Windows.Forms.ToolStripMenuItem();
        this.dropdown = new System.Windows.Forms.ToolStripMenuItem();
        this.deleteEverything = new System.Windows.Forms.ToolStripMenuItem();
        this.save = new System.Windows.Forms.ToolStripMenuItem();
        this.AddStuffMenu.SuspendLayout();
        this.SuspendLayout();
        // 
        // AddStuffMenu
        // 
        this.AddStuffMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.deleteEverything,
            this.save});
        this.AddStuffMenu.Name = "AddStuffMenu";
        this.AddStuffMenu.Size = new System.Drawing.Size(167, 70);
        // 
        // toolStripMenuItem1
        // 
        this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.label,
            this.button,
            this.textbox,
            this.checkbox,
            this.dropdown});
        this.toolStripMenuItem1.Name = "toolStripMenuItem1";
        this.toolStripMenuItem1.Size = new System.Drawing.Size(166, 22);
        this.toolStripMenuItem1.Text = "Add";
        // 
        // label
        // 
        this.label.Name = "label";
        this.label.Size = new System.Drawing.Size(164, 22);
        this.label.Text = "Label";
        // 
        // button
        // 
        this.button.Name = "button";
        this.button.Size = new System.Drawing.Size(164, 22);
        this.button.Text = "Button";
        // 
        // textbox
        // 
        this.textbox.Name = "textbox";
        this.textbox.Size = new System.Drawing.Size(164, 22);
        this.textbox.Text = "Text Box";
        // 
        // checkbox
        // 
        this.checkbox.Name = "checkbox";
        this.checkbox.Size = new System.Drawing.Size(164, 22);
        this.checkbox.Text = "Check Box";
        // 
        // dropdown
        // 
        this.dropdown.Name = "dropdown";
        this.dropdown.Size = new System.Drawing.Size(164, 22);
        this.dropdown.Text = "Dropdown Menu";
        // 
        // deleteEverything
        // 
        this.deleteEverything.Name = "deleteEverything";
        this.deleteEverything.Size = new System.Drawing.Size(166, 22);
        this.deleteEverything.Text = "Delete Everything";
        // 
        // save
        // 
        this.save.Name = "save";
        this.save.Size = new System.Drawing.Size(166, 22);
        this.save.Text = "Save";
        // 
        // TrainerPanel
        // 
        this.Click += new System.EventHandler(this.TrainerPanel_Click);
        this.AddStuffMenu.ResumeLayout(false);
        this.ResumeLayout(false);

    }
    #endregion

    Trainer trainerJson;

    private Point clickPoint; //lol

    private Control draggedControl;
    private Point draggedControlPoint;

    internal TrainerPanel(Trainer trainer)
    {
        InitializeComponent();

        trainerJson = trainer;
        this.Name = "trainerpanel";
        this.Dock = DockStyle.Fill;

        // why cant you set events from the designer???????
        label.Click += AddLabelButtonClick;
        button.Click += AddButtonButtonClick;
        textbox.Click += AddTextboxButtonClick;
        checkbox.Click += AddCheckboxButtonClick;
        dropdown.Click += AddDropdownButtonClick;
        deleteEverything.Click += DeleteEverything_Click;
        save.Click += Save_Click;

        // add controls from JSON file
        SuspendLayout();
        foreach (var i in trainer.Labels)
        {
            this.Controls.Add(DefineLabel.ToLabel(i, this));
        }
        foreach (var i in trainer.Buttons)
        {
            this.Controls.Add(DefineButton.ToButton(i, this));
        }
        foreach (var i in trainer.TextBoxes)
        {
            this.Controls.Add(DefineTextBox.ToTextBox(i, this));
        }
        foreach (var i in trainer.CheckBoxes)
        {
            this.Controls.Add(DefineCheckBox.ToCheckBox(i, this));
        }
        foreach (var i in trainer.Dropdowns)
        {
            this.Controls.Add(DefineDropdown.ToComboBox(i, this));
        }
        ResumeLayout();
    }

    private void Save_Click(object sender, EventArgs e)
    {
        ((MainForm) this.Parent).SaveTrainer();
    }

    private void DeleteEverything_Click(object sender, EventArgs e)
    {
        // todo add message box here, very important
        trainerJson.Labels.Clear();
        trainerJson.TextBoxes.Clear();
        trainerJson.CheckBoxes.Clear();
        trainerJson.Dropdowns.Clear();
        trainerJson.Buttons.Clear();
        trainerJson.OnLoad = string.Empty;
        trainerJson.OnUnload = string.Empty;
        this.Controls.Clear();
    }

    private void AddDropdownButtonClick(object sender, EventArgs e)
    {
        DefineDropdown drop = new DefineDropdown()
        {
            Size = new Size(80, 20),
            Position = clickPoint,
            Name = "",
            Options = new string[] { "" },
            OnItemSelected = "",
            Enabled = true
        };
        trainerJson.Dropdowns.Add(drop);
        this.Controls.Add(DefineDropdown.ToComboBox(drop, this));
    }

    private void AddCheckboxButtonClick(object sender, EventArgs e)
    {
        DefineCheckBox box = new DefineCheckBox()
        {
            Text = "",
            Name = "",
            Enabled = true,
            Position = clickPoint,
            OnCheck = "",
        };
        trainerJson.CheckBoxes.Add(box);
        this.Controls.Add(DefineCheckBox.ToCheckBox(box, this));
    }

    private void AddTextboxButtonClick(object sender, EventArgs e)
    {
        DefineTextBox box = new DefineTextBox()
        {
            Text = "",
            Name = "",
            OnEnter = "",
            Position = clickPoint,
            Enabled = true,
        };
        trainerJson.TextBoxes.Add(box);
        this.Controls.Add(DefineTextBox.ToTextBox(box, this));
    }

    private void AddButtonButtonClick(object sender, EventArgs e)
    {
        DefineButton button = new DefineButton()
        {
            Text = "New Button",
            Name = "",
            OnClick = "",
            Size = new Size(80, 20),
            Enabled = true,
            Position = clickPoint
        };
        trainerJson.Buttons.Add(button);
        this.Controls.Add(DefineButton.ToButton(button, this));
    }

    private void AddLabelButtonClick(object sender, EventArgs e)
    {
        DefineLabel label = new DefineLabel()
        {
            Text = "New Label",
            Name = "",
            Position = clickPoint
        };
        trainerJson.Labels.Add(label);
        this.Controls.Add(DefineLabel.ToLabel(label, this));
    }

    private void TrainerPanel_Click(object sender, EventArgs e)
    {
        var mouse = (MouseEventArgs) e;
        if (mouse.Button == MouseButtons.Right)
        {
            clickPoint = mouse.Location;
            AddStuffMenu.Show(PointToScreen(mouse.Location));
        }
    }

    public void DraggableControlMouseDown(object sender, MouseEventArgs e)
    {
        if (ModifierKeys == Keys.Control)
        {
            draggedControl = sender as Control;
            draggedControlPoint = e.Location;
            Cursor = Cursors.SizeAll;
        }
    }

    public void DraggableControlMouseMove(object sender, MouseEventArgs e)
    {
        if (ModifierKeys != Keys.Control)
        {
            DraggableControlMouseUp(sender, e);
            return;
        }
        if (draggedControl == null || draggedControl != sender)
        {
            return;
        }
        var location = draggedControl.Location;
        location.Offset(e.Location.X - draggedControlPoint.X, e.Location.Y - draggedControlPoint.Y);
        draggedControl.Location = location;
        dynamic tag = draggedControl.Tag; // this is probably a bad way to do this, but it works.
        tag.Position = location;
    }

    public void DraggableControlMouseUp(object sender, MouseEventArgs e)
    {
        draggedControl = null;
        Cursor = Cursors.Default;
    }
}
