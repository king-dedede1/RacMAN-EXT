namespace RacMAN.Forms;

partial class ControllerCombosForm
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
        TreeNode treeNode1 = new TreeNode("Load position", 1, 1);
        TreeNode treeNode2 = new TreeNode("Save position", 1, 1);
        TreeNode treeNode3 = new TreeNode("Die", 1, 1);
        TreeNode treeNode4 = new TreeNode("Move saved position up", 3, 3);
        TreeNode treeNode5 = new TreeNode("Move saved position down", 3, 3);
        TreeNode treeNode6 = new TreeNode("Position Codes", new TreeNode[] { treeNode1, treeNode2, treeNode3, treeNode4, treeNode5 });
        TreeNode treeNode7 = new TreeNode("Reload planet", 1, 1);
        TreeNode treeNode8 = new TreeNode("Toggle ghost ratchet", 3, 3);
        TreeNode treeNode9 = new TreeNode("Practice Codes", new TreeNode[] { treeNode6, treeNode7, treeNode8 });
        TreeNode treeNode10 = new TreeNode("Set aside file", 2, 2);
        TreeNode treeNode11 = new TreeNode("Load file", 2, 2);
        TreeNode treeNode12 = new TreeNode("Savefile Helper", new TreeNode[] { treeNode10, treeNode11 });
        TreeNode treeNode13 = new TreeNode("Ratchet & Clank 3 (NPEA00387)", 4, 4, new TreeNode[] { treeNode9, treeNode12 });
        TreeNode treeNode14 = new TreeNode("Load position", 1, 1);
        TreeNode treeNode15 = new TreeNode("Save position", 1, 1);
        TreeNode treeNode16 = new TreeNode("Die", 1, 1);
        TreeNode treeNode17 = new TreeNode("Toggle ghost ratchet", 3, 3);
        TreeNode treeNode18 = new TreeNode("Ratchet & Clank: Going Commando (SCUS97268)", 4, 4, new TreeNode[] { treeNode14, treeNode15, treeNode16, treeNode17 });
        TreeNode treeNode19 = new TreeNode("???", 1, 1);
        TreeNode treeNode20 = new TreeNode("LEGO Pirates of the Caribbean: The Video Game (BLUS30744)", 4, 4, new TreeNode[] { treeNode19 });
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControllerCombosForm));
        treeView = new TreeView();
        imageList1 = new ImageList(components);
        groupBox1 = new GroupBox();
        hotkeyCheckbox = new CheckBox();
        controllerComboCheckbox = new CheckBox();
        label4 = new Label();
        descriptionTextBox = new TextBox();
        nameTextBox = new TextBox();
        label3 = new Label();
        controllerComboGroup = new GroupBox();
        changeComboButton = new Button();
        controllerComboLabel = new Label();
        hotkeyGroup = new GroupBox();
        globalCheckbox = new CheckBox();
        hotkeyLabel = new Label();
        changeHotkeyButton = new Button();
        groupBox4 = new GroupBox();
        submitActionButton = new Button();
        actionTextBox = new TextBox();
        addButton = new Button();
        removeButton = new Button();
        moveUpButton = new Button();
        moveDownButton = new Button();
        button7 = new Button();
        addFolderButton = new Button();
        groupBox1.SuspendLayout();
        controllerComboGroup.SuspendLayout();
        hotkeyGroup.SuspendLayout();
        groupBox4.SuspendLayout();
        SuspendLayout();
        // 
        // treeView
        // 
        treeView.CheckBoxes = true;
        treeView.HideSelection = false;
        treeView.ImageIndex = 0;
        treeView.ImageList = imageList1;
        treeView.Location = new Point(10, 14);
        treeView.Name = "treeView";
        treeNode1.ImageIndex = 1;
        treeNode1.Name = "Node6";
        treeNode1.SelectedImageIndex = 1;
        treeNode1.Text = "Load position";
        treeNode2.ImageIndex = 1;
        treeNode2.Name = "Node7";
        treeNode2.SelectedImageIndex = 1;
        treeNode2.Text = "Save position";
        treeNode3.ImageIndex = 1;
        treeNode3.Name = "Node8";
        treeNode3.SelectedImageIndex = 1;
        treeNode3.Text = "Die";
        treeNode4.ImageIndex = 3;
        treeNode4.Name = "Node9";
        treeNode4.SelectedImageIndex = 3;
        treeNode4.Text = "Move saved position up";
        treeNode5.ImageIndex = 3;
        treeNode5.Name = "Node10";
        treeNode5.SelectedImageIndex = 3;
        treeNode5.Text = "Move saved position down";
        treeNode6.Name = "Node5";
        treeNode6.Text = "Position Codes";
        treeNode7.ImageIndex = 1;
        treeNode7.Name = "Node11";
        treeNode7.SelectedImageIndex = 1;
        treeNode7.Text = "Reload planet";
        treeNode8.ImageIndex = 3;
        treeNode8.Name = "Node12";
        treeNode8.SelectedImageIndex = 3;
        treeNode8.Text = "Toggle ghost ratchet";
        treeNode9.Name = "Node1";
        treeNode9.Text = "Practice Codes";
        treeNode10.ImageIndex = 2;
        treeNode10.Name = "Node3";
        treeNode10.SelectedImageIndex = 2;
        treeNode10.Text = "Set aside file";
        treeNode11.ImageIndex = 2;
        treeNode11.Name = "Node4";
        treeNode11.SelectedImageIndex = 2;
        treeNode11.Text = "Load file";
        treeNode12.Name = "Node2";
        treeNode12.Text = "Savefile Helper";
        treeNode13.ImageIndex = 4;
        treeNode13.Name = "Node0";
        treeNode13.SelectedImageIndex = 4;
        treeNode13.Text = "Ratchet & Clank 3 (NPEA00387)";
        treeNode14.ImageIndex = 1;
        treeNode14.Name = "Node14";
        treeNode14.SelectedImageIndex = 1;
        treeNode14.Text = "Load position";
        treeNode15.ImageIndex = 1;
        treeNode15.Name = "Node15";
        treeNode15.SelectedImageIndex = 1;
        treeNode15.Text = "Save position";
        treeNode16.ImageIndex = 1;
        treeNode16.Name = "Node16";
        treeNode16.SelectedImageIndex = 1;
        treeNode16.Text = "Die";
        treeNode17.ImageIndex = 3;
        treeNode17.Name = "Node17";
        treeNode17.SelectedImageIndex = 3;
        treeNode17.Text = "Toggle ghost ratchet";
        treeNode18.ImageIndex = 4;
        treeNode18.Name = "Node13";
        treeNode18.SelectedImageIndex = 4;
        treeNode18.Text = "Ratchet & Clank: Going Commando (SCUS97268)";
        treeNode19.ImageIndex = 1;
        treeNode19.Name = "Node19";
        treeNode19.SelectedImageIndex = 1;
        treeNode19.Text = "???";
        treeNode20.ImageIndex = 4;
        treeNode20.Name = "Node18";
        treeNode20.SelectedImageIndex = 4;
        treeNode20.Text = "LEGO Pirates of the Caribbean: The Video Game (BLUS30744)";
        treeView.Nodes.AddRange(new TreeNode[] { treeNode13, treeNode18, treeNode20 });
        treeView.SelectedImageIndex = 0;
        treeView.ShowNodeToolTips = true;
        treeView.Size = new Size(295, 423);
        treeView.TabIndex = 0;
        treeView.AfterCheck += treeView_AfterCheck;
        treeView.BeforeSelect += treeView_BeforeSelect;
        treeView.AfterSelect += treeView_AfterSelect;
        // 
        // imageList1
        // 
        imageList1.ColorDepth = ColorDepth.Depth32Bit;
        imageList1.ImageStream = (ImageListStreamer) resources.GetObject("imageList1.ImageStream");
        imageList1.TransparentColor = Color.Transparent;
        imageList1.Images.SetKeyName(0, "CopyFolderHS.png");
        imageList1.Images.SetKeyName(1, "GameController.png");
        imageList1.Images.SetKeyName(2, "HotKeys.png");
        imageList1.Images.SetKeyName(3, "Both.png");
        imageList1.Images.SetKeyName(4, "CD.png");
        imageList1.Images.SetKeyName(5, "");
        // 
        // groupBox1
        // 
        groupBox1.Controls.Add(hotkeyCheckbox);
        groupBox1.Controls.Add(controllerComboCheckbox);
        groupBox1.Controls.Add(label4);
        groupBox1.Controls.Add(descriptionTextBox);
        groupBox1.Controls.Add(nameTextBox);
        groupBox1.Controls.Add(label3);
        groupBox1.Location = new Point(315, 9);
        groupBox1.Name = "groupBox1";
        groupBox1.Size = new Size(423, 105);
        groupBox1.TabIndex = 1;
        groupBox1.TabStop = false;
        groupBox1.Text = "Information";
        // 
        // hotkeyCheckbox
        // 
        hotkeyCheckbox.AutoSize = true;
        hotkeyCheckbox.Location = new Point(274, 44);
        hotkeyCheckbox.Name = "hotkeyCheckbox";
        hotkeyCheckbox.Size = new Size(64, 19);
        hotkeyCheckbox.TabIndex = 5;
        hotkeyCheckbox.Text = "Hotkey";
        hotkeyCheckbox.UseVisualStyleBackColor = true;
        hotkeyCheckbox.CheckedChanged += hotkeyCheckbox_CheckedChanged;
        // 
        // controllerComboCheckbox
        // 
        controllerComboCheckbox.AutoSize = true;
        controllerComboCheckbox.Location = new Point(274, 19);
        controllerComboCheckbox.Name = "controllerComboCheckbox";
        controllerComboCheckbox.Size = new Size(122, 19);
        controllerComboCheckbox.TabIndex = 4;
        controllerComboCheckbox.Text = "Controller Combo";
        controllerComboCheckbox.UseVisualStyleBackColor = true;
        controllerComboCheckbox.CheckedChanged += controllerComboCheckbox_CheckedChanged;
        // 
        // label4
        // 
        label4.AutoSize = true;
        label4.Location = new Point(3, 49);
        label4.Name = "label4";
        label4.Size = new Size(70, 15);
        label4.TabIndex = 3;
        label4.Text = "Description:";
        // 
        // descriptionTextBox
        // 
        descriptionTextBox.Location = new Point(79, 46);
        descriptionTextBox.Multiline = true;
        descriptionTextBox.Name = "descriptionTextBox";
        descriptionTextBox.Size = new Size(166, 52);
        descriptionTextBox.TabIndex = 2;
        descriptionTextBox.Leave += descriptionTextBox_Leave;
        // 
        // nameTextBox
        // 
        nameTextBox.Location = new Point(79, 17);
        nameTextBox.Name = "nameTextBox";
        nameTextBox.Size = new Size(166, 23);
        nameTextBox.TabIndex = 1;
        nameTextBox.Leave += nameTextBox_Leave;
        // 
        // label3
        // 
        label3.AutoSize = true;
        label3.Location = new Point(31, 20);
        label3.Name = "label3";
        label3.Size = new Size(42, 15);
        label3.TabIndex = 0;
        label3.Text = "Name:";
        // 
        // controllerComboGroup
        // 
        controllerComboGroup.Controls.Add(changeComboButton);
        controllerComboGroup.Controls.Add(controllerComboLabel);
        controllerComboGroup.Location = new Point(316, 121);
        controllerComboGroup.Name = "controllerComboGroup";
        controllerComboGroup.Size = new Size(200, 91);
        controllerComboGroup.TabIndex = 2;
        controllerComboGroup.TabStop = false;
        controllerComboGroup.Text = "Controller";
        // 
        // changeComboButton
        // 
        changeComboButton.Location = new Point(8, 47);
        changeComboButton.Name = "changeComboButton";
        changeComboButton.Size = new Size(111, 27);
        changeComboButton.TabIndex = 1;
        changeComboButton.Text = "Change Combo...";
        changeComboButton.UseVisualStyleBackColor = true;
        changeComboButton.Click += changeComboButton_Click;
        // 
        // controllerComboLabel
        // 
        controllerComboLabel.AutoSize = true;
        controllerComboLabel.Location = new Point(8, 21);
        controllerComboLabel.Name = "controllerComboLabel";
        controllerComboLabel.Size = new Size(76, 15);
        controllerComboLabel.TabIndex = 0;
        controllerComboLabel.Text = "L2+L1+Cross";
        // 
        // hotkeyGroup
        // 
        hotkeyGroup.Controls.Add(globalCheckbox);
        hotkeyGroup.Controls.Add(hotkeyLabel);
        hotkeyGroup.Controls.Add(changeHotkeyButton);
        hotkeyGroup.Enabled = false;
        hotkeyGroup.Location = new Point(522, 121);
        hotkeyGroup.Name = "hotkeyGroup";
        hotkeyGroup.Size = new Size(216, 91);
        hotkeyGroup.TabIndex = 3;
        hotkeyGroup.TabStop = false;
        hotkeyGroup.Text = "Hotkey";
        // 
        // globalCheckbox
        // 
        globalCheckbox.AutoSize = true;
        globalCheckbox.Location = new Point(149, 52);
        globalCheckbox.Name = "globalCheckbox";
        globalCheckbox.Size = new Size(60, 19);
        globalCheckbox.TabIndex = 4;
        globalCheckbox.Text = "Global";
        globalCheckbox.UseVisualStyleBackColor = true;
        globalCheckbox.CheckedChanged += globalCheckbox_CheckedChanged;
        // 
        // hotkeyLabel
        // 
        hotkeyLabel.AutoSize = true;
        hotkeyLabel.Location = new Point(11, 23);
        hotkeyLabel.Name = "hotkeyLabel";
        hotkeyLabel.Size = new Size(84, 15);
        hotkeyLabel.TabIndex = 3;
        hotkeyLabel.Text = "(Not assigned)";
        // 
        // changeHotkeyButton
        // 
        changeHotkeyButton.Location = new Point(15, 47);
        changeHotkeyButton.Name = "changeHotkeyButton";
        changeHotkeyButton.Size = new Size(116, 27);
        changeHotkeyButton.TabIndex = 2;
        changeHotkeyButton.Text = "Change Hotkey...";
        changeHotkeyButton.UseVisualStyleBackColor = true;
        changeHotkeyButton.Click += changeHotkeyButton_Click;
        changeHotkeyButton.KeyUp += changeHotkeyButton_KeyUp;
        // 
        // groupBox4
        // 
        groupBox4.Controls.Add(submitActionButton);
        groupBox4.Controls.Add(actionTextBox);
        groupBox4.Location = new Point(317, 218);
        groupBox4.Name = "groupBox4";
        groupBox4.Size = new Size(421, 255);
        groupBox4.TabIndex = 4;
        groupBox4.TabStop = false;
        groupBox4.Text = "Action";
        // 
        // submitActionButton
        // 
        submitActionButton.Location = new Point(304, 222);
        submitActionButton.Name = "submitActionButton";
        submitActionButton.Size = new Size(110, 28);
        submitActionButton.TabIndex = 1;
        submitActionButton.Text = "Apply Action";
        submitActionButton.UseVisualStyleBackColor = true;
        submitActionButton.Click += submitActionButton_Click;
        // 
        // actionTextBox
        // 
        actionTextBox.BackColor = Color.Black;
        actionTextBox.BorderStyle = BorderStyle.FixedSingle;
        actionTextBox.Font = new Font("Cascadia Code SemiBold", 9.75F, FontStyle.Bold, GraphicsUnit.Point,  0);
        actionTextBox.ForeColor = Color.White;
        actionTextBox.Location = new Point(8, 20);
        actionTextBox.Multiline = true;
        actionTextBox.Name = "actionTextBox";
        actionTextBox.Size = new Size(406, 199);
        actionTextBox.TabIndex = 0;
        actionTextBox.Text = "rac3.LoadPosition()";
        // 
        // addButton
        // 
        addButton.BackgroundImageLayout = ImageLayout.Center;
        addButton.Image = Properties.Resources.add;
        addButton.Location = new Point(10, 441);
        addButton.Name = "addButton";
        addButton.Size = new Size(32, 32);
        addButton.TabIndex = 5;
        addButton.UseVisualStyleBackColor = true;
        addButton.Click += addButton_Click;
        // 
        // removeButton
        // 
        removeButton.Enabled = false;
        removeButton.Image = Properties.Resources.Remove;
        removeButton.Location = new Point(86, 441);
        removeButton.Name = "removeButton";
        removeButton.Size = new Size(32, 32);
        removeButton.TabIndex = 6;
        removeButton.UseVisualStyleBackColor = true;
        // 
        // moveUpButton
        // 
        moveUpButton.Enabled = false;
        moveUpButton.Image = Properties.Resources.Up;
        moveUpButton.Location = new Point(124, 441);
        moveUpButton.Name = "moveUpButton";
        moveUpButton.Size = new Size(32, 32);
        moveUpButton.TabIndex = 7;
        moveUpButton.UseVisualStyleBackColor = true;
        // 
        // moveDownButton
        // 
        moveDownButton.Enabled = false;
        moveDownButton.Image = Properties.Resources.Down;
        moveDownButton.Location = new Point(162, 441);
        moveDownButton.Name = "moveDownButton";
        moveDownButton.Size = new Size(32, 32);
        moveDownButton.TabIndex = 8;
        moveDownButton.UseVisualStyleBackColor = true;
        // 
        // button7
        // 
        button7.Enabled = false;
        button7.Location = new Point(200, 441);
        button7.Name = "button7";
        button7.Size = new Size(105, 32);
        button7.TabIndex = 9;
        button7.Text = "Duplicate";
        button7.UseVisualStyleBackColor = true;
        // 
        // addFolderButton
        // 
        addFolderButton.BackgroundImageLayout = ImageLayout.Center;
        addFolderButton.Image = Properties.Resources.Folder;
        addFolderButton.Location = new Point(48, 441);
        addFolderButton.Name = "addFolderButton";
        addFolderButton.Size = new Size(32, 32);
        addFolderButton.TabIndex = 10;
        addFolderButton.UseVisualStyleBackColor = true;
        addFolderButton.Click += addFolderButton_Click;
        // 
        // ControllerCombosForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(751, 484);
        Controls.Add(addFolderButton);
        Controls.Add(button7);
        Controls.Add(moveDownButton);
        Controls.Add(moveUpButton);
        Controls.Add(removeButton);
        Controls.Add(addButton);
        Controls.Add(groupBox4);
        Controls.Add(hotkeyGroup);
        Controls.Add(controllerComboGroup);
        Controls.Add(groupBox1);
        Controls.Add(treeView);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        Name = "ControllerCombosForm";
        Text = "Hotkeys & Controller Combos";
        FormClosing += ControllerCombosForm_FormClosing;
        groupBox1.ResumeLayout(false);
        groupBox1.PerformLayout();
        controllerComboGroup.ResumeLayout(false);
        controllerComboGroup.PerformLayout();
        hotkeyGroup.ResumeLayout(false);
        hotkeyGroup.PerformLayout();
        groupBox4.ResumeLayout(false);
        groupBox4.PerformLayout();
        ResumeLayout(false);
    }

    #endregion

    private TreeView treeView;
    private ImageList imageList1;
    private GroupBox groupBox1;
    private GroupBox controllerComboGroup;
    private GroupBox hotkeyGroup;
    private Button changeHotkeyButton;
    private Button changeComboButton;
    private Label controllerComboLabel;
    private Label hotkeyLabel;
    private GroupBox groupBox4;
    private TextBox actionTextBox;
    private TextBox descriptionTextBox;
    private TextBox nameTextBox;
    private Label label3;
    private CheckBox hotkeyCheckbox;
    private CheckBox controllerComboCheckbox;
    private Label label4;
    private Button addButton;
    private Button removeButton;
    private Button moveUpButton;
    private Button moveDownButton;
    private Button addFolderButton;
    private Button button7;
    private CheckBox globalCheckbox;
    private Button submitActionButton;
}