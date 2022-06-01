using System;
using System.Runtime.InteropServices;

namespace WinUI.Interop.AppContainer.Audio
{
    /// <summary>
    /// Provides a callback to indicate that activation of a WASAPI interface is complete.
    /// </summary>
    [ComImport]
    [Guid("41D949AB-9862-444A-80F6-C261334DA5EB")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IActivateAudioInterfaceCompletionHandler
    {
        /// <summary>
        /// Indicates that activation of a WASAPI interface is complete and results are available.
        /// </summary>
        /// <param name="activateOperation"></param>
        void ActivateCompleted(IActivateAudioInterfaceAsyncOperation activateOperation);
    }
}
