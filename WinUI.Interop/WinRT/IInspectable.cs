using System;
using System.Runtime.InteropServices;

namespace WinUI.Interop.WinRT
{
    [Guid("AF86E2E0-B12D-4c6a-9C5A-D7AA65101E90")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IInspectable
    {
        [PreserveSig]
        int GetIids(out int iidCount, out IntPtr iids);

        [PreserveSig]
        int GetRuntimeClassName([MarshalAs(UnmanagedType.HString)] out string className);

        [PreserveSig]
        int GetTrustLevel(out TrustLevel trustLevel);
    }
}
