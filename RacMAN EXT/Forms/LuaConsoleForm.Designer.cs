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
        this.console = new System.Windows.Forms.RichTextBox();
        this.commandBox = new System.Windows.Forms.TextBox();
        this.submitButton = new System.Windows.Forms.Button();
        this.SuspendLayout();
        // 
        // console
        // 
        this.console.BackColor = System.Drawing.Color.Black;
        this.console.Font = new System.Drawing.Font("Monaco", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
        this.console.ForeColor = System.Drawing.Color.White;
        this.console.Location = new System.Drawing.Point(12, 12);
        this.console.Name = "console";
        this.console.ReadOnly = true;
        this.console.Size = new System.Drawing.Size(589, 279);
        this.console.TabIndex = 0;
        this.console.Text = "This is some text.\nThis is also some text.\nAnd this is some more text!";
        this.console.TextChanged += new System.EventHandler(this.console_TextChanged);
        // 
        // commandBox
        // 
        this.commandBox.Font = new System.Drawing.Font("Monaco", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
        this.commandBox.Location = new System.Drawing.Point(12, 297);
        this.commandBox.Name = "commandBox";
        this.commandBox.Size = new System.Drawing.Size(480, 22);
        this.commandBox.TabIndex = 1;
        this.commandBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.commandBox_KeyDown);
        // 
        // submitButton
        // 
        this.submitButton.Location = new System.Drawing.Point(508, 297);
        this.submitButton.Name = "submitButton";
        this.submitButton.Size = new System.Drawing.Size(92, 22);
        this.submitButton.TabIndex = 2;
        this.submitButton.Text = "Submit";
        this.submitButton.UseVisualStyleBackColor = true;
        this.submitButton.Click += new System.EventHandler(this.submitButton_Click);
        // 
        // LuaConsoleForm
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(616, 326);
        this.Controls.Add(this.submitButton);
        this.Controls.Add(this.commandBox);
        this.Controls.Add(this.console);
        this.Name = "LuaConsoleForm";
        this.Text = "Console";
        this.ResumeLayout(false);
        this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.RichTextBox console;
    private System.Windows.Forms.TextBox commandBox;
    private System.Windows.Forms.Button submitButton;
}