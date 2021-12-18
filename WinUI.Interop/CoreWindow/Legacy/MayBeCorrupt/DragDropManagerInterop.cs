using System;
using System.Runtime.InteropServices;
using Windows.ApplicationModel.DataTransfer.DragDrop.Core;

namespace WinUI.Interop.CoreWindow.Legacy
{
    //MIDL_INTERFACE("5AD8CBA7-4C01-4DAC-9074-827894292D63")
    //IDragDropManagerInterop : public IInspectable
    //{
    //public:
    //    virtual HRESULT STDMETHODCALLTYPE GetForWindow(
    //        /* [in] */ HWND hwnd,
    //        /* [in] */ REFIID riid,
    //        /* [iid_is][out] */ void** ppv) = 0;
    //};
    [Guid("5AD8CBA7-4C01-4DAC-9074-827894292D63")]
    [InterfaceType(ComInterfaceType.InterfaceIsIInspectable)]
    public interface IDragDropManagerInterop
    {
        CoreDragDropManager GetForWindow(IntPtr hWnd, [In] ref Guid riid);
    }

    [Obsolete("https://docs.microsoft.com/en-us/windows/apps/desktop/modernize/winrt-com-interop-csharp#available-interop-classes")]
    public static class DragDropManagerInterop
    {
        public static CoreDragDropManager GetForWindow(IntPtr hWnd)
        {
            IDragDropManagerInterop dragDropManagerInterop = InteropHelper.GetActivationFactory<IDragDropManagerInterop>(typeof(CoreDragDropManager));
            Guid guid = typeof(CoreDragDropManager).GUID;

            return dragDropManagerInterop.GetForWindow(hWnd, ref guid);
        }
    }
}
