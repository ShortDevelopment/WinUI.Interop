using System;
using System.Runtime.InteropServices;
using Windows.Media;

namespace WinUI.Interop.CoreWindow.Legacy
{

    [ComImport, Guid("ddb0472d-c911-4a1f-86d9-dc3d71a95f5a")]
    [InterfaceType(ComInterfaceType.InterfaceIsIInspectable)]
    interface ISystemMediaTransportControlsInterop
    {
        SystemMediaTransportControls GetForWindow(IntPtr appWindow, [In] ref Guid riid);
    }

    [Obsolete("https://docs.microsoft.com/en-us/windows/apps/desktop/modernize/winrt-com-interop-csharp#available-interop-classes")]
    public static class SystemMediaTransportControlsInterop
    {
        public static SystemMediaTransportControls GetForWindow(IntPtr hWnd)
        {
            Guid iid = InteropHelper.GetIID<SystemMediaTransportControls>();
            ISystemMediaTransportControlsInterop factory = InteropHelper.GetActivationFactory<ISystemMediaTransportControlsInterop>(typeof(SystemMediaTransportControls));
            return factory.GetForWindow(hWnd, ref iid);
        }
    }
}
