namespace RacMAN.Forms.InputDisplay;

partial class InputDisplayForm
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
        contextMenuStrip1 = new ContextMenuStrip(components);
        skinToolStripMenuItem = new ToolStripMenuItem();
        backgroundColorToolStripMenuItem = new ToolStripMenuItem();
        borderlessToolStripMenuItem = new ToolStripMenuItem();
        colorDialog1 = new ColorDialog();
        contextMenuStrip1.SuspendLayout();
        SuspendLayout();
        // 
        // contextMenuStrip1
        // 
        contextMenuStrip1.Items.AddRange(new ToolStripItem[] { skinToolStripMenuItem, backgroundColorToolStripMenuItem, borderlessToolStripMenuItem });
        contextMenuStrip1.Name = "contextMenuStrip1";
        contextMenuStrip1.Size = new Size(181, 92);
        // 
        // skinToolStripMenuItem
        // 
        skinToolStripMenuItem.Name = "skinToolStripMenuItem";
        skinToolStripMenuItem.Size = new Size(179, 22);
        skinToolStripMenuItem.Text = "Skin";
        // 
        // backgroundColorToolStripMenuItem
        // 
        backgroundColorToolStripMenuItem.Name = "backgroundColorToolStripMenuItem";
        backgroundColorToolStripMenuItem.Size = new Size(180, 22);
        backgroundColorToolStripMenuItem.Text = "Background Color...";
        backgroundColorToolStripMenuItem.Click += backgroundColorToolStripMenuItem_Click;
        // 
        // borderlessToolStripMenuItem
        // 
        borderlessToolStripMenuItem.CheckOnClick = true;
        borderlessToolStripMenuItem.Name = "borderlessToolStripMenuItem";
        borderlessToolStripMenuItem.Size = new Size(179, 22);
        borderlessToolStripMenuItem.Text = "Borderless";
        borderlessToolStripMenuItem.CheckedChanged += borderlessToolStripMenuItem_CheckedChanged;
        // 
        // InputDisplayForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.Purple;
        ClientSize = new Size(800, 450);
        DoubleBuffered = true;
        Name = "InputDisplayForm";
        Text = "Input Display";
        Paint += InputDisplayForm_Paint;
        MouseDown += InputDisplayForm_MouseDown;
        MouseMove += InputDisplayForm_MouseMove;
        MouseUp += InputDisplayForm_MouseUp;
        contextMenuStrip1.ResumeLayout(false);
        ResumeLayout(false);
    }

    #endregion

    private ContextMenuStrip contextMenuStrip1;
    private ToolStripMenuItem skinToolStripMenuItem;
    private ToolStripMenuItem backgroundColorToolStripMenuItem;
    private ToolStripMenuItem borderlessToolStripMenuItem;
    private ColorDialog colorDialog1;
}