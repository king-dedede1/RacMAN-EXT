using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RacMAN.Forms.PropertyEditor;


/// <summary>
/// Used to signal that a property should be ignored by the property editor.
/// </summary>
[AttributeUsage(AttributeTargets.Property)]
internal class EditorIgnoreAttribute : Attribute
{
}
