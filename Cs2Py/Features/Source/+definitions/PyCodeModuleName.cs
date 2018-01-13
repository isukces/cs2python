using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Cs2Py.CodeVisitors;
using Cs2Py.Compilation;
using Lang.Python;

namespace Cs2Py.Source
{
    public abstract class PySourceBase
    {
        public static bool EqualCode<T>(T a, T b) where T : class
        {
            if ((a is IPyValue || a == null) && (b is IPyValue || b == null))
            {
                var codeA = a == null ? "" : (a as IPyValue).GetPyCode(null);
                var codeB = a == null ? "" : (b as IPyValue).GetPyCode(null);
                return codeA == codeB;
            }
            if (a == null && b == null) return true;
            if (a == null || b == null) return false;
            return a == b;
        }
        public static bool EqualCode_Array<T>(T[] a, T[] b) where T : class
        {
            if (a == null && b == null) return true;
            if (a == null || b == null) return false;
            if (a.Length != b.Length) return false;
            for (var i = 0; i < a.Length; i++)
                if (!EqualCode(a[i], b[i]))
                    return false;
            return true;
        }
        public static bool EqualCode_List<T>(List<T> a, List<T> b) where T : class
        {
            if (a == null && b == null) return true;
            if (a == null || b == null) return false;
            if (a.Count != b.Count) return false;
            for (var i = 0; i < a.Count; i++)
                if (!EqualCode(a[i], b[i]))
                    return false;
            return true;
        }
        public PySourceItems Kind
        {
            get
            {
                return PyBaseVisitor<int>.GetKind(this);
            }
        }
    }
    public class PyCodeModuleName : PySourceBase, IEquatable<PyCodeModuleName>
    {
        /// <summary>
        ///     Creates instance of modulename not related to any .NET class (i.e. for config code)
        /// </summary>
        /// <param name="name"></param>
        /// <param name="assemblyInfo"></param>
        public PyCodeModuleName(string name, AssemblyTranslationInfo assemblyInfo)
        {
            if (assemblyInfo == null)
                throw new ArgumentNullException(nameof(assemblyInfo));
            if (name == null)
                throw new ArgumentNullException(nameof(name));

            AssemblyInfo = assemblyInfo;
            Name         = name;
        }

        public PyCodeModuleName(Type type, AssemblyTranslationInfo assemblyInfo,
            ClassTranslationInfo     declaringTypeInfo)
        {
            if (assemblyInfo == null)
                throw new ArgumentNullException(nameof(assemblyInfo));
            if ((object)type == null)
                throw new ArgumentNullException(nameof(type));
            if ((object)type.DeclaringType != null && declaringTypeInfo == null)
                throw new ArgumentNullException(nameof(declaringTypeInfo));

            AssemblyInfo = assemblyInfo;

            {
                if (type.FullName == null)
                    Name = type.Name;
                else
                    Name = type.FullName.Replace(".", "_").Replace("+", "__").Replace("<", "__").Replace(">", "__");
                // take module name from parent, this can be overrided if nested class is decorated with attributes
                if (declaringTypeInfo != null && declaringTypeInfo.ModuleName != null)
                    Name = declaringTypeInfo.ModuleName.Name;
                var ats  = type.GetCustomAttributes(false);

                #region ModuleAttribute

                {
                    var moduleAttribute = type.GetCustomAttribute<ModuleAttribute>();
                    if (moduleAttribute != null)
                    {
                        Name                      = moduleAttribute.ModuleShortName;
                        OptionalIncludePathPrefix = moduleAttribute.IncludePathPrefix;
                    }
                }

                #endregion

                #region PageAttribute

                {
                    var pageAttribute = type.GetCustomAttribute<PageAttribute>();
                    if (pageAttribute != null)
                        Name = pageAttribute.ModuleShortName;
                }

                #endregion
            }
        }

        private PyCodeModuleName()
        {
        }

        /// <summary>
        ///     Used for patch only
        /// </summary>
        public static bool IsFrameworkName(PyCodeModuleName name)
        {
            var List = "commonlanguageruntimelibrary".Split(' ');
            return List.Contains(name.Library);
        }

