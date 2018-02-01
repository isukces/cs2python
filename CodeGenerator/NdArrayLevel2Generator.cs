using isukces.code;
using isukces.code.CodeWrite;
using isukces.code.interfaces;

namespace CodeGenerator
{
    internal class NdArrayLevel2Generator
    {
        private NdArrayLevel2Generator(CsFile csFile, int dimension, string wrappedType)
        {
            _dimension   = dimension;
            _wrappedType = wrappedType;
            _class       =
                csFile.GetOrCreateClass("Lang.Python.Numpy", $"NdArray{dimension}D{wrappedType.FirstUpper()}");
            _class.BaseClass = $"NdArray{dimension}D<{wrappedType}>";
        }

        public static CsClass Generate(CsFile f, int dimension, string wrappedType)
        {
            var a = new NdArrayLevel2Generator(f, dimension, wrappedType);
            a.Add_Constructor();
            a.Add_Mean();
            return a._class;
        }

        public static void WithAddParams(CsMethod method, string type, int dimension)
        {
            method.AddParam("obj",   NestedEnumerable(type, dimension));
            method.AddParam("copy",  "bool").ConstValue            = "true";
            method.AddParam("order", "NumpyArrayOrder").ConstValue = "NumpyArrayOrder.K";
        }

        private static string NestedEnumerable(string wrappedType, int dimension)
        {
            var e = wrappedType;
            for (var j = 0; j < dimension; j++)
                e = $"IEnumerable<{e}>";
            return e;
        }

        private void Add_Constructor()
        {
            var co = _class.AddConstructor();
            WithAddParams(co, _wrappedType, _dimension);
            co.BaseConstructorCall = "base(obj, copy, order)";
        }

        private void Add_Mean()
        {
            var m = _class.AddMethod("Mean", _wrappedType == "Complex" ? _wrappedType : "double")
                .WithBody("throw new NotImplementedException();");
            m.Attributes.Add(new CsAttribute("DirectCall").WithArgument("mean"));
        }

        private readonly int     _dimension;
        private readonly string  _wrappedType;
        private readonly CsClass _class;
    }
}