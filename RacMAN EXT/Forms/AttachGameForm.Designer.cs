namespace RacMAN.Forms;

partial class AttachGameForm
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
        comboBox1 = new ComboBox();
        label2 = new Label();
        textBox1 = new TextBox();
        label3 = new Label();
        attachButton = new Button();
        continueButton = new Button();
        versionLabel = new Label();
        SuspendLayout();
        // 
        // comboBox1
        // 
        comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
        comboBox1.FormattingEnabled = true;
        comboBox1.Items.AddRange(new object[] { "PS3 (Ratchetron)", "RPCS3 (PINE)", "PCSX2 (PINE)" });
        comboBox1.Location = new Point(73, 12);
        comboBox1.Margin = new Padding(4, 3, 4, 3);
        comboBox1.Name = "comboBox1";
        comboBox1.Size = new Size(158, 23);
        comboBox1.TabIndex = 0;
        comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
        // 
        // label2
        // 
        label2.AutoSize = true;
        label2.Location = new Point(40, 15);
        label2.Margin = new Padding(4, 0, 4, 0);
        label2.Name = "label2";
        label2.Size = new Size(25, 15);
        label2.TabIndex = 2;
        label2.Text = "API";
        // 
        // textBox1
        // 
        textBox1.Location = new Point(73, 41);
        textBox1.Margin = new Padding(4, 3, 4, 3);
        textBox1.Name = "textBox1";
        textBox1.Size = new Size(157, 23);
        textBox1.TabIndex = 3;
        textBox1.KeyDown += textBox1_KeyDown;
        // 
        // label3
        // 
        label3.AutoSize = true;
        label3.Location = new Point(3, 44);
        label3.Margin = new Padding(4, 0, 4, 0);
        label3.Name = "label3";
        label3.Size = new Size(62, 15);
        label3.TabIndex = 4;
        label3.Text = "IP Address";
        // 
        // attachButton
        // 
        attachButton.Location = new Point(13, 79);
        attachButton.Margin = new Padding(4, 3, 4, 3);
        attachButton.Name = "attachButton";
        attachButton.Size = new Size(217, 32);
        attachButton.TabIndex = 5;
        attachButton.Text = "Connect";
        attachButton.UseVisualStyleBackColor = true;
        attachButton.Click += attachButton_Click;
        // 
        // continueButton
        // 
        continueButton.Location = new Point(13, 117);
        continueButton.Margin = new Padding(4, 3, 4, 3);
        continueButton.Name = "continueButton";
        continueButton.Size = new Size(217, 25);
        continueButton.TabIndex = 6;
        continueButton.Text = "Continue Without Game";
        continueButton.UseVisualStyleBackColor = true;
        continueButton.Click += continueButton_Click;
        // 
        // versionLabel
        // 
        versionLabel.AutoSize = true;
        versionLabel.Location = new Point(12, 157);
        versionLabel.Margin = new Padding(4, 0, 4, 0);
        versionLabel.Name = "versionLabel";
        versionLabel.Size = new Size(53, 15);
        versionLabel.TabIndex = 7;
        versionLabel.Text = "{version}";
        // 
        // AttachGameForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(242, 181);
        Controls.Add(versionLabel);
        Controls.Add(continueButton);
        Controls.Add(attachButton);
        Controls.Add(label3);
        Controls.Add(textBox1);
        Controls.Add(label2);
        Controls.Add(comboBox1);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        Margin = new Padding(4, 3, 4, 3);
        MaximizeBox = false;
        Name = "AttachGameForm";
        Text = "RaCMAN-EXT";
        Shown += AttachGameForm_Shown;
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private System.Windows.Forms.ComboBox comboBox1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox textBox1;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Button attachButton;
    private System.Windows.Forms.Button continueButton;
    private Label versionLabel;
}