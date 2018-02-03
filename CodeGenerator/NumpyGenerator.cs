using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using isukces.code;

namespace CodeGenerator
{
    internal class NumpyGenerator : BaseGenerator
    {
        public static IEnumerable<F> GetSinleArgumentFunctions()
        {
            // https://docs.scipy.org/doc/numpy-1.13.0/reference/routines.math.html
            /*
             * 
sin(x, /[, out, where, casting, order, ...])	Trigonometric sine, element-wise.
cos(x, /[, out, where, casting, order, ...])	Cosine element-wise.
tan(x, /[, out, where, casting, order, ...])	Compute tangent element-wise.

arcsin(x, /[, out, where, casting, order, ...])	Inverse sine, element-wise.
arccos(x, /[, out, where, casting, order, ...])	Trigonometric inverse cosine, element-wise.
arctan(x, /[, out, where, casting, order, ...])	Trigonometric inverse tangent, element-wise.
arctan2(x1, x2, /[, out, where, casting, ...])	Element-wise arc tangent of x1/x2 choosing the quadrant correctly.

degrees(x, /[, out, where, casting, order, ...])	Convert angles from radians to degrees.
radians(x, /[, out, where, casting, order, ...])	Convert angles from degrees to radians.

hypot(x1, x2, /[, out, where, casting, ...])	Given the “legs” of a right triangle, return its hypotenuse.

unwrap(p[, discont, axis])	Unwrap by changing deltas between values to 2*pi complement.
deg2rad(x, /[, out, where, casting, order, ...])	Convert angles from degrees to radians.
rad2deg(x, /[, out, where, casting, order, ...])	Convert angles from radians to degrees.
             */
            yield return new F("Math.Sin").WithDescription("Trigonometric sine, element-wise");
            yield return new F("Math.Cos").WithDescription("Trigonometric cosine element-wise");
            yield return new F("Math.Tan").WithDescription("Trigonometric tangent element-wise");

            yield return new F("Math.Asin", "arcsin").WithDescription("Trigonometric inverse sine, element-wise");
            yield return new F("Math.Acos", "arccos").WithDescription("Trigonometric inverse cosine, element-wise");
            yield return new F("Math.Atan", "arctan").WithDescription("Trigonometric inverse tangent, element-wise");

            /*
             
Hyperbolic functions
sinh(x, /[, out, where, casting, order, ...])	Hyperbolic sine, element-wise.
cosh(x, /[, out, where, casting, order, ...])	Hyperbolic cosine, element-wise.
tanh(x, /[, out, where, casting, order, ...])	Compute hyperbolic tangent element-wise.
arcsinh(x, /[, out, where, casting, order, ...])	Inverse hyperbolic sine element-wise.
arccosh(x, /[, out, where, casting, order, ...])	Inverse hyperbolic cosine, element-wise.
arctanh(x, /[, out, where, casting, order, ...])	Inverse hyperbolic tangent element-wise.* 
             */
            yield return new F("Math." + nameof(Math.Sinh)).WithDescription("Hyperbolic sine, element-wise");
            yield return new F("Math." + nameof(Math.Cosh)).WithDescription("Hyperbolic cosine, element-wise");
            yield return new F("Math." + nameof(Math.Tanh)).WithDescription("Hyperbolic tangent, element-wise");

            yield return new F("PyMath.ASinh", "arcsinh").WithDescription("Inverse hyperbolic sine, element-wise");
            yield return new F("PyMath.ACosh", "arccosh").WithDescription("Inverse hyperbolic cosine, element-wise");
            yield return new F("PyMath.ATanh", "arctanh").WithDescription("Inverse hyperbolic tangent, element-wise");

            // yield return new F("Math.Atan2", "arctan2");
        }

