using Cs2Py.Emit;

namespace Cs2Py
{
    public interface IPyValue : ICodeRelated
    {
        string GetPyCode(PyEmitStyle style);
    }
}