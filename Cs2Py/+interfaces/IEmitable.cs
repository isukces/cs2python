using Cs2Py.Emit;

namespace Cs2Py
{
    public interface IEmitable
    {
        void Emit(PySourceCodeEmiter emiter, PySourceCodeWriter writer, PyEmitStyle style);
    }
}