using System;
using System.Runtime.InteropServices;
using Windows.Foundation;
using Windows.Graphics.Printing;

namespace WinUI.Interop.CoreWindow.Legacy
{
    //MIDL_INTERFACE("c5435a42-8d43-4e7b-a68a-ef311e392087")
    //IPrintManagerInterop : public IInspectable
    //{
    //public:
    //    virtual HRESULT STDMETHODCALLTYPE GetForWindow(
    //        /* [in] */ __RPC__in HWND appWindow,
    //        /* [in] */ __RPC__in REFIID riid,
    //        /* [iid_is][retval][out] */ __RPC__deref_out_opt void** printManager) = 0;

    //    virtual HRESULT STDMETHODCALLTYPE ShowPrintUIForWindowAsync(
    //        /* [in] */ __RPC__in HWND appWindow,
    //        /* [in] */ __RPC__in REFIID riid,
    //        /* [iid_is][retval][out] */ __RPC__deref_out_opt void** asyncOperation) = 0;

    //};

    [Guid("c5435a42-8d43-4e7b-a68a-ef311e392087")]
    [InterfaceType(ComInterfaceType.InterfaceIsIInspectable)]
    public interface IPrintManagerInterop
    {
        PrintManager GetForWindow(IntPtr appWindow, [In] ref Guid riid);
        IAsyncOperation<bool> ShowPrintUIForWindowAsync(IntPtr appWindow, [In] ref Guid riid);
    }

    [Obsolete("https://docs.microsoft.com/en-us/windows/apps/desktop/modernize/winrt-com-interop-csharp#available-interop-classes")]
    public static class PrintManagerInterop
    {
        public static PrintManager GetForWindow(IntPtr hWnd)
        {
            Guid iid = InteropHelper.GetIID<PrintManager>();
            IPrintManagerInterop factory = InteropHelper.GetActivationFactory<IPrintManagerInterop>(typeof(PrintManager));
            return factory.GetForWindow(hWnd, ref iid);
        }
        public static IAsyncOperation<bool> ShowPrintUIForWindowAsync(IntPtr hWnd)
        {
            Guid iid = InteropHelper.GetIID<IAsyncOperation<bool>>();
            IPrintManagerInterop factory = InteropHelper.GetActivationFactory<IPrintManagerInterop>(typeof(PrintManager));
            return factory.ShowPrintUIForWindowAsync(hWnd, ref iid);
        }
    }
}
