using System;
using System.Runtime.InteropServices;

namespace WinUI.Interop.NativeWindow
{
    [ComImport]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("EECDBF0E-BAE9-4CB6-A68E-9598E1CB57BB")]
    public interface IWindowNative
    {
        IntPtr WindowHandle { get; }
    }
}
