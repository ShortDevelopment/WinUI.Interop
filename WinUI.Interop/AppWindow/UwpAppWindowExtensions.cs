using System;
using UwpAppWindow = Windows.UI.WindowManagement.AppWindow;

namespace WinUI.Interop.AppWindow;

public static class UwpAppWindowExtensions
{
    public static IntPtr GetHwnd(this UwpAppWindow window)
            => ((IApplicationWindow_HwndInterop)(object)window).WindowHandle;
}
