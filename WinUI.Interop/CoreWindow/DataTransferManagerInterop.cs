using System;
using System.Runtime.InteropServices;
using Windows.ApplicationModel.DataTransfer;

namespace WinUI.Interop.CoreWindow
{
    [ComImport, Guid("3A3DCD6C-3EAB-43DC-BCDE-45671CE800C8")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IDataTransferManagerInterop
    {
        void GetForWindow(IntPtr appWindow, [In] ref Guid riid, [MarshalAs(UnmanagedType.Interface)] out object result);
        void ShowShareUIForWindow(IntPtr appWindow);
    }

    public static class DataTransferManagerInterop
    {
        public static DataTransferManager GetForWindow(IntPtr hWnd)
        {
            Guid iid = InteropHelper.GetIID<DataTransferManager>();
            IDataTransferManagerInterop factory = InteropHelper.GetActivationFactory<IDataTransferManagerInterop>(typeof(DataTransferManager));
            factory.GetForWindow(hWnd, ref iid, out var result);
            return InteropHelper.CastWinRTObject<DataTransferManager>(result);
        }

        public static void ShowShareUIForWindow(IntPtr hWnd)
        {
            IDataTransferManagerInterop dataTransferManagerInterop = InteropHelper.GetActivationFactory<IDataTransferManagerInterop>(typeof(DataTransferManager));
            dataTransferManagerInterop.ShowShareUIForWindow(hWnd);
        }
    }
}
