using Cs2Py.Emit;

namespace Cs2Py
{
    public interface IPyStatement : ICodeRelated, IEmitable
    {
        StatementEmitInfo GetStatementEmitInfo(PyEmitStyle style);
    }
}