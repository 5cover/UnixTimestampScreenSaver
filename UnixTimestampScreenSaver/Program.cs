using System;
using System.Drawing;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Windows.Forms;

using UnixTimestampScreenSaver.Properties;

namespace Scover.UnixTimestampScreenSaver;

internal static class Program
{
    public static readonly ColorConverter colorConverter = new();
    public static readonly FontConverter fontConverter = new();

    public static Color TimestampColor
    {
        get => (Color)colorConverter.ConvertFromInvariantString(Settings.TimestampColor);
        private set => Settings.TimestampColor = colorConverter.ConvertToInvariantString(value);
    }

    public static Font TimestampFont
    {
        get => (Font)fontConverter.ConvertFromInvariantString(Settings.TimestampFont);
        private set => Settings.TimestampFont = fontConverter.ConvertToInvariantString(value);
    }

    private static Settings Settings => Settings.Default;

    private static void Configure(IWin32Window? owner = null)
    {
        var fontDlg = new FontDialog()
        {
            ShowColor = true,
            Color = TimestampColor,
            Font = TimestampFont,
        };
        if (fontDlg.ShowDialog(owner) == DialogResult.OK)
        {
            TimestampColor = fontDlg.Color;
            TimestampFont = fontDlg.Font;
            Settings.Save();
        }
    }

    [STAThread]
    private static int Main(string[] args)
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);

        if (args.Length == 0)
        {
            Configure(new Win32Window(GetForegroundWindow()));
        }
        else
        {
            const StringComparison Comp = StringComparison.OrdinalIgnoreCase;
            switch (args[0])
            {
                case var arg when arg.Equals("/c", Comp): // configure
                    Configure();
                    break;
                case var arg when arg.Equals("/s", Comp): // run
                    Application.Run(new ScreenSaverAppContext());
                    break;
                case var arg when arg.Equals("/p", Comp): // preview
                    if (args.Length > 1 && ulong.TryParse(args[1], NumberStyles.None, CultureInfo.InvariantCulture, out var hwnd))
                    {
                        Application.Run(new ScreenSaverAppContext(new Win32Window((nint)hwnd)));
                    }
                    else
                    {
                        return 1;
                    }
                    break;
            }
        }

        return 0;

        [DllImport("user32.dll")]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        static extern IntPtr GetForegroundWindow();
    }
}