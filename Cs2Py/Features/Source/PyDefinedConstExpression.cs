using System;
using System.Collections.Generic;
using Cs2Py.Compilation;
using Cs2Py.Emit;

namespace Cs2Py.Source
{
    public class PyDefinedConstExpression : PyValueBase
    {
        /// <summary>
        ///     Tworzy instancję obiektu
        ///     <param name="definedConstName"></param>
        ///     <param name="moduleName"></param>
        /// </summary>
        public PyDefinedConstExpression(string definedConstName, PyCodeModuleName moduleName)
        {
            if (definedConstName == "Py_EOL" && moduleName != null)
                throw new Exception("Py_EOL is built in");
            DefinedConstName = definedConstName;
            _moduleName      = moduleName;
        }

        public override IEnumerable<ICodeRequest> GetCodeRequests()
        {
            if (_moduleName != null)
                yield return new ModuleCodeRequest(_moduleName, "defined const " + DefinedConstName);
        }

        public override string GetPyCode(PyEmitStyle style)
        {
            return DefinedConstName;
        }

        /// <summary>
        ///     Własność jest tylko do odczytu.
        /// </summary>
        public string DefinedConstName { get; } = string.Empty;

        private readonly PyCodeModuleName _moduleName;
    }
}