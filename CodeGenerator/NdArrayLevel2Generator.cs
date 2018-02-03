using isukces.code;
using isukces.code.CodeWrite;
using isukces.code.interfaces;

namespace CodeGenerator
{
    internal class NdArrayLevel2Generator
    {
        private NdArrayLevel2Generator(CsFile csFile, int dimension, string wrappedType)
        {
            _dimension = dimension;
            _wrappedType = wrappedType;
            _class =
                csFile.GetOrCreateClass("Lang.Python.Numpy", $"NdArray{dimension}D{wrappedType.FirstUpper()}");
            _class.BaseClass = $"NdArray{dimension}D<{wrappedType}>";
        }

        public static CsClass Generate(CsFile f, int dimension, string wrappedType)
        {
            var a = new NdArrayLevel2Generator(f, dimension, wrappedType);
            a.Add_Constructor();
            a.Add_Mean();
            if (wrappedType == "double" || wrappedType == "int")
                a.Add_Map(wrappedType, "double");
            if (wrappedType == "int")
                a.Add_Direct_Cast("double");
            return a._class;
        }

        public static void WithAddParams(CsMethod method, string type, int dimension)
        {
            method.AddParam("obj", NestedEnumerable(type, dimension));
            method.AddParam("copy", "bool").ConstValue = "true";
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
            
            co = _class.AddConstructor();
            co.Visibility = Visibilities.Internal;
            co.AddParam("internalData", $"IList<{_wrappedType}>");
            co.AddParam("shapeInfo", "NdArrayShapeInfo");
            co.BaseConstructorCall = "base(internalData, shapeInfo)";
        }

        private void Add_Direct_Cast(string target)
        {
            var m = _class
                .AddMethod("implicit", "NdArray2D" + target.FirstUpper())
                .WithStatic()
                .WithBody("");
            m.AddParam("x", _class.Name);
            m.Body = $"return new {m.ResultType}(x.InternalData.IntToDouble(), x.ShapeInfo);";
            // m.Attributes.Add(new CsAttribute("DirectCall").WithArgument("mean"));
        }

        private void Add_Map(string tIn, string tOut)
        {
            var oType = $"NdArray{_dimension}D{tOut.FirstUpper()}";
            var cf = new CSCodeFormatter();
            cf.Writeln("var q = InternalData.PyMap(map);");
            cf.Writeln("return new " + oType + "(q, ShapeInfo);");
            var m = _class
                .AddMethod("Map", oType)
                .WithBody(cf);
            m.AddParam("map", $"Func<{tIn}, {tOut}>");
        }

        private void Add_Mean()
        {
            string GetBody()
            {
                if (_wrappedType == "object")
                    return NotSupported;
                var calc = IsComplex || IsBool ? "GetMean(InternalData)" : "InternalData.Average()";
                return $"return {calc};";
            }

            var m = _class.AddMethod("Mean", IsComplex ? _wrappedType : "double")
                .WithBody(GetBody());
            m.Attributes.Add(new CsAttribute("DirectCall").WithArgument("mean"));
        }

        private bool IsComplex => _wrappedType == "Complex";
        private bool IsBool => _wrappedType == "bool";

        private readonly int _dimension;
        private readonly string _wrappedType;
        private readonly CsClass _class;
        private const string NotSupported = "throw new NotSupportedException();";
    }
}