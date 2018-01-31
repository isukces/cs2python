using System;
using Cs2Py.Source;

namespace Cs2Py.Compilation
{
    /// <summary>
    ///     Represents dependency from module.
    ///     It is translated into <see cref="PyImportModuleRequest">PyImportModuleRequest</see>
    /// </summary>
    public class DependsOnModuleCodeRequest : ICodeRequest
    {
        /// <summary>
        ///     Tworzy instancję obiektu
        ///     <param name="moduleName"></param>
        ///     <param name="why">Why this Module is requested</param>
        /// </summary>
        public DependsOnModuleCodeRequest(PyCodeModuleName moduleName, string why)
        {
            ModuleName = moduleName;
            Why        = why;
        }


        /// <summary>
        ///     Zwraca tekstową reprezentację obiektu
        /// </summary>
        /// <returns>Tekstowa reprezentacja obiektu</returns>
        public override string ToString()
        {
            return string.IsNullOrEmpty(UseAlias)
                ? ModuleName.ToString()
                : ModuleName + " with alias " + UseAlias;
        }

        /// <summary>
        ///     Własność jest tylko do odczytu.
        /// </summary>
        public PyCodeModuleName ModuleName { get; }


        /// <summary>
        ///     Alias of module
        /// </summary>
        public string UseAlias
        {
            get => _useAlias;
            set
            {
                value = value?.Trim();
                if (string.Equals(value, _useAlias, StringComparison.Ordinal))
                    return;
                _useAlias = value;
                OnAliasChanged?.Invoke(this);
            }
        }

        /// <summary>
        ///     Why this Module is requested
        /// </summary>
        public string Why { get; }

        private string _useAlias;

        public event Action<DependsOnModuleCodeRequest> OnAliasChanged;
    }
}