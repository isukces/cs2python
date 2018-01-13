using Cs2Py.Compilation;

namespace Cs2Py
{
    public interface IModuleProcessor
    {
        void BeforeEmit(PyCodeModule module, TranslationInfo info);
    }
}