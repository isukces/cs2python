using System;
using System.Globalization;
using System.Linq;
using System.Reflection;
using Cs2Py.CSharp;
using Cs2Py.Source;
using Lang.Python;

namespace Cs2Py.Compilation
{
    public class ClassTranslationInfo
    {
        /// <summary>
        ///     Tworzy instancję obiektu
        ///     <param name="type"></param>
        /// </summary>
        public ClassTranslationInfo(Type type, TranslationInfo info)
        {
            Type  = type;
            _info = info;
        }

        // Private Methods 

        private static string DotNetNameToPyName(string fullName)
        {
            if (fullName == null)
                throw new ArgumentNullException(nameof(fullName));
            fullName = fullName.Replace("`", "__");

            return string.Join("",
                from i in fullName.Replace("+", ".").Split('.')
                select PyQualifiedName.TokenNsSeparator + PyQualifiedName.SanitizePyName(i));
        }

        private static MethodInfo FindPyMainMethod(Type type)
        {
            var a  = type.GetMethods(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
            var aa = a.FirstOrDefault(i => i.Name == "PyMain");
            if (aa != null) return aa;
            aa = a.FirstOrDefault(i => i.Name == "PyMain");
            if (aa != null) return aa;
            var bb = a.Where(i => i.Name.ToLower() == "Pymain").ToArray();
            if (bb.Length == 1)
                return bb[0];
            throw new Exception(string.Format("tearful leopard: Type {0} has no PyMain method", type.FullName));
        }

        // Public Methods 

        public override string ToString()
        {
            return string.Format("{0} => {1}@{2}", Type.FullName, _scriptName, _moduleName);
        }

        private bool GetBuildIn()
        {
            Update();
            return _buildIn;
        }
        // Private Methods 

        private bool GetDontIncludeModuleForClassMembers()
        {
            Update();
            return _skip || _isArray || Type.IsEnum;
        }

        private bool GetIgnoreNamespace()
        {
            Update();
            return _ignoreNamespace;
        }

        private PyCodeModuleName GetIncluideModule()
        {
            Update();
            return _isArray || _skip ? null : _moduleName;
        }

        private bool GetIsArray()
        {
            Update();
            return _isArray;
        }

        private bool GetIsPage()
        {
            Update();
            return _isPage;
        }

        private bool GetIsReflected()
        {
            Update();
            return _isReflected;
        }

        private PyCodeModuleName GetModuleName()
        {
            Update();
            return _moduleName;
        }

        private MethodInfo GetPageMethod()
        {
            Update();
            return _pageMethod;
        }

        private PyQualifiedName GetScriptName()
        {
            Update();
            return _scriptName;
        }

        private bool GetSkip()
        {
            Update();
            return _skip;
        }

        private void Update()
        {
            if (_initialized) return;
            _initialized = true;

            var ati = _info.GetOrMakeTranslationInfo(Type.Assembly);

            var declaringTypeTranslationInfo = (object)Type.DeclaringType == null
                ? null
                : _info.GetOrMakeTranslationInfo(Type.DeclaringType);
            var ats          = Type.GetCustomAttributes(false);
            _ignoreNamespace = ats.OfType<IgnoreNamespaceAttribute>().Any();
            {
                // ScriptName
                if (_ignoreNamespace)
                    _scriptName =
                        (PyQualifiedName)PyQualifiedName
                            .SanitizePyName(Type.Name); // only short name without namespace
                else if (Type.IsGenericType)
                    _scriptName =
                        (PyQualifiedName)DotNetNameToPyName(Type.FullName ?? Type.Name); // beware of generic types
                else
                    _scriptName = (PyQualifiedName)DotNetNameToPyName(Type.FullName ?? Type.Name);

                var scriptNameAttribute = ats.OfType<ScriptNameAttribute>().FirstOrDefault();
                if (scriptNameAttribute != null)
                    if (scriptNameAttribute.Name.StartsWith(
                        PyQualifiedName.TokenNsSeparator.ToString(CultureInfo.InvariantCulture)))
                        _scriptName = (PyQualifiedName)scriptNameAttribute.Name;
                    else if (IgnoreNamespace)
                        _scriptName = (PyQualifiedName)(PyQualifiedName.TokenNsSeparator + scriptNameAttribute.Name);
                    else
                        _scriptName =
                            (PyQualifiedName)
                            (DotNetNameToPyName(Type.FullName) + PyQualifiedName.TokenNsSeparator +
                             scriptNameAttribute.Name);
                if (declaringTypeTranslationInfo != null)
                    _scriptName =
                        (PyQualifiedName)(declaringTypeTranslationInfo.ScriptName + "__" +
                                          Type.Name); // parent clas followed by __ and short name
            }

            {
                // Module name
                _moduleName = new PyCodeModuleName(Type, true, declaringTypeTranslationInfo);
            }
            {
                // PageAttribute
                var pageAttribute = ats.OfType<PageAttribute>().FirstOrDefault();
                _isPage           = pageAttribute != null;
                _pageMethod       = _isPage ? FindPyMainMethod(Type) : null;
            }
            {
                // AsArrayAttribute
                var asArrayAttribute = ats.OfType<AsArrayAttribute>().FirstOrDefault();
                _isArray             = asArrayAttribute != null;
            }
            {
                // SkipAttribute
                var skipAttribute = ats.OfType<SkipAttribute>().FirstOrDefault();
                if (skipAttribute != null)
                    _skip = true;
            }
            {
                // BuiltInAttribute
                var builtInAttribute = ats.OfType<BuiltInAttribute>().FirstOrDefault();
                if (builtInAttribute != null)
                    _buildIn = true;
            }

            if (_skip && _buildIn)
                throw new Exception("Don't mix SkipAttribute and BuiltInAttribute for type " + Type.ExcName());
            if (_buildIn)
                _skip = true;
            if (Type.IsGenericParameter)
                _skip = true;
            if (_isArray)
                _skip = true;
        }


        /// <summary>
        ///     Własność jest tylko do odczytu.
        /// </summary>
        public Type Type { get; }

        /// <summary>
        /// </summary>
        public CompilationUnit ParsedCode { get; set; }

        /// <summary>
        ///     Własność jest tylko do odczytu.
        /// </summary>
        public bool IgnoreNamespace => GetIgnoreNamespace();

        /// <summary>
        ///     Własność jest tylko do odczytu.
        /// </summary>
        public PyQualifiedName ScriptName => GetScriptName();

        /// <summary>
        ///     czy klasa ma wygenerować moduł z odpalaną metodą PyMain; własność jest tylko do odczytu.
        /// </summary>
        public bool IsPage => GetIsPage();

        /// <summary>
        ///     czy pominąć generowanie klasy; własność jest tylko do odczytu.
        /// </summary>
        public bool Skip => GetSkip();

        /// <summary>
        ///     class from host application i.e. wordpress; własność jest tylko do odczytu.
        /// </summary>
        public bool BuildIn => GetBuildIn();

        /// <summary>
        ///     czy pominąć includowanie modułu z klasą; własność jest tylko do odczytu.
        /// </summary>
        public bool DontIncludeModuleForClassMembers => GetDontIncludeModuleForClassMembers();

        /// <summary>
        ///     metoda generowana jako kod strony; własność jest tylko do odczytu.
        /// </summary>
        public MethodInfo PageMethod => GetPageMethod();

        /// <summary>
        ///     Własność jest tylko do odczytu.
        /// </summary>
        public PyCodeModuleName ModuleName => GetModuleName();

        /// <summary>
        ///     Własność jest tylko do odczytu.
        /// </summary>
        public PyCodeModuleName IncludeModule => GetIncluideModule();

        /// <summary>
        ///     Infomacja pochodzi jedynie z refleksji a nie z kodu tłumaczonego (prawdopodobnie dotyczy typu z referencyjnej
        ///     biblioteki); własność jest tylko do odczytu.
        /// </summary>
        public bool IsReflected => GetIsReflected();

        /// <summary>
        ///     Czy klasa posiada atrybut ARRAY; własność jest tylko do odczytu.
        /// </summary>
        public bool IsArray => GetIsArray();

        private          bool              _buildIn;
        private          bool              _ignoreNamespace;
        private readonly TranslationInfo   _info;
        private          bool              _initialized;
        private          bool              _isArray;
        private          bool              _isPage;
        private          bool              _isReflected;
        private          PyCodeModuleName _moduleName;
        private          MethodInfo        _pageMethod;
        private          PyQualifiedName  _scriptName;
        private          bool              _skip;
    }
}