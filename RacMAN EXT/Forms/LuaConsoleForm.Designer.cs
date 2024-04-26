namespace RacMAN.Forms;

partial class LuaConsoleForm
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
        console = new RichTextBox();
        commandBox = new TextBox();
        submitButton = new Button();
        SuspendLayout();
        // 
        // console
        // 
        console.BackColor = Color.Black;
        console.Font = new Font("Consolas", 12F, FontStyle.Regular, GraphicsUnit.Point,  0);
        console.ForeColor = Color.White;
        console.Location = new Point(14, 14);
        console.Margin = new Padding(4, 3, 4, 3);
        console.Name = "console";
        console.ReadOnly = true;
        console.Size = new Size(686, 321);
        console.TabIndex = 0;
        console.Text = "This is some text.\nThis is also some text.\nAnd this is some more text!";
        console.TextChanged += console_TextChanged;
        // 
        // commandBox
        // 
        commandBox.Font = new Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point,  0);
        commandBox.Location = new Point(14, 343);
        commandBox.Margin = new Padding(4, 3, 4, 3);
        commandBox.Name = "commandBox";
        commandBox.Size = new Size(559, 22);
        commandBox.TabIndex = 1;
        commandBox.KeyDown += commandBox_KeyDown;
        // 
        // submitButton
        // 
        submitButton.Location = new Point(593, 343);
        submitButton.Margin = new Padding(4, 3, 4, 3);
        submitButton.Name = "submitButton";
        submitButton.Size = new Size(107, 25);
        submitButton.TabIndex = 2;
        submitButton.Text = "Submit";
        submitButton.UseVisualStyleBackColor = true;
        submitButton.Click += submitButton_Click;
        // 
        // LuaConsoleForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(719, 376);
        Controls.Add(submitButton);
        Controls.Add(commandBox);
        Controls.Add(console);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        Margin = new Padding(4, 3, 4, 3);
        Name = "LuaConsoleForm";
        Text = "Console";
        FormClosing += LuaConsoleForm_FormClosing;
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private System.Windows.Forms.RichTextBox console;
    private System.Windows.Forms.TextBox commandBox;
    private System.Windows.Forms.Button submitButton;
}