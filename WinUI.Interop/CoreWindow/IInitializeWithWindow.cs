using System;
using System.Runtime.InteropServices;

namespace WinUI.Interop.CoreWindow
{
    /// <summary>
    /// Exposes a method through which a client can provide an owner window to a Windows Runtime (WinRT) object used in a desktop application. <br/>
    /// (e.g. implemented by <see cref="Windows.Storage.Pickers.FileOpenPicker"/>) <br/>
    /// <see href="https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nn-shobjidl_core-iinitializewithwindow"/>
    /// </summary>
    [ComImport]
    [Guid("3E68D4BD-7135-4D10-8018-9FB6D9F33FA1")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IInitializeWithWindow
    {
        /// <summary>
        /// Specifies an owner window to be used by a Windows Runtime object that is used in a desktop app.
        /// </summary>
        /// <param name="hwnd"></param>
        void Initialize(IntPtr hwnd);
    }
}
