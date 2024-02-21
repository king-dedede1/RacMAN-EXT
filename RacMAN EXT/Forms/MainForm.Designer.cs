namespace RacMAN.Forms;

partial class MainForm
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
        this.menuStrip1 = new System.Windows.Forms.MenuStrip();
        this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.aboutRaCMANToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.reconnectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.combosHotkeysToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.inputDisplayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.autosplittersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.luaConsoleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.rAMWatchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.modLoaderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.modulesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.addRemoveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
        this.pS3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.savesManagerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.menuStrip1.SuspendLayout();
        this.SuspendLayout();
        // 
        // menuStrip1
        // 
        this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.modulesToolStripMenuItem,
            this.pS3ToolStripMenuItem});
        this.menuStrip1.Location = new System.Drawing.Point(0, 0);
        this.menuStrip1.Name = "menuStrip1";
        this.menuStrip1.Size = new System.Drawing.Size(592, 24);
        this.menuStrip1.TabIndex = 0;
        this.menuStrip1.Text = "menuStrip1";
        // 
        // fileToolStripMenuItem
        // 
        this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutRaCMANToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.reconnectToolStripMenuItem});
        this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
        this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
        this.fileToolStripMenuItem.Text = "File";
        // 
        // aboutRaCMANToolStripMenuItem
        // 
        this.aboutRaCMANToolStripMenuItem.Name = "aboutRaCMANToolStripMenuItem";
        this.aboutRaCMANToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
        this.aboutRaCMANToolStripMenuItem.Text = "About RaCMAN...";
        this.aboutRaCMANToolStripMenuItem.Click += new System.EventHandler(this.aboutRaCMANToolStripMenuItem_Click);
        // 
        // settingsToolStripMenuItem
        // 
        this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
        this.settingsToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
        this.settingsToolStripMenuItem.Text = "Settings...";
        // 
        // reconnectToolStripMenuItem
        // 
        this.reconnectToolStripMenuItem.Name = "reconnectToolStripMenuItem";
        this.reconnectToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
        this.reconnectToolStripMenuItem.Text = "Reconnect";
        this.reconnectToolStripMenuItem.Click += new System.EventHandler(this.reconnectToolStripMenuItem_Click);
        // 
        // toolsToolStripMenuItem
        // 
        this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.combosHotkeysToolStripMenuItem,
            this.inputDisplayToolStripMenuItem,
            this.autosplittersToolStripMenuItem,
            this.luaConsoleToolStripMenuItem,
            this.rAMWatchToolStripMenuItem,
            this.modLoaderToolStripMenuItem});
        this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
        this.toolsToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
        this.toolsToolStripMenuItem.Text = "Tools";
        // 
        // combosHotkeysToolStripMenuItem
        // 
        this.combosHotkeysToolStripMenuItem.Name = "combosHotkeysToolStripMenuItem";
        this.combosHotkeysToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
        this.combosHotkeysToolStripMenuItem.Text = "Combos/Hotkeys...";
        // 
        // inputDisplayToolStripMenuItem
        // 
        this.inputDisplayToolStripMenuItem.Name = "inputDisplayToolStripMenuItem";
        this.inputDisplayToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
        this.inputDisplayToolStripMenuItem.Text = "Input Display...";
        // 
        // autosplittersToolStripMenuItem
        // 
        this.autosplittersToolStripMenuItem.Name = "autosplittersToolStripMenuItem";
        this.autosplittersToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
        this.autosplittersToolStripMenuItem.Text = "Autosplitters...";
        // 
        // luaConsoleToolStripMenuItem
        // 
        this.luaConsoleToolStripMenuItem.Name = "luaConsoleToolStripMenuItem";
        this.luaConsoleToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
        this.luaConsoleToolStripMenuItem.Text = "Lua Console...";
        this.luaConsoleToolStripMenuItem.Click += new System.EventHandler(this.luaConsoleToolStripMenuItem_Click);
        // 
        // rAMWatchToolStripMenuItem
        // 
        this.rAMWatchToolStripMenuItem.Name = "rAMWatchToolStripMenuItem";
        this.rAMWatchToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
        this.rAMWatchToolStripMenuItem.Text = "RAM Watch...";
        // 
        // modLoaderToolStripMenuItem
        // 
        this.modLoaderToolStripMenuItem.Name = "modLoaderToolStripMenuItem";
        this.modLoaderToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
        this.modLoaderToolStripMenuItem.Text = "Mod Loader...";
        // 
        // modulesToolStripMenuItem
        // 
        this.modulesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addRemoveToolStripMenuItem,
            this.toolStripSeparator1});
        this.modulesToolStripMenuItem.Name = "modulesToolStripMenuItem";
        this.modulesToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
        this.modulesToolStripMenuItem.Text = "Game";
        // 
        // addRemoveToolStripMenuItem
        // 
        this.addRemoveToolStripMenuItem.Name = "addRemoveToolStripMenuItem";
        this.addRemoveToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
        this.addRemoveToolStripMenuItem.Text = "Add/Remove modules...";
        // 
        // toolStripSeparator1
        // 
        this.toolStripSeparator1.Name = "toolStripSeparator1";
        this.toolStripSeparator1.Size = new System.Drawing.Size(199, 6);
        // 
        // pS3ToolStripMenuItem
        // 
        this.pS3ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.savesManagerToolStripMenuItem});
        this.pS3ToolStripMenuItem.Name = "pS3ToolStripMenuItem";
        this.pS3ToolStripMenuItem.Size = new System.Drawing.Size(38, 20);
        this.pS3ToolStripMenuItem.Text = "PS3";
        // 
        // savesManagerToolStripMenuItem
        // 
        this.savesManagerToolStripMenuItem.Name = "savesManagerToolStripMenuItem";
        this.savesManagerToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
        this.savesManagerToolStripMenuItem.Text = "Saves Manager...";
        // 
        // MainForm
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(592, 450);
        this.Controls.Add(this.menuStrip1);
        this.DoubleBuffered = true;
        this.MainMenuStrip = this.menuStrip1;
        this.Name = "MainForm";
        this.Text = "RaCMAN {version} - {title ID} - {game title}";
        this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
        this.Shown += new System.EventHandler(this.MainForm_Shown);
        this.menuStrip1.ResumeLayout(false);
        this.menuStrip1.PerformLayout();
        this.ResumeLayout(false);
        this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.MenuStrip menuStrip1;
    private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem aboutRaCMANToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem modulesToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem reconnectToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem combosHotkeysToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem inputDisplayToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem autosplittersToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem luaConsoleToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem addRemoveToolStripMenuItem;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    private System.Windows.Forms.ToolStripMenuItem rAMWatchToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem modLoaderToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem pS3ToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem savesManagerToolStripMenuItem;
}