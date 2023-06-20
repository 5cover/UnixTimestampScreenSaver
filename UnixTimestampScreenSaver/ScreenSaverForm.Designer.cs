using System.Drawing;
using System.Windows.Forms;

namespace Scover.UnixTimestampScreenSaver;

partial class ScreenSaverForm
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        labelTimestamp = new Label();
        SuspendLayout();
        // 
        // labelTimestamp
        // 
        labelTimestamp.Dock = DockStyle.Fill;
        labelTimestamp.Location = new Point(0, 0);
        labelTimestamp.Name = "labelTimestamp";
        labelTimestamp.Size = new Size(300, 300);
        labelTimestamp.TabIndex = 0;
        labelTimestamp.TextAlign = ContentAlignment.MiddleCenter;
        labelTimestamp.MouseDown += ScreenSaverForm_OnMouseEvent;
        labelTimestamp.MouseMove += ScreenSaverForm_OnMouseEvent;
        // 
        // ScreenSaverForm
        // 
        BackColor = Color.Black;
        ClientSize = new Size(300, 300);
        Controls.Add(labelTimestamp);
        DoubleBuffered = true;
        FormBorderStyle = FormBorderStyle.None;
        Name = "ScreenSaverForm";
        FormClosed += ScreenSaverForm_FormClosed;
        Load += ScreenSaverForm_Load;
        KeyDown += ScreenSaverForm_KeyDown;
        ResumeLayout(false);
    }

    #endregion

    private Label labelTimestamp;
}