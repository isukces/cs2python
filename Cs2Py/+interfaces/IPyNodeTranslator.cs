using Cs2Py.CSharp;

namespace Cs2Py
{
    public interface IPyNodeTranslator<T> where T : IValue
    {

        IPyValue TranslateToPhp(IExternalTranslationContext ctx, T src);
        int       GetPriority();
    }
}