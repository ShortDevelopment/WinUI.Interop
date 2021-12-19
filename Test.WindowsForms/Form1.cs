using System;
using System.Diagnostics;
using System.Windows.Forms;
using Windows.ApplicationModel.DataTransfer;
using Windows.UI.ApplicationSettings;
using WinUI.Interop;
using WinUI.Interop.CoreWindow;
using WinUI.Interop.CoreWindow.Legacy;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            MessageBox.Show($"IsAppContainer: {InteropHelper.IsAppContainer()}; HasPackageIdentity: {InteropHelper.HasPackageIdentity()}");
        }

        private async void Button1_Click(object sender, EventArgs e)
        {
            await AppServiceConnectionExtendedExecution.OpenForExtendedExecutionAsync();
            DataTransferManager dataTransferManager = DataTransferManagerInterop.GetForWindow(this.Handle);
            DataTransferManagerInterop.ShowShareUIForWindow(Process.GetCurrentProcess().MainWindowHandle);
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            await UserConsentVerifierInterop.RequestVerificationForWindowAsync(this.Handle, "Are you okay with that?!");
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            AccountsSettingsPane accountsSettingsPane = AccountsSettingsPaneInterop.GetForWindow(this.Handle);
            // accountsSettingsPane.AccountCommandsRequested += AccountsSettingsPane_AccountCommandsRequested;
            await AccountsSettingsPaneInterop.ShowManagedAccountsForWindowAsync(this.Handle);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SystemMediaTransportControlsInterop.GetForWindow(this.Handle);
        }
    }
}
