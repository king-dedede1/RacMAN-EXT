using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using static System.Windows.Forms.AxHost;

namespace RacMAN.ControllerCombos;

/// <summary>
/// Manages adding win32 hotkeys, and checks for controller combos and calls their actions.
/// </summary>
internal class ControllerComboManager
{
    Racman State;
    ControllerComboGroup ComboGroup;
    List<ControllerCombo> ComboList;
    Dictionary<int, ControllerCombo> HotkeyDict;
    HotkeyListener Listener;
    bool Running = false;

    // make sure we don't accidentally reuse keys
    private int i = 0;

    internal ControllerComboManager(Racman state, ControllerComboGroup comboGroup)
    {
        State = state;
        ComboGroup = comboGroup;
        HotkeyDict = [];
        ComboList = [];
        Listener = new();

        AddStuffFromGroup(comboGroup);

        Listener.HotkeyPressed += HotkeyPressed;

        Running = true;
        new Thread(ControllerHandlerThread).Start();
    }

    private void AddStuffFromGroup(ControllerComboGroup comboGroup)
    {
        foreach (var subfolder in comboGroup.SubGroups)
        {
            AddStuffFromGroup(subfolder);
        }

        foreach (var combo in comboGroup.Combos)
        {
            if (combo.LuaAction == null)
            {
                combo.LuaAction = State.CompileLuaFunction(combo.LuaActionString);
            }
            if (combo.IsHotkey)
            {
                HotkeyDict.Add(++i, combo);
                Listener.AddHotkey(i, combo.HotkeyKey);
                State.Log($"Added hotkey {combo.Name} with id {i}");

            }
        }
    }

    private void HotkeyPressed(int id)
    {
        State.Log("Event received");
        if (HotkeyDict.ContainsKey(id))
        {
            var isRacmanFocused = Form.ActiveForm != null;
            var hotkey = HotkeyDict[id];
            if (hotkey.IsHotkeyGlobal || isRacmanFocused)
            {
                if (hotkey.LuaAction != null)
                {
                    State.Log($"calling hotkey action {hotkey.Name}");
                    TryCallLuaFunction(hotkey);
                }
                else
                {
                    State.Error($"tried to call hotkey action {hotkey.Name} but it is null");
                }
            }
        }
        else
        {
            State.Error($"hotkey id {id} not found?");
        }
    }

    public void AddOrUpdateCombo(ControllerCombo combo)
    {
        if (!HotkeyDict.ContainsValue(combo))
        {
            HotkeyDict.Add(++i, combo);
            Listener.AddHotkey(i, combo.HotkeyKey);
        }
        else
        {
            var key = HotkeyDict.First(a => a.Value == combo).Key;
            Listener.RemoveHotkey(key);
            Listener.AddHotkey(key, combo.HotkeyKey);
        }
    }

    private void ControllerHandlerThread()
    {
        var inputCheck = true;
        while (Running)
        {
            var allCombos = GetControllerCombosRecursive(ComboGroup);
            RacMAN.API.Inputs.ButtonState currentInputs = State.InputProvider.Inputs.Buttons;
            if (!inputCheck && currentInputs.IsEmpty) inputCheck = true;
            if (inputCheck && !currentInputs.IsEmpty)
            {
                foreach (var combo in allCombos)
                {
                    if (currentInputs == combo.ComboButtonState)
                    {
                        State.Log($"Calling controller combo {combo.Name}!");
                        TryCallLuaFunction(combo);
                        inputCheck = false;
                        break;
                    }
                }
            }
            Thread.Sleep(16);
        }
    }

    private List<ControllerCombo> GetControllerCombosRecursive(ControllerComboGroup group)
    {
        var list = new List<ControllerCombo>();
        list.AddRange(group.Combos.Where(c => c.IsControllerCombo && c.Enabled));
        foreach (var subfolder in group.SubGroups)
        {
            list.AddRange(GetControllerCombosRecursive(subfolder));
        }
        return list;
    } 

    public void Close()
    {
        Running = false;
        foreach(var id in HotkeyDict.Keys)
        {
            Listener.RemoveHotkey(id);
        }
        Listener.DestroyHandle();
    }

    public void TryCallLuaFunction(ControllerCombo combo)
    {
        if (combo.LuaAction != null)
        {
            State.EvalLua(combo.LuaAction);
        }
        else
        {
            State.Log($"{combo.Name} lua func is null, compiling...");
            try
            {
                combo.LuaAction = State.CompileLuaFunction(combo.LuaActionString);
            }
            catch
            {
                State.Error($"Error compiling {combo.Name} action, disabling.");
                combo.Enabled = false;
                return;
            }
            State.EvalLua(combo.LuaAction!);
        }
    }

    private class HotkeyListener : NativeWindow
    {
        internal event Action<int>? HotkeyPressed;

        internal HotkeyListener()
        {
            this.CreateHandle(new CreateParams()
            {
                Caption = "Hotkey Listener"
            });
        }

        internal void AddHotkey(int id, Keys key)
        {
            uint vk = ((uint) key) & 0x0000FFFF;
            uint modifier = (((uint) key) & 0xFFFF0000) >> 16;
            switch (modifier)
            {
                case 1:
                    modifier = 4; break;
                case 2:
                    modifier = 2; break;
                case 4:
                    modifier = 1; break;
            }
            modifier |= 0x4000;
            if (!Win32.RegisterHotKey(this.Handle, id, modifier, vk))
            {
                throw new Exception($"Win32 error adding hotkey: 0x{Win32.GetLastError():X}");
            }
        }

        internal void RemoveHotkey(int id)
        {
            if (!Win32.UnregisterHotKey(this.Handle, id))
            {
                throw new Exception($"Win32 error deleting hotkey: 0x{Win32.GetLastError():X}");
            }
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x312)
            {
                HotkeyPressed?.Invoke((int) m.WParam);
            }
            base.WndProc(ref m);
        }
    }
}

/// <summary>
/// should be moved to its own file?
/// </summary>
internal static class Win32
{
    [DllImport("User32.dll")]
    internal static extern bool RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, uint vk);

    [DllImport("User32.dll")]
    internal static extern bool UnregisterHotKey(IntPtr hWnd, int id);

    [DllImport("Kernel32.dll")]
    internal static extern int GetLastError();
}
