using System;
using System.Collections.Generic;

// ReSharper disable once CheckNamespace
namespace Lang.Python.Numpy
{
    public class NdArray1D<T> : NdArray<T>
    {
        public NdArray1D(IEnumerable<T> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
        {
        }

    }

    public class NdArray1DInt : NdArray1D<int>
    {
        public NdArray1DInt(IEnumerable<int> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
            : base(obj, copy, order)
        {
        }

        [ DirectCall("mean") ]
        public double Mean()
        {
            throw new NotImplementedException();
        }

    }

    public class NdArray1DDouble : NdArray1D<double>
    {
        public NdArray1DDouble(IEnumerable<double> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
            : base(obj, copy, order)
        {
        }

        [ DirectCall("mean") ]
        public double Mean()
        {
            throw new NotImplementedException();
        }

    }

    public class NdArray1DComplex : NdArray1D<Complex>
    {
        public NdArray1DComplex(IEnumerable<Complex> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
            : base(obj, copy, order)
        {
        }

        [ DirectCall("mean") ]
        public Complex Mean()
        {
            throw new NotImplementedException();
        }

    }

    public class NdArray1DBool : NdArray1D<bool>
    {
        public NdArray1DBool(IEnumerable<bool> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
            : base(obj, copy, order)
        {
        }

        [ DirectCall("mean") ]
        public double Mean()
        {
            throw new NotImplementedException();
        }

    }

    public class NdArray2D<T> : NdArray<T>
    {
        public NdArray2D(IEnumerable<IEnumerable<T>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
        {
        }

    }

    public class NdArray2DInt : NdArray2D<int>
    {
        public NdArray2DInt(IEnumerable<IEnumerable<int>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
            : base(obj, copy, order)
        {
        }

        [ DirectCall("mean") ]
        public double Mean()
        {
            throw new NotImplementedException();
        }

    }

    public class NdArray2DDouble : NdArray2D<double>
    {
        public NdArray2DDouble(IEnumerable<IEnumerable<double>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
            : base(obj, copy, order)
        {
        }

        [ DirectCall("mean") ]
        public double Mean()
        {
            throw new NotImplementedException();
        }

    }

    public class NdArray2DComplex : NdArray2D<Complex>
    {
        public NdArray2DComplex(IEnumerable<IEnumerable<Complex>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
            : base(obj, copy, order)
        {
        }

        [ DirectCall("mean") ]
        public Complex Mean()
        {
            throw new NotImplementedException();
        }

    }

    public class NdArray2DBool : NdArray2D<bool>
    {
        public NdArray2DBool(IEnumerable<IEnumerable<bool>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
            : base(obj, copy, order)
        {
        }

        [ DirectCall("mean") ]
        public double Mean()
        {
            throw new NotImplementedException();
        }

    }

    public class NdArray3D<T> : NdArray<T>
    {
        public NdArray3D(IEnumerable<IEnumerable<IEnumerable<T>>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
        {
        }

    }

    public class NdArray3DInt : NdArray3D<int>
    {
        public NdArray3DInt(IEnumerable<IEnumerable<IEnumerable<int>>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
            : base(obj, copy, order)
        {
        }

        [ DirectCall("mean") ]
        public double Mean()
        {
            throw new NotImplementedException();
        }

    }

    public class NdArray3DDouble : NdArray3D<double>
    {
        public NdArray3DDouble(IEnumerable<IEnumerable<IEnumerable<double>>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
            : base(obj, copy, order)
        {
        }

        [ DirectCall("mean") ]
        public double Mean()
        {
            throw new NotImplementedException();
        }

    }

    public class NdArray3DComplex : NdArray3D<Complex>
    {
        public NdArray3DComplex(IEnumerable<IEnumerable<IEnumerable<Complex>>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
            : base(obj, copy, order)
        {
        }

        [ DirectCall("mean") ]
        public Complex Mean()
        {
            throw new NotImplementedException();
        }

    }

