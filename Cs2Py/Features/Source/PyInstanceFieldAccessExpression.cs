using System.Collections.Generic;
using System.Linq;
using Cs2Py.Compilation;
using Cs2Py.Emit;

namespace Cs2Py.Source
{
    public class PyInstanceFieldAccessExpression : PyValueBase
    {
        /// <summary>
        ///     Tworzy instancję obiektu
        ///     <param name="fieldName"></param>
        ///     <param name="targetObject"></param>
        ///     <param name="includeModule"></param>
        /// </summary>
        public PyInstanceFieldAccessExpression(string fieldName, IPyValue targetObject,
            PyCodeModuleName                          includeModule)
        {
            FieldName     = fieldName;
            TargetObject  = targetObject;
            IncludeModule = includeModule;
        }

        public override IEnumerable<ICodeRequest> GetCodeRequests()
        {
            var a = PyStatementBase.GetCodeRequests(TargetObject).ToList();
            if (IncludeModule != null)
                a.Add(new DependsOnModuleCodeRequest(IncludeModule, string.Format("instance field {0}", this)));
            return a;
        }
        // Public Methods 

        public override string GetPyCode(PyEmitStyle style)
        {
            return string.Format("{0}.{1}", TargetObject.GetPyCode(style), FieldName);
        }

        public override string ToString()
        {
            return GetPyCode(new PyEmitStyle());
        }

        /// <summary>
        ///     Własność jest tylko do odczytu.
        /// </summary>
        public string FieldName { get; }

        /// <summary>
        ///     Własność jest tylko do odczytu.
        /// </summary>
        public IPyValue TargetObject { get; }

        /// <summary>
        /// </summary>
        public PyCodeModuleName IncludeModule { get; set; }
    }
}