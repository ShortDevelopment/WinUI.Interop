using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
#if NET5_0_OR_GREATER
using WinRT;
#endif

namespace WinUI.Interop.AppContainer
{
    /// <summary>
    /// <see href="https://gist.github.com/wbokkers/74e05ccc1ee2371ec55c4a7daf551a26"/>
    /// </summary>
    public class AudioInterfaceActivator
    {
        public static async Task<T> ActivateAudioInterfaceAsync<T>(string deviceInterfacePath)
        {
            ActivateAudioInterfaceCompletionHandler<T> activationHandler = new ActivateAudioInterfaceCompletionHandler<T>();
            ActivateAudioInterfaceAsyncInternal(deviceInterfacePath, typeof(T).GUID, IntPtr.Zero, activationHandler, out _);
            return await activationHandler;
        }

        [DllImport("Mmdevapi.dll", EntryPoint = "ActivateAudioInterfaceAsync"), PreserveSig]
        private static extern uint ActivateAudioInterfaceAsyncInternal([In][MarshalAs(UnmanagedType.LPWStr)] string deviceInterfacePath, [In][MarshalAs(UnmanagedType.LPStruct)] Guid riid, [In] IntPtr activationParams, [In] IActivateAudioInterfaceCompletionHandler completionHandler, out IActivateAudioInterfaceAsyncOperation activationOperation);

        [ComImport]
        [Guid("72A22D78-CDE4-431D-B8CC-843A71199B6D")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        private interface IActivateAudioInterfaceAsyncOperation
        {
            void GetActivateResult([MarshalAs(UnmanagedType.Error)] out int activateResult, [MarshalAs(UnmanagedType.IUnknown)] out object activatedInterface);
        }

        private class ActivateAudioInterfaceCompletionHandler<T> : IActivateAudioInterfaceCompletionHandler
        {
            private TaskCompletionSource<T> promise = new TaskCompletionSource<T>();

            public void ActivateCompleted(IActivateAudioInterfaceAsyncOperation activateOperation)
            {
                activateOperation.GetActivateResult(out int activateResult, out object activatedInterface);

                if (activateResult != 0)
                    promise.SetException(new Win32Exception(activateResult));

#if NET5_0_OR_GREATER
                promise.SetResult(activatedInterface.As<T>());
#else
                promise.SetResult((T)activatedInterface);
#endif
            }

            public TaskAwaiter<T> GetAwaiter() => promise.Task.GetAwaiter();
        }

        [ComImport]
        [Guid("41D949AB-9862-444A-80F6-C261334DA5EB")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        private interface IActivateAudioInterfaceCompletionHandler
        {
            void ActivateCompleted(IActivateAudioInterfaceAsyncOperation activateOperation);
        }
    }

}
