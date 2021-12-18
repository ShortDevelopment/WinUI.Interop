using System;
using System.Runtime.InteropServices;
using Windows.UI.Input.Spatial;

namespace WinUI.Interop.CoreWindow.Legacy
{
    [ComImport, Guid("5C4EE536-6A98-4B86-A170-587013D6FD4B")]
    [InterfaceType(ComInterfaceType.InterfaceIsIInspectable)]
    interface ISpatialInteractionManagerInterop
    {
        SpatialInteractionManager GetForWindow(IntPtr appWindow, [In] ref Guid riid);
    }

    [Obsolete("https://docs.microsoft.com/en-us/windows/apps/desktop/modernize/winrt-com-interop-csharp#available-interop-classes")]
    public static class SpatialInteractionManagerInterop
    {
        public static SpatialInteractionManager GetForWindow(IntPtr hWnd)
        {
            Guid iid = typeof(SpatialInteractionManager).GUID;
            ISpatialInteractionManagerInterop factory = InteropHelper.GetActivationFactory<ISpatialInteractionManagerInterop>(typeof(SpatialInteractionManager));
            return factory.GetForWindow(hWnd, ref iid);
        }
    }
}
