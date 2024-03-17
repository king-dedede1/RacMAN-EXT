namespace RacMAN.Forms;
public class TrainerPanel : Panel
{
    Trainer trainerJson;

    internal TrainerPanel(Trainer trainer)
    {
        trainerJson = trainer;
        this.Name = "trainerpanel";
        this.Dock = DockStyle.Fill;

        // add controls from JSON file
        SuspendLayout();

        foreach (var label in trainer.Labels) Controls.Add(ConstructLabel(label));
        foreach (var button in trainer.Buttons) Controls.Add(ConstructButton(button));
        foreach (var textbox in trainer.TextBoxes) Controls.Add(ConstructTextBox(textbox));
        foreach (var checkbox in trainer.CheckBoxes) Controls.Add(ConstructCheckBox(checkbox));
        foreach (var combobox in trainer.Dropdowns) Controls.Add(ConstructComboBox(combobox));

        ResumeLayout();
    }

    internal void CallOnLoadEvent()
    {
        Racman.EvalLua(trainerJson.OnLoad);
    }

    /// <summary>
    /// Construct a label control from JSON definition
    /// </summary>
    /// <param name="define"></param>
    /// <returns></returns>
    private static Label ConstructLabel(DefineLabel define)
    {
        Label label = new Label();
        label.Text = define.Text;
        label.Name = define.Name;
        label.Location = define.Position;
        label.AutoSize = true;
        return label;
    }

    private static Button ConstructButton(DefineButton define)
    {
        Button button = new Button();
        button.Name = define.Name;
        button.Location = define.Position;
        button.Text = define.Text;
        button.Enabled = define.Enabled;
        button.Size = define.Size;
        button.Tag = define; // so Click event knows what event to run
        button.Click += Button_Click;
        return button;
    }

    private static TextBox ConstructTextBox(DefineTextBox define)
    {
        TextBox textBox = new TextBox();
        textBox.Name = define.Name;
        textBox.Location = define.Position;
        textBox.Text = define.Text;
        textBox.Enabled = define.Enabled;
        textBox.Tag = define;
        textBox.KeyDown += TextBox_KeyDown;
        return textBox;
    }

    private static CheckBox ConstructCheckBox(DefineCheckBox define)
    {
        CheckBox checkBox = new CheckBox();
        checkBox.Name = define.Name;
        checkBox.Enabled = define.Enabled;
        checkBox.Text = define.Text;
        checkBox.CheckState = define.CheckState;
        checkBox.Location = define.Position;
        checkBox.ThreeState = define.AllowIndeterminate;
        checkBox.Tag = define;
        checkBox.AutoSize = true;
        checkBox.CheckedChanged += CheckBox_CheckedChanged;
        return checkBox;
    }

    private static ComboBox ConstructComboBox(DefineDropdown define)
    {
        ComboBox comboBox = new ComboBox();
        comboBox.Name = define.Name;
        comboBox.Enabled = define.Enabled;
        comboBox.Location = define.Position;
        comboBox.Size = define.Size;
        comboBox.Items.AddRange(define.Options);
        comboBox.SelectedIndex = define.Index;
        comboBox.Tag = define;
        comboBox.SelectedIndexChanged += ComboBox_SelectedIndexChanged;
        return comboBox;
    }

    private static void ComboBox_SelectedIndexChanged(object? sender, EventArgs e)
    {
        Racman.EvalLua(((sender! as ComboBox)!.Tag as DefineDropdown)!.OnItemSelected);
    }

    private static void CheckBox_CheckedChanged(object? sender, EventArgs e)
    {
        Racman.EvalLua(((sender! as CheckBox)!.Tag as DefineCheckBox)!.OnCheck);
    }

    private static void TextBox_KeyDown(object? sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            Racman.EvalLua(((sender! as TextBox)!.Tag as DefineTextBox)!.OnEnter);
        }
    }

    private static void Button_Click(object? sender, EventArgs e)
    {
        // really good code and I am an excellent programmer
        Racman.EvalLua(((sender! as Button)!.Tag as DefineButton)!.OnClick);
    }
}
