using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RacMAN.Forms.PropertyEditor;
public partial class PropertyEditorForm : Form
{
    private object obj;

    public PropertyEditorForm(object obj)
    {
        InitializeComponent();
        this.obj = obj;

        Stack<(string name, Type type, object value)> props = [];


        foreach (PropertyInfo property in obj.GetType().GetProperties())
        {
            props.Push((property.Name, property.PropertyType, property.GetValue(obj, null)!));
        }

        int x = 0;

        while (props.Count > 0)
        {
            // pop the first one
            var thisObj = props.Pop();

            if (thisObj.value == null) continue;

            // if it's a numerical *or* string *or* bool, make a control
            if (thisObj.value is string or int or long or byte or short)
            {
                var control = new LabelTextBox(thisObj.name, thisObj.value.ToString());
                control.Top = x;
                x += 30;
                Controls.Add(control);
            }
            else if (thisObj.value is string[])
            {
                var control = new LabelTextBox(thisObj.name, thisObj.value.ToString(),true);
                control.Top = x;
                x += 30;
                Controls.Add(control);
            }
            else if (thisObj.value is bool a)
            {
                var control = new CheckBox()
                {
                    Text = thisObj.name,
                    Checked = a,
                    AutoSize = true
                };
                control.Top = x;
                x += 30;
                Controls.Add(control);

            }
            else
            {
                foreach (PropertyInfo n_property in thisObj.value.GetType().GetProperties())
                {
                    props.Push(($"{thisObj.name}.{n_property.Name}", n_property.PropertyType, n_property.GetValue(thisObj.value, null)));
                }
            }

            // if not, push its properties.

        };


        Text = $"Property Editor Form ({Controls.Count} properties)";
    }
}