    public class NdArray3DBool : NdArray3D<bool>
    {
        public NdArray3DBool(IEnumerable<IEnumerable<IEnumerable<bool>>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
            : base(obj, copy, order)
        {
        }

        [ DirectCall("mean") ]
        public double Mean()
        {
            throw new NotImplementedException();
        }

    }

    public class NdArray4D<T> : NdArray<T>
    {
        public NdArray4D(IEnumerable<IEnumerable<IEnumerable<IEnumerable<T>>>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
        {
        }

    }

    public class NdArray4DInt : NdArray4D<int>
    {
        public NdArray4DInt(IEnumerable<IEnumerable<IEnumerable<IEnumerable<int>>>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
            : base(obj, copy, order)
        {
        }

        [ DirectCall("mean") ]
        public double Mean()
        {
            throw new NotImplementedException();
        }

    }

    public class NdArray4DDouble : NdArray4D<double>
    {
        public NdArray4DDouble(IEnumerable<IEnumerable<IEnumerable<IEnumerable<double>>>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
            : base(obj, copy, order)
        {
        }

        [ DirectCall("mean") ]
        public double Mean()
        {
            throw new NotImplementedException();
        }

    }

    public class NdArray4DComplex : NdArray4D<Complex>
    {
        public NdArray4DComplex(IEnumerable<IEnumerable<IEnumerable<IEnumerable<Complex>>>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
            : base(obj, copy, order)
        {
        }

        [ DirectCall("mean") ]
        public Complex Mean()
        {
            throw new NotImplementedException();
        }

    }

    public class NdArray4DBool : NdArray4D<bool>
    {
        public NdArray4DBool(IEnumerable<IEnumerable<IEnumerable<IEnumerable<bool>>>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
            : base(obj, copy, order)
        {
        }

        [ DirectCall("mean") ]
        public double Mean()
        {
            throw new NotImplementedException();
        }

    }

    public class NdArray5D<T> : NdArray<T>
    {
        public NdArray5D(IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<T>>>>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
        {
        }

    }

    public class NdArray5DInt : NdArray5D<int>
    {
        public NdArray5DInt(IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<int>>>>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
            : base(obj, copy, order)
        {
        }

        [ DirectCall("mean") ]
        public double Mean()
        {
            throw new NotImplementedException();
        }

    }

    public class NdArray5DDouble : NdArray5D<double>
    {
        public NdArray5DDouble(IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<double>>>>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
            : base(obj, copy, order)
        {
        }

        [ DirectCall("mean") ]
        public double Mean()
        {
            throw new NotImplementedException();
        }

    }

    public class NdArray5DComplex : NdArray5D<Complex>
    {
        public NdArray5DComplex(IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<Complex>>>>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
            : base(obj, copy, order)
        {
        }

        [ DirectCall("mean") ]
        public Complex Mean()
        {
            throw new NotImplementedException();
        }

    }

    public class NdArray5DBool : NdArray5D<bool>
    {
        public NdArray5DBool(IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<bool>>>>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
            : base(obj, copy, order)
        {
        }

        [ DirectCall("mean") ]
        public double Mean()
        {
            throw new NotImplementedException();
        }

    }

    public class NdArray6D<T> : NdArray<T>
    {
        public NdArray6D(IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<T>>>>>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
        {
        }

    }

    public class NdArray6DInt : NdArray6D<int>
    {
        public NdArray6DInt(IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<int>>>>>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
            : base(obj, copy, order)
        {
        }

        [ DirectCall("mean") ]
        public double Mean()
        {
            throw new NotImplementedException();
        }

    }

    public class NdArray6DDouble : NdArray6D<double>
    {
        public NdArray6DDouble(IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<double>>>>>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
            : base(obj, copy, order)
        {
        }

        [ DirectCall("mean") ]
        public double Mean()
        {
            throw new NotImplementedException();
        }

    }

