namespace RacMAN.Forms;

partial class TrainerEditorForm
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();
        repaintTimer = new System.Windows.Forms.Timer(components);
        contextMenuStrip1 = new ContextMenuStrip(components);
        propertiesToolStripMenuItem = new ToolStripMenuItem();
        textToolStripMenuItem = new ToolStripMenuItem();
        nameToolStripMenuItem = new ToolStripMenuItem();
        eventToolStripMenuItem = new ToolStripMenuItem();
        removeToolStripMenuItem = new ToolStripMenuItem();
        toolStripSeparator1 = new ToolStripSeparator();
        addToolStripMenuItem = new ToolStripMenuItem();
        labelToolStripMenuItem = new ToolStripMenuItem();
        buttonToolStripMenuItem = new ToolStripMenuItem();
        textBoxToolStripMenuItem = new ToolStripMenuItem();
        checkBoxToolStripMenuItem = new ToolStripMenuItem();
        dropdownMenuToolStripMenuItem = new ToolStripMenuItem();
        contextMenuStrip1.SuspendLayout();
        SuspendLayout();
        // 
        // repaintTimer
        // 
        repaintTimer.Enabled = true;
        repaintTimer.Interval = 16;
        repaintTimer.Tick += repaintTimer_Tick;
        // 
        // contextMenuStrip1
        // 
        contextMenuStrip1.Items.AddRange(new ToolStripItem[] { propertiesToolStripMenuItem, textToolStripMenuItem, nameToolStripMenuItem, eventToolStripMenuItem, removeToolStripMenuItem, toolStripSeparator1, addToolStripMenuItem });
        contextMenuStrip1.Name = "contextMenuStrip1";
        contextMenuStrip1.Size = new Size(137, 142);
        // 
        // propertiesToolStripMenuItem
        // 
        propertiesToolStripMenuItem.Name = "propertiesToolStripMenuItem";
        propertiesToolStripMenuItem.Size = new Size(136, 22);
        propertiesToolStripMenuItem.Text = "Properties...";
        propertiesToolStripMenuItem.Click += propertiesToolStripMenuItem_Click;
        // 
        // textToolStripMenuItem
        // 
        textToolStripMenuItem.Name = "textToolStripMenuItem";
        textToolStripMenuItem.Size = new Size(136, 22);
        textToolStripMenuItem.Text = "Text";
        textToolStripMenuItem.Click += textToolStripMenuItem_Click;
        // 
        // nameToolStripMenuItem
        // 
        nameToolStripMenuItem.Name = "nameToolStripMenuItem";
        nameToolStripMenuItem.Size = new Size(136, 22);
        nameToolStripMenuItem.Text = "Name";
        nameToolStripMenuItem.Click += nameToolStripMenuItem_Click;
        // 
        // eventToolStripMenuItem
        // 
        eventToolStripMenuItem.Name = "eventToolStripMenuItem";
        eventToolStripMenuItem.Size = new Size(136, 22);
        eventToolStripMenuItem.Text = "Event";
        eventToolStripMenuItem.Click += eventToolStripMenuItem_Click;
        // 
        // removeToolStripMenuItem
        // 
        removeToolStripMenuItem.Name = "removeToolStripMenuItem";
        removeToolStripMenuItem.Size = new Size(136, 22);
        removeToolStripMenuItem.Text = "Remove";
        removeToolStripMenuItem.Click += removeToolStripMenuItem_Click;
        // 
        // toolStripSeparator1
        // 
        toolStripSeparator1.Name = "toolStripSeparator1";
        toolStripSeparator1.Size = new Size(133, 6);
        // 
        // addToolStripMenuItem
        // 
        addToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { labelToolStripMenuItem, buttonToolStripMenuItem, textBoxToolStripMenuItem, checkBoxToolStripMenuItem, dropdownMenuToolStripMenuItem });
        addToolStripMenuItem.Name = "addToolStripMenuItem";
        addToolStripMenuItem.Size = new Size(136, 22);
        addToolStripMenuItem.Text = "Add";
        // 
        // labelToolStripMenuItem
        // 
        labelToolStripMenuItem.Name = "labelToolStripMenuItem";
        labelToolStripMenuItem.Size = new Size(164, 22);
        labelToolStripMenuItem.Text = "Label";
        labelToolStripMenuItem.Click += labelToolStripMenuItem_Click;
        // 
        // buttonToolStripMenuItem
        // 
        buttonToolStripMenuItem.Name = "buttonToolStripMenuItem";
        buttonToolStripMenuItem.Size = new Size(164, 22);
        buttonToolStripMenuItem.Text = "Button";
        buttonToolStripMenuItem.Click += buttonToolStripMenuItem_Click;
        // 
        // textBoxToolStripMenuItem
        // 
        textBoxToolStripMenuItem.Name = "textBoxToolStripMenuItem";
        textBoxToolStripMenuItem.Size = new Size(164, 22);
        textBoxToolStripMenuItem.Text = "Text Box";
        textBoxToolStripMenuItem.Click += textBoxToolStripMenuItem_Click;
        // 
        // checkBoxToolStripMenuItem
        // 
        checkBoxToolStripMenuItem.Name = "checkBoxToolStripMenuItem";
        checkBoxToolStripMenuItem.Size = new Size(164, 22);
        checkBoxToolStripMenuItem.Text = "Check Box";
        checkBoxToolStripMenuItem.Click += checkBoxToolStripMenuItem_Click;
        // 
        // dropdownMenuToolStripMenuItem
        // 
        dropdownMenuToolStripMenuItem.Name = "dropdownMenuToolStripMenuItem";
        dropdownMenuToolStripMenuItem.Size = new Size(164, 22);
        dropdownMenuToolStripMenuItem.Text = "Dropdown Menu";
        dropdownMenuToolStripMenuItem.Click += dropdownMenuToolStripMenuItem_Click;
        // 
        // TrainerEditorForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(624, 441);
        DoubleBuffered = true;
        FormBorderStyle = FormBorderStyle.FixedSingle;
        Name = "TrainerEditorForm";
        Text = "Trainer Designer";
        FormClosing += TrainerEditorForm_FormClosing;
        Paint += TrainerEditorForm_Paint;
        MouseClick += TrainerEditorForm_MouseClick;
        contextMenuStrip1.ResumeLayout(false);
        ResumeLayout(false);
    }

    #endregion

    private System.Windows.Forms.Timer repaintTimer;
    private ContextMenuStrip contextMenuStrip1;
    private ToolStripMenuItem propertiesToolStripMenuItem;
    private ToolStripMenuItem removeToolStripMenuItem;
    private ToolStripSeparator toolStripSeparator1;
    private ToolStripMenuItem addToolStripMenuItem;
    private ToolStripMenuItem labelToolStripMenuItem;
    private ToolStripMenuItem buttonToolStripMenuItem;
    private ToolStripMenuItem textBoxToolStripMenuItem;
    private ToolStripMenuItem checkBoxToolStripMenuItem;
    private ToolStripMenuItem dropdownMenuToolStripMenuItem;
    private ToolStripMenuItem textToolStripMenuItem;
    private ToolStripMenuItem nameToolStripMenuItem;
    private ToolStripMenuItem eventToolStripMenuItem;
}