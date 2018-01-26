using System.Linq;
using Cs2Py.CSharp;

namespace Cs2Py.NodeTranslators
{
    public class LinqTranslators:  IPyNodeTranslator<CsharpMethodCallExpression>
    {
        public IPyValue TranslateToPython(IExternalTranslationContext ctx, CsharpMethodCallExpression src)
        {
            var type = src.MethodInfo.DeclaringType;
            if (type == typeof(Enumerable))
            {
                return null;
            }

            return null;
        }

        public int GetPriority()
        {
            return 100;
        }
    }
}