using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
#if NET5_0_OR_GREATER
using WinRT;
#endif

namespace WinUI.Interop.AppContainer.Audio
{
    /// <summary>
    /// <see href="https://gist.github.com/wbokkers/74e05ccc1ee2371ec55c4a7daf551a26"/>
    /// </summary>
    public static class AudioInterfaceActivator
    {
        public static Task<T> ActivateAudioInterfaceAsync<T>(string deviceInterfacePath)
            => ActivateAudioInterfaceAsync<T>(deviceInterfacePath, IntPtr.Zero);

        public static async Task<T> ActivateAudioInterfaceAsync<T>(string deviceInterfacePath, IntPtr activationParams)
        {
            ActivateAudioInterfaceCompletionHandler<T> activationHandler = new();
            Marshal.ThrowExceptionForHR(ActivateAudioInterfaceAsyncInternal(deviceInterfacePath, typeof(T).GUID, activationParams, activationHandler, out _));
            return await activationHandler;
        }

        [DllImport("Mmdevapi.dll", EntryPoint = "ActivateAudioInterfaceAsync", CharSet = CharSet.Unicode, ExactSpelling = true), PreserveSig]
        private static extern int ActivateAudioInterfaceAsyncInternal(
            [In][MarshalAs(UnmanagedType.LPWStr)] string deviceInterfacePath,
            [In][MarshalAs(UnmanagedType.LPStruct)] Guid riid,
            [In] IntPtr activationParams,
            [In] IActivateAudioInterfaceCompletionHandler completionHandler,
            out IActivateAudioInterfaceAsyncOperation activationOperation
        );

        private class ActivateAudioInterfaceCompletionHandler<T> : IActivateAudioInterfaceCompletionHandler
        {
            private TaskCompletionSource<T> promise = new();

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

            public TaskAwaiter<T> GetAwaiter()
                => promise.Task.GetAwaiter();
        }
    }
}
