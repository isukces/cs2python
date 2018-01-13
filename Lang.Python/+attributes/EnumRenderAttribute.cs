using System;

namespace Lang.Python
{
    public class EnumRenderAttribute : Attribute
    {
        public EnumRenderAttribute(EnumRenderOptions option, bool definedConst)
        {
            Option       = option;
            DefinedConst = definedConst;
        }

        public EnumRenderOptions Option       { get; private set; }
        public bool              DefinedConst { get; private set; }
    }
}