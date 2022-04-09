using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Text;

namespace WinUI.Interop
{
    public static class RuntimeInformation
    {
        /// <summary>
        /// <see langword="true" /> if <see cref="HasPackageIdentity"/> and <see cref="IsAppContainer"/>
        /// </summary>
        public static bool IsUWP { get => HasPackageIdentity && IsAppContainer; }

        /// <summary>
        /// <see langword="true" /> if <see cref="HasPackageIdentity"/> and not <see cref="IsAppContainer"/>
        /// </summary>
        /// <returns></returns>
        public static bool IsPackagedWin32 { get => HasPackageIdentity && !IsAppContainer; }

        /// <summary>
        /// <see langword="true" /> if not <see cref="HasPackageIdentity"/> and not <see cref="IsAppContainer"/>
        /// </summary>
        /// <returns></returns>
        public static bool IsUnpackagedWin32 { get => !HasPackageIdentity && !IsAppContainer; }

        #region HasPackageIdentity
        public static bool HasPackageIdentity
        {
            get
            {
                int length = 0;
                GetCurrentPackageFullName(ref length, null);
                StringBuilder sb = new StringBuilder(length);
                int hResult = GetCurrentPackageFullName(ref length, sb);
                if (hResult == 0)
                    return true;
                if (hResult == APPMODEL_ERROR_NO_PACKAGE)
                    return false;
                throw new Win32Exception(hResult);
            }
        }

        private const int APPMODEL_ERROR_NO_PACKAGE = 15700;

        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true, ExactSpelling = true)]
        private extern static int GetCurrentPackageFullName(ref int packageFullNameLength, StringBuilder packageFullName);
        #endregion

        #region IsAppContainer
        public static bool IsAppContainer
        {
            get
            {
                uint result = 0;
                uint size = sizeof(uint);
                if (!GetTokenInformation((IntPtr)CurrentProcessPseudoToken, TokenIsAppContainer, ref result, ref size, out size))
                    throw new Win32Exception(Marshal.GetLastWin32Error());
                return Convert.ToBoolean(result);
            }
        }

        private const int TokenIsAppContainer = 29;

        private const int CurrentProcessPseudoToken = -4;

        [DllImport("Advapi32.dll", SetLastError = true, ExactSpelling = true)]
        private extern static bool GetTokenInformation(IntPtr TokenHandle, uint TokenInformationClass, ref uint TokenInformation, ref uint TokenInformationLength, out uint ReturnLength);
        #endregion

        #region Capability
        public static bool HasCapability(string capability)
        {
            Marshal.ThrowExceptionForHR(CapabilityCheck(IntPtr.Zero, capability, out bool result));
            return result;
        }

        [DllImport("sechost.dll", SetLastError = true), PreserveSig]
        private static extern int CapabilityCheck(IntPtr ptr, string capability, out bool result);
        #endregion
    }
}
