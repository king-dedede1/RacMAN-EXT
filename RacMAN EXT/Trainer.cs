namespace RacMAN;
using RacMAN.Forms;

public class Trainer
{
    // Maybe redundant?
    public string TitleID { get; set; }

    // The racman version this trainer was made in, to detect any possible compatibility issues.
    // not sure if necessary, but maybe nice to have
    // System.Version class isn't serializable so this is the best option
    public string RacmanVersion { get; set; }

    // Form controls
    public List<DefineLabel> Labels { get; set; }
    public List<DefineButton> Buttons { get; set; }
    public List<DefineTextBox> TextBoxes { get; set; }
    public List<DefineCheckBox> CheckBoxes { get; set; }
    public List<DefineDropdown> Dropdowns { get; set; }

    // Lua actions
    public string OnLoad { get; set; } // action run when trainer is loaded.
    public string OnUnload { get; set; } // run when trainer is about to be unloaded (i.e. game change, app closing)
}

public class DefineLabel
{
    public string Name { get; set; } // used for access by code.
    public string Text { get; set; }
    public Point Position { get; set; }

    public static Label ToLabel(DefineLabel def, TrainerPanel panel)
    {
        var l = new Label()
        {
            Text = def.Text,
            Location = def.Position,
            Name = def.Name,
            Tag = def,
        };
        l.MouseDown += panel.DraggableControlMouseDown;
        l.MouseMove += panel.DraggableControlMouseMove;
        l.MouseUp += panel.DraggableControlMouseUp;
        return l;
    }
}

public class DefineButton
{
    public string Name { get; set; } // used for access by code.
    public bool Enabled { get; set; } // default value on load, can be changed by code.
    public string Text { get; set; }
    public Point Position { get; set; }
    public Size Size { get; set; }
    public string OnClick { get; set; } // lua action

    public static Button ToButton(DefineButton def, TrainerPanel panel)
    {
        var btn = new Button()
        {
            Name = def.Name,
            Enabled = def.Enabled,
            Text = def.Text,
            Location = def.Position,
            Size = def.Size,
            Tag = def
        };
        btn.MouseDown += panel.DraggableControlMouseDown;
        btn.MouseMove += panel.DraggableControlMouseMove;
        btn.MouseUp += panel.DraggableControlMouseUp;
        btn.Click += (s, e) => Racman.EvalLua(def.OnClick);
        return btn;
    }
}

public class DefineTextBox
{
    public string Name { get; set; }
    public bool Enabled { get; set; }
    public string Text { get; set; } // default value on load, can be changed by code.
    public Point Position { get; set; } // is a rectangle necessary here? idk
    public string OnEnter { get; set; } // for when the enter key is pressed
                                        // maybe add an action for when the text is changed?

    public static TextBox ToTextBox(DefineTextBox def, TrainerPanel panel)
    {
        var box = new TextBox()
        {
            Name = def.Name,
            Enabled = def.Enabled,
            Text = def.Text,
            Location = def.Position,
            Tag = def,
        };
        box.MouseDown += panel.DraggableControlMouseDown;
        box.MouseMove += panel.DraggableControlMouseMove;
        box.MouseUp += panel.DraggableControlMouseUp;
        box.KeyDown += (s, e) =>
        {
            if (e.KeyCode == Keys.Enter)
            {
                Racman.EvalLua(def.OnEnter);
            }
        };
        return box;
    }
}

public class DefineCheckBox
{
    public string Name { get; set; }
    public bool Enabled { get; set; }
    public string Text { get; set; } // the label next to the checkbox
    public CheckState CheckState { get; set; } // default when loading the form, can be changed by code
    public Point Position { get; set; }
    public bool AllowIndeterminate { get; set; } // putting this here to annoy robo
    public string OnCheck { get; set; } // called when checked changed

    public static CheckBox ToCheckBox(DefineCheckBox def, TrainerPanel panel)
    {
        var box = new CheckBox()
        {
            Name = def.Name,
            Enabled = def.Enabled,
            Text = def.Text,
            CheckState = def.CheckState,
            Location = def.Position,
            ThreeState = def.AllowIndeterminate,
            Tag = def
        };

        // These events are required to make the control draggable.
        box.MouseDown += panel.DraggableControlMouseDown;
        box.MouseMove += panel.DraggableControlMouseMove;
        box.MouseUp += panel.DraggableControlMouseUp;
        box.CheckedChanged += (s, e) => Racman.EvalLua(def.OnCheck);
        return box;
    }
}

public class DefineDropdown
{
    public string Name { get; set; }
    public bool Enabled { get; set; }
    public Point Position { get; set; }
    public Size Size { get; set; }
    public string[] Options { get; set; } // dropdown options
    public int Index { get; set; } // index of default selected item
    public string OnItemSelected { get; set; } // called when the user selects a dropdown item
                                               // or you could just put a button next to it like a normal person...

    public static ComboBox ToComboBox(DefineDropdown def, TrainerPanel panel)
    {
        var comboBox = new ComboBox()
        {
            Name = def.Name,
            Enabled = def.Enabled,
            Location = def.Position,
            Size = def.Size,
            DropDownStyle = ComboBoxStyle.DropDownList,
            Tag = def,
        };
        if (def.Options != null)
        {
            comboBox.Items.AddRange(def.Options);
            comboBox.SelectedIndex = def.Index;
        }
        comboBox.MouseDown += panel.DraggableControlMouseDown;
        comboBox.MouseMove += panel.DraggableControlMouseMove;
        comboBox.MouseUp += panel.DraggableControlMouseUp;
        comboBox.SelectedIndexChanged += (s, e) => Racman.EvalLua(def.OnItemSelected);
        return comboBox;
    }
}