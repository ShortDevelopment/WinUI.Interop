﻿#if USING_WINUI
using Microsoft.UI.Xaml;
using WinRT;
#endif

using System;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;

namespace WinUI.Interop.NativeWindow
{
    public static class WindowExtensions
    {
        private static void SetIcon(IntPtr hWnd, string resourceName)
        {
            using (Stream stream = Assembly.GetEntryAssembly().GetManifestResourceStream(resourceName))
            {
                Icon icon = new(stream);
                SendMessage(hWnd, WM_SETICON, IntPtr.Zero, icon.Handle);
            }
        }

        public static void SetIcon(this IWindowNative window, string resourceName) => SetIcon(window.WindowHandle, resourceName);

#if USING_WINUI
        /// <summary>
        /// <see href="https://github.com/microsoft/microsoft-ui-xaml/issues/4056"/>
        /// </summary>
        public static void SetIcon(this Window window, string resourceName) => SetIcon(window.As<IWindowNative>().WindowHandle, resourceName);
#endif

        #region SendMessage
        private const uint WM_SETICON = 0x0080;

        [DllImport("user32")]
        private static extern void SendMessage(IntPtr hWnd, uint msgId, IntPtr reserved, IntPtr hIcon);
        #endregion
    }
}