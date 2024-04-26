namespace RacMAN.Forms;

partial class SettingsForm
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
        groupBox1 = new GroupBox();
        autoconnectCheckbox = new CheckBox();
        label5 = new Label();
        timeoutTextbox = new TextBox();
        label4 = new Label();
        apiComboBox = new ComboBox();
        label3 = new Label();
        label2 = new Label();
        label1 = new Label();
        pcsx2slotTextbox = new TextBox();
        rpcs3slotTextbox = new TextBox();
        ipTextbox = new TextBox();
        globalHotkeysCheckbox = new CheckBox();
        groupBox2 = new GroupBox();
        controllerCombosCheckbox = new CheckBox();
        groupBox3 = new GroupBox();
        controllerSkinComboBox = new ComboBox();
        importSkinButton = new Button();
        label7 = new Label();
        keyColorButton = new Button();
        borderlessCheckbox = new CheckBox();
        label6 = new Label();
        groupBox4 = new GroupBox();
        fontButton = new Button();
        fontLabel = new Label();
        label9 = new Label();
        textColorButton = new Button();
        label8 = new Label();
        backColorButton = new Button();
        sampleTextBox = new TextBox();
        folderBrowserDialog1 = new FolderBrowserDialog();
        colorDialog1 = new ColorDialog();
        fontDialog1 = new FontDialog();
        groupBox1.SuspendLayout();
        groupBox2.SuspendLayout();
        groupBox3.SuspendLayout();
        groupBox4.SuspendLayout();
        SuspendLayout();
        // 
        // groupBox1
        // 
        groupBox1.Controls.Add(autoconnectCheckbox);
        groupBox1.Controls.Add(label5);
        groupBox1.Controls.Add(timeoutTextbox);
        groupBox1.Controls.Add(label4);
        groupBox1.Controls.Add(apiComboBox);
        groupBox1.Controls.Add(label3);
        groupBox1.Controls.Add(label2);
        groupBox1.Controls.Add(label1);
        groupBox1.Controls.Add(pcsx2slotTextbox);
        groupBox1.Controls.Add(rpcs3slotTextbox);
        groupBox1.Controls.Add(ipTextbox);
        groupBox1.Location = new Point(12, 12);
        groupBox1.Name = "groupBox1";
        groupBox1.Size = new Size(450, 119);
        groupBox1.TabIndex = 0;
        groupBox1.TabStop = false;
        groupBox1.Text = "API";
        // 
        // autoconnectCheckbox
        // 
        autoconnectCheckbox.AutoSize = true;
        autoconnectCheckbox.Location = new Point(344, 84);
        autoconnectCheckbox.Name = "autoconnectCheckbox";
        autoconnectCheckbox.Size = new Size(95, 19);
        autoconnectCheckbox.TabIndex = 10;
        autoconnectCheckbox.Text = "Autoconnect";
        autoconnectCheckbox.UseVisualStyleBackColor = true;
        autoconnectCheckbox.CheckedChanged += autoconnectCheckbox_CheckedChanged;
        // 
        // label5
        // 
        label5.AutoSize = true;
        label5.Location = new Point(249, 25);
        label5.Name = "label5";
        label5.Size = new Size(54, 15);
        label5.TabIndex = 9;
        label5.Text = "Timeout:";
        // 
        // timeoutTextbox
        // 
        timeoutTextbox.Location = new Point(309, 22);
        timeoutTextbox.Name = "timeoutTextbox";
        timeoutTextbox.Size = new Size(130, 23);
        timeoutTextbox.TabIndex = 8;
        timeoutTextbox.KeyDown += timeoutTextbox_KeyDown;
        // 
        // label4
        // 
        label4.AutoSize = true;
        label4.Location = new Point(234, 57);
        label4.Name = "label4";
        label4.Size = new Size(69, 15);
        label4.TabIndex = 7;
        label4.Text = "Default API:";
        // 
        // apiComboBox
        // 
        apiComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        apiComboBox.FormattingEnabled = true;
        apiComboBox.Items.AddRange(new object[] { "PS3 (Ratchetron)", "RPCS3 (PINE)", "PCSX2 (PINE)" });
        apiComboBox.Location = new Point(309, 54);
        apiComboBox.Name = "apiComboBox";
        apiComboBox.Size = new Size(130, 23);
        apiComboBox.TabIndex = 6;
        apiComboBox.SelectedIndexChanged += apiComboBox_SelectedIndexChanged;
        // 
        // label3
        // 
        label3.AutoSize = true;
        label3.Location = new Point(1, 83);
        label3.Name = "label3";
        label3.Size = new Size(94, 15);
        label3.TabIndex = 5;
        label3.Text = "PCSX2 PINE slot:";
        // 
        // label2
        // 
        label2.AutoSize = true;
        label2.Location = new Point(1, 54);
        label2.Name = "label2";
        label2.Size = new Size(94, 15);
        label2.TabIndex = 4;
        label2.Text = "RPCS3 PINE slot:";
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Location = new Point(14, 25);
        label1.Name = "label1";
        label1.Size = new Size(81, 15);
        label1.TabIndex = 3;
        label1.Text = "Ratchetron IP:";
        // 
        // pcsx2slotTextbox
        // 
        pcsx2slotTextbox.Location = new Point(101, 80);
        pcsx2slotTextbox.Name = "pcsx2slotTextbox";
        pcsx2slotTextbox.Size = new Size(125, 23);
        pcsx2slotTextbox.TabIndex = 2;
        pcsx2slotTextbox.KeyDown += pcsx2slotTextbox_KeyDown;
        // 
        // rpcs3slotTextbox
        // 
        rpcs3slotTextbox.Location = new Point(101, 51);
        rpcs3slotTextbox.Name = "rpcs3slotTextbox";
        rpcs3slotTextbox.Size = new Size(125, 23);
        rpcs3slotTextbox.TabIndex = 1;
        rpcs3slotTextbox.KeyDown += rpcs3slotTextbox_KeyDown;
        // 
        // ipTextbox
        // 
        ipTextbox.Location = new Point(101, 22);
        ipTextbox.Name = "ipTextbox";
        ipTextbox.Size = new Size(125, 23);
        ipTextbox.TabIndex = 0;
        ipTextbox.KeyDown += ipTextbox_KeyDown;
        // 
        // globalHotkeysCheckbox
        // 
        globalHotkeysCheckbox.AutoSize = true;
        globalHotkeysCheckbox.Location = new Point(14, 32);
        globalHotkeysCheckbox.Name = "globalHotkeysCheckbox";
        globalHotkeysCheckbox.Size = new Size(106, 19);
        globalHotkeysCheckbox.TabIndex = 0;
        globalHotkeysCheckbox.Text = "Global Hotkeys";
        globalHotkeysCheckbox.UseVisualStyleBackColor = true;
        globalHotkeysCheckbox.CheckedChanged += globalHotkeysCheckbox_CheckedChanged;
        // 
        // groupBox2
        // 
        groupBox2.Controls.Add(controllerCombosCheckbox);
        groupBox2.Controls.Add(globalHotkeysCheckbox);
        groupBox2.Location = new Point(12, 137);
        groupBox2.Name = "groupBox2";
        groupBox2.Size = new Size(226, 105);
        groupBox2.TabIndex = 1;
        groupBox2.TabStop = false;
        groupBox2.Text = "Hotkeys/Combos";
        // 
        // controllerCombosCheckbox
        // 
        controllerCombosCheckbox.AutoSize = true;
        controllerCombosCheckbox.Location = new Point(14, 61);
        controllerCombosCheckbox.Name = "controllerCombosCheckbox";
        controllerCombosCheckbox.Size = new Size(203, 19);
        controllerCombosCheckbox.TabIndex = 1;
        controllerCombosCheckbox.Text = "Trigger combos on button release";
        controllerCombosCheckbox.UseVisualStyleBackColor = true;
        controllerCombosCheckbox.CheckedChanged += controllerCombosCheckbox_CheckedChanged;
        // 
        // groupBox3
        // 
        groupBox3.Controls.Add(controllerSkinComboBox);
        groupBox3.Controls.Add(importSkinButton);
        groupBox3.Controls.Add(label7);
        groupBox3.Controls.Add(keyColorButton);
        groupBox3.Controls.Add(borderlessCheckbox);
        groupBox3.Controls.Add(label6);
        groupBox3.Location = new Point(247, 137);
        groupBox3.Name = "groupBox3";
        groupBox3.Size = new Size(215, 105);
        groupBox3.TabIndex = 2;
        groupBox3.TabStop = false;
        groupBox3.Text = "Input Display";
        // 
        // controllerSkinComboBox
        // 
        controllerSkinComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        controllerSkinComboBox.FormattingEnabled = true;
        controllerSkinComboBox.Location = new Point(45, 23);
        controllerSkinComboBox.Name = "controllerSkinComboBox";
        controllerSkinComboBox.Size = new Size(130, 23);
        controllerSkinComboBox.TabIndex = 17;
        controllerSkinComboBox.SelectedValueChanged += controllerSkinComboBox_SelectedValueChanged;
        // 
        // importSkinButton
        // 
        importSkinButton.FlatStyle = FlatStyle.Flat;
        importSkinButton.Image = Properties.Resources.add;
        importSkinButton.Location = new Point(181, 23);
        importSkinButton.Name = "importSkinButton";
        importSkinButton.Size = new Size(23, 23);
        importSkinButton.TabIndex = 16;
        importSkinButton.UseVisualStyleBackColor = true;
        importSkinButton.Click += importSkinButton_Click;
        // 
        // label7
        // 
        label7.AutoSize = true;
        label7.Location = new Point(109, 65);
        label7.Name = "label7";
        label7.Size = new Size(61, 15);
        label7.TabIndex = 15;
        label7.Text = "Key Color:";
        // 
        // keyColorButton
        // 
        keyColorButton.BackColor = Color.FromArgb(  192,   0,   192);
        keyColorButton.FlatStyle = FlatStyle.Flat;
        keyColorButton.Location = new Point(173, 57);
        keyColorButton.Name = "keyColorButton";
        keyColorButton.Size = new Size(31, 31);
        keyColorButton.TabIndex = 14;
        keyColorButton.UseVisualStyleBackColor = false;
        keyColorButton.Click += keyColorButton_Click;
        // 
        // borderlessCheckbox
        // 
        borderlessCheckbox.AutoSize = true;
        borderlessCheckbox.Location = new Point(7, 64);
        borderlessCheckbox.Name = "borderlessCheckbox";
        borderlessCheckbox.Size = new Size(80, 19);
        borderlessCheckbox.TabIndex = 13;
        borderlessCheckbox.Text = "Borderless";
        borderlessCheckbox.UseVisualStyleBackColor = true;
        borderlessCheckbox.CheckedChanged += borderlessCheckbox_CheckedChanged;
        // 
        // label6
        // 
        label6.AutoSize = true;
        label6.Location = new Point(7, 27);
        label6.Name = "label6";
        label6.Size = new Size(32, 15);
        label6.TabIndex = 12;
        label6.Text = "Skin:";
        // 
        // groupBox4
        // 
        groupBox4.Controls.Add(fontButton);
        groupBox4.Controls.Add(fontLabel);
        groupBox4.Controls.Add(label9);
        groupBox4.Controls.Add(textColorButton);
        groupBox4.Controls.Add(label8);
        groupBox4.Controls.Add(backColorButton);
        groupBox4.Controls.Add(sampleTextBox);
        groupBox4.Location = new Point(12, 248);
        groupBox4.Name = "groupBox4";
        groupBox4.Size = new Size(450, 247);
        groupBox4.TabIndex = 3;
        groupBox4.TabStop = false;
        groupBox4.Text = "Console";
        // 
        // fontButton
        // 
        fontButton.Location = new Point(326, 26);
        fontButton.Name = "fontButton";
        fontButton.Size = new Size(113, 22);
        fontButton.TabIndex = 20;
        fontButton.Text = "Choose font...";
        fontButton.UseVisualStyleBackColor = true;
        fontButton.Click += fontButton_Click;
        // 
        // fontLabel
        // 
        fontLabel.AutoSize = true;
        fontLabel.Location = new Point(122, 30);
        fontLabel.Name = "fontLabel";
        fontLabel.Size = new Size(198, 15);
        fontLabel.TabIndex = 19;
        fontLabel.Text = "Font: Cascadia Mono Semibold 10pt";
        // 
        // label9
        // 
        label9.AutoSize = true;
        label9.Location = new Point(6, 67);
        label9.Name = "label9";
        label9.Size = new Size(61, 15);
        label9.TabIndex = 17;
        label9.Text = "Text color:";
        // 
        // textColorButton
        // 
        textColorButton.BackColor = Color.FromArgb(  192,   0,   192);
        textColorButton.FlatStyle = FlatStyle.Flat;
        textColorButton.Location = new Point(73, 59);
        textColorButton.Name = "textColorButton";
        textColorButton.Size = new Size(31, 31);
        textColorButton.TabIndex = 18;
        textColorButton.UseVisualStyleBackColor = false;
        textColorButton.Click += textColorButton_Click;
        // 
        // label8
        // 
        label8.AutoSize = true;
        label8.Location = new Point(6, 30);
        label8.Name = "label8";
        label8.Size = new Size(65, 15);
        label8.TabIndex = 16;
        label8.Text = "Back color:";
        // 
        // backColorButton
        // 
        backColorButton.BackColor = Color.FromArgb(  192,   0,   192);
        backColorButton.FlatStyle = FlatStyle.Flat;
        backColorButton.Location = new Point(73, 22);
        backColorButton.Name = "backColorButton";
        backColorButton.Size = new Size(31, 31);
        backColorButton.TabIndex = 16;
        backColorButton.UseVisualStyleBackColor = false;
        backColorButton.Click += backColorButton_Click;
        // 
        // sampleTextBox
        // 
        sampleTextBox.BackColor = Color.Black;
        sampleTextBox.Font = new Font("Cascadia Code SemiBold", 9.75F, FontStyle.Bold, GraphicsUnit.Point,  0);
        sampleTextBox.ForeColor = Color.White;
        sampleTextBox.Location = new Point(6, 96);
        sampleTextBox.Multiline = true;
        sampleTextBox.Name = "sampleTextBox";
        sampleTextBox.Size = new Size(438, 145);
        sampleTextBox.TabIndex = 0;
        sampleTextBox.Text = "The quick brown fox jumps over the lazy dog.";
        // 
        // SettingsForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(473, 507);
        Controls.Add(groupBox4);
        Controls.Add(groupBox3);
        Controls.Add(groupBox2);
        Controls.Add(groupBox1);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        Name = "SettingsForm";
        Text = "Settings";
        groupBox1.ResumeLayout(false);
        groupBox1.PerformLayout();
        groupBox2.ResumeLayout(false);
        groupBox2.PerformLayout();
        groupBox3.ResumeLayout(false);
        groupBox3.PerformLayout();
        groupBox4.ResumeLayout(false);
        groupBox4.PerformLayout();
        ResumeLayout(false);
    }

    #endregion

    private GroupBox groupBox1;
    private Label label2;
    private Label label1;
    private TextBox pcsx2slotTextbox;
    private TextBox rpcs3slotTextbox;
    private TextBox ipTextbox;
    private CheckBox globalHotkeysCheckbox;
    private Label label4;
    private ComboBox apiComboBox;
    private Label label3;
    private Label label5;
    private TextBox timeoutTextbox;
    private CheckBox autoconnectCheckbox;
    private GroupBox groupBox2;
    private CheckBox controllerCombosCheckbox;
    private GroupBox groupBox3;
    private Label label7;
    private Button keyColorButton;
    private CheckBox borderlessCheckbox;
    private Label label6;
    private GroupBox groupBox4;
    private TextBox sampleTextBox;
    private Label label8;
    private Button backColorButton;
    private Label label9;
    private Button textColorButton;
    private Button importSkinButton;
    private Button fontButton;
    private Label fontLabel;
    private ComboBox controllerSkinComboBox;
    private FolderBrowserDialog folderBrowserDialog1;
    private ColorDialog colorDialog1;
    private FontDialog fontDialog1;
}