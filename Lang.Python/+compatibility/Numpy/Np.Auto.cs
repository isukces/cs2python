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

        [ DirectCall("array") ]
        public static NdArray1DInt Array(IEnumerable<int> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
        {
            return new NdArray1DInt(obj, copy, order);
        }

        [ DirectCall("array") ]
        public static NdArray1DDouble Array(IEnumerable<double> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
        {
            return new NdArray1DDouble(obj, copy, order);
        }

        [ DirectCall("array") ]
        public static NdArray1DComplex Array(IEnumerable<Complex> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
        {
            return new NdArray1DComplex(obj, copy, order);
        }

        [ DirectCall("array") ]
        public static NdArray1DBool Array(IEnumerable<bool> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
        {
            return new NdArray1DBool(obj, copy, order);
        }

        [ DirectCall("array") ]
        public static NdArray2DInt Array(IEnumerable<IEnumerable<int>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
        {
            return new NdArray2DInt(obj, copy, order);
        }

        [ DirectCall("array") ]
        public static NdArray2DDouble Array(IEnumerable<IEnumerable<double>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
        {
            return new NdArray2DDouble(obj, copy, order);
        }

        [ DirectCall("array") ]
        public static NdArray2DComplex Array(IEnumerable<IEnumerable<Complex>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
        {
            return new NdArray2DComplex(obj, copy, order);
        }

        [ DirectCall("array") ]
        public static NdArray2DBool Array(IEnumerable<IEnumerable<bool>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
        {
            return new NdArray2DBool(obj, copy, order);
        }

        [ DirectCall("array") ]
        public static NdArray3DInt Array(IEnumerable<IEnumerable<IEnumerable<int>>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
        {
            return new NdArray3DInt(obj, copy, order);
        }

        [ DirectCall("array") ]
        public static NdArray3DDouble Array(IEnumerable<IEnumerable<IEnumerable<double>>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
        {
            return new NdArray3DDouble(obj, copy, order);
        }

        [ DirectCall("array") ]
        public static NdArray3DComplex Array(IEnumerable<IEnumerable<IEnumerable<Complex>>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
        {
            return new NdArray3DComplex(obj, copy, order);
        }

        [ DirectCall("array") ]
        public static NdArray3DBool Array(IEnumerable<IEnumerable<IEnumerable<bool>>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
        {
            return new NdArray3DBool(obj, copy, order);
        }

        [ DirectCall("array") ]
        public static NdArray4DInt Array(IEnumerable<IEnumerable<IEnumerable<IEnumerable<int>>>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
        {
            return new NdArray4DInt(obj, copy, order);
        }

        [ DirectCall("array") ]
        public static NdArray4DDouble Array(IEnumerable<IEnumerable<IEnumerable<IEnumerable<double>>>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
        {
            return new NdArray4DDouble(obj, copy, order);
        }

        [ DirectCall("array") ]
        public static NdArray4DComplex Array(IEnumerable<IEnumerable<IEnumerable<IEnumerable<Complex>>>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
        {
            return new NdArray4DComplex(obj, copy, order);
        }

        [ DirectCall("array") ]
        public static NdArray4DBool Array(IEnumerable<IEnumerable<IEnumerable<IEnumerable<bool>>>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
        {
            return new NdArray4DBool(obj, copy, order);
        }

        [ DirectCall("array") ]
        public static NdArray5DInt Array(IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<int>>>>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
        {
            return new NdArray5DInt(obj, copy, order);
        }

        [ DirectCall("array") ]
        public static NdArray5DDouble Array(IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<double>>>>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
        {
            return new NdArray5DDouble(obj, copy, order);
        }

        [ DirectCall("array") ]
        public static NdArray5DComplex Array(IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<Complex>>>>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
        {
            return new NdArray5DComplex(obj, copy, order);
        }

        [ DirectCall("array") ]
        public static NdArray5DBool Array(IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<bool>>>>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
        {
            return new NdArray5DBool(obj, copy, order);
        }

        [ DirectCall("array") ]
        public static NdArray6DInt Array(IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<int>>>>>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
        {
            return new NdArray6DInt(obj, copy, order);
        }

        [ DirectCall("array") ]
        public static NdArray6DDouble Array(IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<double>>>>>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
        {
            return new NdArray6DDouble(obj, copy, order);
        }

        [ DirectCall("array") ]
        public static NdArray6DComplex Array(IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<Complex>>>>>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
        {
            return new NdArray6DComplex(obj, copy, order);
        }

        [ DirectCall("array") ]
        public static NdArray6DBool Array(IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<bool>>>>>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
        {
            return new NdArray6DBool(obj, copy, order);
        }

        [ DirectCall("array") ]
        public static NdArray7DInt Array(IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<int>>>>>>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
        {
            return new NdArray7DInt(obj, copy, order);
        }

        [ DirectCall("array") ]
        public static NdArray7DDouble Array(IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<double>>>>>>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
        {
            return new NdArray7DDouble(obj, copy, order);
        }

        [ DirectCall("array") ]
        public static NdArray7DComplex Array(IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<Complex>>>>>>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
        {
            return new NdArray7DComplex(obj, copy, order);
        }

        [ DirectCall("array") ]
        public static NdArray7DBool Array(IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<bool>>>>>>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
        {
            return new NdArray7DBool(obj, copy, order);
        }

        [ DirectCall("array") ]
        public static NdArray8DInt Array(IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<int>>>>>>>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
        {
            return new NdArray8DInt(obj, copy, order);
        }

        [ DirectCall("array") ]
        public static NdArray8DDouble Array(IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<double>>>>>>>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
        {
            return new NdArray8DDouble(obj, copy, order);
        }

        [ DirectCall("array") ]
        public static NdArray8DComplex Array(IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<Complex>>>>>>>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
        {
            return new NdArray8DComplex(obj, copy, order);
        }

        [ DirectCall("array") ]
        public static NdArray8DBool Array(IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<bool>>>>>>>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
        {
            return new NdArray8DBool(obj, copy, order);
        }

        [ DirectCall("array") ]
        public static NdArray9DInt Array(IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<int>>>>>>>>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
        {
            return new NdArray9DInt(obj, copy, order);
        }

        [ DirectCall("array") ]
        public static NdArray9DDouble Array(IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<double>>>>>>>>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
        {
            return new NdArray9DDouble(obj, copy, order);
        }

        [ DirectCall("array") ]
        public static NdArray9DComplex Array(IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<Complex>>>>>>>>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
        {
            return new NdArray9DComplex(obj, copy, order);
        }

        [ DirectCall("array") ]
        public static NdArray9DBool Array(IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<bool>>>>>>>>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
        {
            return new NdArray9DBool(obj, copy, order);
        }

        [ DirectCall("array") ]
        public static NdArray10DInt Array(IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<int>>>>>>>>>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
        {
            return new NdArray10DInt(obj, copy, order);
        }

        [ DirectCall("array") ]
        public static NdArray10DDouble Array(IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<double>>>>>>>>>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
        {
            return new NdArray10DDouble(obj, copy, order);
        }

        [ DirectCall("array") ]
        public static NdArray10DComplex Array(IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<Complex>>>>>>>>>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
        {
            return new NdArray10DComplex(obj, copy, order);
        }

        [ DirectCall("array") ]
        public static NdArray10DBool Array(IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<bool>>>>>>>>>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
        {
            return new NdArray10DBool(obj, copy, order);
        }

        [ DirectCall("array") ]
        public static NdArray11DInt Array(IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<int>>>>>>>>>>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
        {
            return new NdArray11DInt(obj, copy, order);
        }

        [ DirectCall("array") ]
        public static NdArray11DDouble Array(IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<double>>>>>>>>>>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
        {
            return new NdArray11DDouble(obj, copy, order);
        }

        [ DirectCall("array") ]
        public static NdArray11DComplex Array(IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<Complex>>>>>>>>>>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
        {
            return new NdArray11DComplex(obj, copy, order);
        }

        [ DirectCall("array") ]
        public static NdArray11DBool Array(IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<bool>>>>>>>>>>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
        {
            return new NdArray11DBool(obj, copy, order);
        }

        [ DirectCall("array") ]
        public static NdArray12DInt Array(IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<int>>>>>>>>>>>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
        {
            return new NdArray12DInt(obj, copy, order);
        }

        [ DirectCall("array") ]
        public static NdArray12DDouble Array(IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<double>>>>>>>>>>>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
        {
            return new NdArray12DDouble(obj, copy, order);
        }

        [ DirectCall("array") ]
        public static NdArray12DComplex Array(IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<Complex>>>>>>>>>>>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
        {
            return new NdArray12DComplex(obj, copy, order);
        }

        [ DirectCall("array") ]
        public static NdArray12DBool Array(IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<bool>>>>>>>>>>>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
        {
            return new NdArray12DBool(obj, copy, order);
        }

        [ DirectCall("array") ]
        public static NdArray13DInt Array(IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<int>>>>>>>>>>>>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
        {
            return new NdArray13DInt(obj, copy, order);
        }

        [ DirectCall("array") ]
        public static NdArray13DDouble Array(IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<double>>>>>>>>>>>>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
        {
            return new NdArray13DDouble(obj, copy, order);
        }

        [ DirectCall("array") ]
        public static NdArray13DComplex Array(IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<Complex>>>>>>>>>>>>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
        {
            return new NdArray13DComplex(obj, copy, order);
        }

        [ DirectCall("array") ]
        public static NdArray13DBool Array(IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<bool>>>>>>>>>>>>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
        {
            return new NdArray13DBool(obj, copy, order);
        }

        [ DirectCall("array") ]
        public static NdArray14DInt Array(IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<int>>>>>>>>>>>>>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
        {
            return new NdArray14DInt(obj, copy, order);
        }

        [ DirectCall("array") ]
        public static NdArray14DDouble Array(IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<double>>>>>>>>>>>>>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
        {
            return new NdArray14DDouble(obj, copy, order);
        }

        [ DirectCall("array") ]
        public static NdArray14DComplex Array(IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<Complex>>>>>>>>>>>>>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
        {
            return new NdArray14DComplex(obj, copy, order);
        }

        [ DirectCall("array") ]
        public static NdArray14DBool Array(IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<bool>>>>>>>>>>>>>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
        {
            return new NdArray14DBool(obj, copy, order);
        }

        [ DirectCall("array") ]
        public static NdArray15DInt Array(IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<int>>>>>>>>>>>>>>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
        {
            return new NdArray15DInt(obj, copy, order);
        }

        [ DirectCall("array") ]
        public static NdArray15DDouble Array(IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<double>>>>>>>>>>>>>>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
        {
            return new NdArray15DDouble(obj, copy, order);
        }

        [ DirectCall("array") ]
        public static NdArray15DComplex Array(IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<Complex>>>>>>>>>>>>>>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
        {
            return new NdArray15DComplex(obj, copy, order);
        }

        [ DirectCall("array") ]
        public static NdArray15DBool Array(IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<bool>>>>>>>>>>>>>>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
        {
            return new NdArray15DBool(obj, copy, order);
        }

        [ DirectCall("array") ]
        public static NdArray16DInt Array(IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<int>>>>>>>>>>>>>>>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
        {
            return new NdArray16DInt(obj, copy, order);
        }

        [ DirectCall("array") ]
        public static NdArray16DDouble Array(IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<double>>>>>>>>>>>>>>>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
        {
            return new NdArray16DDouble(obj, copy, order);
        }

        [ DirectCall("array") ]
        public static NdArray16DComplex Array(IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<Complex>>>>>>>>>>>>>>>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
        {
            return new NdArray16DComplex(obj, copy, order);
        }

        [ DirectCall("array") ]
        public static NdArray16DBool Array(IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<bool>>>>>>>>>>>>>>>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
        {
            return new NdArray16DBool(obj, copy, order);
        }

        [ DirectCall("array") ]
        public static NdArray17DInt Array(IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<int>>>>>>>>>>>>>>>>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
        {
            return new NdArray17DInt(obj, copy, order);
        }

        [ DirectCall("array") ]
        public static NdArray17DDouble Array(IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<double>>>>>>>>>>>>>>>>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
        {
            return new NdArray17DDouble(obj, copy, order);
        }

        [ DirectCall("array") ]
        public static NdArray17DComplex Array(IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<Complex>>>>>>>>>>>>>>>>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
        {
            return new NdArray17DComplex(obj, copy, order);
        }

        [ DirectCall("array") ]
        public static NdArray17DBool Array(IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<bool>>>>>>>>>>>>>>>>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
        {
            return new NdArray17DBool(obj, copy, order);
        }

        [ DirectCall("array") ]
        public static NdArray18DInt Array(IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<int>>>>>>>>>>>>>>>>>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
        {
            return new NdArray18DInt(obj, copy, order);
        }

        [ DirectCall("array") ]
        public static NdArray18DDouble Array(IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<double>>>>>>>>>>>>>>>>>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
        {
            return new NdArray18DDouble(obj, copy, order);
        }

        [ DirectCall("array") ]
        public static NdArray18DComplex Array(IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<Complex>>>>>>>>>>>>>>>>>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
        {
            return new NdArray18DComplex(obj, copy, order);
        }

        [ DirectCall("array") ]
        public static NdArray18DBool Array(IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<bool>>>>>>>>>>>>>>>>>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
        {
            return new NdArray18DBool(obj, copy, order);
        }

        [ DirectCall("array") ]
        public static NdArray19DInt Array(IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<int>>>>>>>>>>>>>>>>>>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
        {
            return new NdArray19DInt(obj, copy, order);
        }

        [ DirectCall("array") ]
        public static NdArray19DDouble Array(IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<double>>>>>>>>>>>>>>>>>>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
        {
            return new NdArray19DDouble(obj, copy, order);
        }

        [ DirectCall("array") ]
        public static NdArray19DComplex Array(IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<Complex>>>>>>>>>>>>>>>>>>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
        {
            return new NdArray19DComplex(obj, copy, order);
        }

        [ DirectCall("array") ]
        public static NdArray19DBool Array(IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<bool>>>>>>>>>>>>>>>>>>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
        {
            return new NdArray19DBool(obj, copy, order);
        }

        [ DirectCall("array") ]
        public static NdArray20DInt Array(IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<int>>>>>>>>>>>>>>>>>>>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
        {
            return new NdArray20DInt(obj, copy, order);
        }

        [ DirectCall("array") ]
        public static NdArray20DDouble Array(IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<double>>>>>>>>>>>>>>>>>>>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
        {
            return new NdArray20DDouble(obj, copy, order);
        }

        [ DirectCall("array") ]
        public static NdArray20DComplex Array(IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<Complex>>>>>>>>>>>>>>>>>>>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
        {
            return new NdArray20DComplex(obj, copy, order);
        }

        [ DirectCall("array") ]
        public static NdArray20DBool Array(IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<bool>>>>>>>>>>>>>>>>>>>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
        {
            return new NdArray20DBool(obj, copy, order);
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
