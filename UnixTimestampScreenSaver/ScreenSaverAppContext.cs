using System.Linq;
using System.Windows.Forms;

namespace Scover.UnixTimestampScreenSaver;

/// <summary>
/// Wraps the forms (basically, window) for each display so they are shown at the same time.
/// </summary>
internal sealed class ScreenSaverAppContext : ApplicationContext
{
    public ScreenSaverAppContext(IWin32Window? owner = null)
    {
        foreach (var form in Screen.AllScreens.Select(screen => new ScreenSaverForm(screen)))
        {
            form.FormClosed += (s, e) => ExitThread();
            form.Show(owner);
        }
    }
}