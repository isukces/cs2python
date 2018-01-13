using System;
using System.Runtime.InteropServices;

namespace Lang.Python
{
    [Serializable]
    [AttributeUsage(AttributeTargets.Assembly)]
    [Guid("8BEB0934-99A2-4E9B-9710-DBB21C6120F4")]
    public class RequiredTranslatorAttribute : Attribute
    {
        /// <summary>
        ///     Tworzy atrybut oznaczający, że dołączana biblioteka wymaga helpera to cs2Py
        /// </summary>
        /// <param name="suggested">Sugerowana nazwa translatora</param>
        public RequiredTranslatorAttribute(string suggested)
        {
            Suggested = suggested;
        }

        public string Suggested { get; private set; }
    }
}