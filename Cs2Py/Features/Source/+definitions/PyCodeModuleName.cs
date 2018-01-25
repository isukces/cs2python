using System;
using System.IO;
using System.Linq;
using System.Reflection;
using Cs2Py.Compilation;
using JetBrains.Annotations;
using Lang.Python;

namespace Cs2Py.Source
{
    public class PyCodeModuleName : PySourceBase, IEquatable<PyCodeModuleName>
    {
        /// <summary>
        ///     Creates instance of modulename not related to any .NET class (i.e. for config code)
        /// </summary>
        /// <param name="name"></param>
        /// <param name="importName"></param>
        /// <param name="isExternalModule"></param>
        public PyCodeModuleName(string name, string importName, bool isExternalModule)
        {
            Name             = name ?? throw new ArgumentNullException(nameof(name));
            Name             = Pn(Name);
            ImportName       = Pn(importName);
            IsExternalModule = isExternalModule;
        }

        public string ImportName { get; set; }

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
                var moduleAttribute = type.GetCustomAttribute<PyModuleAttribute>();
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

        /// <summary>
        ///     Zwraca tekstową reprezentację obiektu
        /// </summary>
        /// <returns>Tekstowa reprezentacja obiektu</returns>
        public override string ToString()
        {
            return Name;
        }
 
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


        public static PyCodeModuleName FromAttribute([NotNull] PyModuleAttribute pyModuleAttribute)
        {
            if (pyModuleAttribute == null)
                throw new ArgumentNullException(nameof(pyModuleAttribute));
            return new PyCodeModuleName(
                pyModuleAttribute.ModuleShortName,
                pyModuleAttribute.GetImportModuleName(),
                pyModuleAttribute.IsExternal);
        }

        public string GetImportPath(PyCodeModuleName relatedTo)
        {
            return ImportName;
        }
    }
}