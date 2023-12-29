# WinUI.Interop

> [!Warning]
> This package is no longer maintained, as there are better 1st and 3rd party libraries.

This package contains the interop wrappers for *WinRT*-APIs, that depend on `CoreWindow`, and other interop helpers for *WinUI* `Window` (e.g. to set an icon).   
There are also some interop components that may help from inside an AppContainer like when using *UWP*.   
   
This package is based on the work of [AdamBraden/WindowsInteropWrappers](https://github.com/AdamBraden/WindowsInteropWrappers).

---

## Examples
### *WinUI3*: window icon
> [!Tip]
> Use [WinUIEx](https://www.nuget.org/packages/WinUIEx/) instead

The `BuildAction` of the icon file has to be set to `Embedded resource` in the *Properties* window!
```csharp
using Microsoft.UI.Xaml;
using WinUI.Interop.NativeWindow;

namespace NAMESPACE
{
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
            this.SetIcon("NAMESPACE.FILENAME.ico");
        }
    }
}
```

---

### *Win32*: share content
> [!Tip]
> Use `DataTransferManagerInterop` with [CsWinRT](https://www.nuget.org/packages/Microsoft.Windows.CsWinRT) instead

```csharp
using WinUI.Interop.CoreWindow;
```
```csharp
IntPtr hwnd = Process.GetCurrentProcess().MainWindowHandle;
DataTransferManager dataTransferManager = DataTransferManagerInterop.GetForWindow(hwnd);
dataTransferManager.DataRequested += DataTransferManager_DataRequested;
```
```csharp
private async void DataTransferManager_DataRequested(DataTransferManager sender, DataRequestedEventArgs args)
{
    DataRequestDeferral deferral = request.GetDeferral();
    ... // Implementation: https://docs.microsoft.com/en-us/windows/uwp/app-to-app/share-data
    deferral.Complete();
}
```
```csharp
DataTransferManagerInterop.ShowShareUIForWindow(Process.GetCurrentProcess().MainWindowHandle);
```

### *Win32*: UWP dialog
> [!Tip]
> Use `IInitializeWithWindow` with [CsWinRT](https://www.nuget.org/packages/Microsoft.Windows.CsWinRT) instead

#### TargetFramework >= net5.0
```csharp
using WinRT;
using WinUI.Interop.CoreWindow;
```
```csharp
FileSavePicker picker = new FileSavePicker();
picker.As<IInitializeWithWindow>().Initialize(Process.GetCurrentProcess().MainWindowHandle);
...
StorageFile file = await picker.PickSaveFileAsync();
...
```
#### TargetFramework < net5.0
```csharp
using WinUI.Interop.CoreWindow;
```
```csharp
FileSavePicker picker = new FileSavePicker();
(picker as object as IInitializeWithWindow).Initialize(Process.GetCurrentProcess().MainWindowHandle);
...
StorageFile file = await picker.PickSaveFileAsync();
...
```

---

### `RuntimeInformation`
> [!Tip]
> Use [ShortDev.Uwp.FullTrust](https://www.nuget.org/packages/ShortDev.Uwp.FullTrust) instead

```csharp
using WinUI.Interop;
```
```csharp
RuntimeInformation.IsUWP;
RuntimeInformation.IsPackagedWin32;
RuntimeInformation.IsUnpackagedWin32;

RuntimeInformation.HasCapability("extendedExecutionBackgroundAudio");
```

---

### *UWP*: Lowlevel audio control
> [!Tip]
> Use `ActivateAudioInterfaceAsync` with [CsWin32](https://www.nuget.org/packages/Microsoft.Windows.CsWin32) instead

```csharp
using Windows.Media.Devices;
using WinUI.Interop.AppContainer;
```
`IAudioEndpointVolume` is not part of this package! You have to implement the audio Interfaces yourself or use implementations from other libraries like *naudio*! [docs.microsoft.com](https://docs.microsoft.com/en-us/windows/win32/api/_coreaudio/)
```csharp
public IAudioEndpointVolume VolumeManager { get; set; }
async void ...()
{
    string deviceId = MediaDevice.GetDefaultAudioRenderId(AudioDeviceRole.Default);
    VolumeManager = await AudioInterfaceActivator.ActivateAudioInterfaceAsync<IAudioEndpointVolume>(deviceId);
}
```

### *UWP*: Handle of `CoreWindow`
> [!Tip]
> Use `ICoreWindowInterop` with [CsWinRT](https://www.nuget.org/packages/Microsoft.Windows.CsWinRT) instead

```csharp
using System;
using WinUI.Interop.CoreWindow;
```
```csharp
IntPtr hWnd = CoreWindowInterop.CoreWindowHwnd;
```
or
```csharp
IntPtr hWnd = CoreWindow.GetForCurrentThread().GetHwnd();
```
or
```csharp
IntPtr hWnd = Window.Current.GetHwnd();
```

### *UWP*: Handle of `AppWindow`
```csharp
using System;
using WinUI.Interop.AppWindow;
```
```csharp
AppWindow window = ...;
IntPtr hWnd = window.GetHwnd();
```
