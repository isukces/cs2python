using System;
using System.Collections.Generic;
using System.Linq;

// ReSharper disable once CheckNamespace
namespace Lang.Python.Numpy
{
    public partial class Np
    {
        /// <summary>
        /// Trigonometric inverse cosine, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("arccos") ]
        public static List<double> Acos(IList<double> x)
        {
            return x.MapToList(Math.Acos);
        }

        /// <summary>
        /// Trigonometric inverse cosine, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("arccos") ]
        public static List<double> Acos(IEnumerable<double> x)
        {
            return x.MapToList(Math.Acos);
        }

        /// <summary>
        /// Trigonometric inverse cosine, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("arccos") ]
        public static List<double> Acos(NdArray<double> x)
        {
            return x.MapToList(Math.Acos);
        }

        /// <summary>
        /// Inverse hyperbolic cosine, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("arccosh") ]
        public static List<double> ACosh(IList<double> x)
        {
            return x.MapToList(PyMath.ACosh);
        }

        /// <summary>
        /// Inverse hyperbolic cosine, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("arccosh") ]
        public static List<double> ACosh(IEnumerable<double> x)
        {
            return x.MapToList(PyMath.ACosh);
        }

        /// <summary>
        /// Inverse hyperbolic cosine, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("arccosh") ]
        public static List<double> ACosh(NdArray<double> x)
        {
            return x.MapToList(PyMath.ACosh);
        }

        /// <summary>
        /// Trigonometric inverse sine, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("arcsin") ]
        public static List<double> Asin(IList<double> x)
        {
            return x.MapToList(Math.Asin);
        }

        /// <summary>
        /// Trigonometric inverse sine, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("arcsin") ]
        public static List<double> Asin(IEnumerable<double> x)
        {
            return x.MapToList(Math.Asin);
        }

        /// <summary>
        /// Trigonometric inverse sine, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("arcsin") ]
        public static List<double> Asin(NdArray<double> x)
        {
            return x.MapToList(Math.Asin);
        }

        /// <summary>
        /// Inverse hyperbolic sine, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("arcsinh") ]
        public static List<double> ASinh(IList<double> x)
        {
            return x.MapToList(PyMath.ASinh);
        }

        /// <summary>
        /// Inverse hyperbolic sine, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("arcsinh") ]
        public static List<double> ASinh(IEnumerable<double> x)
        {
            return x.MapToList(PyMath.ASinh);
        }

        /// <summary>
        /// Inverse hyperbolic sine, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("arcsinh") ]
        public static List<double> ASinh(NdArray<double> x)
        {
            return x.MapToList(PyMath.ASinh);
        }

        /// <summary>
        /// Trigonometric inverse tangent, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("arctan") ]
        public static List<double> Atan(IList<double> x)
        {
            return x.MapToList(Math.Atan);
        }

        /// <summary>
        /// Trigonometric inverse tangent, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("arctan") ]
        public static List<double> Atan(IEnumerable<double> x)
        {
            return x.MapToList(Math.Atan);
        }

        /// <summary>
        /// Trigonometric inverse tangent, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("arctan") ]
        public static List<double> Atan(NdArray<double> x)
        {
            return x.MapToList(Math.Atan);
        }

        [ DirectCall("arctan2") ]
        public static List<double> Atan2(IList<double> y, IList<double> x)
        {
            return x.Zip(y, (a, b) => new {X = a, Y = b}).MapToList(q => Math.Atan2(q.Y, q.X));
        }

        [ DirectCall("arctan2") ]
        public static List<double> Atan2(IEnumerable<double> y, IList<double> x)
        {
            return x.Zip(y, (a, b) => new {X = a, Y = b}).MapToList(q => Math.Atan2(q.Y, q.X));
        }

        [ DirectCall("arctan2") ]
        public static List<double> Atan2(NdArray<double> y, IList<double> x)
        {
            return x.Zip(y.AsEnumerable(), (a, b) => new {X = a, Y = b}).MapToList(q => Math.Atan2(q.Y, q.X));
        }

        [ DirectCall("arctan2") ]
        public static List<double> Atan2(IList<double> y, IEnumerable<double> x)
        {
            return x.Zip(y, (a, b) => new {X = a, Y = b}).MapToList(q => Math.Atan2(q.Y, q.X));
        }

        [ DirectCall("arctan2") ]
        public static List<double> Atan2(IEnumerable<double> y, IEnumerable<double> x)
        {
            return x.Zip(y, (a, b) => new {X = a, Y = b}).MapToList(q => Math.Atan2(q.Y, q.X));
        }

