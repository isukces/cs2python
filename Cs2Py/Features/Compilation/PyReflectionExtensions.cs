using System;
using System.IO;
using System.Reflection;
using System.Text;

namespace Cs2Py.Compilation
{
    public static class _ReflectionExtensions
    {
        public static FileInfo GetCodeLocation(this Assembly a)
        {
            var assemblyPath = a.CodeBase;
            if (!Uri.TryCreate(assemblyPath, UriKind.RelativeOrAbsolute, out var uri))
                return new FileInfo(assemblyPath);
            if (uri.Scheme != Uri.UriSchemeFile)
                throw new Exception(string.Format("Unsupported protocol in URI {0}", assemblyPath));
            return new FileInfo(uri.LocalPath);
        }

        public static string GetMethodHeader(this MethodInfo method)
        {
            var builder = new StringBuilder();
            builder.Append(GetVisibility(method.IsPublic, method.IsPrivate) + " ");
            builder.Append(TypesUtil.TypeToString(method.ReturnType) + " ");
            builder.Append(method.Name);
            builder.Append("(");
            bool addC = false;
            foreach (var a in method.GetParameters())
            {
                if (a.IsDefined(typeof(ParamArrayAttribute)))
                    builder.Append("params ");
                if (addC) builder.Append(", ");
                addC = true;
                if (a.IsOut)
                    builder.Append("out ");
                else if (a.IsRetval)
                    builder.AppendFormat("ref");
                builder.AppendFormat("{0} {1}", TypesUtil.TypeToString(a.ParameterType), a.Name);
                if (a.HasDefaultValue)
                {
                    builder.AppendFormat(" = {0}", TypesUtil.CSValueToString(a.DefaultValue));
                }
            }

            builder.Append(")");
            return builder.ToString();
        }

        // Public Methods 

        public static string IdString(this Type type)
        {
            var result = type.AssemblyQualifiedName;
            if (result != null) return result;
            if (type.DeclaringMethod == null) return result;
            if (type.DeclaringMethod.ReflectedType != null)
                return type.DeclaringMethod.ReflectedType.AssemblyQualifiedName + "/" + type.Name;
            return result;
        }

        private static string GetVisibility(bool isPublic, bool isPrivate)
        {
            if (isPublic)
                return "public";
            return isPrivate ? "private" : "protected";
        }
    }
}