    public class NdArray6DComplex : NdArray6D<Complex>
    {
        public NdArray6DComplex(IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<Complex>>>>>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
            : base(obj, copy, order)
        {
        }

        [ DirectCall("mean") ]
        public Complex Mean()
        {
            throw new NotImplementedException();
        }

    }

    public class NdArray6DBool : NdArray6D<bool>
    {
        public NdArray6DBool(IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<bool>>>>>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
            : base(obj, copy, order)
        {
        }

        [ DirectCall("mean") ]
        public double Mean()
        {
            throw new NotImplementedException();
        }

    }

    public class NdArray7D<T> : NdArray<T>
    {
        public NdArray7D(IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<T>>>>>>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
        {
        }

    }

    public class NdArray7DInt : NdArray7D<int>
    {
        public NdArray7DInt(IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<int>>>>>>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
            : base(obj, copy, order)
        {
        }

        [ DirectCall("mean") ]
        public double Mean()
        {
            throw new NotImplementedException();
        }

    }

    public class NdArray7DDouble : NdArray7D<double>
    {
        public NdArray7DDouble(IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<double>>>>>>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
            : base(obj, copy, order)
        {
        }

        [ DirectCall("mean") ]
        public double Mean()
        {
            throw new NotImplementedException();
        }

    }

    public class NdArray7DComplex : NdArray7D<Complex>
    {
        public NdArray7DComplex(IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<Complex>>>>>>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
            : base(obj, copy, order)
        {
        }

        [ DirectCall("mean") ]
        public Complex Mean()
        {
            throw new NotImplementedException();
        }

    }

    public class NdArray7DBool : NdArray7D<bool>
    {
        public NdArray7DBool(IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<bool>>>>>>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
            : base(obj, copy, order)
        {
        }

        [ DirectCall("mean") ]
        public double Mean()
        {
            throw new NotImplementedException();
        }

    }

    public class NdArray8D<T> : NdArray<T>
    {
        public NdArray8D(IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<T>>>>>>>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
        {
        }

    }

    public class NdArray8DInt : NdArray8D<int>
    {
        public NdArray8DInt(IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<int>>>>>>>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
            : base(obj, copy, order)
        {
        }

        [ DirectCall("mean") ]
        public double Mean()
        {
            throw new NotImplementedException();
        }

    }

    public class NdArray8DDouble : NdArray8D<double>
    {
        public NdArray8DDouble(IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<double>>>>>>>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
            : base(obj, copy, order)
        {
        }

        [ DirectCall("mean") ]
        public double Mean()
        {
            throw new NotImplementedException();
        }

    }

    public class NdArray8DComplex : NdArray8D<Complex>
    {
        public NdArray8DComplex(IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<Complex>>>>>>>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
            : base(obj, copy, order)
        {
        }

        [ DirectCall("mean") ]
        public Complex Mean()
        {
            throw new NotImplementedException();
        }

    }

    public class NdArray8DBool : NdArray8D<bool>
    {
        public NdArray8DBool(IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<bool>>>>>>>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
            : base(obj, copy, order)
        {
        }

        [ DirectCall("mean") ]
        public double Mean()
        {
            throw new NotImplementedException();
        }

    }

    public class NdArray9D<T> : NdArray<T>
    {
        public NdArray9D(IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<T>>>>>>>>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
        {
        }

    }

    public class NdArray9DInt : NdArray9D<int>
    {
        public NdArray9DInt(IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<int>>>>>>>>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
            : base(obj, copy, order)
        {
        }

        [ DirectCall("mean") ]
        public double Mean()
        {
            throw new NotImplementedException();
        }

    }

    public class NdArray9DDouble : NdArray9D<double>
    {
        public NdArray9DDouble(IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<double>>>>>>>>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
            : base(obj, copy, order)
        {
        }

        [ DirectCall("mean") ]
        public double Mean()
        {
            throw new NotImplementedException();
        }

    }

    public class NdArray9DComplex : NdArray9D<Complex>
    {
        public NdArray9DComplex(IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<Complex>>>>>>>>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
            : base(obj, copy, order)
        {
        }

        [ DirectCall("mean") ]
        public Complex Mean()
        {
            throw new NotImplementedException();
        }

    }

