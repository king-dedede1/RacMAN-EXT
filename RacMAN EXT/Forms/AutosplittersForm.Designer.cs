namespace RacMAN.Forms;

partial class AutosplittersForm
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
        checkedListBox1 = new CheckedListBox();
        label1 = new Label();
        textBox1 = new TextBox();
        groupBox1 = new GroupBox();
        SuspendLayout();
        // 
        // checkedListBox1
        // 
        checkedListBox1.FormattingEnabled = true;
        checkedListBox1.Location = new Point(12, 8);
        checkedListBox1.Name = "checkedListBox1";
        checkedListBox1.Size = new Size(162, 238);
        checkedListBox1.TabIndex = 0;
        checkedListBox1.ItemCheck += checkedListBox1_ItemCheck;
        checkedListBox1.SelectedIndexChanged += checkedListBox1_SelectedIndexChanged;
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Location = new Point(179, 9);
        label1.Name = "label1";
        label1.Size = new Size(29, 15);
        label1.TabIndex = 1;
        label1.Text = "Title";
        // 
        // textBox1
        // 
        textBox1.Location = new Point(179, 63);
        textBox1.Multiline = true;
        textBox1.Name = "textBox1";
        textBox1.ReadOnly = true;
        textBox1.Size = new Size(263, 67);
        textBox1.TabIndex = 2;
        // 
        // groupBox1
        // 
        groupBox1.Location = new Point(180, 139);
        groupBox1.Name = "groupBox1";
        groupBox1.Size = new Size(261, 107);
        groupBox1.TabIndex = 3;
        groupBox1.TabStop = false;
        groupBox1.Text = "Settings";
        // 
        // AutosplittersForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(455, 256);
        Controls.Add(groupBox1);
        Controls.Add(textBox1);
        Controls.Add(label1);
        Controls.Add(checkedListBox1);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        Name = "AutosplittersForm";
        Text = "Autosplitters";
        Load += AutosplittersForm_Load;
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private CheckedListBox checkedListBox1;
    private Label label1;
    private TextBox textBox1;
    private GroupBox groupBox1;
}