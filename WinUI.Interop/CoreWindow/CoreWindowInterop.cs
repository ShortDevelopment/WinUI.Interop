using System;
using System.Runtime.InteropServices;
#if NET5_0_OR_GREATER
using WinRT;
#endif

namespace WinUI.Interop.CoreWindow
{
    [ComImport, Guid("45D64A29-A63E-4CB6-B498-5781D298CB4F")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWindowInterop
    {
        IntPtr WindowHandle { get; }
        bool MessageHandled { get; }
    }

    public static class CoreWindowInterop
    {
        public static ICoreWindowInterop Instance
        {
            get
            {
                Windows.UI.Core.CoreWindow coreWindow = Windows.UI.Core.CoreWindow.GetForCurrentThread();
#if NET5_0_OR_GREATER
                return coreWindow.As<ICoreWindowInterop>();
#else
                return (coreWindow as object as ICoreWindowInterop);
#endif
            }
        }

        public static IntPtr CoreWindowHwnd { get => Instance.WindowHandle; }

        public static IntPtr FrameWindowHwnd { get => GetParent(CoreWindowHwnd); }

        [DllImport("user32.dll", SetLastError = true)]
        private static extern IntPtr GetParent(IntPtr hWnd);
    }
}
