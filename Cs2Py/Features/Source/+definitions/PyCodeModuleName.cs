using System;
using System.IO;
using System.Linq;
using System.Reflection;
using Cs2Py.Compilation;
using Lang.Python;

namespace Cs2Py.Source
{
    public class PyCodeModuleName : PySourceBase, IEquatable<PyCodeModuleName>
    {
        /// <summary>
        ///     Creates instance of modulename not related to any .NET class (i.e. for config code)
        /// </summary>
        /// <param name="name"></param>
        /// <param name="isExternalModule"></param>
        public PyCodeModuleName(string name, bool isExternalModule)
        {
            Name             = name ?? throw new ArgumentNullException(nameof(name));
            Name             = Pn(Name);
            IsExternalModule = isExternalModule;
        }

        public PyCodeModuleName(Type type, bool isExternalModule, ClassTranslationInfo declaringTypeInfo)
        {
            IsExternalModule = isExternalModule;
            if ((object)type == null)
                throw new ArgumentNullException(nameof(type));
            if ((object)type.DeclaringType != null && declaringTypeInfo == null)
                throw new ArgumentNullException(nameof(declaringTypeInfo));
            Name = Pn(GetName(type, declaringTypeInfo));
        }

        private PyCodeModuleName()
        {
        }


        /// <summary>
        ///     Realizuje operator ==
        /// </summary>
        /// <param name="left">lewa strona porównania</param>
        /// <param name="right">prawa strona porównania</param>
        /// <returns><c>true</c> jeśli obiekty są równe</returns>
        public static bool operator ==(PyCodeModuleName left, PyCodeModuleName right)
        {
            if (ReferenceEquals(left, null) && ReferenceEquals(right, null)) return true;
            if (ReferenceEquals(left, null) || ReferenceEquals(right, null)) return false;
            return left.Name == right.Name && left.IsExternalModule == right.IsExternalModule;
        }

        /// <summary>
        ///     Realizuje operator !=
        /// </summary>
        /// <param name="left">lewa strona porównania</param>
        /// <param name="right">prawa strona porównania</param>
        /// <returns><c>true</c> jeśli obiekty są różne</returns>
        public static bool operator !=(PyCodeModuleName left, PyCodeModuleName right)
        {
            return !(left == right);
        }

        private static string GetName(Type type, ClassTranslationInfo declaringTypeInfo)
        {
            {
                // PageAttribute
                var pageAttribute = type.GetCustomAttribute<PageAttribute>();
                if (pageAttribute != null)
                    return pageAttribute.ModuleShortName;
            }
            {
                // ModuleAttribute
                var moduleAttribute = type.GetCustomAttribute<ModuleAttribute>();
                if (moduleAttribute != null)
                    return moduleAttribute.ModuleShortName;
            }
            if (declaringTypeInfo != null && declaringTypeInfo.ModuleName != null)
                return declaringTypeInfo.ModuleName.Name;
            return type.FullName?.Replace(".", "_").Replace("+", "__").Replace("<", "__").Replace(">", "__")
                   ?? type.Name;
        }

        private static string Pn(string value)
        {
            value = (value?.Trim() ?? string.Empty).Replace("\\", "/");
            return value;
        }
        // Private Methods 
/*
        private static string ProcessPath(string name, string relatedTo)
        {
            var p1     = Split(name);
            var p2     = Split(relatedTo);
            var common = 0;
            for (int i = 0, max = Math.Min(p1.Length, p2.Length); i < max; i++)
                if (p1[i] == p2[i])
                    common++;
                else
                    break;
            if (common > 0)
            {
                p1 = p1.Skip(common).ToArray();
                p2 = p2.Skip(common).ToArray();
            }

            var aa = new List<string>();
            for (var i = 0; i < p2.Length - 1; i++)
                aa.Add("..");
            aa.AddRange(p1);
            var g = string.Join("/", aa);
            //if (p1.Length == 1)
            //    return new PyConstValue(Name + extension);
            return g;
        }
    */
        // Private Methods 

        private static string[] Split(string name)
        {
            if (name.Contains("\\"))
                name = name.Replace("\\", "/");
            var p1   = ("/" + name).Split('/').Select(a => a.Trim()).Where(a => !string.IsNullOrEmpty(a)).ToArray();
            return p1;
        }


        /// <summary>
        ///     Sprawdza, czy wskazany obiekt jest równy bieżącemu
        /// </summary>
        /// <param name="other">obiekt do porównania z obiektem bieżącym</param>
        /// <returns><c>true</c> jeśli wskazany obiekt jest równy bieżącemu; w przeciwnym wypadku<c>false</c></returns>
        public bool Equals(PyCodeModuleName other)
        {
            return other == this;
        }

