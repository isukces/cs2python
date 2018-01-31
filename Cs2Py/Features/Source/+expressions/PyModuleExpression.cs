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
            var cr            = new DependsOnModuleCodeRequest(ModuleName, Why);
            cr.OnAliasChanged += request => UseAlias = request.UseAlias;
            return new ICodeRequest[] {cr};
        }

        public override string GetPyCode(PyEmitStyle style)
        {
            if (string.IsNullOrEmpty(UseAlias))
                return ModuleName.Name;
            return UseAlias;
        }

        public PyCodeModuleName ModuleName { get; set; }
        public string           Why        { get; set; }
        public string           UseAlias   { get; private set; }
    }
}