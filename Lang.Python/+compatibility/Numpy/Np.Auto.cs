using Lang.Python.Numpy;
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
        public static double Acos(double x)
        {
            return Math.Acos(x);
        }

        /// <summary>
        /// Trigonometric inverse cosine, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("arccos") ]
        public static PyList<double> Acos(IList<double> x)
        {
            return x.PyMap(value => Math.Acos(value));
        }

        /// <summary>
        /// Trigonometric inverse cosine, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("arccos") ]
        public static PyList<double> Acos(IEnumerable<double> x)
        {
            return x.PyMap(value => Math.Acos(value));
        }

        /// <summary>
        /// Trigonometric inverse cosine, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("arccos") ]
        public static NdArray1DDouble Acos(NdArray1DDouble x)
        {
            return x.Map(value => Math.Acos(value));
        }

        /// <summary>
        /// Trigonometric inverse cosine, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("arccos") ]
        public static PyList<PyList<double>> Acos(IList<IList<double>> x)
        {
            return x.PyMap(q1 => q1.PyMap(value => Math.Acos(value)));
        }

        /// <summary>
        /// Trigonometric inverse cosine, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("arccos") ]
        public static PyList<PyList<double>> Acos(IEnumerable<IEnumerable<double>> x)
        {
            return x.PyMap(q1 => q1.PyMap(value => Math.Acos(value)));
        }

        /// <summary>
        /// Trigonometric inverse cosine, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("arccos") ]
        public static NdArray2DDouble Acos(NdArray2DDouble x)
        {
            return x.Map(value => Math.Acos(value));
        }

        /// <summary>
        /// Trigonometric inverse cosine, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("arccos") ]
        public static PyList<PyList<PyList<double>>> Acos(IList<IList<IList<double>>> x)
        {
            return x.PyMap(q2 => q2.PyMap(q1 => q1.PyMap(value => Math.Acos(value))));
        }

        /// <summary>
        /// Trigonometric inverse cosine, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("arccos") ]
        public static PyList<PyList<PyList<double>>> Acos(IEnumerable<IEnumerable<IEnumerable<double>>> x)
        {
            return x.PyMap(q2 => q2.PyMap(q1 => q1.PyMap(value => Math.Acos(value))));
        }

        /// <summary>
        /// Trigonometric inverse cosine, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("arccos") ]
        public static NdArray3DDouble Acos(NdArray3DDouble x)
        {
            return x.Map(value => Math.Acos(value));
        }

        /// <summary>
        /// Trigonometric inverse cosine, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("arccos") ]
        public static PyList<PyList<PyList<PyList<double>>>> Acos(IList<IList<IList<IList<double>>>> x)
        {
            return x.PyMap(q3 => q3.PyMap(q2 => q2.PyMap(q1 => q1.PyMap(value => Math.Acos(value)))));
        }

        /// <summary>
        /// Trigonometric inverse cosine, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("arccos") ]
        public static PyList<PyList<PyList<PyList<double>>>> Acos(IEnumerable<IEnumerable<IEnumerable<IEnumerable<double>>>> x)
        {
            return x.PyMap(q3 => q3.PyMap(q2 => q2.PyMap(q1 => q1.PyMap(value => Math.Acos(value)))));
        }

        /// <summary>
        /// Trigonometric inverse cosine, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("arccos") ]
        public static NdArray4DDouble Acos(NdArray4DDouble x)
        {
            return x.Map(value => Math.Acos(value));
        }

        /// <summary>
        /// Trigonometric inverse cosine, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("arccos") ]
        public static PyList<double> Acos(IList<int> x)
        {
            return x.PyMap(value => Math.Acos(value));
        }

        /// <summary>
        /// Trigonometric inverse cosine, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("arccos") ]
        public static PyList<double> Acos(IEnumerable<int> x)
        {
            return x.PyMap(value => Math.Acos(value));
        }

        /// <summary>
        /// Trigonometric inverse cosine, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("arccos") ]
        public static PyList<PyList<double>> Acos(IList<IList<int>> x)
        {
            return x.PyMap(q1 => q1.PyMap(value => Math.Acos(value)));
        }

        /// <summary>
        /// Trigonometric inverse cosine, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("arccos") ]
        public static PyList<PyList<double>> Acos(IEnumerable<IEnumerable<int>> x)
        {
            return x.PyMap(q1 => q1.PyMap(value => Math.Acos(value)));
        }

        /// <summary>
        /// Trigonometric inverse cosine, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("arccos") ]
        public static PyList<PyList<PyList<double>>> Acos(IList<IList<IList<int>>> x)
        {
            return x.PyMap(q2 => q2.PyMap(q1 => q1.PyMap(value => Math.Acos(value))));
        }

        /// <summary>
        /// Trigonometric inverse cosine, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("arccos") ]
        public static PyList<PyList<PyList<double>>> Acos(IEnumerable<IEnumerable<IEnumerable<int>>> x)
        {
            return x.PyMap(q2 => q2.PyMap(q1 => q1.PyMap(value => Math.Acos(value))));
        }

        /// <summary>
        /// Trigonometric inverse cosine, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("arccos") ]
        public static PyList<PyList<PyList<PyList<double>>>> Acos(IList<IList<IList<IList<int>>>> x)
        {
            return x.PyMap(q3 => q3.PyMap(q2 => q2.PyMap(q1 => q1.PyMap(value => Math.Acos(value)))));
        }

        /// <summary>
        /// Trigonometric inverse cosine, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("arccos") ]
        public static PyList<PyList<PyList<PyList<double>>>> Acos(IEnumerable<IEnumerable<IEnumerable<IEnumerable<int>>>> x)
        {
            return x.PyMap(q3 => q3.PyMap(q2 => q2.PyMap(q1 => q1.PyMap(value => Math.Acos(value)))));
        }

        /// <summary>
        /// Inverse hyperbolic cosine, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("arccosh") ]
        public static double ACosh(double x)
        {
            return PyMath.ACosh(x);
        }

        /// <summary>
        /// Inverse hyperbolic cosine, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("arccosh") ]
        public static PyList<double> ACosh(IList<double> x)
        {
            return x.PyMap(value => PyMath.ACosh(value));
        }

        /// <summary>
        /// Inverse hyperbolic cosine, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("arccosh") ]
        public static PyList<double> ACosh(IEnumerable<double> x)
        {
            return x.PyMap(value => PyMath.ACosh(value));
        }

        /// <summary>
        /// Inverse hyperbolic cosine, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("arccosh") ]
        public static NdArray1DDouble ACosh(NdArray1DDouble x)
        {
            return x.Map(value => PyMath.ACosh(value));
        }

        /// <summary>
        /// Inverse hyperbolic cosine, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("arccosh") ]
        public static PyList<PyList<double>> ACosh(IList<IList<double>> x)
        {
            return x.PyMap(q1 => q1.PyMap(value => PyMath.ACosh(value)));
        }

        /// <summary>
        /// Inverse hyperbolic cosine, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("arccosh") ]
        public static PyList<PyList<double>> ACosh(IEnumerable<IEnumerable<double>> x)
        {
            return x.PyMap(q1 => q1.PyMap(value => PyMath.ACosh(value)));
        }

        /// <summary>
        /// Inverse hyperbolic cosine, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("arccosh") ]
        public static NdArray2DDouble ACosh(NdArray2DDouble x)
        {
            return x.Map(value => PyMath.ACosh(value));
        }

        /// <summary>
        /// Inverse hyperbolic cosine, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("arccosh") ]
        public static PyList<PyList<PyList<double>>> ACosh(IList<IList<IList<double>>> x)
        {
            return x.PyMap(q2 => q2.PyMap(q1 => q1.PyMap(value => PyMath.ACosh(value))));
        }

        /// <summary>
        /// Inverse hyperbolic cosine, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("arccosh") ]
        public static PyList<PyList<PyList<double>>> ACosh(IEnumerable<IEnumerable<IEnumerable<double>>> x)
        {
            return x.PyMap(q2 => q2.PyMap(q1 => q1.PyMap(value => PyMath.ACosh(value))));
        }

        /// <summary>
        /// Inverse hyperbolic cosine, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("arccosh") ]
        public static NdArray3DDouble ACosh(NdArray3DDouble x)
        {
            return x.Map(value => PyMath.ACosh(value));
        }

        /// <summary>
        /// Inverse hyperbolic cosine, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("arccosh") ]
        public static PyList<PyList<PyList<PyList<double>>>> ACosh(IList<IList<IList<IList<double>>>> x)
        {
            return x.PyMap(q3 => q3.PyMap(q2 => q2.PyMap(q1 => q1.PyMap(value => PyMath.ACosh(value)))));
        }

        /// <summary>
        /// Inverse hyperbolic cosine, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("arccosh") ]
        public static PyList<PyList<PyList<PyList<double>>>> ACosh(IEnumerable<IEnumerable<IEnumerable<IEnumerable<double>>>> x)
        {
            return x.PyMap(q3 => q3.PyMap(q2 => q2.PyMap(q1 => q1.PyMap(value => PyMath.ACosh(value)))));
        }

        /// <summary>
        /// Inverse hyperbolic cosine, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("arccosh") ]
        public static NdArray4DDouble ACosh(NdArray4DDouble x)
        {
            return x.Map(value => PyMath.ACosh(value));
        }

        /// <summary>
        /// Inverse hyperbolic cosine, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("arccosh") ]
        public static PyList<double> ACosh(IList<int> x)
        {
            return x.PyMap(value => PyMath.ACosh(value));
        }

        /// <summary>
        /// Inverse hyperbolic cosine, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("arccosh") ]
        public static PyList<double> ACosh(IEnumerable<int> x)
        {
            return x.PyMap(value => PyMath.ACosh(value));
        }

        /// <summary>
        /// Inverse hyperbolic cosine, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("arccosh") ]
        public static PyList<PyList<double>> ACosh(IList<IList<int>> x)
        {
            return x.PyMap(q1 => q1.PyMap(value => PyMath.ACosh(value)));
        }

        /// <summary>
        /// Inverse hyperbolic cosine, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("arccosh") ]
        public static PyList<PyList<double>> ACosh(IEnumerable<IEnumerable<int>> x)
        {
            return x.PyMap(q1 => q1.PyMap(value => PyMath.ACosh(value)));
        }

        /// <summary>
        /// Inverse hyperbolic cosine, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("arccosh") ]
        public static PyList<PyList<PyList<double>>> ACosh(IList<IList<IList<int>>> x)
        {
            return x.PyMap(q2 => q2.PyMap(q1 => q1.PyMap(value => PyMath.ACosh(value))));
        }

        /// <summary>
        /// Inverse hyperbolic cosine, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("arccosh") ]
        public static PyList<PyList<PyList<double>>> ACosh(IEnumerable<IEnumerable<IEnumerable<int>>> x)
        {
            return x.PyMap(q2 => q2.PyMap(q1 => q1.PyMap(value => PyMath.ACosh(value))));
        }

        /// <summary>
        /// Inverse hyperbolic cosine, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("arccosh") ]
        public static PyList<PyList<PyList<PyList<double>>>> ACosh(IList<IList<IList<IList<int>>>> x)
        {
            return x.PyMap(q3 => q3.PyMap(q2 => q2.PyMap(q1 => q1.PyMap(value => PyMath.ACosh(value)))));
        }

        /// <summary>
        /// Inverse hyperbolic cosine, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("arccosh") ]
        public static PyList<PyList<PyList<PyList<double>>>> ACosh(IEnumerable<IEnumerable<IEnumerable<IEnumerable<int>>>> x)
        {
            return x.PyMap(q3 => q3.PyMap(q2 => q2.PyMap(q1 => q1.PyMap(value => PyMath.ACosh(value)))));
        }

        [ DirectCall("array") ]
        public static NdArray1DInt Array1(IEnumerable<int> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
        {
            return new NdArray1DInt(obj, copy, order);
        }

        [ DirectCall("array") ]
        public static NdArray1DDouble Array1(IEnumerable<double> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
        {
            return new NdArray1DDouble(obj, copy, order);
        }

        [ DirectCall("array") ]
        public static NdArray1DComplex Array1(IEnumerable<Complex> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
        {
            return new NdArray1DComplex(obj, copy, order);
        }

        [ DirectCall("array") ]
        public static NdArray1DBool Array1(IEnumerable<bool> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
        {
            return new NdArray1DBool(obj, copy, order);
        }

        [ DirectCall("array") ]
        public static NdArray1D<T> Array1<T>(IEnumerable<T> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
        {
            return new NdArray1D<T>(obj, copy, order);
        }

        [ DirectCall("array") ]
        public static NdArray2DInt Array2(IEnumerable<IEnumerable<int>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
        {
            return new NdArray2DInt(obj, copy, order);
        }

        [ DirectCall("array") ]
        public static NdArray2DDouble Array2(IEnumerable<IEnumerable<double>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
        {
            return new NdArray2DDouble(obj, copy, order);
        }

        [ DirectCall("array") ]
        public static NdArray2DComplex Array2(IEnumerable<IEnumerable<Complex>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
        {
            return new NdArray2DComplex(obj, copy, order);
        }

        [ DirectCall("array") ]
        public static NdArray2DBool Array2(IEnumerable<IEnumerable<bool>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
        {
            return new NdArray2DBool(obj, copy, order);
        }

        [ DirectCall("array") ]
        public static NdArray2D<T> Array2<T>(IEnumerable<IEnumerable<T>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
        {
            return new NdArray2D<T>(obj, copy, order);
        }

        [ DirectCall("array") ]
        public static NdArray3DInt Array3(IEnumerable<IEnumerable<IEnumerable<int>>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
        {
            return new NdArray3DInt(obj, copy, order);
        }

        [ DirectCall("array") ]
        public static NdArray3DDouble Array3(IEnumerable<IEnumerable<IEnumerable<double>>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
        {
            return new NdArray3DDouble(obj, copy, order);
        }

        [ DirectCall("array") ]
        public static NdArray3DComplex Array3(IEnumerable<IEnumerable<IEnumerable<Complex>>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
        {
            return new NdArray3DComplex(obj, copy, order);
        }

        [ DirectCall("array") ]
        public static NdArray3DBool Array3(IEnumerable<IEnumerable<IEnumerable<bool>>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
        {
            return new NdArray3DBool(obj, copy, order);
        }

        [ DirectCall("array") ]
        public static NdArray3D<T> Array3<T>(IEnumerable<IEnumerable<IEnumerable<T>>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
        {
            return new NdArray3D<T>(obj, copy, order);
        }

        [ DirectCall("array") ]
        public static NdArray4DInt Array4(IEnumerable<IEnumerable<IEnumerable<IEnumerable<int>>>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
        {
            return new NdArray4DInt(obj, copy, order);
        }

        [ DirectCall("array") ]
        public static NdArray4DDouble Array4(IEnumerable<IEnumerable<IEnumerable<IEnumerable<double>>>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
        {
            return new NdArray4DDouble(obj, copy, order);
        }

        [ DirectCall("array") ]
        public static NdArray4DComplex Array4(IEnumerable<IEnumerable<IEnumerable<IEnumerable<Complex>>>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
        {
            return new NdArray4DComplex(obj, copy, order);
        }

        [ DirectCall("array") ]
        public static NdArray4DBool Array4(IEnumerable<IEnumerable<IEnumerable<IEnumerable<bool>>>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
        {
            return new NdArray4DBool(obj, copy, order);
        }

        [ DirectCall("array") ]
        public static NdArray4D<T> Array4<T>(IEnumerable<IEnumerable<IEnumerable<IEnumerable<T>>>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
        {
            return new NdArray4D<T>(obj, copy, order);
        }

        [ DirectCall("array") ]
        public static NdArray5DInt Array5(IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<int>>>>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
        {
            return new NdArray5DInt(obj, copy, order);
        }

        [ DirectCall("array") ]
        public static NdArray5DDouble Array5(IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<double>>>>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
        {
            return new NdArray5DDouble(obj, copy, order);
        }

        [ DirectCall("array") ]
        public static NdArray5DComplex Array5(IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<Complex>>>>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
        {
            return new NdArray5DComplex(obj, copy, order);
        }

        [ DirectCall("array") ]
        public static NdArray5DBool Array5(IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<bool>>>>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
        {
            return new NdArray5DBool(obj, copy, order);
        }

        [ DirectCall("array") ]
        public static NdArray5D<T> Array5<T>(IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<T>>>>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
        {
            return new NdArray5D<T>(obj, copy, order);
        }

        /// <summary>
        /// Trigonometric inverse sine, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("arcsin") ]
        public static double Asin(double x)
        {
            return Math.Asin(x);
        }

        /// <summary>
        /// Trigonometric inverse sine, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("arcsin") ]
        public static PyList<double> Asin(IList<double> x)
        {
            return x.PyMap(value => Math.Asin(value));
        }

        /// <summary>
        /// Trigonometric inverse sine, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("arcsin") ]
        public static PyList<double> Asin(IEnumerable<double> x)
        {
            return x.PyMap(value => Math.Asin(value));
        }

        /// <summary>
        /// Trigonometric inverse sine, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("arcsin") ]
        public static NdArray1DDouble Asin(NdArray1DDouble x)
        {
            return x.Map(value => Math.Asin(value));
        }

        /// <summary>
        /// Trigonometric inverse sine, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("arcsin") ]
        public static PyList<PyList<double>> Asin(IList<IList<double>> x)
        {
            return x.PyMap(q1 => q1.PyMap(value => Math.Asin(value)));
        }

        /// <summary>
        /// Trigonometric inverse sine, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("arcsin") ]
        public static PyList<PyList<double>> Asin(IEnumerable<IEnumerable<double>> x)
        {
            return x.PyMap(q1 => q1.PyMap(value => Math.Asin(value)));
        }

        /// <summary>
        /// Trigonometric inverse sine, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("arcsin") ]
        public static NdArray2DDouble Asin(NdArray2DDouble x)
        {
            return x.Map(value => Math.Asin(value));
        }

        /// <summary>
        /// Trigonometric inverse sine, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("arcsin") ]
        public static PyList<PyList<PyList<double>>> Asin(IList<IList<IList<double>>> x)
        {
            return x.PyMap(q2 => q2.PyMap(q1 => q1.PyMap(value => Math.Asin(value))));
        }

        /// <summary>
        /// Trigonometric inverse sine, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("arcsin") ]
        public static PyList<PyList<PyList<double>>> Asin(IEnumerable<IEnumerable<IEnumerable<double>>> x)
        {
            return x.PyMap(q2 => q2.PyMap(q1 => q1.PyMap(value => Math.Asin(value))));
        }

        /// <summary>
        /// Trigonometric inverse sine, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("arcsin") ]
        public static NdArray3DDouble Asin(NdArray3DDouble x)
        {
            return x.Map(value => Math.Asin(value));
        }

        /// <summary>
        /// Trigonometric inverse sine, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("arcsin") ]
        public static PyList<PyList<PyList<PyList<double>>>> Asin(IList<IList<IList<IList<double>>>> x)
        {
            return x.PyMap(q3 => q3.PyMap(q2 => q2.PyMap(q1 => q1.PyMap(value => Math.Asin(value)))));
        }

        /// <summary>
        /// Trigonometric inverse sine, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("arcsin") ]
        public static PyList<PyList<PyList<PyList<double>>>> Asin(IEnumerable<IEnumerable<IEnumerable<IEnumerable<double>>>> x)
        {
            return x.PyMap(q3 => q3.PyMap(q2 => q2.PyMap(q1 => q1.PyMap(value => Math.Asin(value)))));
        }

        /// <summary>
        /// Trigonometric inverse sine, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("arcsin") ]
        public static NdArray4DDouble Asin(NdArray4DDouble x)
        {
            return x.Map(value => Math.Asin(value));
        }

        /// <summary>
        /// Trigonometric inverse sine, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("arcsin") ]
        public static PyList<double> Asin(IList<int> x)
        {
            return x.PyMap(value => Math.Asin(value));
        }

        /// <summary>
        /// Trigonometric inverse sine, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("arcsin") ]
        public static PyList<double> Asin(IEnumerable<int> x)
        {
            return x.PyMap(value => Math.Asin(value));
        }

        /// <summary>
        /// Trigonometric inverse sine, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("arcsin") ]
        public static PyList<PyList<double>> Asin(IList<IList<int>> x)
        {
            return x.PyMap(q1 => q1.PyMap(value => Math.Asin(value)));
        }

        /// <summary>
        /// Trigonometric inverse sine, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("arcsin") ]
        public static PyList<PyList<double>> Asin(IEnumerable<IEnumerable<int>> x)
        {
            return x.PyMap(q1 => q1.PyMap(value => Math.Asin(value)));
        }

        /// <summary>
        /// Trigonometric inverse sine, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("arcsin") ]
        public static PyList<PyList<PyList<double>>> Asin(IList<IList<IList<int>>> x)
        {
            return x.PyMap(q2 => q2.PyMap(q1 => q1.PyMap(value => Math.Asin(value))));
        }

        /// <summary>
        /// Trigonometric inverse sine, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("arcsin") ]
        public static PyList<PyList<PyList<double>>> Asin(IEnumerable<IEnumerable<IEnumerable<int>>> x)
        {
            return x.PyMap(q2 => q2.PyMap(q1 => q1.PyMap(value => Math.Asin(value))));
        }

        /// <summary>
        /// Trigonometric inverse sine, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("arcsin") ]
        public static PyList<PyList<PyList<PyList<double>>>> Asin(IList<IList<IList<IList<int>>>> x)
        {
            return x.PyMap(q3 => q3.PyMap(q2 => q2.PyMap(q1 => q1.PyMap(value => Math.Asin(value)))));
        }

        /// <summary>
        /// Trigonometric inverse sine, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("arcsin") ]
        public static PyList<PyList<PyList<PyList<double>>>> Asin(IEnumerable<IEnumerable<IEnumerable<IEnumerable<int>>>> x)
        {
            return x.PyMap(q3 => q3.PyMap(q2 => q2.PyMap(q1 => q1.PyMap(value => Math.Asin(value)))));
        }

        /// <summary>
        /// Inverse hyperbolic sine, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("arcsinh") ]
        public static double ASinh(double x)
        {
            return PyMath.ASinh(x);
        }

        /// <summary>
        /// Inverse hyperbolic sine, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("arcsinh") ]
        public static PyList<double> ASinh(IList<double> x)
        {
            return x.PyMap(value => PyMath.ASinh(value));
        }

        /// <summary>
        /// Inverse hyperbolic sine, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("arcsinh") ]
        public static PyList<double> ASinh(IEnumerable<double> x)
        {
            return x.PyMap(value => PyMath.ASinh(value));
        }

        /// <summary>
        /// Inverse hyperbolic sine, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("arcsinh") ]
        public static NdArray1DDouble ASinh(NdArray1DDouble x)
        {
            return x.Map(value => PyMath.ASinh(value));
        }

        /// <summary>
        /// Inverse hyperbolic sine, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("arcsinh") ]
        public static PyList<PyList<double>> ASinh(IList<IList<double>> x)
        {
            return x.PyMap(q1 => q1.PyMap(value => PyMath.ASinh(value)));
        }

        /// <summary>
        /// Inverse hyperbolic sine, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("arcsinh") ]
        public static PyList<PyList<double>> ASinh(IEnumerable<IEnumerable<double>> x)
        {
            return x.PyMap(q1 => q1.PyMap(value => PyMath.ASinh(value)));
        }

        /// <summary>
        /// Inverse hyperbolic sine, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("arcsinh") ]
        public static NdArray2DDouble ASinh(NdArray2DDouble x)
        {
            return x.Map(value => PyMath.ASinh(value));
        }

        /// <summary>
        /// Inverse hyperbolic sine, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("arcsinh") ]
        public static PyList<PyList<PyList<double>>> ASinh(IList<IList<IList<double>>> x)
        {
            return x.PyMap(q2 => q2.PyMap(q1 => q1.PyMap(value => PyMath.ASinh(value))));
        }

        /// <summary>
        /// Inverse hyperbolic sine, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("arcsinh") ]
        public static PyList<PyList<PyList<double>>> ASinh(IEnumerable<IEnumerable<IEnumerable<double>>> x)
        {
            return x.PyMap(q2 => q2.PyMap(q1 => q1.PyMap(value => PyMath.ASinh(value))));
        }

        /// <summary>
        /// Inverse hyperbolic sine, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("arcsinh") ]
        public static NdArray3DDouble ASinh(NdArray3DDouble x)
        {
            return x.Map(value => PyMath.ASinh(value));
        }

        /// <summary>
        /// Inverse hyperbolic sine, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("arcsinh") ]
        public static PyList<PyList<PyList<PyList<double>>>> ASinh(IList<IList<IList<IList<double>>>> x)
        {
            return x.PyMap(q3 => q3.PyMap(q2 => q2.PyMap(q1 => q1.PyMap(value => PyMath.ASinh(value)))));
        }

        /// <summary>
        /// Inverse hyperbolic sine, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("arcsinh") ]
        public static PyList<PyList<PyList<PyList<double>>>> ASinh(IEnumerable<IEnumerable<IEnumerable<IEnumerable<double>>>> x)
        {
            return x.PyMap(q3 => q3.PyMap(q2 => q2.PyMap(q1 => q1.PyMap(value => PyMath.ASinh(value)))));
        }

        /// <summary>
        /// Inverse hyperbolic sine, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("arcsinh") ]
        public static NdArray4DDouble ASinh(NdArray4DDouble x)
        {
            return x.Map(value => PyMath.ASinh(value));
        }

        /// <summary>
        /// Inverse hyperbolic sine, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("arcsinh") ]
        public static PyList<double> ASinh(IList<int> x)
        {
            return x.PyMap(value => PyMath.ASinh(value));
        }

        /// <summary>
        /// Inverse hyperbolic sine, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("arcsinh") ]
        public static PyList<double> ASinh(IEnumerable<int> x)
        {
            return x.PyMap(value => PyMath.ASinh(value));
        }

        /// <summary>
        /// Inverse hyperbolic sine, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("arcsinh") ]
        public static PyList<PyList<double>> ASinh(IList<IList<int>> x)
        {
            return x.PyMap(q1 => q1.PyMap(value => PyMath.ASinh(value)));
        }

        /// <summary>
        /// Inverse hyperbolic sine, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("arcsinh") ]
        public static PyList<PyList<double>> ASinh(IEnumerable<IEnumerable<int>> x)
        {
            return x.PyMap(q1 => q1.PyMap(value => PyMath.ASinh(value)));
        }

        /// <summary>
        /// Inverse hyperbolic sine, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("arcsinh") ]
        public static PyList<PyList<PyList<double>>> ASinh(IList<IList<IList<int>>> x)
        {
            return x.PyMap(q2 => q2.PyMap(q1 => q1.PyMap(value => PyMath.ASinh(value))));
        }

        /// <summary>
        /// Inverse hyperbolic sine, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("arcsinh") ]
        public static PyList<PyList<PyList<double>>> ASinh(IEnumerable<IEnumerable<IEnumerable<int>>> x)
        {
            return x.PyMap(q2 => q2.PyMap(q1 => q1.PyMap(value => PyMath.ASinh(value))));
        }

        /// <summary>
        /// Inverse hyperbolic sine, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("arcsinh") ]
        public static PyList<PyList<PyList<PyList<double>>>> ASinh(IList<IList<IList<IList<int>>>> x)
        {
            return x.PyMap(q3 => q3.PyMap(q2 => q2.PyMap(q1 => q1.PyMap(value => PyMath.ASinh(value)))));
        }

        /// <summary>
        /// Inverse hyperbolic sine, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("arcsinh") ]
        public static PyList<PyList<PyList<PyList<double>>>> ASinh(IEnumerable<IEnumerable<IEnumerable<IEnumerable<int>>>> x)
        {
            return x.PyMap(q3 => q3.PyMap(q2 => q2.PyMap(q1 => q1.PyMap(value => PyMath.ASinh(value)))));
        }

        /// <summary>
        /// Trigonometric inverse tangent, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("arctan") ]
        public static double Atan(double x)
        {
            return Math.Atan(x);
        }

        /// <summary>
        /// Trigonometric inverse tangent, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("arctan") ]
        public static PyList<double> Atan(IList<double> x)
        {
            return x.PyMap(value => Math.Atan(value));
        }

        /// <summary>
        /// Trigonometric inverse tangent, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("arctan") ]
        public static PyList<double> Atan(IEnumerable<double> x)
        {
            return x.PyMap(value => Math.Atan(value));
        }

        /// <summary>
        /// Trigonometric inverse tangent, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("arctan") ]
        public static NdArray1DDouble Atan(NdArray1DDouble x)
        {
            return x.Map(value => Math.Atan(value));
        }

        /// <summary>
        /// Trigonometric inverse tangent, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("arctan") ]
        public static PyList<PyList<double>> Atan(IList<IList<double>> x)
        {
            return x.PyMap(q1 => q1.PyMap(value => Math.Atan(value)));
        }

        /// <summary>
        /// Trigonometric inverse tangent, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("arctan") ]
        public static PyList<PyList<double>> Atan(IEnumerable<IEnumerable<double>> x)
        {
            return x.PyMap(q1 => q1.PyMap(value => Math.Atan(value)));
        }

        /// <summary>
        /// Trigonometric inverse tangent, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("arctan") ]
        public static NdArray2DDouble Atan(NdArray2DDouble x)
        {
            return x.Map(value => Math.Atan(value));
        }

        /// <summary>
        /// Trigonometric inverse tangent, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("arctan") ]
        public static PyList<PyList<PyList<double>>> Atan(IList<IList<IList<double>>> x)
        {
            return x.PyMap(q2 => q2.PyMap(q1 => q1.PyMap(value => Math.Atan(value))));
        }

        /// <summary>
        /// Trigonometric inverse tangent, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("arctan") ]
        public static PyList<PyList<PyList<double>>> Atan(IEnumerable<IEnumerable<IEnumerable<double>>> x)
        {
            return x.PyMap(q2 => q2.PyMap(q1 => q1.PyMap(value => Math.Atan(value))));
        }

        /// <summary>
        /// Trigonometric inverse tangent, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("arctan") ]
        public static NdArray3DDouble Atan(NdArray3DDouble x)
        {
            return x.Map(value => Math.Atan(value));
        }

        /// <summary>
        /// Trigonometric inverse tangent, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("arctan") ]
        public static PyList<PyList<PyList<PyList<double>>>> Atan(IList<IList<IList<IList<double>>>> x)
        {
            return x.PyMap(q3 => q3.PyMap(q2 => q2.PyMap(q1 => q1.PyMap(value => Math.Atan(value)))));
        }

        /// <summary>
        /// Trigonometric inverse tangent, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("arctan") ]
        public static PyList<PyList<PyList<PyList<double>>>> Atan(IEnumerable<IEnumerable<IEnumerable<IEnumerable<double>>>> x)
        {
            return x.PyMap(q3 => q3.PyMap(q2 => q2.PyMap(q1 => q1.PyMap(value => Math.Atan(value)))));
        }

        /// <summary>
        /// Trigonometric inverse tangent, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("arctan") ]
        public static NdArray4DDouble Atan(NdArray4DDouble x)
        {
            return x.Map(value => Math.Atan(value));
        }

        /// <summary>
        /// Trigonometric inverse tangent, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("arctan") ]
        public static PyList<double> Atan(IList<int> x)
        {
            return x.PyMap(value => Math.Atan(value));
        }

        /// <summary>
        /// Trigonometric inverse tangent, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("arctan") ]
        public static PyList<double> Atan(IEnumerable<int> x)
        {
            return x.PyMap(value => Math.Atan(value));
        }

        /// <summary>
        /// Trigonometric inverse tangent, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("arctan") ]
        public static PyList<PyList<double>> Atan(IList<IList<int>> x)
        {
            return x.PyMap(q1 => q1.PyMap(value => Math.Atan(value)));
        }

        /// <summary>
        /// Trigonometric inverse tangent, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("arctan") ]
        public static PyList<PyList<double>> Atan(IEnumerable<IEnumerable<int>> x)
        {
            return x.PyMap(q1 => q1.PyMap(value => Math.Atan(value)));
        }

        /// <summary>
        /// Trigonometric inverse tangent, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("arctan") ]
        public static PyList<PyList<PyList<double>>> Atan(IList<IList<IList<int>>> x)
        {
            return x.PyMap(q2 => q2.PyMap(q1 => q1.PyMap(value => Math.Atan(value))));
        }

        /// <summary>
        /// Trigonometric inverse tangent, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("arctan") ]
        public static PyList<PyList<PyList<double>>> Atan(IEnumerable<IEnumerable<IEnumerable<int>>> x)
        {
            return x.PyMap(q2 => q2.PyMap(q1 => q1.PyMap(value => Math.Atan(value))));
        }

        /// <summary>
        /// Trigonometric inverse tangent, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("arctan") ]
        public static PyList<PyList<PyList<PyList<double>>>> Atan(IList<IList<IList<IList<int>>>> x)
        {
            return x.PyMap(q3 => q3.PyMap(q2 => q2.PyMap(q1 => q1.PyMap(value => Math.Atan(value)))));
        }

        /// <summary>
        /// Trigonometric inverse tangent, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("arctan") ]
        public static PyList<PyList<PyList<PyList<double>>>> Atan(IEnumerable<IEnumerable<IEnumerable<IEnumerable<int>>>> x)
        {
            return x.PyMap(q3 => q3.PyMap(q2 => q2.PyMap(q1 => q1.PyMap(value => Math.Atan(value)))));
        }

        [ DirectCall("arctan2") ]
        public static PyList<double> Atan2(IList<double> y, IList<double> x)
        {
            return x.Zip(y, (a, b) => new {X = a, Y = b}).PyMap(q => Math.Atan2(q.Y, q.X));
        }

        [ DirectCall("arctan2") ]
        public static PyList<double> Atan2(IEnumerable<double> y, IList<double> x)
        {
            return x.Zip(y, (a, b) => new {X = a, Y = b}).PyMap(q => Math.Atan2(q.Y, q.X));
        }

        [ DirectCall("arctan2") ]
        public static PyList<double> Atan2(NdArray<double> y, IList<double> x)
        {
            return x.Zip(y.AsEnumerable(), (a, b) => new {X = a, Y = b}).PyMap(q => Math.Atan2(q.Y, q.X));
        }

        [ DirectCall("arctan2") ]
        public static PyList<double> Atan2(IList<double> y, IEnumerable<double> x)
        {
            return x.Zip(y, (a, b) => new {X = a, Y = b}).PyMap(q => Math.Atan2(q.Y, q.X));
        }

        [ DirectCall("arctan2") ]
        public static PyList<double> Atan2(IEnumerable<double> y, IEnumerable<double> x)
        {
            return x.Zip(y, (a, b) => new {X = a, Y = b}).PyMap(q => Math.Atan2(q.Y, q.X));
        }

        [ DirectCall("arctan2") ]
        public static PyList<double> Atan2(NdArray<double> y, IEnumerable<double> x)
        {
            return x.Zip(y.AsEnumerable(), (a, b) => new {X = a, Y = b}).PyMap(q => Math.Atan2(q.Y, q.X));
        }

        [ DirectCall("arctan2") ]
        public static PyList<double> Atan2(IList<double> y, NdArray<double> x)
        {
            return x.AsEnumerable().Zip(y, (a, b) => new {X = a, Y = b}).PyMap(q => Math.Atan2(q.Y, q.X));
        }

        [ DirectCall("arctan2") ]
        public static PyList<double> Atan2(IEnumerable<double> y, NdArray<double> x)
        {
            return x.AsEnumerable().Zip(y, (a, b) => new {X = a, Y = b}).PyMap(q => Math.Atan2(q.Y, q.X));
        }

        [ DirectCall("arctan2") ]
        public static PyList<double> Atan2(NdArray<double> y, NdArray<double> x)
        {
            return x.AsEnumerable().Zip(y.AsEnumerable(), (a, b) => new {X = a, Y = b}).PyMap(q => Math.Atan2(q.Y, q.X));
        }

        /// <summary>
        /// Inverse hyperbolic tangent, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("arctanh") ]
        public static double ATanh(double x)
        {
            return PyMath.ATanh(x);
        }

        /// <summary>
        /// Inverse hyperbolic tangent, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("arctanh") ]
        public static PyList<double> ATanh(IList<double> x)
        {
            return x.PyMap(value => PyMath.ATanh(value));
        }

        /// <summary>
        /// Inverse hyperbolic tangent, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("arctanh") ]
        public static PyList<double> ATanh(IEnumerable<double> x)
        {
            return x.PyMap(value => PyMath.ATanh(value));
        }

        /// <summary>
        /// Inverse hyperbolic tangent, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("arctanh") ]
        public static NdArray1DDouble ATanh(NdArray1DDouble x)
        {
            return x.Map(value => PyMath.ATanh(value));
        }

        /// <summary>
        /// Inverse hyperbolic tangent, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("arctanh") ]
        public static PyList<PyList<double>> ATanh(IList<IList<double>> x)
        {
            return x.PyMap(q1 => q1.PyMap(value => PyMath.ATanh(value)));
        }

        /// <summary>
        /// Inverse hyperbolic tangent, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("arctanh") ]
        public static PyList<PyList<double>> ATanh(IEnumerable<IEnumerable<double>> x)
        {
            return x.PyMap(q1 => q1.PyMap(value => PyMath.ATanh(value)));
        }

        /// <summary>
        /// Inverse hyperbolic tangent, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("arctanh") ]
        public static NdArray2DDouble ATanh(NdArray2DDouble x)
        {
            return x.Map(value => PyMath.ATanh(value));
        }

        /// <summary>
        /// Inverse hyperbolic tangent, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("arctanh") ]
        public static PyList<PyList<PyList<double>>> ATanh(IList<IList<IList<double>>> x)
        {
            return x.PyMap(q2 => q2.PyMap(q1 => q1.PyMap(value => PyMath.ATanh(value))));
        }

        /// <summary>
        /// Inverse hyperbolic tangent, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("arctanh") ]
        public static PyList<PyList<PyList<double>>> ATanh(IEnumerable<IEnumerable<IEnumerable<double>>> x)
        {
            return x.PyMap(q2 => q2.PyMap(q1 => q1.PyMap(value => PyMath.ATanh(value))));
        }

        /// <summary>
        /// Inverse hyperbolic tangent, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("arctanh") ]
        public static NdArray3DDouble ATanh(NdArray3DDouble x)
        {
            return x.Map(value => PyMath.ATanh(value));
        }

        /// <summary>
        /// Inverse hyperbolic tangent, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("arctanh") ]
        public static PyList<PyList<PyList<PyList<double>>>> ATanh(IList<IList<IList<IList<double>>>> x)
        {
            return x.PyMap(q3 => q3.PyMap(q2 => q2.PyMap(q1 => q1.PyMap(value => PyMath.ATanh(value)))));
        }

        /// <summary>
        /// Inverse hyperbolic tangent, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("arctanh") ]
        public static PyList<PyList<PyList<PyList<double>>>> ATanh(IEnumerable<IEnumerable<IEnumerable<IEnumerable<double>>>> x)
        {
            return x.PyMap(q3 => q3.PyMap(q2 => q2.PyMap(q1 => q1.PyMap(value => PyMath.ATanh(value)))));
        }

        /// <summary>
        /// Inverse hyperbolic tangent, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("arctanh") ]
        public static NdArray4DDouble ATanh(NdArray4DDouble x)
        {
            return x.Map(value => PyMath.ATanh(value));
        }

        /// <summary>
        /// Inverse hyperbolic tangent, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("arctanh") ]
        public static PyList<double> ATanh(IList<int> x)
        {
            return x.PyMap(value => PyMath.ATanh(value));
        }

        /// <summary>
        /// Inverse hyperbolic tangent, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("arctanh") ]
        public static PyList<double> ATanh(IEnumerable<int> x)
        {
            return x.PyMap(value => PyMath.ATanh(value));
        }

        /// <summary>
        /// Inverse hyperbolic tangent, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("arctanh") ]
        public static PyList<PyList<double>> ATanh(IList<IList<int>> x)
        {
            return x.PyMap(q1 => q1.PyMap(value => PyMath.ATanh(value)));
        }

        /// <summary>
        /// Inverse hyperbolic tangent, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("arctanh") ]
        public static PyList<PyList<double>> ATanh(IEnumerable<IEnumerable<int>> x)
        {
            return x.PyMap(q1 => q1.PyMap(value => PyMath.ATanh(value)));
        }

        /// <summary>
        /// Inverse hyperbolic tangent, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("arctanh") ]
        public static PyList<PyList<PyList<double>>> ATanh(IList<IList<IList<int>>> x)
        {
            return x.PyMap(q2 => q2.PyMap(q1 => q1.PyMap(value => PyMath.ATanh(value))));
        }

        /// <summary>
        /// Inverse hyperbolic tangent, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("arctanh") ]
        public static PyList<PyList<PyList<double>>> ATanh(IEnumerable<IEnumerable<IEnumerable<int>>> x)
        {
            return x.PyMap(q2 => q2.PyMap(q1 => q1.PyMap(value => PyMath.ATanh(value))));
        }

        /// <summary>
        /// Inverse hyperbolic tangent, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("arctanh") ]
        public static PyList<PyList<PyList<PyList<double>>>> ATanh(IList<IList<IList<IList<int>>>> x)
        {
            return x.PyMap(q3 => q3.PyMap(q2 => q2.PyMap(q1 => q1.PyMap(value => PyMath.ATanh(value)))));
        }

        /// <summary>
        /// Inverse hyperbolic tangent, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("arctanh") ]
        public static PyList<PyList<PyList<PyList<double>>>> ATanh(IEnumerable<IEnumerable<IEnumerable<IEnumerable<int>>>> x)
        {
            return x.PyMap(q3 => q3.PyMap(q2 => q2.PyMap(q1 => q1.PyMap(value => PyMath.ATanh(value)))));
        }

        /// <summary>
        /// Trigonometric cosine element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("cos") ]
        public static double Cos(double x)
        {
            return Math.Cos(x);
        }

        /// <summary>
        /// Trigonometric cosine element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("cos") ]
        public static PyList<double> Cos(IList<double> x)
        {
            return x.PyMap(value => Math.Cos(value));
        }

        /// <summary>
        /// Trigonometric cosine element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("cos") ]
        public static PyList<double> Cos(IEnumerable<double> x)
        {
            return x.PyMap(value => Math.Cos(value));
        }

        /// <summary>
        /// Trigonometric cosine element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("cos") ]
        public static NdArray1DDouble Cos(NdArray1DDouble x)
        {
            return x.Map(value => Math.Cos(value));
        }

        /// <summary>
        /// Trigonometric cosine element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("cos") ]
        public static PyList<PyList<double>> Cos(IList<IList<double>> x)
        {
            return x.PyMap(q1 => q1.PyMap(value => Math.Cos(value)));
        }

        /// <summary>
        /// Trigonometric cosine element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("cos") ]
        public static PyList<PyList<double>> Cos(IEnumerable<IEnumerable<double>> x)
        {
            return x.PyMap(q1 => q1.PyMap(value => Math.Cos(value)));
        }

        /// <summary>
        /// Trigonometric cosine element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("cos") ]
        public static NdArray2DDouble Cos(NdArray2DDouble x)
        {
            return x.Map(value => Math.Cos(value));
        }

        /// <summary>
        /// Trigonometric cosine element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("cos") ]
        public static PyList<PyList<PyList<double>>> Cos(IList<IList<IList<double>>> x)
        {
            return x.PyMap(q2 => q2.PyMap(q1 => q1.PyMap(value => Math.Cos(value))));
        }

        /// <summary>
        /// Trigonometric cosine element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("cos") ]
        public static PyList<PyList<PyList<double>>> Cos(IEnumerable<IEnumerable<IEnumerable<double>>> x)
        {
            return x.PyMap(q2 => q2.PyMap(q1 => q1.PyMap(value => Math.Cos(value))));
        }

        /// <summary>
        /// Trigonometric cosine element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("cos") ]
        public static NdArray3DDouble Cos(NdArray3DDouble x)
        {
            return x.Map(value => Math.Cos(value));
        }

        /// <summary>
        /// Trigonometric cosine element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("cos") ]
        public static PyList<PyList<PyList<PyList<double>>>> Cos(IList<IList<IList<IList<double>>>> x)
        {
            return x.PyMap(q3 => q3.PyMap(q2 => q2.PyMap(q1 => q1.PyMap(value => Math.Cos(value)))));
        }

        /// <summary>
        /// Trigonometric cosine element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("cos") ]
        public static PyList<PyList<PyList<PyList<double>>>> Cos(IEnumerable<IEnumerable<IEnumerable<IEnumerable<double>>>> x)
        {
            return x.PyMap(q3 => q3.PyMap(q2 => q2.PyMap(q1 => q1.PyMap(value => Math.Cos(value)))));
        }

        /// <summary>
        /// Trigonometric cosine element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("cos") ]
        public static NdArray4DDouble Cos(NdArray4DDouble x)
        {
            return x.Map(value => Math.Cos(value));
        }

        /// <summary>
        /// Trigonometric cosine element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("cos") ]
        public static PyList<double> Cos(IList<int> x)
        {
            return x.PyMap(value => Math.Cos(value));
        }

        /// <summary>
        /// Trigonometric cosine element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("cos") ]
        public static PyList<double> Cos(IEnumerable<int> x)
        {
            return x.PyMap(value => Math.Cos(value));
        }

        /// <summary>
        /// Trigonometric cosine element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("cos") ]
        public static PyList<PyList<double>> Cos(IList<IList<int>> x)
        {
            return x.PyMap(q1 => q1.PyMap(value => Math.Cos(value)));
        }

        /// <summary>
        /// Trigonometric cosine element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("cos") ]
        public static PyList<PyList<double>> Cos(IEnumerable<IEnumerable<int>> x)
        {
            return x.PyMap(q1 => q1.PyMap(value => Math.Cos(value)));
        }

        /// <summary>
        /// Trigonometric cosine element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("cos") ]
        public static PyList<PyList<PyList<double>>> Cos(IList<IList<IList<int>>> x)
        {
            return x.PyMap(q2 => q2.PyMap(q1 => q1.PyMap(value => Math.Cos(value))));
        }

        /// <summary>
        /// Trigonometric cosine element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("cos") ]
        public static PyList<PyList<PyList<double>>> Cos(IEnumerable<IEnumerable<IEnumerable<int>>> x)
        {
            return x.PyMap(q2 => q2.PyMap(q1 => q1.PyMap(value => Math.Cos(value))));
        }

        /// <summary>
        /// Trigonometric cosine element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("cos") ]
        public static PyList<PyList<PyList<PyList<double>>>> Cos(IList<IList<IList<IList<int>>>> x)
        {
            return x.PyMap(q3 => q3.PyMap(q2 => q2.PyMap(q1 => q1.PyMap(value => Math.Cos(value)))));
        }

        /// <summary>
        /// Trigonometric cosine element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("cos") ]
        public static PyList<PyList<PyList<PyList<double>>>> Cos(IEnumerable<IEnumerable<IEnumerable<IEnumerable<int>>>> x)
        {
            return x.PyMap(q3 => q3.PyMap(q2 => q2.PyMap(q1 => q1.PyMap(value => Math.Cos(value)))));
        }

        /// <summary>
        /// Hyperbolic cosine, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("cosh") ]
        public static double Cosh(double x)
        {
            return Math.Cosh(x);
        }

        /// <summary>
        /// Hyperbolic cosine, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("cosh") ]
        public static PyList<double> Cosh(IList<double> x)
        {
            return x.PyMap(value => Math.Cosh(value));
        }

        /// <summary>
        /// Hyperbolic cosine, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("cosh") ]
        public static PyList<double> Cosh(IEnumerable<double> x)
        {
            return x.PyMap(value => Math.Cosh(value));
        }

        /// <summary>
        /// Hyperbolic cosine, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("cosh") ]
        public static NdArray1DDouble Cosh(NdArray1DDouble x)
        {
            return x.Map(value => Math.Cosh(value));
        }

        /// <summary>
        /// Hyperbolic cosine, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("cosh") ]
        public static PyList<PyList<double>> Cosh(IList<IList<double>> x)
        {
            return x.PyMap(q1 => q1.PyMap(value => Math.Cosh(value)));
        }

        /// <summary>
        /// Hyperbolic cosine, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("cosh") ]
        public static PyList<PyList<double>> Cosh(IEnumerable<IEnumerable<double>> x)
        {
            return x.PyMap(q1 => q1.PyMap(value => Math.Cosh(value)));
        }

        /// <summary>
        /// Hyperbolic cosine, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("cosh") ]
        public static NdArray2DDouble Cosh(NdArray2DDouble x)
        {
            return x.Map(value => Math.Cosh(value));
        }

        /// <summary>
        /// Hyperbolic cosine, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("cosh") ]
        public static PyList<PyList<PyList<double>>> Cosh(IList<IList<IList<double>>> x)
        {
            return x.PyMap(q2 => q2.PyMap(q1 => q1.PyMap(value => Math.Cosh(value))));
        }

        /// <summary>
        /// Hyperbolic cosine, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("cosh") ]
        public static PyList<PyList<PyList<double>>> Cosh(IEnumerable<IEnumerable<IEnumerable<double>>> x)
        {
            return x.PyMap(q2 => q2.PyMap(q1 => q1.PyMap(value => Math.Cosh(value))));
        }

        /// <summary>
        /// Hyperbolic cosine, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("cosh") ]
        public static NdArray3DDouble Cosh(NdArray3DDouble x)
        {
            return x.Map(value => Math.Cosh(value));
        }

        /// <summary>
        /// Hyperbolic cosine, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("cosh") ]
        public static PyList<PyList<PyList<PyList<double>>>> Cosh(IList<IList<IList<IList<double>>>> x)
        {
            return x.PyMap(q3 => q3.PyMap(q2 => q2.PyMap(q1 => q1.PyMap(value => Math.Cosh(value)))));
        }

        /// <summary>
        /// Hyperbolic cosine, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("cosh") ]
        public static PyList<PyList<PyList<PyList<double>>>> Cosh(IEnumerable<IEnumerable<IEnumerable<IEnumerable<double>>>> x)
        {
            return x.PyMap(q3 => q3.PyMap(q2 => q2.PyMap(q1 => q1.PyMap(value => Math.Cosh(value)))));
        }

        /// <summary>
        /// Hyperbolic cosine, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("cosh") ]
        public static NdArray4DDouble Cosh(NdArray4DDouble x)
        {
            return x.Map(value => Math.Cosh(value));
        }

        /// <summary>
        /// Hyperbolic cosine, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("cosh") ]
        public static PyList<double> Cosh(IList<int> x)
        {
            return x.PyMap(value => Math.Cosh(value));
        }

        /// <summary>
        /// Hyperbolic cosine, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("cosh") ]
        public static PyList<double> Cosh(IEnumerable<int> x)
        {
            return x.PyMap(value => Math.Cosh(value));
        }

        /// <summary>
        /// Hyperbolic cosine, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("cosh") ]
        public static PyList<PyList<double>> Cosh(IList<IList<int>> x)
        {
            return x.PyMap(q1 => q1.PyMap(value => Math.Cosh(value)));
        }

        /// <summary>
        /// Hyperbolic cosine, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("cosh") ]
        public static PyList<PyList<double>> Cosh(IEnumerable<IEnumerable<int>> x)
        {
            return x.PyMap(q1 => q1.PyMap(value => Math.Cosh(value)));
        }

        /// <summary>
        /// Hyperbolic cosine, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("cosh") ]
        public static PyList<PyList<PyList<double>>> Cosh(IList<IList<IList<int>>> x)
        {
            return x.PyMap(q2 => q2.PyMap(q1 => q1.PyMap(value => Math.Cosh(value))));
        }

        /// <summary>
        /// Hyperbolic cosine, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("cosh") ]
        public static PyList<PyList<PyList<double>>> Cosh(IEnumerable<IEnumerable<IEnumerable<int>>> x)
        {
            return x.PyMap(q2 => q2.PyMap(q1 => q1.PyMap(value => Math.Cosh(value))));
        }

        /// <summary>
        /// Hyperbolic cosine, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("cosh") ]
        public static PyList<PyList<PyList<PyList<double>>>> Cosh(IList<IList<IList<IList<int>>>> x)
        {
            return x.PyMap(q3 => q3.PyMap(q2 => q2.PyMap(q1 => q1.PyMap(value => Math.Cosh(value)))));
        }

        /// <summary>
        /// Hyperbolic cosine, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("cosh") ]
        public static PyList<PyList<PyList<PyList<double>>>> Cosh(IEnumerable<IEnumerable<IEnumerable<IEnumerable<int>>>> x)
        {
            return x.PyMap(q3 => q3.PyMap(q2 => q2.PyMap(q1 => q1.PyMap(value => Math.Cosh(value)))));
        }

        [ DirectCall("degrees") ]
        public static double Degrees(double x)
        {
            const double mul = 180.0 / Math.PI;
            return x * mul;
        }

        [ DirectCall("degrees") ]
        public static PyList<double> Degrees(IList<double> x)
        {
            const double mul = 180.0 / Math.PI;
            return x.PyMap(value => value * mul);
        }

        [ DirectCall("degrees") ]
        public static PyList<double> Degrees(IEnumerable<double> x)
        {
            const double mul = 180.0 / Math.PI;
            return x.PyMap(value => value * mul);
        }

        [ DirectCall("degrees") ]
        public static NdArray1DDouble Degrees(NdArray1DDouble x)
        {
            const double mul = 180.0 / Math.PI;
            return x.Map(value => value * mul);
        }

        [ DirectCall("degrees") ]
        public static PyList<PyList<double>> Degrees(IList<IList<double>> x)
        {
            const double mul = 180.0 / Math.PI;
            return x.PyMap(q1 => q1.PyMap(value => value * mul));
        }

        [ DirectCall("degrees") ]
        public static PyList<PyList<double>> Degrees(IEnumerable<IEnumerable<double>> x)
        {
            const double mul = 180.0 / Math.PI;
            return x.PyMap(q1 => q1.PyMap(value => value * mul));
        }

        [ DirectCall("degrees") ]
        public static NdArray2DDouble Degrees(NdArray2DDouble x)
        {
            const double mul = 180.0 / Math.PI;
            return x.Map(value => value * mul);
        }

        [ DirectCall("degrees") ]
        public static PyList<PyList<PyList<double>>> Degrees(IList<IList<IList<double>>> x)
        {
            const double mul = 180.0 / Math.PI;
            return x.PyMap(q2 => q2.PyMap(q1 => q1.PyMap(value => value * mul)));
        }

        [ DirectCall("degrees") ]
        public static PyList<PyList<PyList<double>>> Degrees(IEnumerable<IEnumerable<IEnumerable<double>>> x)
        {
            const double mul = 180.0 / Math.PI;
            return x.PyMap(q2 => q2.PyMap(q1 => q1.PyMap(value => value * mul)));
        }

        [ DirectCall("degrees") ]
        public static NdArray3DDouble Degrees(NdArray3DDouble x)
        {
            const double mul = 180.0 / Math.PI;
            return x.Map(value => value * mul);
        }

        [ DirectCall("degrees") ]
        public static PyList<PyList<PyList<PyList<double>>>> Degrees(IList<IList<IList<IList<double>>>> x)
        {
            const double mul = 180.0 / Math.PI;
            return x.PyMap(q3 => q3.PyMap(q2 => q2.PyMap(q1 => q1.PyMap(value => value * mul))));
        }

        [ DirectCall("degrees") ]
        public static PyList<PyList<PyList<PyList<double>>>> Degrees(IEnumerable<IEnumerable<IEnumerable<IEnumerable<double>>>> x)
        {
            const double mul = 180.0 / Math.PI;
            return x.PyMap(q3 => q3.PyMap(q2 => q2.PyMap(q1 => q1.PyMap(value => value * mul))));
        }

        [ DirectCall("degrees") ]
        public static NdArray4DDouble Degrees(NdArray4DDouble x)
        {
            const double mul = 180.0 / Math.PI;
            return x.Map(value => value * mul);
        }

        [ DirectCall("degrees") ]
        public static PyList<double> Degrees(IList<int> x)
        {
            const double mul = 180.0 / Math.PI;
            return x.PyMap(value => value * mul);
        }

        [ DirectCall("degrees") ]
        public static PyList<double> Degrees(IEnumerable<int> x)
        {
            const double mul = 180.0 / Math.PI;
            return x.PyMap(value => value * mul);
        }

        [ DirectCall("degrees") ]
        public static PyList<PyList<double>> Degrees(IList<IList<int>> x)
        {
            const double mul = 180.0 / Math.PI;
            return x.PyMap(q1 => q1.PyMap(value => value * mul));
        }

        [ DirectCall("degrees") ]
        public static PyList<PyList<double>> Degrees(IEnumerable<IEnumerable<int>> x)
        {
            const double mul = 180.0 / Math.PI;
            return x.PyMap(q1 => q1.PyMap(value => value * mul));
        }

        [ DirectCall("degrees") ]
        public static PyList<PyList<PyList<double>>> Degrees(IList<IList<IList<int>>> x)
        {
            const double mul = 180.0 / Math.PI;
            return x.PyMap(q2 => q2.PyMap(q1 => q1.PyMap(value => value * mul)));
        }

        [ DirectCall("degrees") ]
        public static PyList<PyList<PyList<double>>> Degrees(IEnumerable<IEnumerable<IEnumerable<int>>> x)
        {
            const double mul = 180.0 / Math.PI;
            return x.PyMap(q2 => q2.PyMap(q1 => q1.PyMap(value => value * mul)));
        }

        [ DirectCall("degrees") ]
        public static PyList<PyList<PyList<PyList<double>>>> Degrees(IList<IList<IList<IList<int>>>> x)
        {
            const double mul = 180.0 / Math.PI;
            return x.PyMap(q3 => q3.PyMap(q2 => q2.PyMap(q1 => q1.PyMap(value => value * mul))));
        }

        [ DirectCall("degrees") ]
        public static PyList<PyList<PyList<PyList<double>>>> Degrees(IEnumerable<IEnumerable<IEnumerable<IEnumerable<int>>>> x)
        {
            const double mul = 180.0 / Math.PI;
            return x.PyMap(q3 => q3.PyMap(q2 => q2.PyMap(q1 => q1.PyMap(value => value * mul))));
        }

        [ DirectCall("hypot") ]
        public static PyList<double> Hypot(IList<double> x, IList<double> y)
        {
            return x.Zip(y, (a, b) => new {X = a, Y = b}).PyMap(q => Math.Sqrt(q.Y * q.Y + q.X * q.X));
        }

        [ DirectCall("hypot") ]
        public static PyList<double> Hypot(IEnumerable<double> x, IList<double> y)
        {
            return x.Zip(y, (a, b) => new {X = a, Y = b}).PyMap(q => Math.Sqrt(q.Y * q.Y + q.X * q.X));
        }

        [ DirectCall("hypot") ]
        public static PyList<double> Hypot(NdArray<double> x, IList<double> y)
        {
            return x.AsEnumerable().Zip(y, (a, b) => new {X = a, Y = b}).PyMap(q => Math.Sqrt(q.Y * q.Y + q.X * q.X));
        }

        [ DirectCall("hypot") ]
        public static PyList<double> Hypot(IList<double> x, IEnumerable<double> y)
        {
            return x.Zip(y, (a, b) => new {X = a, Y = b}).PyMap(q => Math.Sqrt(q.Y * q.Y + q.X * q.X));
        }

        [ DirectCall("hypot") ]
        public static PyList<double> Hypot(IEnumerable<double> x, IEnumerable<double> y)
        {
            return x.Zip(y, (a, b) => new {X = a, Y = b}).PyMap(q => Math.Sqrt(q.Y * q.Y + q.X * q.X));
        }

        [ DirectCall("hypot") ]
        public static PyList<double> Hypot(NdArray<double> x, IEnumerable<double> y)
        {
            return x.AsEnumerable().Zip(y, (a, b) => new {X = a, Y = b}).PyMap(q => Math.Sqrt(q.Y * q.Y + q.X * q.X));
        }

        [ DirectCall("hypot") ]
        public static PyList<double> Hypot(IList<double> x, NdArray<double> y)
        {
            return x.Zip(y.AsEnumerable(), (a, b) => new {X = a, Y = b}).PyMap(q => Math.Sqrt(q.Y * q.Y + q.X * q.X));
        }

        [ DirectCall("hypot") ]
        public static PyList<double> Hypot(IEnumerable<double> x, NdArray<double> y)
        {
            return x.Zip(y.AsEnumerable(), (a, b) => new {X = a, Y = b}).PyMap(q => Math.Sqrt(q.Y * q.Y + q.X * q.X));
        }

        [ DirectCall("hypot") ]
        public static PyList<double> Hypot(NdArray<double> x, NdArray<double> y)
        {
            return x.AsEnumerable().Zip(y.AsEnumerable(), (a, b) => new {X = a, Y = b}).PyMap(q => Math.Sqrt(q.Y * q.Y + q.X * q.X));
        }

        [ DirectCall("radians") ]
        public static double Radians(double x)
        {
            const double mul = Math.PI / 180.0;
            return x * mul;
        }

        [ DirectCall("radians") ]
        public static PyList<double> Radians(IList<double> x)
        {
            const double mul = Math.PI / 180.0;
            return x.PyMap(value => value * mul);
        }

        [ DirectCall("radians") ]
        public static PyList<double> Radians(IEnumerable<double> x)
        {
            const double mul = Math.PI / 180.0;
            return x.PyMap(value => value * mul);
        }

        [ DirectCall("radians") ]
        public static NdArray1DDouble Radians(NdArray1DDouble x)
        {
            const double mul = Math.PI / 180.0;
            return x.Map(value => value * mul);
        }

        [ DirectCall("radians") ]
        public static PyList<PyList<double>> Radians(IList<IList<double>> x)
        {
            const double mul = Math.PI / 180.0;
            return x.PyMap(q1 => q1.PyMap(value => value * mul));
        }

        [ DirectCall("radians") ]
        public static PyList<PyList<double>> Radians(IEnumerable<IEnumerable<double>> x)
        {
            const double mul = Math.PI / 180.0;
            return x.PyMap(q1 => q1.PyMap(value => value * mul));
        }

        [ DirectCall("radians") ]
        public static NdArray2DDouble Radians(NdArray2DDouble x)
        {
            const double mul = Math.PI / 180.0;
            return x.Map(value => value * mul);
        }

        [ DirectCall("radians") ]
        public static PyList<PyList<PyList<double>>> Radians(IList<IList<IList<double>>> x)
        {
            const double mul = Math.PI / 180.0;
            return x.PyMap(q2 => q2.PyMap(q1 => q1.PyMap(value => value * mul)));
        }

        [ DirectCall("radians") ]
        public static PyList<PyList<PyList<double>>> Radians(IEnumerable<IEnumerable<IEnumerable<double>>> x)
        {
            const double mul = Math.PI / 180.0;
            return x.PyMap(q2 => q2.PyMap(q1 => q1.PyMap(value => value * mul)));
        }

        [ DirectCall("radians") ]
        public static NdArray3DDouble Radians(NdArray3DDouble x)
        {
            const double mul = Math.PI / 180.0;
            return x.Map(value => value * mul);
        }

        [ DirectCall("radians") ]
        public static PyList<PyList<PyList<PyList<double>>>> Radians(IList<IList<IList<IList<double>>>> x)
        {
            const double mul = Math.PI / 180.0;
            return x.PyMap(q3 => q3.PyMap(q2 => q2.PyMap(q1 => q1.PyMap(value => value * mul))));
        }

        [ DirectCall("radians") ]
        public static PyList<PyList<PyList<PyList<double>>>> Radians(IEnumerable<IEnumerable<IEnumerable<IEnumerable<double>>>> x)
        {
            const double mul = Math.PI / 180.0;
            return x.PyMap(q3 => q3.PyMap(q2 => q2.PyMap(q1 => q1.PyMap(value => value * mul))));
        }

        [ DirectCall("radians") ]
        public static NdArray4DDouble Radians(NdArray4DDouble x)
        {
            const double mul = Math.PI / 180.0;
            return x.Map(value => value * mul);
        }

        [ DirectCall("radians") ]
        public static PyList<double> Radians(IList<int> x)
        {
            const double mul = Math.PI / 180.0;
            return x.PyMap(value => value * mul);
        }

        [ DirectCall("radians") ]
        public static PyList<double> Radians(IEnumerable<int> x)
        {
            const double mul = Math.PI / 180.0;
            return x.PyMap(value => value * mul);
        }

        [ DirectCall("radians") ]
        public static PyList<PyList<double>> Radians(IList<IList<int>> x)
        {
            const double mul = Math.PI / 180.0;
            return x.PyMap(q1 => q1.PyMap(value => value * mul));
        }

        [ DirectCall("radians") ]
        public static PyList<PyList<double>> Radians(IEnumerable<IEnumerable<int>> x)
        {
            const double mul = Math.PI / 180.0;
            return x.PyMap(q1 => q1.PyMap(value => value * mul));
        }

        [ DirectCall("radians") ]
        public static PyList<PyList<PyList<double>>> Radians(IList<IList<IList<int>>> x)
        {
            const double mul = Math.PI / 180.0;
            return x.PyMap(q2 => q2.PyMap(q1 => q1.PyMap(value => value * mul)));
        }

        [ DirectCall("radians") ]
        public static PyList<PyList<PyList<double>>> Radians(IEnumerable<IEnumerable<IEnumerable<int>>> x)
        {
            const double mul = Math.PI / 180.0;
            return x.PyMap(q2 => q2.PyMap(q1 => q1.PyMap(value => value * mul)));
        }

        [ DirectCall("radians") ]
        public static PyList<PyList<PyList<PyList<double>>>> Radians(IList<IList<IList<IList<int>>>> x)
        {
            const double mul = Math.PI / 180.0;
            return x.PyMap(q3 => q3.PyMap(q2 => q2.PyMap(q1 => q1.PyMap(value => value * mul))));
        }

        [ DirectCall("radians") ]
        public static PyList<PyList<PyList<PyList<double>>>> Radians(IEnumerable<IEnumerable<IEnumerable<IEnumerable<int>>>> x)
        {
            const double mul = Math.PI / 180.0;
            return x.PyMap(q3 => q3.PyMap(q2 => q2.PyMap(q1 => q1.PyMap(value => value * mul))));
        }

        /// <summary>
        /// Trigonometric sine, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("sin") ]
        public static double Sin(double x)
        {
            return Math.Sin(x);
        }

        /// <summary>
        /// Trigonometric sine, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("sin") ]
        public static PyList<double> Sin(IList<double> x)
        {
            return x.PyMap(value => Math.Sin(value));
        }

        /// <summary>
        /// Trigonometric sine, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("sin") ]
        public static PyList<double> Sin(IEnumerable<double> x)
        {
            return x.PyMap(value => Math.Sin(value));
        }

        /// <summary>
        /// Trigonometric sine, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("sin") ]
        public static NdArray1DDouble Sin(NdArray1DDouble x)
        {
            return x.Map(value => Math.Sin(value));
        }

        /// <summary>
        /// Trigonometric sine, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("sin") ]
        public static PyList<PyList<double>> Sin(IList<IList<double>> x)
        {
            return x.PyMap(q1 => q1.PyMap(value => Math.Sin(value)));
        }

        /// <summary>
        /// Trigonometric sine, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("sin") ]
        public static PyList<PyList<double>> Sin(IEnumerable<IEnumerable<double>> x)
        {
            return x.PyMap(q1 => q1.PyMap(value => Math.Sin(value)));
        }

        /// <summary>
        /// Trigonometric sine, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("sin") ]
        public static NdArray2DDouble Sin(NdArray2DDouble x)
        {
            return x.Map(value => Math.Sin(value));
        }

        /// <summary>
        /// Trigonometric sine, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("sin") ]
        public static PyList<PyList<PyList<double>>> Sin(IList<IList<IList<double>>> x)
        {
            return x.PyMap(q2 => q2.PyMap(q1 => q1.PyMap(value => Math.Sin(value))));
        }

        /// <summary>
        /// Trigonometric sine, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("sin") ]
        public static PyList<PyList<PyList<double>>> Sin(IEnumerable<IEnumerable<IEnumerable<double>>> x)
        {
            return x.PyMap(q2 => q2.PyMap(q1 => q1.PyMap(value => Math.Sin(value))));
        }

        /// <summary>
        /// Trigonometric sine, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("sin") ]
        public static NdArray3DDouble Sin(NdArray3DDouble x)
        {
            return x.Map(value => Math.Sin(value));
        }

        /// <summary>
        /// Trigonometric sine, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("sin") ]
        public static PyList<PyList<PyList<PyList<double>>>> Sin(IList<IList<IList<IList<double>>>> x)
        {
            return x.PyMap(q3 => q3.PyMap(q2 => q2.PyMap(q1 => q1.PyMap(value => Math.Sin(value)))));
        }

        /// <summary>
        /// Trigonometric sine, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("sin") ]
        public static PyList<PyList<PyList<PyList<double>>>> Sin(IEnumerable<IEnumerable<IEnumerable<IEnumerable<double>>>> x)
        {
            return x.PyMap(q3 => q3.PyMap(q2 => q2.PyMap(q1 => q1.PyMap(value => Math.Sin(value)))));
        }

        /// <summary>
        /// Trigonometric sine, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("sin") ]
        public static NdArray4DDouble Sin(NdArray4DDouble x)
        {
            return x.Map(value => Math.Sin(value));
        }

        /// <summary>
        /// Trigonometric sine, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("sin") ]
        public static PyList<double> Sin(IList<int> x)
        {
            return x.PyMap(value => Math.Sin(value));
        }

        /// <summary>
        /// Trigonometric sine, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("sin") ]
        public static PyList<double> Sin(IEnumerable<int> x)
        {
            return x.PyMap(value => Math.Sin(value));
        }

        /// <summary>
        /// Trigonometric sine, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("sin") ]
        public static PyList<PyList<double>> Sin(IList<IList<int>> x)
        {
            return x.PyMap(q1 => q1.PyMap(value => Math.Sin(value)));
        }

        /// <summary>
        /// Trigonometric sine, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("sin") ]
        public static PyList<PyList<double>> Sin(IEnumerable<IEnumerable<int>> x)
        {
            return x.PyMap(q1 => q1.PyMap(value => Math.Sin(value)));
        }

        /// <summary>
        /// Trigonometric sine, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("sin") ]
        public static PyList<PyList<PyList<double>>> Sin(IList<IList<IList<int>>> x)
        {
            return x.PyMap(q2 => q2.PyMap(q1 => q1.PyMap(value => Math.Sin(value))));
        }

        /// <summary>
        /// Trigonometric sine, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("sin") ]
        public static PyList<PyList<PyList<double>>> Sin(IEnumerable<IEnumerable<IEnumerable<int>>> x)
        {
            return x.PyMap(q2 => q2.PyMap(q1 => q1.PyMap(value => Math.Sin(value))));
        }

        /// <summary>
        /// Trigonometric sine, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("sin") ]
        public static PyList<PyList<PyList<PyList<double>>>> Sin(IList<IList<IList<IList<int>>>> x)
        {
            return x.PyMap(q3 => q3.PyMap(q2 => q2.PyMap(q1 => q1.PyMap(value => Math.Sin(value)))));
        }

        /// <summary>
        /// Trigonometric sine, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("sin") ]
        public static PyList<PyList<PyList<PyList<double>>>> Sin(IEnumerable<IEnumerable<IEnumerable<IEnumerable<int>>>> x)
        {
            return x.PyMap(q3 => q3.PyMap(q2 => q2.PyMap(q1 => q1.PyMap(value => Math.Sin(value)))));
        }

        /// <summary>
        /// Hyperbolic sine, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("sinh") ]
        public static double Sinh(double x)
        {
            return Math.Sinh(x);
        }

        /// <summary>
        /// Hyperbolic sine, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("sinh") ]
        public static PyList<double> Sinh(IList<double> x)
        {
            return x.PyMap(value => Math.Sinh(value));
        }

        /// <summary>
        /// Hyperbolic sine, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("sinh") ]
        public static PyList<double> Sinh(IEnumerable<double> x)
        {
            return x.PyMap(value => Math.Sinh(value));
        }

        /// <summary>
        /// Hyperbolic sine, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("sinh") ]
        public static NdArray1DDouble Sinh(NdArray1DDouble x)
        {
            return x.Map(value => Math.Sinh(value));
        }

        /// <summary>
        /// Hyperbolic sine, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("sinh") ]
        public static PyList<PyList<double>> Sinh(IList<IList<double>> x)
        {
            return x.PyMap(q1 => q1.PyMap(value => Math.Sinh(value)));
        }

        /// <summary>
        /// Hyperbolic sine, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("sinh") ]
        public static PyList<PyList<double>> Sinh(IEnumerable<IEnumerable<double>> x)
        {
            return x.PyMap(q1 => q1.PyMap(value => Math.Sinh(value)));
        }

        /// <summary>
        /// Hyperbolic sine, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("sinh") ]
        public static NdArray2DDouble Sinh(NdArray2DDouble x)
        {
            return x.Map(value => Math.Sinh(value));
        }

        /// <summary>
        /// Hyperbolic sine, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("sinh") ]
        public static PyList<PyList<PyList<double>>> Sinh(IList<IList<IList<double>>> x)
        {
            return x.PyMap(q2 => q2.PyMap(q1 => q1.PyMap(value => Math.Sinh(value))));
        }

        /// <summary>
        /// Hyperbolic sine, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("sinh") ]
        public static PyList<PyList<PyList<double>>> Sinh(IEnumerable<IEnumerable<IEnumerable<double>>> x)
        {
            return x.PyMap(q2 => q2.PyMap(q1 => q1.PyMap(value => Math.Sinh(value))));
        }

        /// <summary>
        /// Hyperbolic sine, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("sinh") ]
        public static NdArray3DDouble Sinh(NdArray3DDouble x)
        {
            return x.Map(value => Math.Sinh(value));
        }

        /// <summary>
        /// Hyperbolic sine, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("sinh") ]
        public static PyList<PyList<PyList<PyList<double>>>> Sinh(IList<IList<IList<IList<double>>>> x)
        {
            return x.PyMap(q3 => q3.PyMap(q2 => q2.PyMap(q1 => q1.PyMap(value => Math.Sinh(value)))));
        }

        /// <summary>
        /// Hyperbolic sine, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("sinh") ]
        public static PyList<PyList<PyList<PyList<double>>>> Sinh(IEnumerable<IEnumerable<IEnumerable<IEnumerable<double>>>> x)
        {
            return x.PyMap(q3 => q3.PyMap(q2 => q2.PyMap(q1 => q1.PyMap(value => Math.Sinh(value)))));
        }

        /// <summary>
        /// Hyperbolic sine, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("sinh") ]
        public static NdArray4DDouble Sinh(NdArray4DDouble x)
        {
            return x.Map(value => Math.Sinh(value));
        }

        /// <summary>
        /// Hyperbolic sine, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("sinh") ]
        public static PyList<double> Sinh(IList<int> x)
        {
            return x.PyMap(value => Math.Sinh(value));
        }

        /// <summary>
        /// Hyperbolic sine, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("sinh") ]
        public static PyList<double> Sinh(IEnumerable<int> x)
        {
            return x.PyMap(value => Math.Sinh(value));
        }

        /// <summary>
        /// Hyperbolic sine, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("sinh") ]
        public static PyList<PyList<double>> Sinh(IList<IList<int>> x)
        {
            return x.PyMap(q1 => q1.PyMap(value => Math.Sinh(value)));
        }

        /// <summary>
        /// Hyperbolic sine, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("sinh") ]
        public static PyList<PyList<double>> Sinh(IEnumerable<IEnumerable<int>> x)
        {
            return x.PyMap(q1 => q1.PyMap(value => Math.Sinh(value)));
        }

        /// <summary>
        /// Hyperbolic sine, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("sinh") ]
        public static PyList<PyList<PyList<double>>> Sinh(IList<IList<IList<int>>> x)
        {
            return x.PyMap(q2 => q2.PyMap(q1 => q1.PyMap(value => Math.Sinh(value))));
        }

        /// <summary>
        /// Hyperbolic sine, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("sinh") ]
        public static PyList<PyList<PyList<double>>> Sinh(IEnumerable<IEnumerable<IEnumerable<int>>> x)
        {
            return x.PyMap(q2 => q2.PyMap(q1 => q1.PyMap(value => Math.Sinh(value))));
        }

        /// <summary>
        /// Hyperbolic sine, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("sinh") ]
        public static PyList<PyList<PyList<PyList<double>>>> Sinh(IList<IList<IList<IList<int>>>> x)
        {
            return x.PyMap(q3 => q3.PyMap(q2 => q2.PyMap(q1 => q1.PyMap(value => Math.Sinh(value)))));
        }

        /// <summary>
        /// Hyperbolic sine, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("sinh") ]
        public static PyList<PyList<PyList<PyList<double>>>> Sinh(IEnumerable<IEnumerable<IEnumerable<IEnumerable<int>>>> x)
        {
            return x.PyMap(q3 => q3.PyMap(q2 => q2.PyMap(q1 => q1.PyMap(value => Math.Sinh(value)))));
        }

        /// <summary>
        /// Trigonometric tangent element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("tan") ]
        public static double Tan(double x)
        {
            return Math.Tan(x);
        }

        /// <summary>
        /// Trigonometric tangent element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("tan") ]
        public static PyList<double> Tan(IList<double> x)
        {
            return x.PyMap(value => Math.Tan(value));
        }

        /// <summary>
        /// Trigonometric tangent element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("tan") ]
        public static PyList<double> Tan(IEnumerable<double> x)
        {
            return x.PyMap(value => Math.Tan(value));
        }

        /// <summary>
        /// Trigonometric tangent element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("tan") ]
        public static NdArray1DDouble Tan(NdArray1DDouble x)
        {
            return x.Map(value => Math.Tan(value));
        }

        /// <summary>
        /// Trigonometric tangent element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("tan") ]
        public static PyList<PyList<double>> Tan(IList<IList<double>> x)
        {
            return x.PyMap(q1 => q1.PyMap(value => Math.Tan(value)));
        }

        /// <summary>
        /// Trigonometric tangent element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("tan") ]
        public static PyList<PyList<double>> Tan(IEnumerable<IEnumerable<double>> x)
        {
            return x.PyMap(q1 => q1.PyMap(value => Math.Tan(value)));
        }

        /// <summary>
        /// Trigonometric tangent element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("tan") ]
        public static NdArray2DDouble Tan(NdArray2DDouble x)
        {
            return x.Map(value => Math.Tan(value));
        }

        /// <summary>
        /// Trigonometric tangent element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("tan") ]
        public static PyList<PyList<PyList<double>>> Tan(IList<IList<IList<double>>> x)
        {
            return x.PyMap(q2 => q2.PyMap(q1 => q1.PyMap(value => Math.Tan(value))));
        }

        /// <summary>
        /// Trigonometric tangent element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("tan") ]
        public static PyList<PyList<PyList<double>>> Tan(IEnumerable<IEnumerable<IEnumerable<double>>> x)
        {
            return x.PyMap(q2 => q2.PyMap(q1 => q1.PyMap(value => Math.Tan(value))));
        }

        /// <summary>
        /// Trigonometric tangent element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("tan") ]
        public static NdArray3DDouble Tan(NdArray3DDouble x)
        {
            return x.Map(value => Math.Tan(value));
        }

        /// <summary>
        /// Trigonometric tangent element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("tan") ]
        public static PyList<PyList<PyList<PyList<double>>>> Tan(IList<IList<IList<IList<double>>>> x)
        {
            return x.PyMap(q3 => q3.PyMap(q2 => q2.PyMap(q1 => q1.PyMap(value => Math.Tan(value)))));
        }

        /// <summary>
        /// Trigonometric tangent element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("tan") ]
        public static PyList<PyList<PyList<PyList<double>>>> Tan(IEnumerable<IEnumerable<IEnumerable<IEnumerable<double>>>> x)
        {
            return x.PyMap(q3 => q3.PyMap(q2 => q2.PyMap(q1 => q1.PyMap(value => Math.Tan(value)))));
        }

        /// <summary>
        /// Trigonometric tangent element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("tan") ]
        public static NdArray4DDouble Tan(NdArray4DDouble x)
        {
            return x.Map(value => Math.Tan(value));
        }

        /// <summary>
        /// Trigonometric tangent element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("tan") ]
        public static PyList<double> Tan(IList<int> x)
        {
            return x.PyMap(value => Math.Tan(value));
        }

        /// <summary>
        /// Trigonometric tangent element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("tan") ]
        public static PyList<double> Tan(IEnumerable<int> x)
        {
            return x.PyMap(value => Math.Tan(value));
        }

        /// <summary>
        /// Trigonometric tangent element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("tan") ]
        public static PyList<PyList<double>> Tan(IList<IList<int>> x)
        {
            return x.PyMap(q1 => q1.PyMap(value => Math.Tan(value)));
        }

        /// <summary>
        /// Trigonometric tangent element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("tan") ]
        public static PyList<PyList<double>> Tan(IEnumerable<IEnumerable<int>> x)
        {
            return x.PyMap(q1 => q1.PyMap(value => Math.Tan(value)));
        }

        /// <summary>
        /// Trigonometric tangent element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("tan") ]
        public static PyList<PyList<PyList<double>>> Tan(IList<IList<IList<int>>> x)
        {
            return x.PyMap(q2 => q2.PyMap(q1 => q1.PyMap(value => Math.Tan(value))));
        }

        /// <summary>
        /// Trigonometric tangent element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("tan") ]
        public static PyList<PyList<PyList<double>>> Tan(IEnumerable<IEnumerable<IEnumerable<int>>> x)
        {
            return x.PyMap(q2 => q2.PyMap(q1 => q1.PyMap(value => Math.Tan(value))));
        }

        /// <summary>
        /// Trigonometric tangent element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("tan") ]
        public static PyList<PyList<PyList<PyList<double>>>> Tan(IList<IList<IList<IList<int>>>> x)
        {
            return x.PyMap(q3 => q3.PyMap(q2 => q2.PyMap(q1 => q1.PyMap(value => Math.Tan(value)))));
        }

        /// <summary>
        /// Trigonometric tangent element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("tan") ]
        public static PyList<PyList<PyList<PyList<double>>>> Tan(IEnumerable<IEnumerable<IEnumerable<IEnumerable<int>>>> x)
        {
            return x.PyMap(q3 => q3.PyMap(q2 => q2.PyMap(q1 => q1.PyMap(value => Math.Tan(value)))));
        }

        /// <summary>
        /// Hyperbolic tangent, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("tanh") ]
        public static double Tanh(double x)
        {
            return Math.Tanh(x);
        }

        /// <summary>
        /// Hyperbolic tangent, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("tanh") ]
        public static PyList<double> Tanh(IList<double> x)
        {
            return x.PyMap(value => Math.Tanh(value));
        }

        /// <summary>
        /// Hyperbolic tangent, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("tanh") ]
        public static PyList<double> Tanh(IEnumerable<double> x)
        {
            return x.PyMap(value => Math.Tanh(value));
        }

        /// <summary>
        /// Hyperbolic tangent, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("tanh") ]
        public static NdArray1DDouble Tanh(NdArray1DDouble x)
        {
            return x.Map(value => Math.Tanh(value));
        }

        /// <summary>
        /// Hyperbolic tangent, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("tanh") ]
        public static PyList<PyList<double>> Tanh(IList<IList<double>> x)
        {
            return x.PyMap(q1 => q1.PyMap(value => Math.Tanh(value)));
        }

        /// <summary>
        /// Hyperbolic tangent, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("tanh") ]
        public static PyList<PyList<double>> Tanh(IEnumerable<IEnumerable<double>> x)
        {
            return x.PyMap(q1 => q1.PyMap(value => Math.Tanh(value)));
        }

        /// <summary>
        /// Hyperbolic tangent, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("tanh") ]
        public static NdArray2DDouble Tanh(NdArray2DDouble x)
        {
            return x.Map(value => Math.Tanh(value));
        }

        /// <summary>
        /// Hyperbolic tangent, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("tanh") ]
        public static PyList<PyList<PyList<double>>> Tanh(IList<IList<IList<double>>> x)
        {
            return x.PyMap(q2 => q2.PyMap(q1 => q1.PyMap(value => Math.Tanh(value))));
        }

        /// <summary>
        /// Hyperbolic tangent, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("tanh") ]
        public static PyList<PyList<PyList<double>>> Tanh(IEnumerable<IEnumerable<IEnumerable<double>>> x)
        {
            return x.PyMap(q2 => q2.PyMap(q1 => q1.PyMap(value => Math.Tanh(value))));
        }

        /// <summary>
        /// Hyperbolic tangent, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("tanh") ]
        public static NdArray3DDouble Tanh(NdArray3DDouble x)
        {
            return x.Map(value => Math.Tanh(value));
        }

        /// <summary>
        /// Hyperbolic tangent, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("tanh") ]
        public static PyList<PyList<PyList<PyList<double>>>> Tanh(IList<IList<IList<IList<double>>>> x)
        {
            return x.PyMap(q3 => q3.PyMap(q2 => q2.PyMap(q1 => q1.PyMap(value => Math.Tanh(value)))));
        }

        /// <summary>
        /// Hyperbolic tangent, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("tanh") ]
        public static PyList<PyList<PyList<PyList<double>>>> Tanh(IEnumerable<IEnumerable<IEnumerable<IEnumerable<double>>>> x)
        {
            return x.PyMap(q3 => q3.PyMap(q2 => q2.PyMap(q1 => q1.PyMap(value => Math.Tanh(value)))));
        }

        /// <summary>
        /// Hyperbolic tangent, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("tanh") ]
        public static NdArray4DDouble Tanh(NdArray4DDouble x)
        {
            return x.Map(value => Math.Tanh(value));
        }

        /// <summary>
        /// Hyperbolic tangent, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("tanh") ]
        public static PyList<double> Tanh(IList<int> x)
        {
            return x.PyMap(value => Math.Tanh(value));
        }

        /// <summary>
        /// Hyperbolic tangent, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("tanh") ]
        public static PyList<double> Tanh(IEnumerable<int> x)
        {
            return x.PyMap(value => Math.Tanh(value));
        }

        /// <summary>
        /// Hyperbolic tangent, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("tanh") ]
        public static PyList<PyList<double>> Tanh(IList<IList<int>> x)
        {
            return x.PyMap(q1 => q1.PyMap(value => Math.Tanh(value)));
        }

        /// <summary>
        /// Hyperbolic tangent, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("tanh") ]
        public static PyList<PyList<double>> Tanh(IEnumerable<IEnumerable<int>> x)
        {
            return x.PyMap(q1 => q1.PyMap(value => Math.Tanh(value)));
        }

        /// <summary>
        /// Hyperbolic tangent, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("tanh") ]
        public static PyList<PyList<PyList<double>>> Tanh(IList<IList<IList<int>>> x)
        {
            return x.PyMap(q2 => q2.PyMap(q1 => q1.PyMap(value => Math.Tanh(value))));
        }

        /// <summary>
        /// Hyperbolic tangent, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("tanh") ]
        public static PyList<PyList<PyList<double>>> Tanh(IEnumerable<IEnumerable<IEnumerable<int>>> x)
        {
            return x.PyMap(q2 => q2.PyMap(q1 => q1.PyMap(value => Math.Tanh(value))));
        }

        /// <summary>
        /// Hyperbolic tangent, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("tanh") ]
        public static PyList<PyList<PyList<PyList<double>>>> Tanh(IList<IList<IList<IList<int>>>> x)
        {
            return x.PyMap(q3 => q3.PyMap(q2 => q2.PyMap(q1 => q1.PyMap(value => Math.Tanh(value)))));
        }

        /// <summary>
        /// Hyperbolic tangent, element-wise
        /// </summary>
        /// <param name="x"></param>
        [ DirectCall("tanh") ]
        public static PyList<PyList<PyList<PyList<double>>>> Tanh(IEnumerable<IEnumerable<IEnumerable<IEnumerable<int>>>> x)
        {
            return x.PyMap(q3 => q3.PyMap(q2 => q2.PyMap(q1 => q1.PyMap(value => Math.Tanh(value)))));
        }

    }
}
