using System;

namespace Lang.Python
{
    public class PriovidesTranslatorAttribute : Attribute
    {
        public PriovidesTranslatorAttribute(string translatorForAssembly)
        {
            TranslatorForAssembly = Guid.Parse(translatorForAssembly);
        }
        public Guid TranslatorForAssembly { get; private set; }
    }
}