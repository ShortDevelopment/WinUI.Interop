using System;

namespace WinUI.Interop
{

    public class InteropHelper
    {
        public static Guid GetIID<T>()
        {
            return GetIID(typeof(T));
        }

        public static Guid GetIID<T>(string interfaceName)
        {
            return GetIID(typeof(T).GetInterface(interfaceName));
        }

        public static Guid GetIID(Type type)
        {
            return type.GUID;
        }
    }

}