        /// <summary>
        ///     Sprawdza, czy wskazany obiekt jest równy bieżącemu
        /// </summary>
        /// <param name="other">obiekt do porównania z obiektem bieżącym</param>
        /// <returns><c>true</c> jeśli wskazany obiekt jest równy bieżącemu; w przeciwnym wypadku<c>false</c></returns>
        public override bool Equals(object other)
        {
            return other is PyCodeModuleName pyCodeModuleName && Equals(pyCodeModuleName);
        }

        /// <summary>
        ///     Zwraca kod HASH obiektu
        /// </summary>
        /// <returns>kod HASH obiektu</returns>
        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }

        public string MakeEmitPath(string basePath, int someNumber)
        {
            var p = Path.Combine(basePath, Name.Replace("/", "\\") + ".py");
            return p;
        }

        // Public Methods 


        public string MakeIncludePath(PyCodeModuleName relatedTo)
        {
            if (IsExternalModule)
                return Name;
            throw new NotImplementedException();
            return Name;
            /*
            if (relatedTo.Library == Library)
            {
                var knownPath = ProcessPath(_name + _extension, relatedTo._name + _extension);
                //dirname(__FILE__)
                var __FILE__ = new PyDefinedConstExpression("__FILE__", null);
                var dirname  = new PyMethodCallExpression("dirname", __FILE__);
                var path     = new PyConstValue(PathUtil.MakeUnixPath(PathUtil.UNIX_SEP + knownPath));
                var result   = PyBinaryOperatorExpression.ConcatStrings(dirname, path);
                return result;
            }
            else
            {
                string path      = null;
                string pathRelTo = null;
                if (PyIncludePathExpression is PyConstValue)
                {
                    path = (PyIncludePathExpression as PyConstValue).Value as string;
                    if (path == null)
                        throw new NotSupportedException();
                }
                else
                {
                    return PyIncludePathExpression; // assume expression like MPDF_LIB_PATH . 'lib/mpdf/mpdf.Py'
                }

                if (relatedTo.PyIncludePathExpression is PyConstValue)
                {
                    pathRelTo = (relatedTo.PyIncludePathExpression as PyConstValue).Value as string;
                    if (pathRelTo == null)
                        throw new NotSupportedException();
                }

                if (!string.IsNullOrEmpty(path) && !string.IsNullOrEmpty(path))
                {
                    var knownPath = ProcessPath(path, pathRelTo);
                    return new PyConstValue(knownPath);
                }

                throw new NotSupportedException();
            }
            */
        }

        /// <summary>
        ///     Zwraca tekstową reprezentację obiektu
        /// </summary>
        /// <returns>Tekstowa reprezentacja obiektu</returns>
        public override string ToString()
        {
            return Name;
        }

/*
        private void UpdateIncludePathExpression()
        {
            if (AssemblyInfo == null)
            {
                PyIncludePathExpression = null;
                return;
            }

            var pathItems = new List<IPyValue>();
            {
                var assemblyPath = AssemblyInfo.PyIncludePathExpression;
                if (assemblyPath != null)
                    pathItems.Add(assemblyPath);
            }
            if (OptionalIncludePathPrefix != null && OptionalIncludePathPrefix.Any())
                foreach (var n in OptionalIncludePathPrefix)
                    if (n.StartsWith("$"))
                        pathItems.Add(new PyVariableExpression(n, PyVariableKind.Global));
                    else
                        pathItems.Add(new PyDefinedConstExpression(n, null));
            pathItems.Add(new PyConstValue(_name + Extension));
            PyIncludePathExpression = PyBinaryOperatorExpression.ConcatStrings(pathItems.ToArray());
        }
*/
#if OLD
        public static PyCodeModuleName Cs2PyConfigModuleName => new PyCodeModuleName(CS2PY_CONFIG_MODULE_NAME, false);
        /// <summary>
        ///     Late binging module
        /// </summary>
        public const string CS2PY_CONFIG_MODULE_NAME = "*cs2Pyconfig*";
#endif

        /// <summary>
        ///     Module name without library prefix
        /// </summary>
        public string Name { get; } = string.Empty;

        public bool IsExternalModule { get; }


        /// <summary>
        ///     Indicated that name is empty; własność jest tylko do odczytu.
        /// </summary>
        public bool IsEmpty => string.IsNullOrEmpty(Name);


    }
}