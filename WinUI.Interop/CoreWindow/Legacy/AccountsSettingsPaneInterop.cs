using System;
using System.Runtime.InteropServices;
using Windows.Foundation;
using Windows.UI.ApplicationSettings;

namespace WinUI.Interop.CoreWindow.Legacy
{
    [ComImport, Guid("D3EE12AD-3865-4362-9746-B75A682DF0E6")]
    [InterfaceType(ComInterfaceType.InterfaceIsIInspectable)]
    public interface IAccountsSettingsPaneInterop
    {
        AccountsSettingsPane GetForWindow([In] IntPtr appWindow, [In] ref Guid riid);
        IAsyncAction ShowManagedAccountsForWindowAsync([In] IntPtr appWindow, [In] ref Guid riid);
        IAsyncAction ShowAddAccountForWindowAsync([In] IntPtr appWindow, [In] ref Guid riid);
    }

    [Obsolete("https://docs.microsoft.com/en-us/windows/apps/desktop/modernize/winrt-com-interop-csharp#available-interop-classes")]
    public static class AccountsSettingsPaneInterop
    {
        public static AccountsSettingsPane GetForWindow(IntPtr hWnd)
        {
            Guid iid = InteropHelper.GetIID<AccountsSettingsPane>();
            IAccountsSettingsPaneInterop factory = InteropHelper.GetActivationFactory<IAccountsSettingsPaneInterop>(typeof(AccountsSettingsPane));
            return factory.GetForWindow(hWnd, ref iid);
        }
        public static IAsyncAction ShowManagedAccountsForWindowAsync(IntPtr hWnd)
        {
            Guid iid = typeof(IAsyncAction).GUID;
            IAccountsSettingsPaneInterop factory = InteropHelper.GetActivationFactory<IAccountsSettingsPaneInterop>(typeof(AccountsSettingsPane));
            return factory.ShowManagedAccountsForWindowAsync(hWnd, ref iid);
        }
        public static IAsyncAction ShowAddAccountForWindowAsync(IntPtr hWnd)
        {
            Guid iid = typeof(IAsyncAction).GUID;
            IAccountsSettingsPaneInterop factory = InteropHelper.GetActivationFactory<IAccountsSettingsPaneInterop>(typeof(AccountsSettingsPane));
            return factory.ShowAddAccountForWindowAsync(hWnd, ref iid);
        }
    }
}
