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
        label1 = new Label();
        label2 = new Label();
        textBox1 = new TextBox();
        label3 = new Label();
        attachButton = new Button();
        continueButton = new Button();
        SuspendLayout();
        // 
        // comboBox1
        // 
        comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
        comboBox1.FormattingEnabled = true;
        comboBox1.Items.AddRange(new object[] { "PS3 (Ratchetron)", "PS3 EMU (RPCS3)", "PS2 EMU (PCSX2)" });
        comboBox1.Location = new Point(92, 58);
        comboBox1.Margin = new Padding(4, 3, 4, 3);
        comboBox1.Name = "comboBox1";
        comboBox1.Size = new Size(158, 23);
        comboBox1.TabIndex = 0;
        comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Location = new Point(82, 20);
        label1.Margin = new Padding(4, 0, 4, 0);
        label1.Name = "label1";
        label1.Size = new Size(100, 15);
        label1.TabIndex = 1;
        label1.Text = "Connect to Game";
        // 
        // label2
        // 
        label2.AutoSize = true;
        label2.Location = new Point(44, 61);
        label2.Margin = new Padding(4, 0, 4, 0);
        label2.Name = "label2";
        label2.Size = new Size(25, 15);
        label2.TabIndex = 2;
        label2.Text = "API";
        // 
        // textBox1
        // 
        textBox1.Location = new Point(92, 85);
        textBox1.Margin = new Padding(4, 3, 4, 3);
        textBox1.Name = "textBox1";
        textBox1.Size = new Size(157, 23);
        textBox1.TabIndex = 3;
        textBox1.KeyDown += textBox1_KeyDown;
        // 
        // label3
        // 
        label3.AutoSize = true;
        label3.Location = new Point(22, 88);
        label3.Margin = new Padding(4, 0, 4, 0);
        label3.Name = "label3";
        label3.Size = new Size(62, 15);
        label3.TabIndex = 4;
        label3.Text = "IP Address";
        // 
        // attachButton
        // 
        attachButton.Location = new Point(52, 132);
        attachButton.Margin = new Padding(4, 3, 4, 3);
        attachButton.Name = "attachButton";
        attachButton.Size = new Size(170, 41);
        attachButton.TabIndex = 5;
        attachButton.Text = "Connect";
        attachButton.UseVisualStyleBackColor = true;
        attachButton.Click += attachButton_Click;
        // 
        // continueButton
        // 
        continueButton.Location = new Point(52, 179);
        continueButton.Margin = new Padding(4, 3, 4, 3);
        continueButton.Name = "continueButton";
        continueButton.Size = new Size(170, 25);
        continueButton.TabIndex = 6;
        continueButton.Text = "Continue Without Game";
        continueButton.UseVisualStyleBackColor = true;
        continueButton.Click += continueButton_Click;
        // 
        // AttachGameForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(272, 218);
        Controls.Add(continueButton);
        Controls.Add(attachButton);
        Controls.Add(label3);
        Controls.Add(textBox1);
        Controls.Add(label2);
        Controls.Add(label1);
        Controls.Add(comboBox1);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        Margin = new Padding(4, 3, 4, 3);
        Name = "AttachGameForm";
        Text = "AttachGameForm";
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private System.Windows.Forms.ComboBox comboBox1;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox textBox1;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Button attachButton;
    private System.Windows.Forms.Button continueButton;
}