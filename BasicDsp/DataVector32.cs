using System;
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedMember.Global

namespace BasicDsp
{
   public sealed unsafe partial class DataVector32 : 
        IComplexVectorOperations32,
        IRealVectorOperations32,
        IFrequencyDomainVectorOperations32,
        ITimeDomainVectorOperations32
    {
        private DataVector32Native.DataVector32Struct* _native;

        private const int Complex = 1;

        private const int Real = 0;

       public static DataVector32 NewGenericVector(bool isComplex, VectorDomain domain, int length)
       {
           if (length < 0)
           {
               throw new ArgumentException("Vector length must be >= 0", nameof(length));
           }

           return new DataVector32(DataVector32Native.New(isComplex ? Complex : Real, (int)domain, 0.0f, (ulong)length, 1.0f));
       }

       public static DataVector32 NewGenericVector(bool isComplex, VectorDomain domain, float[] data)
       {
           var vector = new DataVector32(DataVector32Native.New(isComplex ? Complex : Real, (int)domain, 0.0f, (ulong)data.Length, 1.0f));
           for (int i = 0; i < data.Length; i++)
           {
               vector[i] = data[i];
           }

           return vector;
       }

        public static IRealTimeDomainVector32 NewRealTimeVectorFromConstant(float constant, int length)
        {
            if (length < 0)
            {
                throw new ArgumentException("Vector length must be >= 0", nameof(length));
            }

            return new DataVector32(DataVector32Native.New(Real, (int)VectorDomain.Time, constant, (ulong)length, 1.0f));
        }

        public static IRealTimeDomainVector32 NewRealTimeVectorFromArray(float[] data)
        {
            var vector = new DataVector32(DataVector32Native.New(Real, (int)VectorDomain.Time, 0.0f, (ulong)data.Length, 1.0f));
            for (int i = 0; i < data.Length; i++)
            {
                vector[i] = data[i];
            }

            return vector;
        }

        public static IComplexTimeDomainVector32 NewComplexTimeVectorFromConstant(float constant, int length)
        {
            if (length < 0)
            {
                throw new ArgumentException("Vector length must be >= 0", nameof(length));
            }

            return new DataVector32(DataVector32Native.New(Complex, (int)VectorDomain.Time, constant, (ulong)length, 1.0f));
        }

        public static IComplexTimeDomainVector32 NewComplexTimeVectorFromInterleaved(float[] data)
        {
            var vector = new DataVector32(DataVector32Native.New(Real, (int)VectorDomain.Time, 0.0f, (ulong)data.Length, 1.0f));
            for (int i = 0; i < data.Length; i++)
            {
                vector[i] = data[i];
            }

            return vector;
        }

        private DataVector32(DataVector32Native.DataVector32Struct* native)
        {
            _native = native;
        }

        public float this[int index]
        {
            get
            {
                if (index < 0 || index >= Length)
                {
                    throw new IndexOutOfRangeException("Index must be >= 0 and < " + Length);
                }

                return DataVector32Native.GetValue(_native, (ulong)index);
            }

            set
            {
                if (index < 0 || index >= Length)
                {
                    throw new IndexOutOfRangeException("Index must be >= 0 and < " + Length);
                }

                DataVector32Native.SetValue(_native, (ulong)index, value);
            }
        }

        public DataVector32 Add(float value)
        {
            Unwrap(DataVector32Native.RealOffset(_native, value));
            return this;
        }

        public DataVector32 Add(float real, float imag)
        {
            Unwrap(DataVector32Native.ComplexOffset(_native, real, imag));
            return this;
        }

        public DataVector32 Add(DataVector32 vector)
        {
            Unwrap(DataVector32Native.AddVector(_native, vector._native));
            return this;
        }

        public DataVector32 Subtract(float value)
        {
            Unwrap(DataVector32Native.RealOffset(_native, -value));
            return this;
        }

        public DataVector32 Subtract(float real, float imag)
        {
            Unwrap(DataVector32Native.ComplexOffset(_native, -real, -imag));
            return this;
        }

        public DataVector32 Subtract(DataVector32 vector)
        {
            Unwrap(DataVector32Native.SubtractVector(_native, vector._native));
            return this;
        }

        public DataVector32 Multiply(float value)
        {
            Unwrap(DataVector32Native.RealScale(_native, value));
            return this;
        }

        public DataVector32 Multiply(float real, float imag)
        {
            Unwrap(DataVector32Native.ComplexScale(_native, real, imag));
            return this;
        }

        public DataVector32 Multiply(DataVector32 vector)
        {
            Unwrap(DataVector32Native.MultiplyVector(_native, vector._native));
            return this;
        }

        public DataVector32 Divide(float value)
        {
            Unwrap(DataVector32Native.RealScale(_native, 1 / value));
            return this;
        }

        public DataVector32 Divide(float real, float imag)
        {
            Unwrap(DataVector32Native.ComplexDivide(_native, real, imag));
            return this;
        }

        public DataVector32 Divide(DataVector32 vector)
        {
            Unwrap(DataVector32Native.DivideVector(_native, vector._native));
            return this;
        }

        public DataVector32 ZeroPad(int points, PaddingOption paddingOption)
        {
            if (points < 0)
            {
                throw new IndexOutOfRangeException("Points must be >= 0");
            }

            Unwrap(DataVector32Native.ZeroPad(_native, (ulong)points, (int)paddingOption));
            return this;
        }

        public DataVector32 ZeroInterleave(int factor)
        {
            Unwrap(DataVector32Native.ZeroInterleave(_native, factor));
            return this;
        }

        public DataVector32 Diff()
        {
            Unwrap(DataVector32Native.Diff(_native));
            return this;
        }

        public DataVector32 DiffWithStart()
        {
            Unwrap(DataVector32Native.DiffWithStart(_native));
            return this;
        }

        public DataVector32 CumSum()
        {
            Unwrap(DataVector32Native.CumSum(_native));
            return this;
        }

        public DataVector32 Abs()
        {
            Unwrap(IsComplex ? DataVector32Native.ComplexAbs(_native) : DataVector32Native.RealAbs(_native));
            return this;
        }

       public DataVector32 Sqrt()
        {
            Unwrap(DataVector32Native.Sqrt(_native));
            return this;
        }

        public DataVector32 Square()
        {
            Unwrap(DataVector32Native.Square(_native));
            return this;
        }

        public DataVector32 Root(float value)
        {
            Unwrap(DataVector32Native.Root(_native, value));
            return this;
        }

        public DataVector32 Power(float value)
        {
            Unwrap(DataVector32Native.Power(_native, value));
            return this;
        }

        public DataVector32 Logn()
        {
            Unwrap(DataVector32Native.Logn(_native));
            return this;
        }

        public DataVector32 Expn()
        {
            Unwrap(DataVector32Native.Expn(_native));
            return this;
        }

        public DataVector32 Exp(float value)
        {
            Unwrap(DataVector32Native.Exp(_native, value));
            return this;
        }

        public DataVector32 Log(float value)
        {
            Unwrap(DataVector32Native.Log(_native, value));
            return this;
        }

        public DataVector32 ToComplex()
        {
            Unwrap(DataVector32Native.ToComplex(_native));
            return this;
        }

        public DataVector32 Sin()
        {
            Unwrap(DataVector32Native.Sin(_native));
            return this;
        }

        public DataVector32 Cos()
        {
            Unwrap(DataVector32Native.Cos(_native));
            return this;
        }

        public DataVector32 SwapHalves()
        {
          Unwrap(DataVector32Native.SwapHalves(_native));
          return this;
        }

        public DataVector32 Wrap(float value)
        {
            Unwrap(DataVector32Native.Wrap(_native, value));
            return this;
        }

        public DataVector32 Unwrap(float value)
        {
            Unwrap(DataVector32Native.Unwrap(_native, value));
            return this;
        }

        public DataVector32 Magnitude()
        {
            Unwrap(DataVector32Native.ComplexAbs(_native));
            return this;
        }

        public void GetMagnitude(DataVector32 destination)
        {
            CheckResultCode(DataVector32Native.GetComplexAbs(_native, destination._native));
        }

        public DataVector32 MagnitudeSquared()
        {
            Unwrap(DataVector32Native.ComplexAbsSquared(_native));
            return this;
        }

        public DataVector32 ComplexConj()
        {
            Unwrap(DataVector32Native.ComplexConj(_native));
            return this;
        }

        public DataVector32 ToReal()
        {
            Unwrap(DataVector32Native.ToReal(_native));
            return this;
        }

        public DataVector32 ToImag()
        {
            Unwrap(DataVector32Native.ToImag(_native));
            return this;
        }

        public void GetReal(DataVector32 destination)
        {
            CheckResultCode(DataVector32Native.GetReal(_native, destination._native));
        }

        public void GetImag(DataVector32 destination)
        {
            CheckResultCode(DataVector32Native.GetImag(_native, destination._native));
        }

        public DataVector32 Phase()
        {
            Unwrap(DataVector32Native.Phase(_native));
            return this;
        }

        public void GetPhase(DataVector32 destination)
        {
            CheckResultCode(DataVector32Native.GetPhase(_native, destination._native));
        }

        public DataVector32 PlainFft()
        {
            Unwrap(DataVector32Native.PlainFft(_native));
            return this;
        }

            public DataVector32 PlainIfft()
        {
            Unwrap(DataVector32Native.PlainIfft(_native));
            return this;
        }

        private void Unwrap(DataVector32Native.VectorResult32 result)
        {
            _native = result.vector;
            CheckResultCode(result.resultCode);
        }

        private void CheckResultCode(int resultCode)
        {
            switch (resultCode)
            {
                case 0:
                    break;
                case 1:
                    throw new VectorMustHaveTheSameSizeException();
                default:
                    throw new UnknownResultCode();
            }
        }

        public VectorDomain Domain => DataVector32Native.GetDomain(_native) == 0 ? VectorDomain.Time : VectorDomain.Frequency;

       public float Delta => DataVector32Native.Delta(_native);

       public bool IsComplex => DataVector32Native.IsComplex(_native) != 0;

       public int Length => (int) DataVector32Native.GetLength(_native);

       public int AllocatedLength => (int)DataVector32Native.GetAllocatedLength(_native);

       public int Points => (int)DataVector32Native.GetPoints(_native);

       public void Dispose()
        {
            if (_native != null)
            {
                DataVector32Native.DeleteVector(_native);
                _native = null;
            }
        }
    }
}