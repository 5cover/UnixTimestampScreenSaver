using System;
using System.Drawing;
using System.Windows.Forms;

namespace Scover.UnixTimestampScreenSaver;

internal sealed partial class ScreenSaverForm : Form
{
    private readonly Timer _timer = new()
    {
        Interval = 1000,
    };

    private Point _lastMousePos;

    public ScreenSaverForm(Screen screen)
    {
        InitializeComponent();

        Bounds = screen.Bounds;
        TopMost = true;

        labelTimestamp.Font = Program.TimestampFont;
        labelTimestamp.ForeColor = Program.TimestampColor;

        _timer.Tick += (s, e) => labelTimestamp.Text = DateTimeOffset.Now.ToUnixTimeSeconds().ToString();
    }

    private void ScreenSaverForm_FormClosed(object sender, EventArgs e) => _timer.Stop();

    private void ScreenSaverForm_KeyDown(object sender, KeyEventArgs e) => Close();

    private void ScreenSaverForm_Load(object sender, EventArgs e)
    {
        Cursor.Hide();
        _timer.Start();
    }

    private void ScreenSaverForm_OnMouseEvent(object sender, MouseEventArgs e)
    {
        if (!_lastMousePos.IsEmpty && (_lastMousePos != new Point(e.X, e.Y) || e.Clicks > 0))
        {
            Close();
        }
        else
        {
            _lastMousePos = new Point(e.X, e.Y);
        }
    }
}