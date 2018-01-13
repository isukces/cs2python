using System;
using Cs2Py.Compilation;
using Cs2Py.CSharp;

namespace Cs2Py
{
    public interface IExternalTranslationContext
    {
        IPyValue       TranslateValue(IValue srcValue);
        TranslationInfo GetTranslationInfo();

        ClassReplaceInfo FindOneClassReplacer(Type srcType);

        Version PyVersion { get; }
    }
}