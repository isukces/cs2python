using System.Collections.Generic;
using Cs2Py.Compilation;
using Cs2Py.Emit;

namespace Cs2Py.Source
{
    public class PyModuleExpression : PyValueBase
    {
        public PyModuleExpression(PyCodeModuleName moduleName, string why)
        {
            ModuleName = moduleName;
            Why        = why;
        }

        public override IEnumerable<ICodeRequest> GetCodeRequests()
        {
            return new ICodeRequest[]
            {
                new ModuleCodeRequest(ModuleName, Why)
            };
        }


        public override string GetPyCode(PyEmitStyle style)
        {
            return ModuleName.Name;
        }

        public PyCodeModuleName ModuleName { get; set; }
        public string           Why        { get; set; }
    }
}