    public class NdArray9DBool : NdArray9D<bool>
    {
        public NdArray9DBool(IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<bool>>>>>>>>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
            : base(obj, copy, order)
        {
        }

        [ DirectCall("mean") ]
        public double Mean()
        {
            throw new NotImplementedException();
        }

    }

    public class NdArray10D<T> : NdArray<T>
    {
        public NdArray10D(IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<T>>>>>>>>>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
        {
        }

    }

    public class NdArray10DInt : NdArray10D<int>
    {
        public NdArray10DInt(IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<int>>>>>>>>>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
            : base(obj, copy, order)
        {
        }

        [ DirectCall("mean") ]
        public double Mean()
        {
            throw new NotImplementedException();
        }

    }

    public class NdArray10DDouble : NdArray10D<double>
    {
        public NdArray10DDouble(IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<double>>>>>>>>>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
            : base(obj, copy, order)
        {
        }

        [ DirectCall("mean") ]
        public double Mean()
        {
            throw new NotImplementedException();
        }

    }

    public class NdArray10DComplex : NdArray10D<Complex>
    {
        public NdArray10DComplex(IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<Complex>>>>>>>>>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
            : base(obj, copy, order)
        {
        }

        [ DirectCall("mean") ]
        public Complex Mean()
        {
            throw new NotImplementedException();
        }

    }

    public class NdArray10DBool : NdArray10D<bool>
    {
        public NdArray10DBool(IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<bool>>>>>>>>>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
            : base(obj, copy, order)
        {
        }

        [ DirectCall("mean") ]
        public double Mean()
        {
            throw new NotImplementedException();
        }

    }

    public class NdArray11D<T> : NdArray<T>
    {
        public NdArray11D(IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<T>>>>>>>>>>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
        {
        }

    }

    public class NdArray11DInt : NdArray11D<int>
    {
        public NdArray11DInt(IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<int>>>>>>>>>>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
            : base(obj, copy, order)
        {
        }

        [ DirectCall("mean") ]
        public double Mean()
        {
            throw new NotImplementedException();
        }

    }

    public class NdArray11DDouble : NdArray11D<double>
    {
        public NdArray11DDouble(IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<double>>>>>>>>>>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
            : base(obj, copy, order)
        {
        }

        [ DirectCall("mean") ]
        public double Mean()
        {
            throw new NotImplementedException();
        }

    }

    public class NdArray11DComplex : NdArray11D<Complex>
    {
        public NdArray11DComplex(IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<Complex>>>>>>>>>>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
            : base(obj, copy, order)
        {
        }

        [ DirectCall("mean") ]
        public Complex Mean()
        {
            throw new NotImplementedException();
        }

    }

    public class NdArray11DBool : NdArray11D<bool>
    {
        public NdArray11DBool(IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<bool>>>>>>>>>>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
            : base(obj, copy, order)
        {
        }

        [ DirectCall("mean") ]
        public double Mean()
        {
            throw new NotImplementedException();
        }

    }

    public class NdArray12D<T> : NdArray<T>
    {
        public NdArray12D(IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<T>>>>>>>>>>>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
        {
        }

    }

    public class NdArray12DInt : NdArray12D<int>
    {
        public NdArray12DInt(IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<int>>>>>>>>>>>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
            : base(obj, copy, order)
        {
        }

        [ DirectCall("mean") ]
        public double Mean()
        {
            throw new NotImplementedException();
        }

    }

    public class NdArray12DDouble : NdArray12D<double>
    {
        public NdArray12DDouble(IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<double>>>>>>>>>>>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
            : base(obj, copy, order)
        {
        }

        [ DirectCall("mean") ]
        public double Mean()
        {
            throw new NotImplementedException();
        }

    }

