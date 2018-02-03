using isukces.code;
using isukces.code.CodeWrite;
using isukces.code.interfaces;

namespace CodeGenerator
{
    internal class NdArrayLevel1Generator
    {
        private NdArrayLevel1Generator(CsFile csFile, int dimension)
        {
            _dimension       = dimension;
            _class           = csFile.GetOrCreateClass("Lang.Python.Numpy", $"NdArray{dimension}D<T>");
            _class.BaseClass = "NdArray<T>";
        }

        public static CsClass Generate(CsFile f, int dimension)
        {
            var a = new NdArrayLevel1Generator(f, dimension);
            a.Add_Constructor();
            a.Add_Map();
            return a._class;
        }

        private void Add_Constructor()
        {
            var co = _class.AddConstructor();
            NdArrayLevel2Generator.WithAddParams(co, "T", _dimension);
            if (_dimension == 1)
                co.WithBody("InternalData = obj.ToIListCastOrConvert();");
            // protected
            co            = _class.AddConstructor();
            co.Visibility = Visibilities.Internal;
            co.AddParam("internalData",  "IList<T>");
            co.AddParam("shapeInfo", "NdArrayShapeInfo");
            co.Body = " InternalData = internalData; ShapeInfo = shapeInfo;";

        }

        private void Add_Map()
        {
            /*public NdArray2D<TOut> Map<TOut>(Func<T, TOut> map)
        {
            var q = InternalData.PyMap(map);
            return new NdArray2D<TOut>
            {
                InternalData = q
            };
        }*/
            var oType = $"NdArray{_dimension}D<TOut>";
            var cf    = new CSCodeFormatter();
            cf.Writeln("var q = InternalData.PyMap(map);");
            cf.Writeln("return new " + oType +"(q, ShapeInfo);");
            var m = _class
                .AddMethod("Map<TOut>", oType)
                .WithBody(cf);
            m.AddParam("map", "Func<T, TOut>");
        }

        private readonly int     _dimension;
        private readonly CsClass _class;
    }
}