        [ DirectCall("arctan2") ]
        public static List<double> Atan2(NdArray<double> y, IEnumerable<double> x)
        {
            return x.Zip(y.AsEnumerable(), (a, b) => new {X = a, Y = b}).MapToList(q => Math.Atan2(q.Y, q.X));
        }

        [ DirectCall("arctan2") ]
        public static List<double> Atan2(IList<double> y, NdArray<double> x)
        {
            return x.AsEnumerable().Zip(y, (a, b) => new {X = a, Y = b}).MapToList(q => Math.Atan2(q.Y, q.X));
        }

        [ DirectCall("arctan2") ]
        public static List<double> Atan2(IEnumerable<double> y, NdArray<double> x)
        {
            return x.AsEnumerable().Zip(y, (a, b) => new {X = a, Y = b}).MapToList(q => Math.Atan2(q.Y, q.X));
        }

        [ DirectCall("arctan2") ]
        public static List<double> Atan2(NdArray<double> y, NdArray<double> x)
        {
            return x.AsEnumerable().Zip(y.AsEnumerable(), (a, b) => new {X = a, Y = b}).MapToList(q => Math.Atan2(q.Y, q.X));
        }

        /// <summary>
        /// Inverse hyperbolic tangent, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("arctanh") ]
        public static List<double> ATanh(IList<double> x)
        {
            return x.MapToList(PyMath.ATanh);
        }

        /// <summary>
        /// Inverse hyperbolic tangent, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("arctanh") ]
        public static List<double> ATanh(IEnumerable<double> x)
        {
            return x.MapToList(PyMath.ATanh);
        }

        /// <summary>
        /// Inverse hyperbolic tangent, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("arctanh") ]
        public static List<double> ATanh(NdArray<double> x)
        {
            return x.MapToList(PyMath.ATanh);
        }

        /// <summary>
        /// Trigonometric cosine element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("cos") ]
        public static List<double> Cos(IList<double> x)
        {
            return x.MapToList(Math.Cos);
        }

        /// <summary>
        /// Trigonometric cosine element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("cos") ]
        public static List<double> Cos(IEnumerable<double> x)
        {
            return x.MapToList(Math.Cos);
        }

        /// <summary>
        /// Trigonometric cosine element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("cos") ]
        public static List<double> Cos(NdArray<double> x)
        {
            return x.MapToList(Math.Cos);
        }

        /// <summary>
        /// Hyperbolic cosine, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("cosh") ]
        public static List<double> Cosh(IList<double> x)
        {
            return x.MapToList(Math.Cosh);
        }

        /// <summary>
        /// Hyperbolic cosine, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("cosh") ]
        public static List<double> Cosh(IEnumerable<double> x)
        {
            return x.MapToList(Math.Cosh);
        }

        /// <summary>
        /// Hyperbolic cosine, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("cosh") ]
        public static List<double> Cosh(NdArray<double> x)
        {
            return x.MapToList(Math.Cosh);
        }

        [ DirectCall("degrees") ]
        public static List<double> Degrees(IList<double> x)
        {
            const double mul = 180.0 / Math.PI;
            return x.MapToList(value => value * mul);
        }

        [ DirectCall("degrees") ]
        public static List<double> Degrees(IEnumerable<double> x)
        {
            const double mul = 180.0 / Math.PI;
            return x.MapToList(value => value * mul);
        }

        [ DirectCall("degrees") ]
        public static List<double> Degrees(NdArray<double> x)
        {
            const double mul = 180.0 / Math.PI;
            return x.MapToList(value => value * mul);
        }

        [ DirectCall("hypot") ]
        public static List<double> Hypot(IList<double> x, IList<double> y)
        {
            return x.Zip(y, (a, b) => new {X = a, Y = b}).MapToList(q => Math.Sqrt(q.Y * q.Y + q.X * q.X));
        }

        [ DirectCall("hypot") ]
        public static List<double> Hypot(IEnumerable<double> x, IList<double> y)
        {
            return x.Zip(y, (a, b) => new {X = a, Y = b}).MapToList(q => Math.Sqrt(q.Y * q.Y + q.X * q.X));
        }

        [ DirectCall("hypot") ]
        public static List<double> Hypot(NdArray<double> x, IList<double> y)
        {
            return x.AsEnumerable().Zip(y, (a, b) => new {X = a, Y = b}).MapToList(q => Math.Sqrt(q.Y * q.Y + q.X * q.X));
        }

        [ DirectCall("hypot") ]
        public static List<double> Hypot(IList<double> x, IEnumerable<double> y)
        {
            return x.Zip(y, (a, b) => new {X = a, Y = b}).MapToList(q => Math.Sqrt(q.Y * q.Y + q.X * q.X));
        }

