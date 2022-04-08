using System;
using System.Runtime.InteropServices;

namespace WinUI.Interop.WinRT
{
    public static class IInspectableExtensions
    {
        public static unsafe Guid[] GetIids(this IInspectable inspectable)
        {
            Marshal.ThrowExceptionForHR(inspectable.GetIids(out var count, out var ptr));
            Guid[] iids = new Guid[count];
            for (int i = 0; i < count; i++)
                iids[i] = ((Guid*)ptr)[i];
            return iids;
        }

        public static string GetRuntimeClassName(this IInspectable inspectable)
        {
            Marshal.ThrowExceptionForHR(inspectable.GetRuntimeClassName(out var name));
            return name;
        }

        public static TrustLevel GetTrustLevel(this IInspectable inspectable)
        {
            Marshal.ThrowExceptionForHR(inspectable.GetTrustLevel(out var trustLevel));
            return trustLevel;
        }
    }
}
