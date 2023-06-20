using System;
using System.Windows.Forms;

namespace Scover.UnixTimestampScreenSaver;

internal sealed class Win32Window : IWin32Window
{
    public Win32Window(IntPtr handle)
    {
        Handle = handle;
    }

    public IntPtr Handle { get; }
}