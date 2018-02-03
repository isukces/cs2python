using System;
using System.Collections.Generic;
using System.Linq;

// ReSharper disable once CheckNamespace
namespace Lang.Python.Numpy
{
    public class NdArray1D<T> : NdArray<T>
    {
        public NdArray1D(IEnumerable<T> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
        {
            InternalData = obj.ToIListCastOrConvert();
        }

        internal NdArray1D(IList<T> internalData, NdArrayShapeInfo shapeInfo)
        {
            InternalData = internalData; ShapeInfo = shapeInfo;
        }

        public NdArray1D<TOut> Map<TOut>(Func<T, TOut> map)
        {
            var q = InternalData.PyMap(map);
            return new NdArray1D<TOut>(q, ShapeInfo);
        }

    }

    public class NdArray1DInt : NdArray1D<int>
    {
        public NdArray1DInt(IEnumerable<int> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
            : base(obj, copy, order)
        {
        }

        internal NdArray1DInt(IList<int> internalData, NdArrayShapeInfo shapeInfo)
            : base(internalData, shapeInfo)
        {
        }

        public NdArray1DDouble Map(Func<int, double> map)
        {
            var q = InternalData.PyMap(map);
            return new NdArray1DDouble(q, ShapeInfo);
        }

        [ DirectCall("mean") ]
        public double Mean()
        {
            return InternalData.Average();
        }

        public static implicit operator NdArray2DDouble(NdArray1DInt x)
        {
            return new NdArray2DDouble(x.InternalData.IntToDouble(), x.ShapeInfo);
        }

    }

    public class NdArray1DDouble : NdArray1D<double>
    {
        public NdArray1DDouble(IEnumerable<double> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
            : base(obj, copy, order)
        {
        }

        internal NdArray1DDouble(IList<double> internalData, NdArrayShapeInfo shapeInfo)
            : base(internalData, shapeInfo)
        {
        }

        public NdArray1DDouble Map(Func<double, double> map)
        {
            var q = InternalData.PyMap(map);
            return new NdArray1DDouble(q, ShapeInfo);
        }

        [ DirectCall("mean") ]
        public double Mean()
        {
            return InternalData.Average();
        }

    }

    public class NdArray1DComplex : NdArray1D<Complex>
    {
        public NdArray1DComplex(IEnumerable<Complex> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
            : base(obj, copy, order)
        {
        }

        internal NdArray1DComplex(IList<Complex> internalData, NdArrayShapeInfo shapeInfo)
            : base(internalData, shapeInfo)
        {
        }

        [ DirectCall("mean") ]
        public Complex Mean()
        {
            return GetMean(InternalData);
        }

    }

    public class NdArray1DBool : NdArray1D<bool>
    {
        public NdArray1DBool(IEnumerable<bool> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
            : base(obj, copy, order)
        {
        }

        internal NdArray1DBool(IList<bool> internalData, NdArrayShapeInfo shapeInfo)
            : base(internalData, shapeInfo)
        {
        }

        [ DirectCall("mean") ]
        public double Mean()
        {
            return GetMean(InternalData);
        }

    }

    public class NdArray2D<T> : NdArray<T>
    {
        public NdArray2D(IEnumerable<IEnumerable<T>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
        {
        }

        internal NdArray2D(IList<T> internalData, NdArrayShapeInfo shapeInfo)
        {
            InternalData = internalData; ShapeInfo = shapeInfo;
        }

        public NdArray2D<TOut> Map<TOut>(Func<T, TOut> map)
        {
            var q = InternalData.PyMap(map);
            return new NdArray2D<TOut>(q, ShapeInfo);
        }

    }

    public class NdArray2DInt : NdArray2D<int>
    {
        public NdArray2DInt(IEnumerable<IEnumerable<int>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
            : base(obj, copy, order)
        {
        }

        internal NdArray2DInt(IList<int> internalData, NdArrayShapeInfo shapeInfo)
            : base(internalData, shapeInfo)
        {
        }

        public NdArray2DDouble Map(Func<int, double> map)
        {
            var q = InternalData.PyMap(map);
            return new NdArray2DDouble(q, ShapeInfo);
        }

        [ DirectCall("mean") ]
        public double Mean()
        {
            return InternalData.Average();
        }

        public static implicit operator NdArray2DDouble(NdArray2DInt x)
        {
            return new NdArray2DDouble(x.InternalData.IntToDouble(), x.ShapeInfo);
        }

    }

    public class NdArray2DDouble : NdArray2D<double>
    {
        public NdArray2DDouble(IEnumerable<IEnumerable<double>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
            : base(obj, copy, order)
        {
        }

        internal NdArray2DDouble(IList<double> internalData, NdArrayShapeInfo shapeInfo)
            : base(internalData, shapeInfo)
        {
        }

        public NdArray2DDouble Map(Func<double, double> map)
        {
            var q = InternalData.PyMap(map);
            return new NdArray2DDouble(q, ShapeInfo);
        }

        [ DirectCall("mean") ]
        public double Mean()
        {
            return InternalData.Average();
        }

    }

