namespace RacMAN;
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

    public Trainer(string titleID)
    {
        TitleID = titleID;
        RacmanVersion = "1";
        Labels = [];
        Buttons = [];
        TextBoxes = [];
        CheckBoxes = [];
        Dropdowns = [];
        OnLoad = "";
        OnUnload = "";
    }

    internal static Trainer DeepCopy(Trainer t)
    {
        return new Trainer(t.TitleID)
        {
            RacmanVersion = t.RacmanVersion,
            OnLoad = t.OnLoad,
            OnUnload = t.OnUnload,
            Labels = t.Labels.ConvertAll(DefineLabel.Copy),
            Buttons = t.Buttons.ConvertAll(DefineButton.Copy),
            TextBoxes = t.TextBoxes.ConvertAll(DefineTextBox.Copy),
            CheckBoxes = t.CheckBoxes.ConvertAll(DefineCheckBox.Copy),
            Dropdowns = t.Dropdowns.ConvertAll(DefineDropdown.Copy)
        };
    }
}

public class DefineLabel
{
    public string Name { get; set; } // used for access by code.
    public string Text { get; set; }
    public Point Position { get; set; }

    internal static DefineLabel Copy(DefineLabel o)
    {
        return (DefineLabel) o.MemberwiseClone();
    }

    internal DefineLabel Copy()
    {
        return Copy(this);
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

    internal static DefineButton Copy(DefineButton o)
    {
        return (DefineButton) o.MemberwiseClone();
    }

    internal DefineButton Copy()
    {
        return Copy(this);
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

    internal static DefineTextBox Copy(DefineTextBox o)
    {
        return (DefineTextBox) o.MemberwiseClone();
    }

    internal DefineTextBox Copy()
    {
        return Copy(this);
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

    internal static DefineCheckBox Copy(DefineCheckBox o)
    {
        return (DefineCheckBox) o.MemberwiseClone();
    }

    internal DefineCheckBox Copy()
    {
        return Copy(this);
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

    internal static DefineDropdown Copy(DefineDropdown o)
    {
        return (DefineDropdown) o.MemberwiseClone();
    }

    internal DefineDropdown Copy()
    {
        return Copy(this);
    }
}