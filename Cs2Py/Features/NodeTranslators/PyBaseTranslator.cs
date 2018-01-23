using Cs2Py.CSharp;
using Cs2Py.Source;
using Lang.Python;

namespace Cs2Py.NodeTranslators
{
    public class PyBaseTranslator : IPyNodeTranslator<CsharpMethodCallExpression>
    {
        public IPyValue TranslateToPython(IExternalTranslationContext ctx, CsharpMethodCallExpression src)
        {
            if (src.MethodInfo.DeclaringType == typeof(Py))
            {
                if (src.MethodInfo.Name==nameof(Py.Nothing))
                    return new PyEmptyExpression();
            }

            return null;
        }

        public int GetPriority()
        {
            return 3;
        }
    }
}