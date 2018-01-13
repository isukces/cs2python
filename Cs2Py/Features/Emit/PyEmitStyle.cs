using System;
using Cs2Py.Compilation;
using Cs2Py.Source;

namespace Cs2Py.Emit
{
    public class PyEmitStyle : ICloneable
    {
        public static PyEmitStyle xClone(PyEmitStyle x)
        {
            if (x == null)
                return new PyEmitStyle();
            return (PyEmitStyle)(x as ICloneable).Clone();
        }

        public static PyEmitStyle xClone(PyEmitStyle x, ShowBracketsEnum e)
        {
            var tmp      = xClone(x);
            tmp.Brackets = e;
            return tmp;
        }


        /// <summary>
        ///     Creates copy of object
        /// </summary>
        object ICloneable.Clone()
        {
            var myClone = new PyEmitStyle
            {
                AsIncrementor                 = AsIncrementor,
                Brackets                      = Brackets,
                UseBracketsEvenIfNotNecessary = UseBracketsEvenIfNotNecessary,
                CurrentNamespace              = CurrentNamespace,
                CurrentClass                  = CurrentClass
            };
            return myClone;
        }

        /// <summary>
        /// </summary>
        public bool AsIncrementor { get; set; }

        /// <summary>
        /// </summary>
        public ShowBracketsEnum Brackets { get; set; }


        /// <summary>
        /// </summary>
        public bool UseBracketsEvenIfNotNecessary { get; set; }

        /// <summary>
        /// </summary>
        public PyNamespace CurrentNamespace { get; set; }

        /// <summary>
        ///     Name of current class
        /// </summary>
        public PyQualifiedName CurrentClass { get; set; }

        public EmitStyleCompression Compression { get; set; }
    }
}