    public class NdArray12DComplex : NdArray12D<Complex>
    {
        public NdArray12DComplex(IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<Complex>>>>>>>>>>>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
            : base(obj, copy, order)
        {
        }

        [ DirectCall("mean") ]
        public Complex Mean()
        {
            throw new NotImplementedException();
        }

    }

    public class NdArray12DBool : NdArray12D<bool>
    {
        public NdArray12DBool(IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<bool>>>>>>>>>>>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
            : base(obj, copy, order)
        {
        }

        [ DirectCall("mean") ]
        public double Mean()
        {
            throw new NotImplementedException();
        }

    }

    public class NdArray13D<T> : NdArray<T>
    {
        public NdArray13D(IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<T>>>>>>>>>>>>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
        {
        }

    }

    public class NdArray13DInt : NdArray13D<int>
    {
        public NdArray13DInt(IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<int>>>>>>>>>>>>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
            : base(obj, copy, order)
        {
        }

        [ DirectCall("mean") ]
        public double Mean()
        {
            throw new NotImplementedException();
        }

    }

    public class NdArray13DDouble : NdArray13D<double>
    {
        public NdArray13DDouble(IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<double>>>>>>>>>>>>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
            : base(obj, copy, order)
        {
        }

        [ DirectCall("mean") ]
        public double Mean()
        {
            throw new NotImplementedException();
        }

    }

    public class NdArray13DComplex : NdArray13D<Complex>
    {
        public NdArray13DComplex(IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<Complex>>>>>>>>>>>>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
            : base(obj, copy, order)
        {
        }

        [ DirectCall("mean") ]
        public Complex Mean()
        {
            throw new NotImplementedException();
        }

    }

    public class NdArray13DBool : NdArray13D<bool>
    {
        public NdArray13DBool(IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<bool>>>>>>>>>>>>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
            : base(obj, copy, order)
        {
        }

        [ DirectCall("mean") ]
        public double Mean()
        {
            throw new NotImplementedException();
        }

    }

    public class NdArray14D<T> : NdArray<T>
    {
        public NdArray14D(IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<T>>>>>>>>>>>>>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
        {
        }

    }

    public class NdArray14DInt : NdArray14D<int>
    {
        public NdArray14DInt(IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<int>>>>>>>>>>>>>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
            : base(obj, copy, order)
        {
        }

        [ DirectCall("mean") ]
        public double Mean()
        {
            throw new NotImplementedException();
        }

    }

    public class NdArray14DDouble : NdArray14D<double>
    {
        public NdArray14DDouble(IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<double>>>>>>>>>>>>>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
            : base(obj, copy, order)
        {
        }

        [ DirectCall("mean") ]
        public double Mean()
        {
            throw new NotImplementedException();
        }

    }

    public class NdArray14DComplex : NdArray14D<Complex>
    {
        public NdArray14DComplex(IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<Complex>>>>>>>>>>>>>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
            : base(obj, copy, order)
        {
        }

        [ DirectCall("mean") ]
        public Complex Mean()
        {
            throw new NotImplementedException();
        }

    }

    public class NdArray14DBool : NdArray14D<bool>
    {
        public NdArray14DBool(IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<bool>>>>>>>>>>>>>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
            : base(obj, copy, order)
        {
        }

        [ DirectCall("mean") ]
        public double Mean()
        {
            throw new NotImplementedException();
        }

    }

    public class NdArray15D<T> : NdArray<T>
    {
        public NdArray15D(IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<T>>>>>>>>>>>>>>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
        {
        }

    }

    public class NdArray15DInt : NdArray15D<int>
    {
        public NdArray15DInt(IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<int>>>>>>>>>>>>>>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
            : base(obj, copy, order)
        {
        }

        [ DirectCall("mean") ]
        public double Mean()
        {
            throw new NotImplementedException();
        }

    }

    public class NdArray15DDouble : NdArray15D<double>
    {
        public NdArray15DDouble(IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<double>>>>>>>>>>>>>>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
            : base(obj, copy, order)
        {
        }

        [ DirectCall("mean") ]
        public double Mean()
        {
            throw new NotImplementedException();
        }

    }

