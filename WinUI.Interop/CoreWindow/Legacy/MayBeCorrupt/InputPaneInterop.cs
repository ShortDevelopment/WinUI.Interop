﻿using System;
using Windows.UI.ViewManagement;

namespace WinUI.Interop.CoreWindow.Legacy
{
    //MIDL_INTERFACE("75CF2C57-9195-4931-8332-F0B409E916AF")
    //IInputPaneInterop : public IInspectable
    //{
    //public:
    //    virtual HRESULT STDMETHODCALLTYPE GetForWindow(
    //        /* [in] */ __RPC__in HWND appWindow,
    //        /* [in] */ __RPC__in REFIID riid,
    //        /* [iid_is][retval][out] */ __RPC__deref_out_opt void** inputPane) = 0;

    //};
    [System.Runtime.InteropServices.Guid("75CF2C57-9195-4931-8332-F0B409E916AF")]
    [System.Runtime.InteropServices.InterfaceType(System.Runtime.InteropServices.ComInterfaceType.InterfaceIsIInspectable)]
    public interface IInputPaneInterop
    {
        InputPane GetForWindow(IntPtr appWindow, [System.Runtime.InteropServices.In] ref Guid riid);
    }

    [Obsolete("https://docs.microsoft.com/en-us/windows/apps/desktop/modernize/winrt-com-interop-csharp#available-interop-classes")]
    public static class InputPaneInterop
    {
        public static InputPane GetForWindow(IntPtr hWnd)
        {
            IInputPaneInterop inputPaneInterop = (IInputPaneInterop)InteropHelper.GetActivationFactory<IInputPaneInterop>(typeof(InputPane));
            Guid guid = typeof(InputPane).GUID;

            return inputPaneInterop.GetForWindow(hWnd, ref guid);
        }
    }
}
