using System;
using System.Reflection;
using Cs2Py.Source;
using Lang.Python;

namespace Cs2Py.Compilation
{
    public class AssemblyTranslationInfo 
    {
        public static AssemblyTranslationInfo FromAssembly(Assembly assembly, TranslationInfo translationInfo)
        {
            if (assembly == null)
                return null;
            var ati = new AssemblyTranslationInfo();
            {
                ati.Assembly = assembly;

                var moduleIncludeConst = assembly.GetCustomAttribute<ModuleIncludeConstAttribute>();
                if (moduleIncludeConst != null)
                {
                    ati.IncludePathConstOrVarName = (moduleIncludeConst.ConstOrVarName ?? "").Trim();
                    if (ati.IncludePathConstOrVarName.StartsWith("$"))
                    {
                    }
                    else
                    {
                        ati.IncludePathConstOrVarName = "\\" + ati.IncludePathConstOrVarName.TrimStart('\\');
                    }
                }

                ati.RootPath = GetRootPath(assembly);

                var PyPackageSource = assembly.GetCustomAttribute<PyPackageSourceAttribute>();
                if (PyPackageSource != null)
                {
                    ati.PyPackageSourceUri = PyPackageSource.SourceUri;
                    ati.PyPackagePathStrip = PyPackageSource.StripArchivePath;
                }

                {
                    var configModule = assembly.GetCustomAttribute<ConfigModuleAttribute>();
                    if (configModule != null)
                        ati.ConfigModuleName = configModule.Name;
                }
            }
            ati.LibraryName             = LibNameFromAssembly(assembly);
            ati.PyIncludePathExpression = GetDefaultIncludePath(ati, translationInfo);
            return ati;
        }

        public static string GetRootPath(Assembly assembly)
        {
            var rootPathAttribute = assembly.GetCustomAttribute<RootPathAttribute>();
            if (rootPathAttribute == null)
                return string.Empty;
            var result = (rootPathAttribute.Path ?? "").Replace("\\", "/").TrimEnd('/').TrimStart('/') + "/";
            while (result.Contains("//"))
                result = result.Replace("//", "/");
            return result;
        }

        private static IPyValue GetDefaultIncludePath(AssemblyTranslationInfo ati, TranslationInfo translationInfo)
        {
            return new PyConstValue("---FAKE---");
#if PHP
            var pathElements = new List<IPyValue>();

            #region Take include path variable or const

            if (!string.IsNullOrEmpty(ati.IncludePathConstOrVarName))
                if (ati.IncludePathConstOrVarName.StartsWith("$"))
                {
                    pathElements.Add(new PyVariableExpression(ati.IncludePathConstOrVarName, PyVariableKind.Global));
                }
                else
                {
                    var tmp = ati.IncludePathConstOrVarName;
                    if (!tmp.StartsWith("\\")) // defined const is in global namespace ALWAYS
                        tmp = "\\" + tmp;

                    KnownConstInfo info;
                    if (translationInfo != null && translationInfo.KnownConstsValues.TryGetValue(tmp, out info) &&
                        info.UseFixedValue)
                        pathElements.Add(new PyConstValue(info.Value));
                    else
                        pathElements.Add(new PyDefinedConstExpression(tmp, PyCodeModuleName.Cs2PyConfigModuleName));
                }

            #endregion

            //#region RootPathAttribute
            //{
            //    if (!string.IsNullOrEmpty(ati.RootPath) && ati.RootPath != "/")
            //        pathElements.Add(new PyConstValue(ati.RootPath));
            //}
            //#endregion
            var result = PyBinaryOperatorExpression.ConcatStrings(pathElements.ToArray());
            return result;
    #else
            throw new NotImplementedException();
#endif
        }

        private static string LibNameFromAssembly(Assembly a)
        {
            var tmp = a.ManifestModule.ScopeName.ToLower();
            if (tmp.EndsWith(".dll"))
                tmp = tmp.Substring(0, tmp.Length - 4);
            return tmp;
        }

        // Private Methods 
        public override string ToString()
        {
            return LibraryName;
        }


        /// <summary>
        ///     Własność jest tylko do odczytu.
        /// </summary>
        public Assembly Assembly { get; private set; }

        /// <summary>
        ///     Własność jest tylko do odczytu.
        /// </summary>
        public string LibraryName { get; private set; } = string.Empty;

        /// <summary>
        ///     nazwa stałej lub zmiennej, która oznacza ścieżkę do biblioteki; własność jest tylko do odczytu.
        /// </summary>
        public string IncludePathConstOrVarName { get; private set; } = string.Empty;

        /// <summary>
        ///     Własność jest tylko do odczytu.
        /// </summary>
        public string RootPath { get; private set; } = string.Empty;

        /// <summary>
        ///     Własność jest tylko do odczytu.
        /// </summary>
        public string PyPackageSourceUri { get; private set; } = string.Empty;

        /// <summary>
        ///     Własność jest tylko do odczytu.
        /// </summary>
        public string PyPackagePathStrip { get; private set; } = string.Empty;

        /// <summary>
        ///     Własność jest tylko do odczytu.
        /// </summary>
        public IPyValue PyIncludePathExpression { get; private set; }

        /// <summary>
        /// </summary>
        public string ConfigModuleName
        {
            get => _configModuleName;
            private set => _configModuleName = (value ?? string.Empty).Trim();
        }

        private string _configModuleName = "cs2Py";
    }
}