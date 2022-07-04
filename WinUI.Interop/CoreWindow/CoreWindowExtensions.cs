#if NETSTANDARD
using System;
using Windows.UI.Xaml;

namespace WinUI.Interop.CoreWindow
{
    public static class CoreWindowExtensions
    {
        public static IntPtr GetHwnd(this Window window)
            => window.CoreWindow.GetHwnd();

        public static IntPtr GetHwnd(this Windows.UI.Core.CoreWindow window)
            => (window as object as ICoreWindowInterop)!.WindowHandle;
    }
}
#endif