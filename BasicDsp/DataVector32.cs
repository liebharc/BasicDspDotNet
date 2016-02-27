using System;
using System.Runtime.InteropServices;

namespace BasicDsp
{
   public unsafe sealed class DataVector32 : 
        IRealTimeDomainVector32,
        IRealFrequencyDomainVector32,
        IComplexTimeDomainVector32,
        IComplexFrequencyDomainVector32
    {
        private DataVector32Native.DataVector32Struct* _native;

        private const int Complex = 1;

        private const int Real = 0;

       public static DataVector32 NewGenericVector(bool isComplex, VectorDomain domain, int length)
       {
           if (length < 0)
           {
               throw new ArgumentException("Vector length must be >= 0", "length");
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
                throw new ArgumentException("Vector length must be >= 0", "length");
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
                throw new ArgumentException("Vector length must be >= 0", "length");
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

        public IRealFrequencyDomainVector32 Add(IRealFrequencyDomainVector32 vector)
        {
            return Add((DataVector32)vector);
        }

        IRealFrequencyDomainVector32 IRealFrequencyDomainVector32.Subtract(float value)
        {
            return Subtract(value);
        }

        public IRealFrequencyDomainVector32 Subtract(IRealFrequencyDomainVector32 vector)
        {
            return Subtract((DataVector32) vector);
        }

        IRealFrequencyDomainVector32 IRealFrequencyDomainVector32.Multiply(float value)
        {
            return Multiply(value);
        }

        public IRealFrequencyDomainVector32 Multiply(IRealFrequencyDomainVector32 vector)
        {
            return Multiply((DataVector32)vector);
        }

        IRealFrequencyDomainVector32 IRealFrequencyDomainVector32.Divide(float value)
        {
            return Divide(value);
        }

        public IRealFrequencyDomainVector32 Divide(IRealFrequencyDomainVector32 vector)
        {
            return Divide((DataVector32)vector);
        }

        IRealFrequencyDomainVector32 IRealFrequencyDomainVector32.ZeroPad(int points)
        {
            return ZeroPad(points);
        }

        IRealFrequencyDomainVector32 IRealFrequencyDomainVector32.ZeroInterleave(int factor)
        {
            return ZeroInterleave(factor);
        }

        IRealFrequencyDomainVector32 IRealFrequencyDomainVector32.Diff()
        {
            return Diff();
        }

        IRealFrequencyDomainVector32 IRealFrequencyDomainVector32.DiffWithStart()
        {
            return DiffWithStart();
        }

        IRealFrequencyDomainVector32 IRealFrequencyDomainVector32.CumSum()
        {
            return CumSum();
        }

        IRealFrequencyDomainVector32 IRealFrequencyDomainVector32.Abs()
        {
            return Abs();
        }

        IRealFrequencyDomainVector32 IRealFrequencyDomainVector32.Sqrt()
        {
            return Sqrt();
        }

        IRealFrequencyDomainVector32 IRealFrequencyDomainVector32.Square()
        {
            return Square();
        }

        IRealFrequencyDomainVector32 IRealFrequencyDomainVector32.Root(float value)
        {
            return Root(value);
        }

        IRealFrequencyDomainVector32 IRealFrequencyDomainVector32.Power(float value)
        {
            return Power(value);
        }

        IRealFrequencyDomainVector32 IRealFrequencyDomainVector32.Logn()
        {
            return Logn();
        }

        IRealFrequencyDomainVector32 IRealFrequencyDomainVector32.Expn()
        {
            return Expn();
        }

        IRealFrequencyDomainVector32 IRealFrequencyDomainVector32.Exp(float value)
        {
            return Exp(value);
        }

        IRealFrequencyDomainVector32 IRealFrequencyDomainVector32.Log(float value)
        {
            return Log(value);
        }

        IComplexFrequencyDomainVector32 IRealFrequencyDomainVector32.ToComplex()
        {
            return ToComplex();
        }

        IRealFrequencyDomainVector32 IRealFrequencyDomainVector32.Sin()
        {
            return Sin();
        }

        IRealFrequencyDomainVector32 IRealFrequencyDomainVector32.Cos()
        {
            return Cos();
        }

        IRealFrequencyDomainVector32 IRealFrequencyDomainVector32.Wrap(float value)
        {
            return Wrap(value);
        }

        IRealFrequencyDomainVector32 IRealFrequencyDomainVector32.Unwrap(float value)
        {
            return Unwrap(value);
        }

        public void GetPhase(IRealFrequencyDomainVector32 destination)
        {
            GetPhase((DataVector32)destination);
        }

        IComplexTimeDomainVector32 IComplexFrequencyDomainVector32.PlainIfft()
        {
            return PlainIfft();
        }

        IComplexTimeDomainVector32 IRealFrequencyDomainVector32.PlainIfft()
        {
            return PlainIfft();
        }

        public IRealTimeDomainVector32 Add(IRealTimeDomainVector32 vector)
        {
            return Add((DataVector32) vector);
        }

        IRealTimeDomainVector32 IRealTimeDomainVector32.Subtract(float value)
        {
            return Subtract(value);
        }

        public IRealTimeDomainVector32 Subtract(IRealTimeDomainVector32 vector)
        {
            return Subtract((DataVector32)vector);
        }

        IRealTimeDomainVector32 IRealTimeDomainVector32.Multiply(float value)
        {
            return Multiply(value);
        }

        public IRealTimeDomainVector32 Multiply(IRealTimeDomainVector32 vector)
        {
            return Multiply((DataVector32)vector);
        }

        IRealTimeDomainVector32 IRealTimeDomainVector32.Divide(float value)
        {
            return Divide(value);
        }

        public IRealTimeDomainVector32 Divide(IRealTimeDomainVector32 vector)
        {
            return Divide((DataVector32)vector);
        }

        IRealTimeDomainVector32 IRealTimeDomainVector32.ZeroPad(int points)
        {
            return ZeroPad(points);
        }

        IRealTimeDomainVector32 IRealTimeDomainVector32.ZeroInterleave(int factor)
        {
            return ZeroInterleave(factor);
        }

        IRealTimeDomainVector32 IRealTimeDomainVector32.Diff()
        {
            return Diff();
        }

        IRealTimeDomainVector32 IRealTimeDomainVector32.DiffWithStart()
        {
            return DiffWithStart();
        }

        IRealTimeDomainVector32 IRealTimeDomainVector32.CumSum()
        {
            return CumSum();
        }

        IRealTimeDomainVector32 IRealTimeDomainVector32.Abs()
        {
            return Abs();
        }

        IRealTimeDomainVector32 IRealTimeDomainVector32.Sqrt()
        {
            return Sqrt();
        }

        IRealTimeDomainVector32 IRealTimeDomainVector32.Square()
        {
            return Square();
        }

        IRealTimeDomainVector32 IRealTimeDomainVector32.Root(float value)
        {
            return Root(value);
        }

        IRealTimeDomainVector32 IRealTimeDomainVector32.Power(float value)
        {
            return Power(value);
        }

        IRealTimeDomainVector32 IRealTimeDomainVector32.Logn()
        {
            return Logn();
        }

        IRealTimeDomainVector32 IRealTimeDomainVector32.Expn()
        {
            return Expn();
        }

        IRealTimeDomainVector32 IRealTimeDomainVector32.Exp(float value)
        {
            return Exp(value);
        }

        IRealTimeDomainVector32 IRealTimeDomainVector32.Log(float value)
        {
            return Log(value);
        }

        IRealTimeDomainVector32 IRealTimeDomainVector32.Sin()
        {
          return Sin();
        }

        IRealTimeDomainVector32 IRealTimeDomainVector32.Cos()
        {
          return Cos();
        }

        IComplexTimeDomainVector32 IRealTimeDomainVector32.ToComplex()
        {
            return ToComplex();
        }

        IRealTimeDomainVector32 IRealTimeDomainVector32.Wrap(float value)
        {
            return Wrap(value);
        }

        IRealTimeDomainVector32 IRealTimeDomainVector32.Unwrap(float value)
        {
            return Unwrap(value);
        }

        public void GetPhase(IRealTimeDomainVector32 destination)
        {
            GetPhase((DataVector32)destination);
        }

        IComplexFrequencyDomainVector32 IComplexTimeDomainVector32.PlainFft()
        {
            return PlainFft();
        }

        IComplexFrequencyDomainVector32 IRealTimeDomainVector32.PlainFft()
        {
            return PlainFft();
        }

        public DataVector32 Add(float real, float imag)
        {
            Unwrap(DataVector32Native.ComplexOffset(_native, real, imag));
            return this;
        }

        public IComplexFrequencyDomainVector32 Add(IComplexFrequencyDomainVector32 vector)
        {
            return Add((DataVector32) vector);
        }

        IComplexFrequencyDomainVector32 IComplexFrequencyDomainVector32.Subtract(float real, float imag)
        {
            return Subtract(real, imag);
        }

        public IComplexFrequencyDomainVector32 Subtract(IComplexFrequencyDomainVector32 vector)
        {
            return Subtract((DataVector32)vector);
        }

        IComplexFrequencyDomainVector32 IComplexFrequencyDomainVector32.Multiply(float real, float imag)
        {
            return Multiply(real, imag);
        }

        public IComplexFrequencyDomainVector32 Multiply(IComplexFrequencyDomainVector32 vector)
        {
            return Multiply((DataVector32)vector);
        }

        IComplexFrequencyDomainVector32 IComplexFrequencyDomainVector32.Divide(float real, float imag)
        {
            return Divide(real, imag);
        }

        public IComplexFrequencyDomainVector32 Divide(IComplexFrequencyDomainVector32 vector)
        {
            return Divide((DataVector32)vector);
        }

        IRealFrequencyDomainVector32 IComplexFrequencyDomainVector32.Abs()
        {
            return ComplexAbs();
        }

        public void GetComplexAbs(IRealFrequencyDomainVector32 destination)
        {
            GetComplexAbs((DataVector32)destination);
        }

        IRealFrequencyDomainVector32 IComplexFrequencyDomainVector32.ComplexAbsSquared()
        {
            return ComplexAbsSquared();
        }

        IComplexFrequencyDomainVector32 IComplexFrequencyDomainVector32.ComplexConj()
        {
            return ComplexConj();
        }

        IRealFrequencyDomainVector32 IComplexFrequencyDomainVector32.ToReal()
        {
            return ToReal();
        }

        IRealFrequencyDomainVector32 IComplexFrequencyDomainVector32.ToImag()
        {
            return ToImag();
        }

        public void GetReal(IRealFrequencyDomainVector32 destination)
        {
            GetReal((DataVector32)destination);
        }

        public void GetImag(IRealFrequencyDomainVector32 destination)
        {
            GetImag((DataVector32)destination);
        }

        IRealFrequencyDomainVector32 IComplexFrequencyDomainVector32.Phase()
        {
            return Phase();
        }

        public IComplexTimeDomainVector32 Add(IComplexTimeDomainVector32 vector)
        {
            return Add((DataVector32)vector);
        }

        IComplexTimeDomainVector32 IComplexTimeDomainVector32.Subtract(float real, float imag)
        {
            return Subtract(real, imag);
        }

        public IComplexTimeDomainVector32 Subtract(IComplexTimeDomainVector32 vector)
        {
            return Subtract((DataVector32)vector);
        }

        IComplexTimeDomainVector32 IComplexTimeDomainVector32.Multiply(float real, float imag)
        {
            return Multiply(real, imag);
        }

        public IComplexTimeDomainVector32 Multiply(IComplexTimeDomainVector32 vector)
        {
            return Multiply((DataVector32)vector);
        }

        IComplexTimeDomainVector32 IComplexTimeDomainVector32.Divide(float real, float imag)
        {
            return Divide(real, imag);
        }

        public IComplexTimeDomainVector32 Divide(IComplexTimeDomainVector32 vector)
        {
            return Divide((DataVector32)vector);
        }

        IRealTimeDomainVector32 IComplexTimeDomainVector32.Abs()
        {
            return ComplexAbs();
        }

        IRealTimeDomainVector32 IRealTimeDomainVector32.SwapHalves()
        {
          Unwrap(DataVector32Native.SwapHalves(_native));
          return this;
        }

        IComplexTimeDomainVector32 IComplexTimeDomainVector32.SwapHalves()
        {
          Unwrap(DataVector32Native.SwapHalves(_native));
          return this;
        }

        public void GetComplexAbs(IRealTimeDomainVector32 destination)
        {
            GetComplexAbs((DataVector32)destination);
        }

        IRealTimeDomainVector32 IComplexTimeDomainVector32.ComplexAbsSquared()
        {
            return ComplexAbsSquared();
        }

        IComplexTimeDomainVector32 IComplexTimeDomainVector32.ComplexConj()
        {
            return ComplexConj();
        }

        IRealTimeDomainVector32 IComplexTimeDomainVector32.ToReal()
        {
            return ToReal();
        }

        IRealTimeDomainVector32 IComplexTimeDomainVector32.ToImag()
        {
            return ToImag();
        }

        public void GetReal(IRealTimeDomainVector32 destination)
        {
            GetReal((DataVector32)destination);
        }

        public void GetImag(IRealTimeDomainVector32 destination)
        {
            GetImag((DataVector32)destination);
        }

        IRealTimeDomainVector32 IComplexTimeDomainVector32.Phase()
        {
            return Phase();
        }


        IRealTimeDomainVector32 IRealTimeDomainVector32.Add(float value)
        {
            return Add(value);
        }

        IRealFrequencyDomainVector32 IRealFrequencyDomainVector32.Add(float value)
        {
            return Add(value);
        }

        IComplexTimeDomainVector32 IComplexTimeDomainVector32.Add(float real, float imag)
        {
            return Add(real, imag);
        }

        IComplexFrequencyDomainVector32 IComplexFrequencyDomainVector32.Add(float real, float imag)
        {
            return Add(real, imag);
        }

        IComplexTimeDomainVector32 IComplexTimeDomainVector32.Sqrt()
        {
          return Sqrt();
        }

        IComplexTimeDomainVector32 IComplexTimeDomainVector32.Square()
        {
          return Square();
        }

        IComplexTimeDomainVector32 IComplexTimeDomainVector32.Root(float value)
        {
          return Root(value);
        }

        IComplexTimeDomainVector32 IComplexTimeDomainVector32.Power(float value)
        {
          return Power(value);
        }

        IComplexTimeDomainVector32 IComplexTimeDomainVector32.Logn()
        {
          return Logn();
        }

        IComplexTimeDomainVector32 IComplexTimeDomainVector32.Expn()
        {
          return Expn();
        }

        IComplexTimeDomainVector32 IComplexTimeDomainVector32.Exp(float value)
        {
          return Exp(value);
        }

        IComplexTimeDomainVector32 IComplexTimeDomainVector32.Log(float value)
        {
          return Log(value);
        }

        IComplexTimeDomainVector32 IComplexTimeDomainVector32.Sin()
        {
          return Sin();
        }

        IComplexTimeDomainVector32 IComplexTimeDomainVector32.Cos()
        {
          return Cos();
        }

        IComplexFrequencyDomainVector32 IComplexFrequencyDomainVector32.SwapHalves()
        {
          Unwrap(DataVector32Native.SwapHalves(_native));
          return this;
        }

        IComplexFrequencyDomainVector32 IComplexFrequencyDomainVector32.Sqrt()
        {
          return Sqrt();
        }

        IComplexFrequencyDomainVector32 IComplexFrequencyDomainVector32.Square()
        {
          return Square();
        }

        IComplexFrequencyDomainVector32 IComplexFrequencyDomainVector32.Root(float value)
        {
          return Root(value);
        }

        IComplexFrequencyDomainVector32 IComplexFrequencyDomainVector32.Power(float value)
        {
          return Power(value);
        }

        IComplexFrequencyDomainVector32 IComplexFrequencyDomainVector32.Logn()
        {
          return Logn();
        }

        IComplexFrequencyDomainVector32 IComplexFrequencyDomainVector32.Expn()
        {
          return Expn();
        }

        IComplexFrequencyDomainVector32 IComplexFrequencyDomainVector32.Exp(float value)
        {
          return Exp(value);
        }

        IComplexFrequencyDomainVector32 IComplexFrequencyDomainVector32.Log(float value)
        {
          return Log(value);
        }

        IComplexFrequencyDomainVector32 IComplexFrequencyDomainVector32.Sin()
        {
          return Sin();
        }

        IComplexFrequencyDomainVector32 IComplexFrequencyDomainVector32.Cos()
        {
          return Cos();
        }

        IRealFrequencyDomainVector32 IRealFrequencyDomainVector32.SwapHalves()
        {
          Unwrap(DataVector32Native.SwapHalves(_native));
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

        public DataVector32 ZeroPad(int points)
        {
            if (points < 0)
            {
                throw new IndexOutOfRangeException("Points must be >= 0");
            }

            Unwrap(DataVector32Native.ZeroPad(_native, (ulong)points));
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
            if (IsComplex)
              Unwrap(DataVector32Native.ComplexAbs(_native));
            else
              Unwrap(DataVector32Native.RealAbs(_native));
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

        public DataVector32 ComplexAbs()
        {
            Unwrap(DataVector32Native.ComplexAbs(_native));
            return this;
        }

        public void GetComplexAbs(DataVector32 destination)
        {
            CheckResultCode(DataVector32Native.GetComplexAbs(_native, destination._native));
        }

        public DataVector32 ComplexAbsSquared()
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

        public VectorDomain Domain
        {
            get { return DataVector32Native.GetDomain(_native) == 0 ? VectorDomain.Time : VectorDomain.Frequency; }
        }

     public float Delta
     {
       get { return DataVector32Native.Delta(_native); }
     }

     public bool IsComplex
        {
            get { return DataVector32Native.IsComplex(_native) != 0; }
        }

        public int Length
        {
            get { return (int) DataVector32Native.GetLength(_native); }
        }

        public int AllocatedLength
        {
            get { return (int)DataVector32Native.GetAllocatedLength(_native); }
        }

        public int Points
        {
            get { return (int)DataVector32Native.GetPoints(_native); }
        }
        
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