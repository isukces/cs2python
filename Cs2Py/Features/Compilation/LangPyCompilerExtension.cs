using System;
using System.Linq;
using System.Reflection;
using Cs2Py.Source;
using Lang.Python;

namespace Cs2Py.Compilation
{
    public static class LangPyCompilerExtension
    {
        public static string ExcName(this Type type)
        {
            return type == null
                ? "[EMPTY TYPE]"
                : (type.FullName ?? type.Name);
        }

        public static string ExcName(this FieldInfo fieldInfo)
        {
            return fieldInfo == null
                ? "[EMPTY FieldInfo]"
                : string.Format("{0}.{1}", fieldInfo.Name, fieldInfo.DeclaringType.ExcName());
        }

        public static string ExcName(this MethodInfo fieldInfo)
        {
            return fieldInfo == null
                ? "[EMPTY FieldInfo]"
                : string.Format("{0}.{1}", fieldInfo.Name, fieldInfo.DeclaringType.ExcName());
        }


        public static bool IsEmpty(this PyCodeModuleName phpCodeModuleName)
        {
            return phpCodeModuleName == null || phpCodeModuleName.IsEmpty;
        }
        
        public static T[] GetAttributes<T>(this ICustomAttributeProvider member) where T : Attribute
        {
            var attributes = member.GetCustomAttributes(true).OfType<T>().ToArray();
            if (attributes.Any())
                return attributes;
            var fn             = typeof(T).FullName;
            var checkAttribute = member.GetCustomAttributes(true).FirstOrDefault(a => a.GetType().FullName == fn);
            if (checkAttribute == null)
                return new T[0];
            var loadedAssembly          = checkAttribute.GetType().Assembly.Location;
            var expectedAssembly        = typeof(DirectCallAttribute).Assembly.Location;
            var loadedAssemblyVersion   = checkAttribute.GetType().Assembly.GetName().Version;
            var expectedAssemblyVersion = typeof(DirectCallAttribute).Assembly.GetName().Version;
            throw new Exception(string.Format("Assembly Lang.Python {0} ver {2} has been loaded instead of {1} ver {3}",
                loadedAssembly, expectedAssembly, loadedAssemblyVersion, expectedAssemblyVersion));
        }
        
        public static T GetAttribute<T>(this ICustomAttributeProvider member) where T : Attribute
        {
            var attributes = GetAttributes<T>(member);
            return attributes.FirstOrDefault();
        }

        
        public static DirectCallAttribute GetDirectCallAttribute(this MethodInfo methodInfo)
        {
            if (methodInfo == null)
                throw new ArgumentNullException(nameof(methodInfo));
            return GetAttribute<DirectCallAttribute>(methodInfo);
        }
    }
}