    public class NdArray15DComplex : NdArray15D<Complex>
    {
        public NdArray15DComplex(IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<Complex>>>>>>>>>>>>>>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
            : base(obj, copy, order)
        {
        }

        [ DirectCall("mean") ]
        public Complex Mean()
        {
            throw new NotImplementedException();
        }

    }

    public class NdArray15DBool : NdArray15D<bool>
    {
        public NdArray15DBool(IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<bool>>>>>>>>>>>>>>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
            : base(obj, copy, order)
        {
        }

        [ DirectCall("mean") ]
        public double Mean()
        {
            throw new NotImplementedException();
        }

    }

    public class NdArray16D<T> : NdArray<T>
    {
        public NdArray16D(IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<T>>>>>>>>>>>>>>>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
        {
        }

    }

    public class NdArray16DInt : NdArray16D<int>
    {
        public NdArray16DInt(IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<int>>>>>>>>>>>>>>>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
            : base(obj, copy, order)
        {
        }

        [ DirectCall("mean") ]
        public double Mean()
        {
            throw new NotImplementedException();
        }

    }

    public class NdArray16DDouble : NdArray16D<double>
    {
        public NdArray16DDouble(IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<double>>>>>>>>>>>>>>>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
            : base(obj, copy, order)
        {
        }

        [ DirectCall("mean") ]
        public double Mean()
        {
            throw new NotImplementedException();
        }

    }

    public class NdArray16DComplex : NdArray16D<Complex>
    {
        public NdArray16DComplex(IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<Complex>>>>>>>>>>>>>>>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
            : base(obj, copy, order)
        {
        }

        [ DirectCall("mean") ]
        public Complex Mean()
        {
            throw new NotImplementedException();
        }

    }

    public class NdArray16DBool : NdArray16D<bool>
    {
        public NdArray16DBool(IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<bool>>>>>>>>>>>>>>>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
            : base(obj, copy, order)
        {
        }

        [ DirectCall("mean") ]
        public double Mean()
        {
            throw new NotImplementedException();
        }

    }

    public class NdArray17D<T> : NdArray<T>
    {
        public NdArray17D(IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<T>>>>>>>>>>>>>>>>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
        {
        }

    }

    public class NdArray17DInt : NdArray17D<int>
    {
        public NdArray17DInt(IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<int>>>>>>>>>>>>>>>>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
            : base(obj, copy, order)
        {
        }

        [ DirectCall("mean") ]
        public double Mean()
        {
            throw new NotImplementedException();
        }

    }

    public class NdArray17DDouble : NdArray17D<double>
    {
        public NdArray17DDouble(IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<double>>>>>>>>>>>>>>>>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
            : base(obj, copy, order)
        {
        }

        [ DirectCall("mean") ]
        public double Mean()
        {
            throw new NotImplementedException();
        }

    }

    public class NdArray17DComplex : NdArray17D<Complex>
    {
        public NdArray17DComplex(IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<Complex>>>>>>>>>>>>>>>>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
            : base(obj, copy, order)
        {
        }

        [ DirectCall("mean") ]
        public Complex Mean()
        {
            throw new NotImplementedException();
        }

    }

    public class NdArray17DBool : NdArray17D<bool>
    {
        public NdArray17DBool(IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<bool>>>>>>>>>>>>>>>>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
            : base(obj, copy, order)
        {
        }

        [ DirectCall("mean") ]
        public double Mean()
        {
            throw new NotImplementedException();
        }

    }

    public class NdArray18D<T> : NdArray<T>
    {
        public NdArray18D(IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<T>>>>>>>>>>>>>>>>>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
        {
        }

    }

    public class NdArray18DInt : NdArray18D<int>
    {
        public NdArray18DInt(IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<int>>>>>>>>>>>>>>>>>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
            : base(obj, copy, order)
        {
        }

        [ DirectCall("mean") ]
        public double Mean()
        {
            throw new NotImplementedException();
        }

    }

