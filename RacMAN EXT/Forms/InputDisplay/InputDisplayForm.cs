using RacMAN.API.Inputs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ButtonState = RacMAN.API.Inputs.ButtonState;
using Timer = System.Windows.Forms.Timer;

namespace RacMAN.Forms.InputDisplay;
public partial class InputDisplayForm : Form
{
    Racman State { get; set; }

    private InputDisplaySkin _skin;
    public InputDisplaySkin Skin
    {
        get => _skin;
        set
        {
            _skin = value;
            UpdateSize();
        }
    }

    private bool _borderless;
    public bool Borderless
    {
        get => _borderless;
        set
        {
            _borderless = value;
            UpdateBorder();
        }
    }

    private const string SkinFolder = "data/common/inputdisplay/";
    private const GraphicsUnit units = GraphicsUnit.Pixel;
    private bool mouseDown;
    private Timer timer;
    private Point mouseLocation;
    private string[] skinPaths;

    public InputDisplayForm(Racman state)
    {
        InitializeComponent();

        State = state;

        timer = new();
        timer.Interval = 16;
        timer.Tick += Timer_Tick;
        timer.Start();

        Skin = InputDisplaySkin.Load(Path.Join(SkinFolder, State.Settings.InputDisplaySkin ??= "Compact"));
        borderlessToolStripMenuItem.Checked = (bool) State.Settings.InputDisplayBorderless!;
        BackColor = (Color) State.Settings.InputDisplayBackColor!;

        UpdateBorder();

        skinPaths = Directory.GetDirectories(SkinFolder);
        foreach (var skinpath in skinPaths)
        {
            var menuItem = new ToolStripMenuItem();
            menuItem.Text = Path.GetFileName(skinpath);
            menuItem.Click += delegate
            {
                Skin = InputDisplaySkin.Load(skinpath);
                State.Settings.InputDisplaySkin = Path.GetFileName(skinpath);
            };
            skinToolStripMenuItem.DropDownItems.Add(menuItem);
        }
    }

    private void UpdateSize()
    {
        Width = Skin.Buttons["base"].spriteWidth;
        Height = Skin.Buttons["base"].spriteHeight;
        if (!Borderless)
        {
            Width += 15;
            Height += 39;
        }
    }

    private void UpdateBorder()
    {
        if (Borderless)
        {
            FormBorderStyle = FormBorderStyle.None;
        }
        else
        {
            FormBorderStyle = FormBorderStyle.FixedSingle;
        }
        UpdateSize();
    }

    private void Timer_Tick(object? sender, EventArgs e)
    {
        Refresh();
    }

