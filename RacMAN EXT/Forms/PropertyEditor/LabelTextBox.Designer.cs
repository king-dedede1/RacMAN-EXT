namespace RacMAN.Forms.PropertyEditor;

partial class LabelTextBox
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

    #region Component Designer generated code

    /// <summary> 
    /// Required method for Designer support - do not modify 
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        label1 = new Label();
        textBox1 = new TextBox();
        SuspendLayout();
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Location = new Point(3, 6);
        label1.Name = "label1";
        label1.Size = new Size(38, 15);
        label1.TabIndex = 0;
        label1.Text = "label1";
        // 
        // textBox1
        // 
        textBox1.Location = new Point(156, 3);
        textBox1.Name = "textBox1";
        textBox1.Size = new Size(188, 23);
        textBox1.TabIndex = 1;
        // 
        // LabelTextBox
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        Controls.Add(textBox1);
        Controls.Add(label1);
        Name = "LabelTextBox";
        Size = new Size(347, 32);
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Label label1;
    private TextBox textBox1;
}
