using RacMAN.ControllerCombos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace RacMAN.Forms;
public partial class ControllerCombosForm : Form
{
    private ControllerCombo? selectedCombo;
    private Racman state;
    private bool ignoreCheckedEvents = false;
    public ControllerCombosForm(ControllerComboGroup comboGroup, Racman state)
    {
        InitializeComponent();

        treeView.Nodes.Clear();
        AddNodesFromComboGroup(comboGroup, treeView.Nodes, true);
        this.state = state;
    }

    private void AddNodesFromComboGroup(ControllerComboGroup comboGroup, TreeNodeCollection parent, bool useDiscIcon = false)
    {
        // Make a container node and add it
        TreeNode node = new(comboGroup.Name);
        node.ImageIndex = useDiscIcon ? 4 : 0;
        node.SelectedImageIndex = useDiscIcon ? 4 : 0;
        node.ToolTipText = comboGroup.Description;
        node.Tag = comboGroup;
        node.Expand();
        parent.Add(node);

        // Add the container's children

        // Sub-folders first
        foreach (ControllerComboGroup subGroup in comboGroup.SubGroups)
        {
            AddNodesFromComboGroup(subGroup, node.Nodes);
        }

        // Then combo nodes
        foreach (ControllerCombo combo in comboGroup.Combos)
        {
            AddNodeFromCombo(combo, node.Nodes);
        }
    }

    private TreeNode AddNodeFromCombo(ControllerCombo combo, TreeNodeCollection parent)
    {
        TreeNode node = new(combo.Name);
        node.ToolTipText = combo.Description;
        node.Checked = combo.Enabled;
        node.Tag = combo;
        node.ImageIndex = GetIconForCombo(combo);
        node.SelectedImageIndex = GetIconForCombo(combo);

        parent.Add(node);
        return node;
    }

    private int GetIconForCombo(ControllerCombo combo)
    {
        if (combo.IsHotkey && combo.IsControllerCombo)
        {
            return 3;
        }
        else if (combo.IsHotkey)
        {
            return 2;
        }
        else if (combo.IsControllerCombo)
        {
            return 1;
        }
        return 5;
    }

    private void treeView_AfterSelect(object sender, TreeViewEventArgs e)
    {
        if (e.Node?.Tag is ControllerCombo combo)
        {
            selectedCombo = combo;
            RefreshComboControls(combo);
        }
        else
        {
            selectedCombo = null;
            RefreshComboControls(null);
        }
    }

    private void treeView_AfterCheck(object sender, TreeViewEventArgs e)
    {
        if (e.Node.Tag is ControllerCombo combo)
        {
            combo.Enabled = e.Node.Checked;
        }


        if (e.Node.Checked)
        {
            foreach (TreeNode childNode in e.Node.Nodes)
            {
                childNode.Checked = e.Node.Checked;
            }
        }
        else
        {

            // we are unchecking this node, so the parent should also be unchecked.
            if (e.Node.Parent != null)
            {
                e.Node.Parent.Checked = false;
            }
        }
    }

    private void RefreshComboControls(ControllerCombo? combo)
    {
        if (combo == null)
        {
            groupBox1.Enabled = false;
            hotkeyGroup.Enabled = false;
            controllerComboGroup.Enabled = false;
            groupBox4.Enabled = false;

            nameTextBox.Clear();
            descriptionTextBox.Clear();
            controllerComboCheckbox.Checked = false;
            hotkeyCheckbox.Checked = false;
            controllerComboLabel.Text = "N/A";
            hotkeyLabel.Text = "N/A";
            globalCheckbox.Checked = false;
            actionTextBox.Clear();
        }
        else
        {
            groupBox1.Enabled = true;
            groupBox4.Enabled = true;
            hotkeyCheckbox.Enabled = true;
            controllerComboCheckbox.Enabled = true;
            controllerComboGroup.Enabled = combo.IsControllerCombo;
            hotkeyGroup.Enabled = combo.IsHotkey;

            nameTextBox.Text = combo.Name;
            descriptionTextBox.Text = combo.Description;
            actionTextBox.Text = combo.LuaActionString;
            ignoreCheckedEvents = true;
            controllerComboCheckbox.Checked = combo.IsControllerCombo;
            hotkeyCheckbox.Checked = combo.IsHotkey;
            globalCheckbox.Checked = combo.IsHotkeyGlobal;
            ignoreCheckedEvents = false;
            controllerComboLabel.Text = combo.ComboButtonState.ToString();
            hotkeyLabel.Text = new KeysConverter().ConvertToString(combo.HotkeyKey);
        }
    }