        private static void Add_Atan2(CsClass cl)
        {
            TwoArgs(cl, nameof(Math.Atan2), "arctan2", "y", "x",
                (cf, type1, type2) =>
                {
                    var xx = IsNdArray(type2) ? "x.AsEnumerable()" : "x";
                    var yy = IsNdArray(type1) ? "y.AsEnumerable()" : "y";
                    cf.Writeln("return " + xx + ".Zip(" + yy +
                               ", (a, b) => new {X = a, Y = b}).PyMap(q => Math.Atan2(q.Y, q.X));");
                });
        }


        private static void Add_Degrees_Radians(CsClass cl)
        {
            for (var i = 0; i < 2; i++)
            {
                var c = i == 0
                    ? "const double mul = 180.0 / Math.PI;"
                    : "const double mul = Math.PI / 180.0;";
                OneArg(cl, i == 0 ? "Degrees" : "Radians", null, q =>
                {
                    var cf = new CodeFormatter();
                    cf.Writeln(c);
                    var map = q.Map("# * mul");
                    cf.Writeln("return " + map + ";");
                    q.Make(cf.Text);
                });
            }
        }

        private static void Add_Hypot(CsClass cl)
        {
            TwoArgs(cl, "Hypot", null, "x", "y",
                (cf, type1, type2) =>
                {
                    var xx = IsNdArray(type1) ? "x.AsEnumerable()" : "x";
                    var yy = IsNdArray(type2) ? "y.AsEnumerable()" : "y";
                    cf.Writeln(
                        "return " + xx + ".Zip(" + yy +
                        ", (a, b) => new {X = a, Y = b}).PyMap(q => Math.Sqrt(q.Y * q.Y + q.X * q.X));");
                });
        }


        private static void Add_SingleArgumentFunctions(CsClass cl)
        {
            foreach (var i in GetSinleArgumentFunctions())
                OneArg(cl, i.DotnetName, i.PyName,
                    q =>
                    {
                        var im  = i.Implementation;
                        var cf  = new CodeFormatter();
                        var lambda = $"{im}(#)";                                            
                        var map = q.Map(lambda);
                       
                        cf.Writeln("return " + map + ";");
                        var m         = q.Make(cf.Text);
                        m.Description = i.Description;
                    });
        }

        private static IEnumerable<string> GetListTypes(CsClass cl)
        {
            return new[]
            {
                cl.TypeName(typeof(IList<double>)),
                cl.TypeName(typeof(IEnumerable<double>)),
                "NdArray<double>"
            };
        }

        private static IEnumerable<string> GetListTypes2(CsClass cl)
        {
            return new[]
            {
                "IList",
                "IEnumerable",
                "NdArray"
            };
        }

        private static bool IsNdArray(string t)
        {
            return t == "NdArray<double>";
        }

        private static void OneArg(CsClass cl, string dotnetName, string pyName, Action<OneArgMethodGenerator> gen)
        {
            if (pyName == null)
                pyName = dotnetName.ToLower();
            foreach (var wrapped in "double,int".Split(','))
                for (var dim = 0; dim < MaxDim; dim++)
                {
                    if (dim == 0 && wrapped == "int")
                        continue;
                    foreach (var type in GetListTypes2(cl))
                    {
                        if (type == "NdArray")
                        {
                            if (wrapped == "int") continue; // we have implicit operator
                        }
                        var o = new OneArgMethodGenerator(dotnetName, pyName, cl)
                        {
                            TInput     = wrapped,
                            TOutput    = "double",
                            Collection = dim == 0 ? null : type,
                            Dimension  = dim
                        };
                        gen(o);
                        if (dim == 0)
                            break;
                    }
                    
                }
        }

        private static void TwoArgs(CsClass         cl, string dotnetName, string pyName, string firstVar,
            string                                  secondVar,
            Action<CSCodeFormatter, string, string> code)
        {
            if (pyName == null)
                pyName = dotnetName.ToLower();
            foreach (var typeX in GetListTypes(cl))
            foreach (var typeY in GetListTypes(cl))
            {
                var cf = new CSCodeFormatter();
                code(cf, typeY, typeX);
                var m = cl.AddMethod(dotnetName, "PyList<double>")
                    .WithBody(cf)
                    .WithStatic()
                    .WithBodyComment($"Generated by {nameof(NumpyGenerator)}.{nameof(TwoArgs)}")
                    .WithDirectCall(pyName);
                m.AddParam(firstVar,  typeY);
                m.AddParam(secondVar, typeX);
            }
        }


