using System;
using System.Reflection;
using System.Runtime.InteropServices;

#if NET5_0_OR_GREATER
using WinRT;
#else
using System.Runtime.InteropServices.WindowsRuntime;
#endif

namespace WinUI.Interop
{
    public static class InteropHelper
    {
        /// <summary>
        /// Get's the default interface id of a <c>WinRT</c> class
        /// </summary>
        /// <typeparam name="T"><c>WinRT</c> class</typeparam>
        /// <returns></returns>
        public static Guid GetIID<T>()
        {
#if NET5_0_OR_GREATER
            if (TryGetDefaultInterfaceTypeForRuntimeClassType(typeof(T), out Type defaultInterfaceType))
                return GuidGenerator.GetIID(defaultInterfaceType);
            return GuidGenerator.GetIID(typeof(T));
#else
            return typeof(T).GetInterface("I" + typeof(T).Name)?.GUID ?? typeof(T).GUID;
#endif
        }

#if NET5_0_OR_GREATER
        /// <summary>
        /// <see href="https://github.com/microsoft/CsWinRT/blob/master/src/WinRT.Runtime/Projections.cs#L378-L397"/>
        /// </summary>
        public static bool TryGetDefaultInterfaceTypeForRuntimeClassType(Type runtimeClass, out Type defaultInterface)
        {
            runtimeClass = runtimeClass.GetRuntimeClassCCWType() ?? runtimeClass;
            defaultInterface = null;

            ProjectedRuntimeClassAttribute attr = runtimeClass.GetCustomAttribute<ProjectedRuntimeClassAttribute>();
            if (attr is null)
                return false;

            if (attr.DefaultInterfaceProperty != null)
                defaultInterface = runtimeClass.GetProperty(attr.DefaultInterfaceProperty, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly).PropertyType;
            else
                defaultInterface = attr.DefaultInterface;

            return true;
        }
#endif

        public static TInteropInterface GetActivationFactory<TClass, TInteropInterface>()
            => GetActivationFactory<TInteropInterface>(typeof(TClass));

        public static T GetActivationFactory<T>(Type classType)
        {
#if NET5_0_OR_GREATER
            try
            {
                // ToDo: Improve this (performance)!
                var method = classType.GetMethod("As", BindingFlags.Static | BindingFlags.Public);
                return method.MakeGenericMethod(new[] { typeof(T) }).Invoke(null, null).As<T>();
            }
            catch (Exception ex)
            {
                throw new PlatformNotSupportedException("Please use the built-in net5.0 interops!" + Environment.NewLine + "https://docs.microsoft.com/en-us/windows/apps/desktop/modernize/winrt-com-interop-csharp#available-interop-classes", ex);
            }
#else
            return (T)WindowsRuntimeMarshal.GetActivationFactory(classType);
#endif
        }

        public static T CastWinRTObject<T>(object value)
        {
#if NET5_0_OR_GREATER
            return MarshalInterface<T>.FromAbi(Marshal.GetIUnknownForObject(value));
#else
            return (T)value;
#endif
        }
    }
}