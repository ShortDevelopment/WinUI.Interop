using System;
using System.Runtime.InteropServices;

namespace WinUI.Interop.AppContainer.Audio
{
    /// <summary>
    /// Represents an asynchronous operation activating a WASAPI interface and provides a method to retrieve the results of the activation.
    /// </summary>
    [ComImport]
    [Guid("72A22D78-CDE4-431D-B8CC-843A71199B6D")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IActivateAudioInterfaceAsyncOperation
    {
        [PreserveSig]
        int GetActivateResult(out int activateResult, [MarshalAs(UnmanagedType.IUnknown)] out object activatedInterface);
    }
}
