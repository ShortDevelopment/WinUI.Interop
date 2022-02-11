#if USING_WINUI
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
    public static partial class WindowExtensions
    {
        /// <summary>
        /// Set's the icon of a <c>Win32</c> Window
        /// </summary>
        /// <param name="hWnd">Handle of the window</param>
        /// <param name="resourceName">Full qualified name of the embedded resource icon file</param>
        private static void SetIcon(IntPtr hWnd, string resourceName)
        {
            using (Stream stream = Assembly.GetEntryAssembly().GetManifestResourceStream(resourceName))
            {
                Icon icon = new(stream);
                SendMessage(hWnd, WM_SETICON, IntPtr.Zero, icon.Handle);
            }
        }

        /// <summary>
        /// Set's the icon of a <see cref="IWindowNative"/> Window
        /// </summary>
        /// <param name="window">Reference to a <see cref="IWindowNative"/> Window</param>
        /// <param name="resourceName">Full qualified name of the embedded resource icon file</param>
        public static void SetIcon(this IWindowNative window, string resourceName) => SetIcon(window.WindowHandle, resourceName);

#if USING_WINUI
        /// <summary>
        /// Set's the icon of a <c>WinUI</c> <see cref="Microsoft.UI.Xaml.Window"/> <br/>
        /// <see href="https://github.com/microsoft/microsoft-ui-xaml/issues/4056"/>
        /// </summary>
        /// <param name="window">Reference to a <c>WinUI</c> <see cref="Microsoft.UI.Xaml.Window"/></param>
        /// <param name="resourceName">Full qualified name of the embedded resource icon file</param>
        public static void SetIcon(this Window window, string resourceName) => SetIcon(window.GetHandle(), resourceName);
#endif

        #region SendMessage
        private const uint WM_SETICON = 0x0080;

        [DllImport("user32")]
        private static extern void SendMessage(IntPtr hWnd, uint msgId, IntPtr reserved, IntPtr hIcon);
        #endregion
    }
}