    public class NdArray2DComplex : NdArray2D<Complex>
    {
        public NdArray2DComplex(IEnumerable<IEnumerable<Complex>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
            : base(obj, copy, order)
        {
        }

        internal NdArray2DComplex(IList<Complex> internalData, NdArrayShapeInfo shapeInfo)
            : base(internalData, shapeInfo)
        {
        }

        [ DirectCall("mean") ]
        public Complex Mean()
        {
            return GetMean(InternalData);
        }

    }

    public class NdArray2DBool : NdArray2D<bool>
    {
        public NdArray2DBool(IEnumerable<IEnumerable<bool>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
            : base(obj, copy, order)
        {
        }

        internal NdArray2DBool(IList<bool> internalData, NdArrayShapeInfo shapeInfo)
            : base(internalData, shapeInfo)
        {
        }

        [ DirectCall("mean") ]
        public double Mean()
        {
            return GetMean(InternalData);
        }

    }

    public class NdArray3D<T> : NdArray<T>
    {
        public NdArray3D(IEnumerable<IEnumerable<IEnumerable<T>>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
        {
        }

        internal NdArray3D(IList<T> internalData, NdArrayShapeInfo shapeInfo)
        {
            InternalData = internalData; ShapeInfo = shapeInfo;
        }

        public NdArray3D<TOut> Map<TOut>(Func<T, TOut> map)
        {
            var q = InternalData.PyMap(map);
            return new NdArray3D<TOut>(q, ShapeInfo);
        }

    }

    public class NdArray3DInt : NdArray3D<int>
    {
        public NdArray3DInt(IEnumerable<IEnumerable<IEnumerable<int>>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
            : base(obj, copy, order)
        {
        }

        internal NdArray3DInt(IList<int> internalData, NdArrayShapeInfo shapeInfo)
            : base(internalData, shapeInfo)
        {
        }

        public NdArray3DDouble Map(Func<int, double> map)
        {
            var q = InternalData.PyMap(map);
            return new NdArray3DDouble(q, ShapeInfo);
        }

        [ DirectCall("mean") ]
        public double Mean()
        {
            return InternalData.Average();
        }

        public static implicit operator NdArray2DDouble(NdArray3DInt x)
        {
            return new NdArray2DDouble(x.InternalData.IntToDouble(), x.ShapeInfo);
        }

    }

    public class NdArray3DDouble : NdArray3D<double>
    {
        public NdArray3DDouble(IEnumerable<IEnumerable<IEnumerable<double>>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
            : base(obj, copy, order)
        {
        }

        internal NdArray3DDouble(IList<double> internalData, NdArrayShapeInfo shapeInfo)
            : base(internalData, shapeInfo)
        {
        }

        public NdArray3DDouble Map(Func<double, double> map)
        {
            var q = InternalData.PyMap(map);
            return new NdArray3DDouble(q, ShapeInfo);
        }

        [ DirectCall("mean") ]
        public double Mean()
        {
            return InternalData.Average();
        }

    }

    public class NdArray3DComplex : NdArray3D<Complex>
    {
        public NdArray3DComplex(IEnumerable<IEnumerable<IEnumerable<Complex>>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
            : base(obj, copy, order)
        {
        }

        internal NdArray3DComplex(IList<Complex> internalData, NdArrayShapeInfo shapeInfo)
            : base(internalData, shapeInfo)
        {
        }

        [ DirectCall("mean") ]
        public Complex Mean()
        {
            return GetMean(InternalData);
        }

    }

    public class NdArray3DBool : NdArray3D<bool>
    {
        public NdArray3DBool(IEnumerable<IEnumerable<IEnumerable<bool>>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
            : base(obj, copy, order)
        {
        }

        internal NdArray3DBool(IList<bool> internalData, NdArrayShapeInfo shapeInfo)
            : base(internalData, shapeInfo)
        {
        }

        [ DirectCall("mean") ]
        public double Mean()
        {
            return GetMean(InternalData);
        }

    }

    public class NdArray4D<T> : NdArray<T>
    {
        public NdArray4D(IEnumerable<IEnumerable<IEnumerable<IEnumerable<T>>>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
        {
        }

        internal NdArray4D(IList<T> internalData, NdArrayShapeInfo shapeInfo)
        {
            InternalData = internalData; ShapeInfo = shapeInfo;
        }

        public NdArray4D<TOut> Map<TOut>(Func<T, TOut> map)
        {
            var q = InternalData.PyMap(map);
            return new NdArray4D<TOut>(q, ShapeInfo);
        }

    }

