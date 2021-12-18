using System;
using System.Runtime.InteropServices;
using Windows.Foundation;
using Windows.Security.Authentication.Web.Core;
using Windows.Security.Credentials;

namespace WinUI.Interop.CoreWindow.Legacy
{
    [Guid("F4B8E804-811E-4436-B69C-44CB67B72084")]
    [InterfaceType(ComInterfaceType.InterfaceIsIInspectable)]
    public interface IWebAuthenticationCoreManagerInterop
    {
        IAsyncOperation<WebTokenRequestResult> RequestTokenForWindowAsync(IntPtr appWindow, WebTokenRequest request, [In] ref Guid riid);
        IAsyncOperation<WebTokenRequestResult> RequestTokenWithWebAccountForWindowAsync(IntPtr appWindow, WebTokenRequest request, WebAccount webAccount, [In] ref Guid riid);
    }

    [Obsolete("https://docs.microsoft.com/en-us/windows/apps/desktop/modernize/winrt-com-interop-csharp#available-interop-classes")]
    public static class WebAuthenticationCoreManagerInterop
    {
        public static IAsyncOperation<WebTokenRequestResult> RequestTokenForWindowAsync(IntPtr hWnd, WebTokenRequest request)
        {
            Guid iid = InteropHelper.GetIID<IAsyncOperation<WebTokenRequestResult>>();
            IWebAuthenticationCoreManagerInterop factory = InteropHelper.GetActivationFactory<IWebAuthenticationCoreManagerInterop>(typeof(WebAuthenticationCoreManager));
            return factory.RequestTokenForWindowAsync(hWnd, request, ref iid);
        }
        public static IAsyncOperation<WebTokenRequestResult> RequestTokenWithWebAccountForWindowAsync(IntPtr hWnd, WebTokenRequest request, WebAccount webAccount)
        {
            Guid iid = InteropHelper.GetIID<IAsyncOperation<WebTokenRequestResult>>();
            IWebAuthenticationCoreManagerInterop factory = InteropHelper.GetActivationFactory<IWebAuthenticationCoreManagerInterop>(typeof(WebAuthenticationCoreManager));
            return factory.RequestTokenWithWebAccountForWindowAsync(hWnd, request, webAccount, ref iid);
        }
    }
}
