﻿#if USING_WINUI
using Microsoft.UI;
using WinUIAppWindow = Microsoft.UI.Windowing.AppWindow;
using Microsoft.UI.Xaml;
using System;
using WinRT;
#endif

namespace WinUI.Interop.NativeWindow
{
    /// <summary>
    /// Provides Extension for the <c>WinUI</c> <see cref="Microsoft.UI.Xaml.Window"/> <br/>
    /// Can be used with any <c>Win32</c> Window
    /// </summary>
    public static partial class WindowExtensions
    {
#if USING_WINUI
        /// <summary>
        /// Get's the handle of a <c>WinUI</c> <see cref="Microsoft.UI.Xaml.Window"/>
        /// </summary>
        /// <param name="window">Reference to a <c>WinUI</c> <see cref="Microsoft.UI.Xaml.Window"/></param>
        public static IntPtr GetHandle(this Window window) => window.As<IWindowNative>().WindowHandle;

        /// <summary>
        /// Get's the <see cref="AppWindow"/> that is assigned to the <c>WinUI</c> <see cref="Window"/>
        /// </summary>
        /// <param name="window">Reference to a <c>WinUI</c> <see cref="Microsoft.UI.Xaml.Window"/></param>
        /// <returns></returns>
        public static WinUIAppWindow GetAppWindow(this Window window)
        {
            IntPtr hWnd = window.GetHandle();
            var winId = Win32Interop.GetWindowIdFromWindow(hWnd);
            return WinUIAppWindow.GetFromWindowId(winId);
        }
#endif
    }
}