    public class NdArray18DDouble : NdArray18D<double>
    {
        public NdArray18DDouble(IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<double>>>>>>>>>>>>>>>>>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
            : base(obj, copy, order)
        {
        }

        [ DirectCall("mean") ]
        public double Mean()
        {
            throw new NotImplementedException();
        }

    }

    public class NdArray18DComplex : NdArray18D<Complex>
    {
        public NdArray18DComplex(IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<Complex>>>>>>>>>>>>>>>>>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
            : base(obj, copy, order)
        {
        }

        [ DirectCall("mean") ]
        public Complex Mean()
        {
            throw new NotImplementedException();
        }

    }

    public class NdArray18DBool : NdArray18D<bool>
    {
        public NdArray18DBool(IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<bool>>>>>>>>>>>>>>>>>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
            : base(obj, copy, order)
        {
        }

        [ DirectCall("mean") ]
        public double Mean()
        {
            throw new NotImplementedException();
        }

    }

    public class NdArray19D<T> : NdArray<T>
    {
        public NdArray19D(IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<T>>>>>>>>>>>>>>>>>>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
        {
        }

    }

    public class NdArray19DInt : NdArray19D<int>
    {
        public NdArray19DInt(IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<int>>>>>>>>>>>>>>>>>>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
            : base(obj, copy, order)
        {
        }

        [ DirectCall("mean") ]
        public double Mean()
        {
            throw new NotImplementedException();
        }

    }

    public class NdArray19DDouble : NdArray19D<double>
    {
        public NdArray19DDouble(IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<double>>>>>>>>>>>>>>>>>>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
            : base(obj, copy, order)
        {
        }

        [ DirectCall("mean") ]
        public double Mean()
        {
            throw new NotImplementedException();
        }

    }

    public class NdArray19DComplex : NdArray19D<Complex>
    {
        public NdArray19DComplex(IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<Complex>>>>>>>>>>>>>>>>>>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
            : base(obj, copy, order)
        {
        }

        [ DirectCall("mean") ]
        public Complex Mean()
        {
            throw new NotImplementedException();
        }

    }

    public class NdArray19DBool : NdArray19D<bool>
    {
        public NdArray19DBool(IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<bool>>>>>>>>>>>>>>>>>>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
            : base(obj, copy, order)
        {
        }

        [ DirectCall("mean") ]
        public double Mean()
        {
            throw new NotImplementedException();
        }

    }

    public class NdArray20D<T> : NdArray<T>
    {
        public NdArray20D(IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<T>>>>>>>>>>>>>>>>>>>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
        {
        }

    }

    public class NdArray20DInt : NdArray20D<int>
    {
        public NdArray20DInt(IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<int>>>>>>>>>>>>>>>>>>>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
            : base(obj, copy, order)
        {
        }

        [ DirectCall("mean") ]
        public double Mean()
        {
            throw new NotImplementedException();
        }

    }

    public class NdArray20DDouble : NdArray20D<double>
    {
        public NdArray20DDouble(IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<double>>>>>>>>>>>>>>>>>>>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
            : base(obj, copy, order)
        {
        }

        [ DirectCall("mean") ]
        public double Mean()
        {
            throw new NotImplementedException();
        }

    }

    public class NdArray20DComplex : NdArray20D<Complex>
    {
        public NdArray20DComplex(IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<Complex>>>>>>>>>>>>>>>>>>>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
            : base(obj, copy, order)
        {
        }

        [ DirectCall("mean") ]
        public Complex Mean()
        {
            throw new NotImplementedException();
        }

    }

    public class NdArray20DBool : NdArray20D<bool>
    {
        public NdArray20DBool(IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<IEnumerable<bool>>>>>>>>>>>>>>>>>>>> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
            : base(obj, copy, order)
        {
        }

        [ DirectCall("mean") ]
        public double Mean()
        {
            throw new NotImplementedException();
        }

    }
}