    private void addButton_Click(object sender, EventArgs e)
    {
        if (treeView.SelectedNode.Tag is ControllerComboGroup group)
        {
            var combo = new ControllerCombo();
            combo.Name = "New Combo";
            combo.IsControllerCombo = true;
            combo.Description = "";
            combo.LuaActionString = "-- Your code goes here...";
            group.Combos.Add(combo);

            treeView.SelectedNode = AddNodeFromCombo(combo, treeView.SelectedNode.Nodes);
        }
    }

    private void treeView_BeforeSelect(object sender, TreeViewCancelEventArgs e)
    {
        SaveStuffFromControls();
    }

    private void SaveStuffFromControls()
    {
        if (selectedCombo != null)
        {
            // Save stuff from form and put it in selectedCombo.
            // Except lua action, that's done separately.

            selectedCombo.Name = nameTextBox.Text;
            selectedCombo.Description = descriptionTextBox.Text;
            selectedCombo.IsControllerCombo = controllerComboCheckbox.Checked;
            selectedCombo.IsHotkey = hotkeyCheckbox.Checked;
            selectedCombo.IsHotkeyGlobal = globalCheckbox.Checked;

            treeView.SelectedNode.Text = selectedCombo.Name;
            treeView.SelectedNode.ToolTipText = selectedCombo.Description;
            treeView.SelectedNode.ImageIndex = GetIconForCombo(selectedCombo);
            treeView.SelectedNode.SelectedImageIndex = GetIconForCombo(selectedCombo);
        }
    }

    private void ControllerCombosForm_FormClosing(object sender, FormClosingEventArgs e)
    {
        SaveStuffFromControls();
        if (MessageBox.Show("Do you want to save your changes?", "Save?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
        {
            state.Game.SaveCombos();
        }
    }

    private void nameTextBox_Leave(object sender, EventArgs e)
    {
        SaveStuffFromControls();
    }

    private void descriptionTextBox_Leave(object sender, EventArgs e)
    {
        SaveStuffFromControls();
    }

    private void controllerComboCheckbox_CheckedChanged(object sender, EventArgs e)
    {
        if (ignoreCheckedEvents) return;
        SaveStuffFromControls();
        controllerComboGroup.Enabled = controllerComboCheckbox.Checked;
    }

    private void hotkeyCheckbox_CheckedChanged(object sender, EventArgs e)
    {
        if (ignoreCheckedEvents) return;
        SaveStuffFromControls();
        hotkeyGroup.Enabled = hotkeyCheckbox.Checked;
    }

    private void addFolderButton_Click(object sender, EventArgs e)
    {
        if (treeView.SelectedNode.Tag is ControllerComboGroup group)
        {
            var combo = new ControllerComboGroup();
            combo.Name = InputDialog.ShowInputDialog("Folder name:");
            combo.Description = "";
            group.SubGroups.Add(combo);

            AddNodesFromComboGroup(combo, treeView.SelectedNode.Nodes);
        }
    }

    private void submitActionButton_Click(object sender, EventArgs e)
    {
        if (selectedCombo == null) return;

        var function = state.CompileLuaFunction(actionTextBox.Text);
        if (function != null)
        {
            selectedCombo.LuaAction = function;
            selectedCombo.LuaActionString = actionTextBox.Text;
        }
        else
        {
            MessageBox.Show("Error compiling lua function. Your changes have not been saved.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
    private bool waitingForKey = true;
    private void changeHotkeyButton_Click(object sender, EventArgs e)
    {
        changeHotkeyButton.Text = "Waiting...";
        waitingForKey = true;
    }

    private void changeHotkeyButton_KeyUp(object sender, KeyEventArgs e)
    {

        if (selectedCombo != null && waitingForKey)
        {
            selectedCombo.HotkeyKey = e.Modifiers | e.KeyCode;
            SaveStuffFromControls();
            hotkeyLabel.Text = new KeysConverter().ConvertToString(e.Modifiers | e.KeyCode);
            changeHotkeyButton.Text = "Change Hotkey...";
            waitingForKey = false;

            // Update the hotkey
            state.ControllerComboManager.AddOrUpdateCombo(selectedCombo);
        }
    }

    private void globalCheckbox_CheckedChanged(object sender, EventArgs e)
    {
        if (ignoreCheckedEvents) return;
        SaveStuffFromControls();
    }

    private void changeComboButton_Click(object sender, EventArgs e)
    {
        if (state.InputProvider != null && selectedCombo != null)
        {
            MessageBox.Show("Hold down the buttons on the controller and press OK.");
            var buttons = state.InputProvider.Inputs.Buttons;
            selectedCombo.ComboButtonState = buttons;
            controllerComboLabel.Text = buttons.ToString();
        }
        else
        {
            MessageBox.Show("Can't read controller input right now; no input provider is available.");
        }
    }
}