    public class NdArray4DInt : NdArray4D<int>
    {
        public NdArray4DInt(IEnumerable<IEnumerable<IEnumerable<IEnumerable<int>>>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
            : base(obj, copy, order)
        {
        }

        internal NdArray4DInt(IList<int> internalData, NdArrayShapeInfo shapeInfo)
            : base(internalData, shapeInfo)
        {
        }

        public NdArray4DDouble Map(Func<int, double> map)
        {
            var q = InternalData.PyMap(map);
            return new NdArray4DDouble(q, ShapeInfo);
        }

        [ DirectCall("mean") ]
        public double Mean()
        {
            return InternalData.Average();
        }

        public static implicit operator NdArray2DDouble(NdArray4DInt x)
        {
            return new NdArray2DDouble(x.InternalData.IntToDouble(), x.ShapeInfo);
        }

    }

    public class NdArray4DDouble : NdArray4D<double>
    {
        public NdArray4DDouble(IEnumerable<IEnumerable<IEnumerable<IEnumerable<double>>>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
            : base(obj, copy, order)
        {
        }

        internal NdArray4DDouble(IList<double> internalData, NdArrayShapeInfo shapeInfo)
            : base(internalData, shapeInfo)
        {
        }

        public NdArray4DDouble Map(Func<double, double> map)
        {
            var q = InternalData.PyMap(map);
            return new NdArray4DDouble(q, ShapeInfo);
        }

        [ DirectCall("mean") ]
        public double Mean()
        {
            return InternalData.Average();
        }

    }

    public class NdArray4DComplex : NdArray4D<Complex>
    {
        public NdArray4DComplex(IEnumerable<IEnumerable<IEnumerable<IEnumerable<Complex>>>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
            : base(obj, copy, order)
        {
        }

        internal NdArray4DComplex(IList<Complex> internalData, NdArrayShapeInfo shapeInfo)
            : base(internalData, shapeInfo)
        {
        }

        [ DirectCall("mean") ]
        public Complex Mean()
        {
            return GetMean(InternalData);
        }

    }

    public class NdArray4DBool : NdArray4D<bool>
    {
        public NdArray4DBool(IEnumerable<IEnumerable<IEnumerable<IEnumerable<bool>>>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
            : base(obj, copy, order)
        {
        }

        internal NdArray4DBool(IList<bool> internalData, NdArrayShapeInfo shapeInfo)
            : base(internalData, shapeInfo)
        {
        }

        [ DirectCall("mean") ]
        public double Mean()
        {
            return GetMean(InternalData);
        }

    }

    public class NdArray5D<T> : NdArray<T>
    {
        public NdArray5D(IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<T>>>>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
        {
        }

        internal NdArray5D(IList<T> internalData, NdArrayShapeInfo shapeInfo)
        {
            InternalData = internalData; ShapeInfo = shapeInfo;
        }

        public NdArray5D<TOut> Map<TOut>(Func<T, TOut> map)
        {
            var q = InternalData.PyMap(map);
            return new NdArray5D<TOut>(q, ShapeInfo);
        }

    }

    public class NdArray5DInt : NdArray5D<int>
    {
        public NdArray5DInt(IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<int>>>>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
            : base(obj, copy, order)
        {
        }

        internal NdArray5DInt(IList<int> internalData, NdArrayShapeInfo shapeInfo)
            : base(internalData, shapeInfo)
        {
        }

        public NdArray5DDouble Map(Func<int, double> map)
        {
            var q = InternalData.PyMap(map);
            return new NdArray5DDouble(q, ShapeInfo);
        }

        [ DirectCall("mean") ]
        public double Mean()
        {
            return InternalData.Average();
        }

        public static implicit operator NdArray2DDouble(NdArray5DInt x)
        {
            return new NdArray2DDouble(x.InternalData.IntToDouble(), x.ShapeInfo);
        }

    }

    public class NdArray5DDouble : NdArray5D<double>
    {
        public NdArray5DDouble(IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<double>>>>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
            : base(obj, copy, order)
        {
        }

        internal NdArray5DDouble(IList<double> internalData, NdArrayShapeInfo shapeInfo)
            : base(internalData, shapeInfo)
        {
        }

        public NdArray5DDouble Map(Func<double, double> map)
        {
            var q = InternalData.PyMap(map);
            return new NdArray5DDouble(q, ShapeInfo);
        }

        [ DirectCall("mean") ]
        public double Mean()
        {
            return InternalData.Average();
        }

    }

    public class NdArray5DComplex : NdArray5D<Complex>
    {
        public NdArray5DComplex(IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<Complex>>>>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
            : base(obj, copy, order)
        {
        }

        internal NdArray5DComplex(IList<Complex> internalData, NdArrayShapeInfo shapeInfo)
            : base(internalData, shapeInfo)
        {
        }

        [ DirectCall("mean") ]
        public Complex Mean()
        {
            return GetMean(InternalData);
        }

    }

    public class NdArray5DBool : NdArray5D<bool>
    {
        public NdArray5DBool(IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<bool>>>>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
            : base(obj, copy, order)
        {
        }

        internal NdArray5DBool(IList<bool> internalData, NdArrayShapeInfo shapeInfo)
            : base(internalData, shapeInfo)
        {
        }

        [ DirectCall("mean") ]
        public double Mean()
        {
            return GetMean(InternalData);
        }

    }
}
