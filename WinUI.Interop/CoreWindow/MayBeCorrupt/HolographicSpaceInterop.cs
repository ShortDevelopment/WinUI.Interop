using System;
using System.Runtime.InteropServices;
using Windows.Graphics.Holographic;

namespace WinUI.Interop.CoreWindow
{
    [ComImport, Guid("5C4EE536-6A98-4B86-A170-587013D6FD4B")]
    [InterfaceType(ComInterfaceType.InterfaceIsIInspectable)]
    public interface IHolographicSpaceInterop
    {
        void CreateForWindow(IntPtr appWindow, [In] ref Guid riid, [MarshalAs(UnmanagedType.Interface)] out object result);
    }

    public static class HolographicSpaceInterop
    {
        public static HolographicSpace CreateForWindow(IntPtr hWnd)
        {
            Guid iid = typeof(HolographicSpace).GUID;
            IHolographicSpaceInterop factory = InteropHelper.GetActivationFactory<IHolographicSpaceInterop>(typeof(HolographicSpace));            
            factory.CreateForWindow(hWnd, ref iid, out var result);
            return InteropHelper.CastWinRTObject<HolographicSpace>(result);
        }
    }
}