        [ DirectCall("hypot") ]
        public static List<double> Hypot(IEnumerable<double> x, IEnumerable<double> y)
        {
            return x.Zip(y, (a, b) => new {X = a, Y = b}).MapToList(q => Math.Sqrt(q.Y * q.Y + q.X * q.X));
        }

        [ DirectCall("hypot") ]
        public static List<double> Hypot(NdArray<double> x, IEnumerable<double> y)
        {
            return x.AsEnumerable().Zip(y, (a, b) => new {X = a, Y = b}).MapToList(q => Math.Sqrt(q.Y * q.Y + q.X * q.X));
        }

        [ DirectCall("hypot") ]
        public static List<double> Hypot(IList<double> x, NdArray<double> y)
        {
            return x.Zip(y.AsEnumerable(), (a, b) => new {X = a, Y = b}).MapToList(q => Math.Sqrt(q.Y * q.Y + q.X * q.X));
        }

        [ DirectCall("hypot") ]
        public static List<double> Hypot(IEnumerable<double> x, NdArray<double> y)
        {
            return x.Zip(y.AsEnumerable(), (a, b) => new {X = a, Y = b}).MapToList(q => Math.Sqrt(q.Y * q.Y + q.X * q.X));
        }

        [ DirectCall("hypot") ]
        public static List<double> Hypot(NdArray<double> x, NdArray<double> y)
        {
            return x.AsEnumerable().Zip(y.AsEnumerable(), (a, b) => new {X = a, Y = b}).MapToList(q => Math.Sqrt(q.Y * q.Y + q.X * q.X));
        }

        [ DirectCall("radians") ]
        public static List<double> Radians(IList<double> x)
        {
            const double mul = Math.PI / 180.0;
            return x.MapToList(value => value * mul);
        }

        [ DirectCall("radians") ]
        public static List<double> Radians(IEnumerable<double> x)
        {
            const double mul = Math.PI / 180.0;
            return x.MapToList(value => value * mul);
        }

        [ DirectCall("radians") ]
        public static List<double> Radians(NdArray<double> x)
        {
            const double mul = Math.PI / 180.0;
            return x.AsEnumerable().MapToList(value => value * mul);
        }

        /// <summary>
        /// Trigonometric sine, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("sin") ]
        public static List<double> Sin(IList<double> x)
        {
            return x.MapToList(Math.Sin);
        }

        /// <summary>
        /// Trigonometric sine, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("sin") ]
        public static List<double> Sin(IEnumerable<double> x)
        {
            return x.MapToList(Math.Sin);
        }

        /// <summary>
        /// Trigonometric sine, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("sin") ]
        public static List<double> Sin(NdArray<double> x)
        {
            return x.MapToList(Math.Sin);
        }

        /// <summary>
        /// Hyperbolic sine, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("sinh") ]
        public static List<double> Sinh(IList<double> x)
        {
            return x.MapToList(Math.Sinh);
        }

        /// <summary>
        /// Hyperbolic sine, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("sinh") ]
        public static List<double> Sinh(IEnumerable<double> x)
        {
            return x.MapToList(Math.Sinh);
        }

        /// <summary>
        /// Hyperbolic sine, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("sinh") ]
        public static List<double> Sinh(NdArray<double> x)
        {
            return x.MapToList(Math.Sinh);
        }

        /// <summary>
        /// Trigonometric tangent element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("tan") ]
        public static List<double> Tan(IList<double> x)
        {
            return x.MapToList(Math.Tan);
        }

        /// <summary>
        /// Trigonometric tangent element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("tan") ]
        public static List<double> Tan(IEnumerable<double> x)
        {
            return x.MapToList(Math.Tan);
        }

        /// <summary>
        /// Trigonometric tangent element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("tan") ]
        public static List<double> Tan(NdArray<double> x)
        {
            return x.MapToList(Math.Tan);
        }

        /// <summary>
        /// Hyperbolic tangent, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("tanh") ]
        public static List<double> Tanh(IList<double> x)
        {
            return x.MapToList(Math.Tanh);
        }

        /// <summary>
        /// Hyperbolic tangent, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("tanh") ]
        public static List<double> Tanh(IEnumerable<double> x)
        {
            return x.MapToList(Math.Tanh);
        }

        /// <summary>
        /// Hyperbolic tangent, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("tanh") ]
        public static List<double> Tanh(NdArray<double> x)
        {
            return x.MapToList(Math.Tanh);
        }

    }
}
