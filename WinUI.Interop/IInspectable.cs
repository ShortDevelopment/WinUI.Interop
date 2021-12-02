using System;
using System.Runtime.InteropServices;

namespace WinUI.Interop
{

    [ComImport]
    [Guid("AF86E2E0-B12D-4c6a-9C5A-D7AA65101E90")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IInspectable
    {
        void GetIids(out int iidCount, [MarshalAs(UnmanagedType.LPArray)] out Guid[] iids);
        void GetRuntimeClassName(out IntPtr className);
        void GetTrustLevel(out IntPtr trustLevel);
    }

}
