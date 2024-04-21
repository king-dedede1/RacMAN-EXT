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
        menuStrip1 = new MenuStrip();
        fileToolStripMenuItem = new ToolStripMenuItem();
        aboutRaCMANToolStripMenuItem = new ToolStripMenuItem();
        settingsToolStripMenuItem = new ToolStripMenuItem();
        reconnectToolStripMenuItem = new ToolStripMenuItem();
        toolStripSeparator2 = new ToolStripSeparator();
        reloadLuaStateToolStripMenuItem = new ToolStripMenuItem();
        toolStripSeparator3 = new ToolStripSeparator();
        installGamePackageToolStripMenuItem = new ToolStripMenuItem();
        toolsToolStripMenuItem = new ToolStripMenuItem();
        combosHotkeysToolStripMenuItem = new ToolStripMenuItem();
        inputDisplayToolStripMenuItem = new ToolStripMenuItem();
        autosplittersToolStripMenuItem = new ToolStripMenuItem();
        luaConsoleToolStripMenuItem = new ToolStripMenuItem();
        rAMWatchToolStripMenuItem = new ToolStripMenuItem();
        modLoaderToolStripMenuItem = new ToolStripMenuItem();
        trainerMenuItem = new ToolStripMenuItem();
        reloadToolStripMenuItem = new ToolStripMenuItem();
        openDesignerToolStripMenuItem = new ToolStripMenuItem();
        modulesToolStripMenuItem = new ToolStripMenuItem();
        addRemoveToolStripMenuItem = new ToolStripMenuItem();
        toolStripSeparator1 = new ToolStripSeparator();
        pS3ToolStripMenuItem = new ToolStripMenuItem();
        savesManagerToolStripMenuItem = new ToolStripMenuItem();
        openFileDialog1 = new OpenFileDialog();
        menuStrip1.SuspendLayout();
        SuspendLayout();
        // 
        // menuStrip1
        // 
        menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, toolsToolStripMenuItem, trainerMenuItem, modulesToolStripMenuItem, pS3ToolStripMenuItem });
        menuStrip1.Location = new Point(0, 0);
        menuStrip1.Name = "menuStrip1";
        menuStrip1.Padding = new Padding(7, 2, 0, 2);
        menuStrip1.Size = new Size(624, 24);
        menuStrip1.TabIndex = 0;
        menuStrip1.Text = "menuStrip1";
        // 
        // fileToolStripMenuItem
        // 
        fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { aboutRaCMANToolStripMenuItem, settingsToolStripMenuItem, reconnectToolStripMenuItem, toolStripSeparator2, reloadLuaStateToolStripMenuItem, toolStripSeparator3, installGamePackageToolStripMenuItem });
        fileToolStripMenuItem.Name = "fileToolStripMenuItem";
        fileToolStripMenuItem.Size = new Size(37, 20);
        fileToolStripMenuItem.Text = "File";
        // 
        // aboutRaCMANToolStripMenuItem
        // 
        aboutRaCMANToolStripMenuItem.Name = "aboutRaCMANToolStripMenuItem";
        aboutRaCMANToolStripMenuItem.Size = new Size(195, 22);
        aboutRaCMANToolStripMenuItem.Text = "About RaCMAN...";
        aboutRaCMANToolStripMenuItem.Click += aboutRaCMANToolStripMenuItem_Click;
        // 
        // settingsToolStripMenuItem
        // 
        settingsToolStripMenuItem.Enabled = false;
        settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
        settingsToolStripMenuItem.Size = new Size(195, 22);
        settingsToolStripMenuItem.Text = "Settings...";
        // 
        // reconnectToolStripMenuItem
        // 
        reconnectToolStripMenuItem.Name = "reconnectToolStripMenuItem";
        reconnectToolStripMenuItem.Size = new Size(195, 22);
        reconnectToolStripMenuItem.Text = "Reconnect";
        reconnectToolStripMenuItem.Click += reconnectToolStripMenuItem_Click;
        // 
        // toolStripSeparator2
        // 
        toolStripSeparator2.Name = "toolStripSeparator2";
        toolStripSeparator2.Size = new Size(192, 6);
        // 
        // reloadLuaStateToolStripMenuItem
        // 
        reloadLuaStateToolStripMenuItem.Name = "reloadLuaStateToolStripMenuItem";
        reloadLuaStateToolStripMenuItem.Size = new Size(195, 22);
        reloadLuaStateToolStripMenuItem.Text = "Reload Lua runtime";
        reloadLuaStateToolStripMenuItem.Click += reloadLuaStateToolStripMenuItem_Click;
        // 
        // toolStripSeparator3
        // 
        toolStripSeparator3.Name = "toolStripSeparator3";
        toolStripSeparator3.Size = new Size(192, 6);
        // 
        // installGamePackageToolStripMenuItem
        // 
        installGamePackageToolStripMenuItem.Name = "installGamePackageToolStripMenuItem";
        installGamePackageToolStripMenuItem.Size = new Size(195, 22);
        installGamePackageToolStripMenuItem.Text = "Install Game Package...";
        installGamePackageToolStripMenuItem.Click += installGamePackageToolStripMenuItem_Click;
        // 
        // toolsToolStripMenuItem
        // 
        toolsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { combosHotkeysToolStripMenuItem, inputDisplayToolStripMenuItem, autosplittersToolStripMenuItem, luaConsoleToolStripMenuItem, rAMWatchToolStripMenuItem, modLoaderToolStripMenuItem });
        toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
        toolsToolStripMenuItem.Size = new Size(46, 20);
        toolsToolStripMenuItem.Text = "Tools";
        // 
        // combosHotkeysToolStripMenuItem
        // 
        combosHotkeysToolStripMenuItem.Enabled = false;
        combosHotkeysToolStripMenuItem.Name = "combosHotkeysToolStripMenuItem";
        combosHotkeysToolStripMenuItem.Size = new Size(180, 22);
        combosHotkeysToolStripMenuItem.Text = "Combos/Hotkeys...";
        // 
        // inputDisplayToolStripMenuItem
        // 
        inputDisplayToolStripMenuItem.Enabled = false;
        inputDisplayToolStripMenuItem.Name = "inputDisplayToolStripMenuItem";
        inputDisplayToolStripMenuItem.Size = new Size(180, 22);
        inputDisplayToolStripMenuItem.Text = "Input Display...";
        // 
        // autosplittersToolStripMenuItem
        // 
        autosplittersToolStripMenuItem.Name = "autosplittersToolStripMenuItem";
        autosplittersToolStripMenuItem.Size = new Size(180, 22);
        autosplittersToolStripMenuItem.Text = "Autosplitters...";
        autosplittersToolStripMenuItem.Click += autosplittersToolStripMenuItem_Click;
        // 
        // luaConsoleToolStripMenuItem
        // 
        luaConsoleToolStripMenuItem.Name = "luaConsoleToolStripMenuItem";
        luaConsoleToolStripMenuItem.Size = new Size(180, 22);
        luaConsoleToolStripMenuItem.Text = "Lua Console...";
        luaConsoleToolStripMenuItem.Click += luaConsoleToolStripMenuItem_Click;
        // 
        // rAMWatchToolStripMenuItem
        // 
        rAMWatchToolStripMenuItem.Enabled = false;
        rAMWatchToolStripMenuItem.Name = "rAMWatchToolStripMenuItem";
        rAMWatchToolStripMenuItem.Size = new Size(180, 22);
        rAMWatchToolStripMenuItem.Text = "RAM Watch...";
        // 
        // modLoaderToolStripMenuItem
        // 
        modLoaderToolStripMenuItem.Enabled = false;
        modLoaderToolStripMenuItem.Name = "modLoaderToolStripMenuItem";
        modLoaderToolStripMenuItem.Size = new Size(180, 22);
        modLoaderToolStripMenuItem.Text = "Mod Loader...";
        // 
        // trainerMenuItem
        // 
        trainerMenuItem.DropDownItems.AddRange(new ToolStripItem[] { reloadToolStripMenuItem, openDesignerToolStripMenuItem });
        trainerMenuItem.Name = "trainerMenuItem";
        trainerMenuItem.Size = new Size(54, 20);
        trainerMenuItem.Text = "Trainer";
        // 
        // reloadToolStripMenuItem
        // 
        reloadToolStripMenuItem.Name = "reloadToolStripMenuItem";
        reloadToolStripMenuItem.Size = new Size(180, 22);
        reloadToolStripMenuItem.Text = "Reload";
        reloadToolStripMenuItem.Click += reloadToolStripMenuItem_Click;
        // 
        // openDesignerToolStripMenuItem
        // 
        openDesignerToolStripMenuItem.Name = "openDesignerToolStripMenuItem";
        openDesignerToolStripMenuItem.Size = new Size(180, 22);
        openDesignerToolStripMenuItem.Text = "Open Editor...";
        openDesignerToolStripMenuItem.Click += openDesignerToolStripMenuItem_Click;
        // 
        // modulesToolStripMenuItem
        // 
        modulesToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { addRemoveToolStripMenuItem, toolStripSeparator1 });
        modulesToolStripMenuItem.Name = "modulesToolStripMenuItem";
        modulesToolStripMenuItem.Size = new Size(50, 20);
        modulesToolStripMenuItem.Text = "Game";
        // 
        // addRemoveToolStripMenuItem
        // 
        addRemoveToolStripMenuItem.Enabled = false;
        addRemoveToolStripMenuItem.Name = "addRemoveToolStripMenuItem";
        addRemoveToolStripMenuItem.Size = new Size(202, 22);
        addRemoveToolStripMenuItem.Text = "Add/Remove modules...";
        // 
        // toolStripSeparator1
        // 
        toolStripSeparator1.Name = "toolStripSeparator1";
        toolStripSeparator1.Size = new Size(199, 6);
        // 
        // pS3ToolStripMenuItem
        // 
        pS3ToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { savesManagerToolStripMenuItem });
        pS3ToolStripMenuItem.Name = "pS3ToolStripMenuItem";
        pS3ToolStripMenuItem.Size = new Size(38, 20);
        pS3ToolStripMenuItem.Text = "PS3";
        // 
        // savesManagerToolStripMenuItem
        // 
        savesManagerToolStripMenuItem.Enabled = false;
        savesManagerToolStripMenuItem.Name = "savesManagerToolStripMenuItem";
        savesManagerToolStripMenuItem.Size = new Size(162, 22);
        savesManagerToolStripMenuItem.Text = "Saves Manager...";
        // 
        // openFileDialog1
        // 
        openFileDialog1.Filter = "ZIP files|*.zip|All files|*.*";
        // 
        // MainForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(624, 441);
        Controls.Add(menuStrip1);
        DoubleBuffered = true;
        MainMenuStrip = menuStrip1;
        Margin = new Padding(4, 3, 4, 3);
        Name = "MainForm";
        Text = "RaCMAN {version} - {title ID} - {game title}";
        FormClosing += MainForm_FormClosing;
        Shown += MainForm_Shown;
        menuStrip1.ResumeLayout(false);
        menuStrip1.PerformLayout();
        ResumeLayout(false);
        PerformLayout();
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
    private ToolStripSeparator toolStripSeparator2;
    private ToolStripMenuItem reloadLuaStateToolStripMenuItem;
    private ToolStripMenuItem trainerMenuItem;
    private ToolStripMenuItem reloadToolStripMenuItem;
    private ToolStripMenuItem openDesignerToolStripMenuItem;
    private ToolStripSeparator toolStripSeparator3;
    private ToolStripMenuItem installGamePackageToolStripMenuItem;
    private OpenFileDialog openFileDialog1;
}