        /// <summary>
        ///     Realizuje operator ==
        /// </summary>
        /// <param name="left">lewa strona porównania</param>
        /// <param name="right">prawa strona porównania</param>
        /// <returns><c>true</c> jeśli obiekty są równe</returns>
        public static bool operator ==(PyCodeModuleName left, PyCodeModuleName right)
        {
            if (left == (object)null && right == (object)null) return true;
            if (left == (object)null || right == (object)null) return false;
            return left.Library == right.Library && left._name == right._name;
        }

        /// <summary>
        ///     Realizuje operator !=
        /// </summary>
        /// <param name="left">lewa strona porównania</param>
        /// <param name="right">prawa strona porównania</param>
        /// <returns><c>true</c> jeśli obiekty są różne</returns>
        public static bool operator !=(PyCodeModuleName left, PyCodeModuleName right)
        {
            if (left == (object)null && right == (object)null) return false;
            if (left == (object)null || right == (object)null) return true;
            return left.Library != right.Library || left._name != right._name;
        }
        // Private Methods 

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
            if (!(other is PyCodeModuleName)) return false;
            return Equals((PyCodeModuleName)other);
        }

        /// <summary>
        ///     Zwraca kod HASH obiektu
        /// </summary>
        /// <returns>kod HASH obiektu</returns>
        public override int GetHashCode()
        {
            // Good implementation suggested by Josh Bloch
            var _hash_ = 17;
            _hash_     = _hash_ * 31 + (Library == (object)null ? 0 : Library.GetHashCode());
            _hash_     = _hash_ * 31 + _name.GetHashCode();
            return _hash_;
        }

        // Public Methods 

        public string MakeEmitPath(string basePath, int dupa)
        {
            var p = Path.Combine(basePath, Name.Replace("/", "\\") + _extension);
            return p;
        }

        public IPyValue MakeIncludePath(PyCodeModuleName relatedTo)
        {
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
        }

        /// <summary>
        ///     Zwraca tekstową reprezentację obiektu
        /// </summary>
        /// <returns>Tekstowa reprezentacja obiektu</returns>
        public override string ToString()
        {
            return string.Format("{0}@{1}", _name, Library);
        }

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

        public static PyCodeModuleName Cs2PyConfigModuleName
        {
            get
            {
                var a  = new PyCodeModuleName();
                a.Name = CS2Py_CONFIG_MODULE_NAME;
                return a;
            }
        }

        /// <summary>
        ///     Własność jest tylko do odczytu.
        /// </summary>
        public AssemblyTranslationInfo AssemblyInfo { get; }

        /// <summary>
        ///     Library name for containing assembly; własność dopuszcza wartości NULL i jest tylko do odczytu.
        /// </summary>
        public string Library => AssemblyInfo?.LibraryName;

        /// <summary>
        ///     Module name without library prefix
        /// </summary>
        public string Name
        {
            get => _name;
            set
            {
                value = (value ?? string.Empty).Trim();
                value = value.Replace("\\", "/");
                if (value == _name) return;
                _name = value;
                UpdateIncludePathExpression();
            }
        }

        /// <summary>
        ///     defined const or variables to include before module name
        /// </summary>
        public string[] OptionalIncludePathPrefix { get; set; }

        /// <summary>
        ///     rozszerzenie nazwy pliku
        /// </summary>
        public string Extension
        {
            get => _extension;
            set => _extension = (value ?? string.Empty).Trim();
        }

        /// <summary>
        ///     Expression with complete path to this module
        /// </summary>
        public IPyValue PyIncludePathExpression { get; set; }

        /// <summary>
        ///     Indicated that name is empty; własność jest tylko do odczytu.
        /// </summary>
        public bool IsEmpty => string.IsNullOrEmpty(_name);

        private string _name      = string.Empty;
        private string _extension = ".Py";

        #region Fields

        /// <summary>
        ///     Late binging module
        /// </summary>
        public const string CS2Py_CONFIG_MODULE_NAME = "*cs2Pyconfig*";

        #endregion Fields
    }
}