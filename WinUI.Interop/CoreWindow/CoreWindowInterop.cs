using System;
using System.Runtime.InteropServices;
#if NET5_0_OR_GREATER
using WinRT;
#endif

namespace WinUI.Interop.CoreWindow
{
    /// <summary>
    /// Enables apps to obtain the window handle of the window (<see cref="Windows.UI.Core.CoreWindow"/>) associated with this interface.
    /// </summary>
    [ComImport, Guid("45D64A29-A63E-4CB6-B498-5781D298CB4F")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWindowInterop
    {
        /// <summary>
        /// Obtains the handle (HWND) to the CoreWindow for an app.
        /// </summary>
        IntPtr WindowHandle { get; }

        /// <summary>
        /// Sets whether or not the message to the CoreWindow has been handled.
        /// </summary>
        bool MessageHandled { set; }
    }

    /// <summary>
    /// Get low-level information about a <see cref="Windows.UI.Core.CoreWindow"/> (e.g. its handle)
    /// </summary>
    public static class CoreWindowInterop
    {
        /// <summary>
        /// Get's the <see cref="ICoreWindowInterop"/> for the <see cref="Windows.UI.Core.CoreWindow"/> of the current thread
        /// </summary>
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

        /// <summary>
        /// Handle of the <see cref="Windows.UI.Core.CoreWindow"/> of the current thread
        /// </summary>
        public static IntPtr CoreWindowHwnd { get => Instance.WindowHandle; }

        /// <summary>
        /// Handle of the <c>ApplicationFrameWindow</c> of the current thread. <br/>
        /// This window is hosted by another process!
        /// </summary>
        public static IntPtr FrameWindowHwnd { get => GetParent(CoreWindowHwnd); }

        [DllImport("user32.dll", SetLastError = true)]
        private static extern IntPtr GetParent(IntPtr hWnd);
    }
}
