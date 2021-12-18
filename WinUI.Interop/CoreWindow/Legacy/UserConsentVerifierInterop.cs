using System;
using System.Runtime.InteropServices;
using Windows.Foundation;
using Windows.Security.Credentials.UI;

namespace WinUI.Interop.CoreWindow.Legacy
{
    [ComImport, Guid("39E050C3-4E74-441A-8DC0-B81104DF949C")]
    [InterfaceType(ComInterfaceType.InterfaceIsIInspectable)]
    public interface IUserConsentVerifierInterop
    {
        IAsyncOperation<UserConsentVerificationResult> RequestVerificationForWindowAsync(IntPtr appWindow, [MarshalAs(UnmanagedType.HString)] string Message, [In] ref Guid riid);
    }

    [Obsolete("https://docs.microsoft.com/en-us/windows/apps/desktop/modernize/winrt-com-interop-csharp#available-interop-classes")]
    public static class UserConsentVerifierInterop
    {
        public static IAsyncOperation<UserConsentVerificationResult> RequestVerificationForWindowAsync(IntPtr hWnd, string Message)
        {
            Guid iid = typeof(IAsyncOperation<UserConsentVerificationResult>).GUID;
            IUserConsentVerifierInterop factory = InteropHelper.GetActivationFactory<IUserConsentVerifierInterop>(typeof(UserConsentVerifier));
            return factory.RequestVerificationForWindowAsync(hWnd, Message, ref iid);
        }
    }
}
