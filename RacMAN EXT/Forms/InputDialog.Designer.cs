namespace RacMAN.Forms;

partial class InputDialog
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
        textBox1 = new TextBox();
        label1 = new Label();
        submitButton = new Button();
        SuspendLayout();
        // 
        // textBox1
        // 
        textBox1.Location = new Point(12, 27);
        textBox1.Name = "textBox1";
        textBox1.Size = new Size(170, 23);
        textBox1.TabIndex = 0;
        textBox1.KeyDown += textBox1_KeyDown;
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Location = new Point(12, 9);
        label1.Name = "label1";
        label1.Size = new Size(38, 15);
        label1.TabIndex = 1;
        label1.Text = "label1";
        // 
        // submitButton
        // 
        submitButton.Location = new Point(188, 27);
        submitButton.Name = "submitButton";
        submitButton.Size = new Size(69, 24);
        submitButton.TabIndex = 2;
        submitButton.Text = "Submit";
        submitButton.UseVisualStyleBackColor = true;
        submitButton.Click += submitButton_Click;
        // 
        // InputDialog
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(264, 60);
        Controls.Add(submitButton);
        Controls.Add(label1);
        Controls.Add(textBox1);
        Name = "InputDialog";
        Text = "InputDialog";
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private TextBox textBox1;
    private Label label1;
    private Button submitButton;
}