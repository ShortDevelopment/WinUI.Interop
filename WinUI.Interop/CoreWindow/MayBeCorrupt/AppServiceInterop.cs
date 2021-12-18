using System;
using System.Runtime.InteropServices;
using Windows.ApplicationModel.AppService;
using Windows.Foundation;

namespace WinUI.Interop.CoreWindow
{

    [ComImport, Guid("65219584-F9CB-4AE3-81F9-A28A6CA450D9")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IAppServiceConnectionExtendedExecution
    {
        void OpenForExtendedExecutionAsync([In] ref Guid riid, [MarshalAs(UnmanagedType.Interface)] out object result);
    }

    public static class AppServiceConnectionExtendedExecution
    {
        public static IAsyncOperation<AppServiceConnectionStatus> OpenForExtendedExecutionAsync()
        {
            Guid iid = InteropHelper.GetIID<IAsyncOperation<AppServiceConnectionStatus>>();
            IAppServiceConnectionExtendedExecution appServiceConnectionStatus = InteropHelper.GetActivationFactory<IAppServiceConnectionExtendedExecution>(typeof(AppServiceConnection));
            appServiceConnectionStatus.OpenForExtendedExecutionAsync(ref iid, out var result);
            return InteropHelper.CastWinRTObject<IAsyncOperation<AppServiceConnectionStatus>>(result);
        }
    }
}
