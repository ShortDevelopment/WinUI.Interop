namespace WinUI.Interop.WinRT
{
    /// <summary>
    /// Represents the trust level of an activatable class. <br />
    /// <see href="https://docs.microsoft.com/en-us/windows/win32/api/inspectable/ne-inspectable-trustlevel">TrustLevel enumeration</see>
    /// </summary>
    public enum TrustLevel
    {
        /// <summary>
        /// The component has access to resources that are not protected.
        /// </summary>
        BaseTrust = 0,
        /// <summary>
        /// The component has access to resources requested in the app manifest and approved by the user.
        /// </summary>
        PartialTrust,
        /// <summary>
        /// The component requires the full privileges of the user.
        /// </summary>
        FullTrust
    }
}