        public void Generate()
        {
            var file = CreateFile();
            file.AddImportNamespace(typeof(List<int>).Namespace);
            file.AddImportNamespace("System.Linq");
            file.AddImportNamespace("Lang.Python.Numpy");
            var cl       = file.GetOrCreateClass("Lang.Python.Numpy", "Np");
            cl.IsPartial = true;
            Add_SingleArgumentFunctions(cl);
            Add_Atan2(cl);
            Add_Degrees_Radians(cl);
            Add_Hypot(cl);
            Add_ArrayMethods(cl);
            var fileName = Path.Combine(BasePath.FullName, "Lang.Python", "+compatibility", "Numpy", cl.GetShortName());
            file.SaveIfDifferent(fileName);
        }

        private void Add_ArrayMethods(CsClass cl)
        {
            /* [DirectCall("array")]
            public static NdArray2D<int> Array(
                IEnumerable<IEnumerable<int>> obj,
                bool             copy  = true,
                NumpyArrayOrder  order = NumpyArrayOrder.K)
            {
                return NdArray.Make(obj, copy, order);
            }*/

            var f = CreateFile();
            f.AddImportNamespace("System.Collections.Generic");
            f.AddImportNamespace("System.Linq");
            for (var dimension = 1; dimension <= MaxDim; dimension++)
            {
                NdArrayLevel1Generator.Generate(f, dimension);
                foreach (var wrappedType in NumpyArrayWrappedTypes)
                {
                    var classLevel2 = NdArrayLevel2Generator.Generate(f, dimension, wrappedType);
                    var resultType  = classLevel2.Name;
                    var m           = cl.AddMethod("Array"+dimension, resultType)
                        .WithDirectCall("array")
                        .WithStatic()
                        .WithBodyComment($"Generated by {nameof(NumpyGenerator)}.{nameof(Add_ArrayMethods)}/1")
                        .WithBody($"return new {resultType}(obj, copy, order);");
                    NdArrayLevel2Generator.WithAddParams(m, wrappedType, dimension);
                }

                // other types
                {
                    const string wrappedType = "T";
                    // var          classLevel2 = NdArrayLevel2Generator.Generate(f, dimension, wrappedType);
                    foreach (var i in new[] {true })
                    {
                        var resultType = $"NdArray{dimension}D<T>";
                        var m          = cl.AddMethod("Array" + (i ? $"{dimension}" : "") + "<T>", resultType)
                            .WithDirectCall("array")
                            .WithStatic()
                            .WithBodyComment($"Generated by {nameof(NumpyGenerator)}.{nameof(Add_ArrayMethods)}/2")
                            .WithBody($"return new {resultType}(obj, copy, order);");
                        NdArrayLevel2Generator.WithAddParams(m, wrappedType, dimension);
                    }
                }
            }

            var fileName = Path.Combine(BasePath.FullName, "Lang.Python", "+compatibility", "Numpy", "NdArray.Auto.cs");
            f.SaveIfDifferent(fileName);
        }


        private static readonly string[] NumpyArrayWrappedTypes = "int,double,Complex,bool".Split(',');

        public const int MaxDim = 5;

        internal struct F
        {
            public F(string implementation) : this()
            {
                DotnetName     = implementation.Split('.').Last();
                Implementation = implementation;
                PyName         = DotnetName.ToLower();
            }

            public F(string implementation, string pyName) : this()
            {
                Implementation = implementation;
                PyName         = pyName;
                DotnetName     = implementation.Split('.').Last();
            }

            public F WithDescription(string desc)
            {
                Description = desc;
                return this;
            }

            public string Implementation { get; set; }
            public string PyName         { get; set; }
            public string DotnetName     { get; set; }
            public string Description    { get; set; }
        }
    }
}