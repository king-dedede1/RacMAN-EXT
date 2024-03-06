using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace RacMAN.Forms;

/// <summary>
/// Represents a draggable handle that can be used to resize controls in the trainer designer.
/// </summary>
internal class Handle : Control
{

    private bool isDragged;
    private Control parent;
    private Point lastMouse;
    private Point startMouse;
    private Rectangle startBounds;
    private static System.Windows.Forms.Timer timer = new() {Interval = 16 };
    private const AnchorStyles center = (AnchorStyles) 0b1111;

    Handle(Control parent, AnchorStyles anchor)
    {
        Anchor = anchor;
        BackColor = Color.Black;
        this.parent = parent;

        Width = 6;
        Height = 6;

        MouseDown += Handle_MouseDown;
        MouseUp += Handle_MouseUp;
        timer.Tick += Timer_Tick;
        timer.Interval = 16;
        timer.Start();

        // position in the right corner
        this.Top = parent.Height / 2 - Height / 2;
        this.Left = parent.Width / 2 - Width / 2;
        if (Anchor != AnchorStyles.None)
        {
            if (anchor.HasFlag(AnchorStyles.Left)) this.Left = 0;
            else if (anchor.HasFlag(AnchorStyles.Right)) this.Left = parent.Width - this.Width;
            if (anchor.HasFlag(AnchorStyles.Top)) this.Top = 0;
            else if (Anchor.HasFlag(AnchorStyles.Bottom)) this.Top = parent.Height - this.Height;
        }

        // I don't think I could make more unreadable code if I tried.
        Cursor = (int)Anchor switch
        {
            0 => Cursors.SizeAll,
            1 => Cursors.SizeNS,
            2 => Cursors.SizeNS,
            4 => Cursors.SizeWE,
            5 => Cursors.SizeNWSE,
            6 => Cursors.SizeNESW,
            8 => Cursors.SizeWE,
            9 => Cursors.SizeNESW,
            10 => Cursors.SizeNWSE,
            15 => Cursors.SizeAll,
            _ => Cursors.Hand
        };
    }

    ~Handle()
    {
        timer.Stop();
    }

    // this is dumb but I just want to finish it
    private void Timer_Tick(object? sender, EventArgs e)
    {
        if (isDragged)
        {
            var deltaX = Cursor.Position.X - startMouse.X;
            var deltaY = Cursor.Position.Y - startMouse.Y;

            if (lastMouse == Cursor.Position) return;
            
            var left = startBounds.Left;
            var right = startBounds.Right;
            var top = startBounds.Top;
            var bottom = startBounds.Bottom;

            // dumb fix
            // using None works well for resizing, and center works well for moving, so use them both I guess?
            if (Anchor == AnchorStyles.None) Anchor = center;

            if (Anchor.HasFlag(AnchorStyles.Left)) left += deltaX;
            if (Anchor.HasFlag(AnchorStyles.Right)) right += deltaX;
            if (Anchor.HasFlag(AnchorStyles.Bottom)) bottom += deltaY;
            if (Anchor.HasFlag(AnchorStyles.Top)) top += deltaY;

            if (Anchor == center) Anchor = AnchorStyles.None;

            parent.SetBounds(left, top, right - left, bottom - top);
            lastMouse = Cursor.Position;

            dynamic tag = parent.Tag!;
            if (tag.GetType().GetProperty("Size") != null)
            {
                tag.Size = new Size(right - left, bottom - top);
            }
            tag.Position = new Point(left, top);
        }
    }

    private void Handle_MouseUp(object? sender, MouseEventArgs e)
    {
        isDragged = false;
    }

    private void Handle_MouseDown(object? sender, MouseEventArgs e)
    {
        isDragged = true;
        lastMouse = Cursor.Position;
        startMouse = Cursor.Position;
        startBounds = parent.Bounds;
    }

    public static void MakeSidesCornersAndCenter(Control control)
    {
        control.Controls.Add(new Handle(control, AnchorStyles.Left));
        control.Controls.Add(new Handle(control, AnchorStyles.Bottom));
        control.Controls.Add(new Handle(control, AnchorStyles.Right));
        control.Controls.Add(new Handle(control, AnchorStyles.Top));
        control.Controls.Add(new Handle(control, AnchorStyles.Bottom | AnchorStyles.Left));
        control.Controls.Add(new Handle(control, AnchorStyles.Bottom | AnchorStyles.Right));
        control.Controls.Add(new Handle(control, AnchorStyles.Top | AnchorStyles.Left));
        control.Controls.Add(new Handle(control, AnchorStyles.Top | AnchorStyles.Right));
        control.Controls.Add(new Handle(control, AnchorStyles.None));
    }

    public static void MakeLeftRightCenter(Control control)
    {
        control.Controls.Add(new Handle(control, AnchorStyles.Left));
        control.Controls.Add(new Handle(control, AnchorStyles.Right));
        control.Controls.Add(new Handle(control, AnchorStyles.None));
    }

    public static void MakeCenter(Control control)
    {
        control.Controls.Add(new Handle(control, AnchorStyles.None));
    }

}
