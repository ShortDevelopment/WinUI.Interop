using System;
using System.Runtime.InteropServices;
using Windows.Foundation;
using Windows.Graphics.Printing3D;

namespace WinUI.Interop.CoreWindow
{
    [Guid("9CA31010-1484-4587-B26B-DDDF9F9CAECD")]
    [InterfaceType(ComInterfaceType.InterfaceIsIInspectable)]
    public interface IPrinting3DManagerInterop
    {
        Print3DManager GetForWindow(IntPtr appWindow, [In] ref Guid riid);
        IAsyncOperation<bool> ShowPrintUIForWindowAsync(IntPtr appWindow, [In] ref Guid riid);
    }

    //Helper to initialize Print3DManager
    public static class Print3DManagerInterop
    {
        public static Print3DManager GetForWindow(IntPtr hWnd)
        {
            Guid iid = typeof(Print3DManager).GUID;
            IPrinting3DManagerInterop factory = InteropHelper.GetActivationFactory<IPrinting3DManagerInterop>(typeof(Print3DManager));
            return factory.GetForWindow(hWnd, ref iid);
        }
        public static IAsyncOperation<bool> ShowPrintUIForWindowAsync(IntPtr hWnd)
        {
            Guid iid = typeof(IAsyncOperation<bool>).GUID;
            IPrinting3DManagerInterop factory = InteropHelper.GetActivationFactory<IPrinting3DManagerInterop>(typeof(Print3DManager));
            return factory.ShowPrintUIForWindowAsync(hWnd, ref iid);
        }
    }
}