    private void InputDisplayForm_Paint(object sender, PaintEventArgs e)
    {
        Image sprite = Skin.Image!;

        InputPlot basePlot = Skin.Buttons["base"];
        InputPlot r3 = Skin.Buttons["r3"];
        InputPlot r3Press = Skin.Buttons["r3Press"];
        InputPlot l3 = Skin.Buttons["l3"];
        InputPlot l3Press = Skin.Buttons["l3Press"];

        InputPlot dpadLeft = Skin.Buttons["dpadLeft"];
        InputPlot dpadRight = Skin.Buttons["dpadRight"];
        InputPlot dpadDown = Skin.Buttons["dpadDown"];
        InputPlot dpadUp = Skin.Buttons["dpadUp"];

        InputPlot cross = Skin.Buttons["cross"];
        InputPlot circle = Skin.Buttons["circle"];
        InputPlot triangle = Skin.Buttons["triangle"];
        InputPlot square = Skin.Buttons["square"];

        InputPlot select = Skin.Buttons["select"];
        InputPlot start = Skin.Buttons["start"];

        InputPlot r1 = Skin.Buttons["r1"];
        InputPlot l1 = Skin.Buttons["l1"];
        InputPlot l2 = Skin.Buttons["l2"];
        InputPlot r2 = Skin.Buttons["r2"];

        InputState inputs = State.InputProvider.Inputs;
        ButtonState buttons = inputs.Buttons;
        Graphics g = e.Graphics;

        g.DrawImage(sprite, basePlot.drawX, basePlot.drawY, new Rectangle(basePlot.spriteX, basePlot.spriteY, basePlot.spriteWidth, basePlot.spriteHeight), units);
        if (buttons.R3)
        {
            g.DrawImage(sprite, r3.drawX + (inputs.RX * Skin.AnalogPitch), r3.drawY + (inputs.RY * Skin.AnalogPitch), new Rectangle(r3.spriteX, r3.spriteY, r3.spriteWidth, r3.spriteHeight), units);
        }
        else
        {
            g.DrawImage(sprite, r3Press.drawX + (inputs.RX * Skin.AnalogPitch), r3Press.drawY + (inputs.RY * Skin.AnalogPitch), new Rectangle(r3Press.spriteX, r3Press.spriteY, r3Press.spriteWidth, r3Press.spriteHeight), units);
        }
        if (buttons.L3)
        {
            g.DrawImage(sprite, l3.drawX + (inputs.LX * Skin.AnalogPitch), l3.drawY + (inputs.LY * Skin.AnalogPitch), new Rectangle(l3.spriteX, l3.spriteY, l3.spriteWidth, l3.spriteHeight), units);
        }
        else
        {
            g.DrawImage(sprite, l3Press.drawX + (inputs.LX * Skin.AnalogPitch), l3Press.drawY + (inputs.LY * Skin.AnalogPitch), new Rectangle(l3Press.spriteX, l3Press.spriteY, l3Press.spriteWidth, l3Press.spriteHeight), units);
        }
        if (buttons.DLeft)
        {
            g.DrawImage(sprite, dpadLeft.drawX, dpadLeft.drawY, new Rectangle(dpadLeft.spriteX, dpadLeft.spriteY, dpadLeft.spriteWidth, dpadLeft.spriteHeight), units);
        }
        if (buttons.DRight)
        {
            g.DrawImage(sprite, dpadRight.drawX, dpadRight.drawY, new Rectangle(dpadRight.spriteX, dpadRight.spriteY, dpadRight.spriteWidth, dpadRight.spriteHeight), units);
        }
        if (buttons.DDown)
        {
            g.DrawImage(sprite, dpadDown.drawX, dpadDown.drawY, new Rectangle(dpadDown.spriteX, dpadDown.spriteY, dpadDown.spriteWidth, dpadDown.spriteHeight), units);
        }
        if (buttons.DUp)
        {
            g.DrawImage(sprite, dpadUp.drawX, dpadUp.drawY, new Rectangle(dpadUp.spriteX, dpadUp.spriteY, dpadUp.spriteWidth, dpadUp.spriteHeight), units);
        }
        if (buttons.Cross)
        {
            g.DrawImage(sprite, cross.drawX, cross.drawY, new Rectangle(cross.spriteX, cross.spriteY, cross.spriteWidth, cross.spriteHeight), units);
        }
        if (buttons.Circle)
        {
            g.DrawImage(sprite, circle.drawX, circle.drawY, new Rectangle(circle.spriteX, circle.spriteY, circle.spriteWidth, circle.spriteHeight), units);
        }
        if (buttons.Triangle)
        {
            g.DrawImage(sprite, triangle.drawX, triangle.drawY, new Rectangle(triangle.spriteX, triangle.spriteY, triangle.spriteWidth, triangle.spriteHeight), units);
        }
        if (buttons.Square)
        {
            g.DrawImage(sprite, square.drawX, square.drawY, new Rectangle(square.spriteX, square.spriteY, square.spriteWidth, square.spriteHeight), units);
        }
        if (buttons.Select)
        {
            g.DrawImage(sprite, select.drawX, select.drawY, new Rectangle(select.spriteX, select.spriteY, select.spriteWidth, select.spriteHeight), units);
        }
        if (buttons.Start)
        {
            g.DrawImage(sprite, start.drawX, start.drawY, new Rectangle(start.spriteX, start.spriteY, start.spriteWidth, start.spriteHeight), units);
        }
        if (buttons.R1)
        {
            g.DrawImage(sprite, r1.drawX, r1.drawY, new Rectangle(r1.spriteX, r1.spriteY, r1.spriteWidth, r1.spriteHeight), units);
        }
        if (buttons.L1)
        {
            g.DrawImage(sprite, l1.drawX, l1.drawY, new Rectangle(l1.spriteX, l1.spriteY, l1.spriteWidth, l1.spriteHeight), units);
        }
        if (buttons.L2)
        {
            g.DrawImage(sprite, l2.drawX, l2.drawY, new Rectangle(l2.spriteX, l2.spriteY, l2.spriteWidth, l2.spriteHeight), units);
        }
        if (buttons.R2)
        {
            g.DrawImage(sprite, r2.drawX, r2.drawY, new Rectangle(r2.spriteX, r2.spriteY, r2.spriteWidth, r2.spriteHeight), units);
        }
    }

    private void InputDisplayForm_MouseDown(object sender, MouseEventArgs e)
    {
        if (Borderless && e.Button == MouseButtons.Left)
        {
            mouseDown = true;
            mouseLocation = e.Location;
        }
    }

    private void InputDisplayForm_MouseMove(object sender, MouseEventArgs e)
    {
        if (mouseDown)
        {
            this.Location = new Point(
                Location.X - mouseLocation.X + e.X,
                Location.Y - mouseLocation.Y + e.Y
                );
            Update();
        }
    }

    private void InputDisplayForm_MouseUp(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left)
            mouseDown = false;
        else if (e.Button == MouseButtons.Right)
        {
            contextMenuStrip1.Show(this, e.Location);
        }
    }

    private void borderlessToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
    {
        Borderless = borderlessToolStripMenuItem.Checked;
        State.Settings.InputDisplayBorderless = Borderless;
    }

    private void backgroundColorToolStripMenuItem_Click(object sender, EventArgs e)
    {
        colorDialog1.Color = BackColor;
        if (colorDialog1.ShowDialog() == DialogResult.OK)
        {
            BackColor = colorDialog1.Color;
            State.Settings.InputDisplayBackColor = BackColor;
        }
    }

    private void hideToolStripMenuItem_Click(object sender, EventArgs e)
    {
        Hide();
    }
}
