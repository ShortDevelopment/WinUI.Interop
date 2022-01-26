#if USING_WINUI
using Microsoft.UI.Xaml;
using WinRT;
#endif

using System;

namespace WinUI.Interop.NativeWindow
{
    public static partial class WindowExtensions
    {
#if USING_WINUI
        /// <summary>
        /// Set's the handle of a <c>WinUI</c> <see cref="Microsoft.UI.Xaml.Window"/>
        /// </summary>
        /// <param name="window">Reference to a <c>WinUI</c> <see cref="Microsoft.UI.Xaml.Window"/></param>
        public static IntPtr GetHandle(this Window window) => window.As<IWindowNative>().WindowHandle;
#endif
    }
}
