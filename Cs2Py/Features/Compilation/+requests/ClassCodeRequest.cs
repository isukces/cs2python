using Cs2Py.Source;

namespace Cs2Py.Compilation
{
    public class ClassCodeRequest : ICodeRequest
    {
        /// <summary>
        ///     Tworzy instancję obiektu
        ///     <param name="className"></param>
        /// </summary>
        public ClassCodeRequest(PyQualifiedName className)
        {
            ClassName = className;
        }


        /// <summary>
        ///     Zwraca tekstową reprezentację obiektu
        /// </summary>
        /// <returns>Tekstowa reprezentacja obiektu</returns>
        public override string ToString()
        {
            return "ClassCodeRequest ##PyClassName##";
        }

        /// <summary>
        /// </summary>
        public PyQualifiedName ClassName { get; set; }
    }
}