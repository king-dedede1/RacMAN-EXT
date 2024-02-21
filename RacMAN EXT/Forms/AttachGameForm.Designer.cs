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
        this.comboBox1 = new System.Windows.Forms.ComboBox();
        this.label1 = new System.Windows.Forms.Label();
        this.label2 = new System.Windows.Forms.Label();
        this.textBox1 = new System.Windows.Forms.TextBox();
        this.label3 = new System.Windows.Forms.Label();
        this.attachButton = new System.Windows.Forms.Button();
        this.continueButton = new System.Windows.Forms.Button();
        this.SuspendLayout();
        // 
        // comboBox1
        // 
        this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.comboBox1.FormattingEnabled = true;
        this.comboBox1.Items.AddRange(new object[] {
            "PS3 (Ratchetron/WebMAN)",
            "RPCS3",
            "PCSX2"});
        this.comboBox1.Location = new System.Drawing.Point(56, 49);
        this.comboBox1.Name = "comboBox1";
        this.comboBox1.Size = new System.Drawing.Size(166, 21);
        this.comboBox1.TabIndex = 0;
        this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
        // 
        // label1
        // 
        this.label1.AutoSize = true;
        this.label1.Location = new System.Drawing.Point(72, 22);
        this.label1.Name = "label1";
        this.label1.Size = new System.Drawing.Size(90, 13);
        this.label1.TabIndex = 1;
        this.label1.Text = "Connect to Game";
        // 
        // label2
        // 
        this.label2.AutoSize = true;
        this.label2.Location = new System.Drawing.Point(26, 52);
        this.label2.Name = "label2";
        this.label2.Size = new System.Drawing.Size(24, 13);
        this.label2.TabIndex = 2;
        this.label2.Text = "API";
        // 
        // textBox1
        // 
        this.textBox1.Location = new System.Drawing.Point(134, 73);
        this.textBox1.Name = "textBox1";
        this.textBox1.Size = new System.Drawing.Size(87, 20);
        this.textBox1.TabIndex = 3;
        // 
        // label3
        // 
        this.label3.AutoSize = true;
        this.label3.Location = new System.Drawing.Point(26, 76);
        this.label3.Name = "label3";
        this.label3.Size = new System.Drawing.Size(58, 13);
        this.label3.TabIndex = 4;
        this.label3.Text = "IP Address";
        // 
        // attachButton
        // 
        this.attachButton.Location = new System.Drawing.Point(46, 127);
        this.attachButton.Name = "attachButton";
        this.attachButton.Size = new System.Drawing.Size(145, 23);
        this.attachButton.TabIndex = 5;
        this.attachButton.Text = "Attach Game";
        this.attachButton.UseVisualStyleBackColor = true;
        this.attachButton.Click += new System.EventHandler(this.attachButton_Click);
        // 
        // continueButton
        // 
        this.continueButton.Location = new System.Drawing.Point(45, 155);
        this.continueButton.Name = "continueButton";
        this.continueButton.Size = new System.Drawing.Size(146, 22);
        this.continueButton.TabIndex = 6;
        this.continueButton.Text = "Continue Without Game";
        this.continueButton.UseVisualStyleBackColor = true;
        this.continueButton.Click += new System.EventHandler(this.continueButton_Click);
        // 
        // AttachGameForm
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(233, 189);
        this.Controls.Add(this.continueButton);
        this.Controls.Add(this.attachButton);
        this.Controls.Add(this.label3);
        this.Controls.Add(this.textBox1);
        this.Controls.Add(this.label2);
        this.Controls.Add(this.label1);
        this.Controls.Add(this.comboBox1);
        this.Name = "AttachGameForm";
        this.Text = "AttachGameForm";
        this.ResumeLayout(false);
        this.PerformLayout();

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