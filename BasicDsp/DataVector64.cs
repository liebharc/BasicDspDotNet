using System;
using System.Runtime.InteropServices;

namespace BasicDsp
{
    public unsafe sealed class DataVector64 :
         IRealTimeDomainVector64,
         IRealFrequencyDomainVector64,
         IComplexTimeDomainVector64,
         IComplexFrequencyDomainVector64
    {
        private DataVector64Native.DataVector64Struct* _native;

        private const int Complex = 1;

        private const int Real = 0;

        public static DataVector64 NewGenericVector(bool isComplex, VectorDomain domain, int length)
        {
            if (length < 0)
            {
                throw new ArgumentException("Vector length must be >= 0", "length");
            }

            return new DataVector64(DataVector64Native.New(isComplex ? Complex : Real, (int)domain, 0.0f, (ulong)length, 1.0f));
        }

        public static DataVector64 NewGenericVector(bool isComplex, VectorDomain domain, double[] data)
        {
            var vector = new DataVector64(DataVector64Native.New(isComplex ? Complex : Real, (int)domain, 0.0f, (ulong)data.Length, 1.0f));
            for (int i = 0; i < data.Length; i++)
            {
                vector[i] = data[i];
            }

            return vector;
        }

        public static IRealTimeDomainVector64 NewRealTimeVectorFromConstant(double constant, int length)
        {
            if (length < 0)
            {
                throw new ArgumentException("Vector length must be >= 0", "length");
            }

            return new DataVector64(DataVector64Native.New(Real, (int)VectorDomain.Time, constant, (ulong)length, 1.0f));
        }

        public static IRealTimeDomainVector64 NewRealTimeVectorFromArray(double[] data)
        {
            var vector = new DataVector64(DataVector64Native.New(Real, (int)VectorDomain.Time, 0.0f, (ulong)data.Length, 1.0f));
            for (int i = 0; i < data.Length; i++)
            {
                vector[i] = data[i];
            }

            return vector;
        }

        public static IComplexTimeDomainVector64 NewComplexTimeVectorFromConstant(double constant, int length)
        {
            if (length < 0)
            {
                throw new ArgumentException("Vector length must be >= 0", "length");
            }

            return new DataVector64(DataVector64Native.New(Complex, (int)VectorDomain.Time, constant, (ulong)length, 1.0f));
        }

        public static IComplexTimeDomainVector64 NewComplexTimeVectorFromInterleaved(double[] data)
        {
            var vector = new DataVector64(DataVector64Native.New(Real, (int)VectorDomain.Time, 0.0f, (ulong)data.Length, 1.0f));
            for (int i = 0; i < data.Length; i++)
            {
                vector[i] = data[i];
            }

            return vector;
        }

        private DataVector64(DataVector64Native.DataVector64Struct* native)
        {
            _native = native;
        }

        public double this[int index]
        {
            get
            {
                if (index < 0 || index >= Length)
                {
                    throw new IndexOutOfRangeException("Index must be >= 0 and < " + Length);
                }

                return DataVector64Native.GetValue(_native, (ulong)index);
            }

            set
            {
                if (index < 0 || index >= Length)
                {
                    throw new IndexOutOfRangeException("Index must be >= 0 and < " + Length);
                }

                DataVector64Native.SetValue(_native, (ulong)index, value);
            }
        }

        public DataVector64 Add(double value)
        {
            Unwrap(DataVector64Native.RealOffset(_native, value));
            return this;
        }

        public IRealFrequencyDomainVector64 Add(IRealFrequencyDomainVector64 vector)
        {
            return Add((DataVector64)vector);
        }

        IRealFrequencyDomainVector64 IRealFrequencyDomainVector64.Subtract(double value)
        {
            return Subtract(value);
        }

        public IRealFrequencyDomainVector64 Subtract(IRealFrequencyDomainVector64 vector)
        {
            return Subtract((DataVector64)vector);
        }

        IRealFrequencyDomainVector64 IRealFrequencyDomainVector64.Multiply(double value)
        {
            return Multiply(value);
        }

        public IRealFrequencyDomainVector64 Multiply(IRealFrequencyDomainVector64 vector)
        {
            return Multiply((DataVector64)vector);
        }

        IRealFrequencyDomainVector64 IRealFrequencyDomainVector64.Divide(double value)
        {
            return Divide(value);
        }

        public IRealFrequencyDomainVector64 Divide(IRealFrequencyDomainVector64 vector)
        {
            return Divide((DataVector64)vector);
        }

        IRealFrequencyDomainVector64 IRealFrequencyDomainVector64.ZeroPad(int points)
        {
            return ZeroPad(points);
        }

        IRealFrequencyDomainVector64 IRealFrequencyDomainVector64.ZeroInterleave(int factor)
        {
            return ZeroInterleave(factor);
        }

        IRealFrequencyDomainVector64 IRealFrequencyDomainVector64.Diff()
        {
            return Diff();
        }

        IRealFrequencyDomainVector64 IRealFrequencyDomainVector64.DiffWithStart()
        {
            return DiffWithStart();
        }

        IRealFrequencyDomainVector64 IRealFrequencyDomainVector64.CumSum()
        {
            return CumSum();
        }

        IRealFrequencyDomainVector64 IRealFrequencyDomainVector64.Abs()
        {
            return Abs();
        }

        IRealFrequencyDomainVector64 IRealFrequencyDomainVector64.Sqrt()
        {
            return Sqrt();
        }

        IRealFrequencyDomainVector64 IRealFrequencyDomainVector64.Square()
        {
            return Square();
        }

        IRealFrequencyDomainVector64 IRealFrequencyDomainVector64.Root(double value)
        {
            return Root(value);
        }

        IRealFrequencyDomainVector64 IRealFrequencyDomainVector64.Power(double value)
        {
            return Power(value);
        }

        IRealFrequencyDomainVector64 IRealFrequencyDomainVector64.Logn()
        {
            return Logn();
        }

        IRealFrequencyDomainVector64 IRealFrequencyDomainVector64.Expn()
        {
            return Expn();
        }

        IRealFrequencyDomainVector64 IRealFrequencyDomainVector64.Exp(double value)
        {
            return Exp(value);
        }

        IRealFrequencyDomainVector64 IRealFrequencyDomainVector64.Log(double value)
        {
            return Log(value);
        }

        IComplexFrequencyDomainVector64 IRealFrequencyDomainVector64.ToComplex()
        {
            return ToComplex();
        }

        IRealFrequencyDomainVector64 IRealFrequencyDomainVector64.Sin()
        {
            return Sin();
        }

        IRealFrequencyDomainVector64 IRealFrequencyDomainVector64.Cos()
        {
            return Cos();
        }

        IRealFrequencyDomainVector64 IRealFrequencyDomainVector64.Wrap(double value)
        {
            return Wrap(value);
        }

        IRealFrequencyDomainVector64 IRealFrequencyDomainVector64.Unwrap(double value)
        {
            return Unwrap(value);
        }

        public void GetPhase(IRealFrequencyDomainVector64 destination)
        {
            GetPhase((DataVector64)destination);
        }

        IComplexTimeDomainVector64 IComplexFrequencyDomainVector64.PlainIfft()
        {
            return PlainIfft();
        }

        IComplexTimeDomainVector64 IRealFrequencyDomainVector64.PlainIfft()
        {
            return PlainIfft();
        }

        public IRealTimeDomainVector64 Add(IRealTimeDomainVector64 vector)
        {
            return Add((DataVector64)vector);
        }

        IRealTimeDomainVector64 IRealTimeDomainVector64.Subtract(double value)
        {
            return Subtract(value);
        }

        public IRealTimeDomainVector64 Subtract(IRealTimeDomainVector64 vector)
        {
            return Subtract((DataVector64)vector);
        }

        IRealTimeDomainVector64 IRealTimeDomainVector64.Multiply(double value)
        {
            return Multiply(value);
        }

        public IRealTimeDomainVector64 Multiply(IRealTimeDomainVector64 vector)
        {
            return Multiply((DataVector64)vector);
        }

        IRealTimeDomainVector64 IRealTimeDomainVector64.Divide(double value)
        {
            return Divide(value);
        }

        public IRealTimeDomainVector64 Divide(IRealTimeDomainVector64 vector)
        {
            return Divide((DataVector64)vector);
        }

        IRealTimeDomainVector64 IRealTimeDomainVector64.ZeroPad(int points)
        {
            return ZeroPad(points);
        }

        IRealTimeDomainVector64 IRealTimeDomainVector64.ZeroInterleave(int factor)
        {
            return ZeroInterleave(factor);
        }

        IRealTimeDomainVector64 IRealTimeDomainVector64.Diff()
        {
            return Diff();
        }

        IRealTimeDomainVector64 IRealTimeDomainVector64.DiffWithStart()
        {
            return DiffWithStart();
        }

        IRealTimeDomainVector64 IRealTimeDomainVector64.CumSum()
        {
            return CumSum();
        }

        IRealTimeDomainVector64 IRealTimeDomainVector64.Abs()
        {
            return Abs();
        }

        IRealTimeDomainVector64 IRealTimeDomainVector64.Sqrt()
        {
            return Sqrt();
        }

        IRealTimeDomainVector64 IRealTimeDomainVector64.Square()
        {
            return Square();
        }

        IRealTimeDomainVector64 IRealTimeDomainVector64.Root(double value)
        {
            return Root(value);
        }

        IRealTimeDomainVector64 IRealTimeDomainVector64.Power(double value)
        {
            return Power(value);
        }

        IRealTimeDomainVector64 IRealTimeDomainVector64.Logn()
        {
            return Logn();
        }

        IRealTimeDomainVector64 IRealTimeDomainVector64.Expn()
        {
            return Expn();
        }

        IRealTimeDomainVector64 IRealTimeDomainVector64.Exp(double value)
        {
            return Exp(value);
        }

        IRealTimeDomainVector64 IRealTimeDomainVector64.Log(double value)
        {
            return Log(value);
        }

        IRealTimeDomainVector64 IRealTimeDomainVector64.Sin()
        {
            return Sin();
        }

        IRealTimeDomainVector64 IRealTimeDomainVector64.Cos()
        {
            return Cos();
        }

        IComplexTimeDomainVector64 IRealTimeDomainVector64.ToComplex()
        {
            return ToComplex();
        }

        IRealTimeDomainVector64 IRealTimeDomainVector64.Wrap(double value)
        {
            return Wrap(value);
        }

        IRealTimeDomainVector64 IRealTimeDomainVector64.Unwrap(double value)
        {
            return Unwrap(value);
        }

        public void GetPhase(IRealTimeDomainVector64 destination)
        {
            GetPhase((DataVector64)destination);
        }

        IComplexFrequencyDomainVector64 IComplexTimeDomainVector64.PlainFft()
        {
            return PlainFft();
        }

        IComplexFrequencyDomainVector64 IRealTimeDomainVector64.PlainFft()
        {
            return PlainFft();
        }

        public DataVector64 Add(double real, double imag)
        {
            Unwrap(DataVector64Native.ComplexOffset(_native, real, imag));
            return this;
        }

        public IComplexFrequencyDomainVector64 Add(IComplexFrequencyDomainVector64 vector)
        {
            return Add((DataVector64)vector);
        }

        IComplexFrequencyDomainVector64 IComplexFrequencyDomainVector64.Subtract(double real, double imag)
        {
            return Subtract(real, imag);
        }

        public IComplexFrequencyDomainVector64 Subtract(IComplexFrequencyDomainVector64 vector)
        {
            return Subtract((DataVector64)vector);
        }

        IComplexFrequencyDomainVector64 IComplexFrequencyDomainVector64.Multiply(double real, double imag)
        {
            return Multiply(real, imag);
        }

        public IComplexFrequencyDomainVector64 Multiply(IComplexFrequencyDomainVector64 vector)
        {
            return Multiply((DataVector64)vector);
        }

        IComplexFrequencyDomainVector64 IComplexFrequencyDomainVector64.Divide(double real, double imag)
        {
            return Divide(real, imag);
        }

        public IComplexFrequencyDomainVector64 Divide(IComplexFrequencyDomainVector64 vector)
        {
            return Divide((DataVector64)vector);
        }

        IRealFrequencyDomainVector64 IComplexFrequencyDomainVector64.Abs()
        {
            return ComplexAbs();
        }

        public void GetComplexAbs(IRealFrequencyDomainVector64 destination)
        {
            GetComplexAbs((DataVector64)destination);
        }

        IRealFrequencyDomainVector64 IComplexFrequencyDomainVector64.ComplexAbsSquared()
        {
            return ComplexAbsSquared();
        }

        IComplexFrequencyDomainVector64 IComplexFrequencyDomainVector64.ComplexConj()
        {
            return ComplexConj();
        }

        IRealFrequencyDomainVector64 IComplexFrequencyDomainVector64.ToReal()
        {
            return ToReal();
        }

        IRealFrequencyDomainVector64 IComplexFrequencyDomainVector64.ToImag()
        {
            return ToImag();
        }

        public void GetReal(IRealFrequencyDomainVector64 destination)
        {
            GetReal((DataVector64)destination);
        }

        public void GetImag(IRealFrequencyDomainVector64 destination)
        {
            GetImag((DataVector64)destination);
        }

        IRealFrequencyDomainVector64 IComplexFrequencyDomainVector64.Phase()
        {
            return Phase();
        }

        public IComplexTimeDomainVector64 Add(IComplexTimeDomainVector64 vector)
        {
            return Add((DataVector64)vector);
        }

        IComplexTimeDomainVector64 IComplexTimeDomainVector64.Subtract(double real, double imag)
        {
            return Subtract(real, imag);
        }

        public IComplexTimeDomainVector64 Subtract(IComplexTimeDomainVector64 vector)
        {
            return Subtract((DataVector64)vector);
        }

        IComplexTimeDomainVector64 IComplexTimeDomainVector64.Multiply(double real, double imag)
        {
            return Multiply(real, imag);
        }

        public IComplexTimeDomainVector64 Multiply(IComplexTimeDomainVector64 vector)
        {
            return Multiply((DataVector64)vector);
        }

        IComplexTimeDomainVector64 IComplexTimeDomainVector64.Divide(double real, double imag)
        {
            return Divide(real, imag);
        }

        public IComplexTimeDomainVector64 Divide(IComplexTimeDomainVector64 vector)
        {
            return Divide((DataVector64)vector);
        }

        IRealTimeDomainVector64 IComplexTimeDomainVector64.Abs()
        {
            return ComplexAbs();
        }

        IRealTimeDomainVector64 IRealTimeDomainVector64.SwapHalves()
        {
            Unwrap(DataVector64Native.SwapHalves(_native));
            return this;
        }

        IComplexTimeDomainVector64 IComplexTimeDomainVector64.SwapHalves()
        {
            Unwrap(DataVector64Native.SwapHalves(_native));
            return this;
        }

        public void GetComplexAbs(IRealTimeDomainVector64 destination)
        {
            GetComplexAbs((DataVector64)destination);
        }

        IRealTimeDomainVector64 IComplexTimeDomainVector64.ComplexAbsSquared()
        {
            return ComplexAbsSquared();
        }

        IComplexTimeDomainVector64 IComplexTimeDomainVector64.ComplexConj()
        {
            return ComplexConj();
        }

        IRealTimeDomainVector64 IComplexTimeDomainVector64.ToReal()
        {
            return ToReal();
        }

        IRealTimeDomainVector64 IComplexTimeDomainVector64.ToImag()
        {
            return ToImag();
        }

        public void GetReal(IRealTimeDomainVector64 destination)
        {
            GetReal((DataVector64)destination);
        }

        public void GetImag(IRealTimeDomainVector64 destination)
        {
            GetImag((DataVector64)destination);
        }

        IRealTimeDomainVector64 IComplexTimeDomainVector64.Phase()
        {
            return Phase();
        }


        IRealTimeDomainVector64 IRealTimeDomainVector64.Add(double value)
        {
            return Add(value);
        }

        IRealFrequencyDomainVector64 IRealFrequencyDomainVector64.Add(double value)
        {
            return Add(value);
        }

        IComplexTimeDomainVector64 IComplexTimeDomainVector64.Add(double real, double imag)
        {
            return Add(real, imag);
        }

        IComplexFrequencyDomainVector64 IComplexFrequencyDomainVector64.Add(double real, double imag)
        {
            return Add(real, imag);
        }

        IComplexTimeDomainVector64 IComplexTimeDomainVector64.Sqrt()
        {
            return Sqrt();
        }

        IComplexTimeDomainVector64 IComplexTimeDomainVector64.Square()
        {
            return Square();
        }

        IComplexTimeDomainVector64 IComplexTimeDomainVector64.Root(double value)
        {
            return Root(value);
        }

        IComplexTimeDomainVector64 IComplexTimeDomainVector64.Power(double value)
        {
            return Power(value);
        }

        IComplexTimeDomainVector64 IComplexTimeDomainVector64.Logn()
        {
            return Logn();
        }

        IComplexTimeDomainVector64 IComplexTimeDomainVector64.Expn()
        {
            return Expn();
        }

        IComplexTimeDomainVector64 IComplexTimeDomainVector64.Exp(double value)
        {
            return Exp(value);
        }

        IComplexTimeDomainVector64 IComplexTimeDomainVector64.Log(double value)
        {
            return Log(value);
        }

        IComplexTimeDomainVector64 IComplexTimeDomainVector64.Sin()
        {
            return Sin();
        }

        IComplexTimeDomainVector64 IComplexTimeDomainVector64.Cos()
        {
            return Cos();
        }

        IComplexFrequencyDomainVector64 IComplexFrequencyDomainVector64.SwapHalves()
        {
            Unwrap(DataVector64Native.SwapHalves(_native));
            return this;
        }

        IComplexFrequencyDomainVector64 IComplexFrequencyDomainVector64.Sqrt()
        {
            return Sqrt();
        }

        IComplexFrequencyDomainVector64 IComplexFrequencyDomainVector64.Square()
        {
            return Square();
        }

        IComplexFrequencyDomainVector64 IComplexFrequencyDomainVector64.Root(double value)
        {
            return Root(value);
        }

        IComplexFrequencyDomainVector64 IComplexFrequencyDomainVector64.Power(double value)
        {
            return Power(value);
        }

        IComplexFrequencyDomainVector64 IComplexFrequencyDomainVector64.Logn()
        {
            return Logn();
        }

        IComplexFrequencyDomainVector64 IComplexFrequencyDomainVector64.Expn()
        {
            return Expn();
        }

        IComplexFrequencyDomainVector64 IComplexFrequencyDomainVector64.Exp(double value)
        {
            return Exp(value);
        }

        IComplexFrequencyDomainVector64 IComplexFrequencyDomainVector64.Log(double value)
        {
            return Log(value);
        }

        IComplexFrequencyDomainVector64 IComplexFrequencyDomainVector64.Sin()
        {
            return Sin();
        }

        IComplexFrequencyDomainVector64 IComplexFrequencyDomainVector64.Cos()
        {
            return Cos();
        }

        IRealFrequencyDomainVector64 IRealFrequencyDomainVector64.SwapHalves()
        {
            Unwrap(DataVector64Native.SwapHalves(_native));
            return this;
        }

        public DataVector64 Add(DataVector64 vector)
        {
            Unwrap(DataVector64Native.AddVector(_native, vector._native));
            return this;
        }

        public DataVector64 Subtract(double value)
        {
            Unwrap(DataVector64Native.RealOffset(_native, -value));
            return this;
        }

        public DataVector64 Subtract(double real, double imag)
        {
            Unwrap(DataVector64Native.ComplexOffset(_native, -real, -imag));
            return this;
        }

        public DataVector64 Subtract(DataVector64 vector)
        {
            Unwrap(DataVector64Native.SubtractVector(_native, vector._native));
            return this;
        }

        public DataVector64 Multiply(double value)
        {
            Unwrap(DataVector64Native.RealScale(_native, value));
            return this;
        }

        public DataVector64 Multiply(double real, double imag)
        {
            Unwrap(DataVector64Native.ComplexScale(_native, real, imag));
            return this;
        }

        public DataVector64 Multiply(DataVector64 vector)
        {
            Unwrap(DataVector64Native.MultiplyVector(_native, vector._native));
            return this;
        }

        public DataVector64 Divide(double value)
        {
            Unwrap(DataVector64Native.RealScale(_native, 1 / value));
            return this;
        }

        public DataVector64 Divide(double real, double imag)
        {
            Unwrap(DataVector64Native.ComplexDivide(_native, real, imag));
            return this;
        }

        public DataVector64 Divide(DataVector64 vector)
        {
            Unwrap(DataVector64Native.DivideVector(_native, vector._native));
            return this;
        }

        public DataVector64 ZeroPad(int points)
        {
            if (points < 0)
            {
                throw new IndexOutOfRangeException("Points must be >= 0");
            }

            Unwrap(DataVector64Native.ZeroPad(_native, (ulong)points));
            return this;
        }

        public DataVector64 ZeroInterleave(int factor)
        {
            Unwrap(DataVector64Native.ZeroInterleave(_native, factor));
            return this;
        }

        public DataVector64 Diff()
        {
            Unwrap(DataVector64Native.Diff(_native));
            return this;
        }

        public DataVector64 DiffWithStart()
        {
            Unwrap(DataVector64Native.DiffWithStart(_native));
            return this;
        }

        public DataVector64 CumSum()
        {
            Unwrap(DataVector64Native.CumSum(_native));
            return this;
        }

        public DataVector64 Abs()
        {
            if (IsComplex)
                Unwrap(DataVector64Native.ComplexAbs(_native));
            else
                Unwrap(DataVector64Native.RealAbs(_native));
            return this;
        }

        public DataVector64 Sqrt()
        {
            Unwrap(DataVector64Native.Sqrt(_native));
            return this;
        }

        public DataVector64 Square()
        {
            Unwrap(DataVector64Native.Square(_native));
            return this;
        }

        public DataVector64 Root(double value)
        {
            Unwrap(DataVector64Native.Root(_native, value));
            return this;
        }

        public DataVector64 Power(double value)
        {
            Unwrap(DataVector64Native.Power(_native, value));
            return this;
        }

        public DataVector64 Logn()
        {
            Unwrap(DataVector64Native.Logn(_native));
            return this;
        }

        public DataVector64 Expn()
        {
            Unwrap(DataVector64Native.Expn(_native));
            return this;
        }

        public DataVector64 Exp(double value)
        {
            Unwrap(DataVector64Native.Exp(_native, value));
            return this;
        }

        public DataVector64 Log(double value)
        {
            Unwrap(DataVector64Native.Log(_native, value));
            return this;
        }

        public DataVector64 ToComplex()
        {
            Unwrap(DataVector64Native.ToComplex(_native));
            return this;
        }

        public DataVector64 Sin()
        {
            Unwrap(DataVector64Native.Sin(_native));
            return this;
        }

        public DataVector64 Cos()
        {
            Unwrap(DataVector64Native.Cos(_native));
            return this;
        }

        public DataVector64 SwapHalves()
        {
            Unwrap(DataVector64Native.SwapHalves(_native));
            return this;
        }

        public DataVector64 Wrap(double value)
        {
            Unwrap(DataVector64Native.Wrap(_native, value));
            return this;
        }

        public DataVector64 Unwrap(double value)
        {
            Unwrap(DataVector64Native.Unwrap(_native, value));
            return this;
        }

        public DataVector64 ComplexAbs()
        {
            Unwrap(DataVector64Native.ComplexAbs(_native));
            return this;
        }

        public void GetComplexAbs(DataVector64 destination)
        {
            CheckResultCode(DataVector64Native.GetComplexAbs(_native, destination._native));
        }

        public DataVector64 ComplexAbsSquared()
        {
            Unwrap(DataVector64Native.ComplexAbsSquared(_native));
            return this;
        }

        public DataVector64 ComplexConj()
        {
            Unwrap(DataVector64Native.ComplexConj(_native));
            return this;
        }

        public DataVector64 ToReal()
        {
            Unwrap(DataVector64Native.ToReal(_native));
            return this;
        }

        public DataVector64 ToImag()
        {
            Unwrap(DataVector64Native.ToImag(_native));
            return this;
        }

        public void GetReal(DataVector64 destination)
        {
            CheckResultCode(DataVector64Native.GetReal(_native, destination._native));
        }

        public void GetImag(DataVector64 destination)
        {
            CheckResultCode(DataVector64Native.GetImag(_native, destination._native));
        }

        public DataVector64 Phase()
        {
            Unwrap(DataVector64Native.Phase(_native));
            return this;
        }

        public void GetPhase(DataVector64 destination)
        {
            CheckResultCode(DataVector64Native.GetPhase(_native, destination._native));
        }

        public DataVector64 PlainFft()
        {
            Unwrap(DataVector64Native.PlainFft(_native));
            return this;
        }

        public DataVector64 PlainIfft()
        {
            Unwrap(DataVector64Native.PlainIfft(_native));
            return this;
        }

        private void Unwrap(DataVector64Native.VectorResult64 result)
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
            get { return DataVector64Native.GetDomain(_native) == 0 ? VectorDomain.Time : VectorDomain.Frequency; }
        }

        public double Delta
        {
          get { return DataVector64Native.Delta(_native); }
        }

      public bool IsComplex
        {
            get { return DataVector64Native.IsComplex(_native) != 0; }
        }

        public int Length
        {
            get { return (int)DataVector64Native.GetLength(_native); }
        }

        public int AllocatedLength
        {
            get { return (int)DataVector64Native.GetAllocatedLength(_native); }
        }

        public int Points
        {
            get { return (int)DataVector64Native.GetPoints(_native); }
        }

        public void Dispose()
        {
            if (_native != null)
            {
                DataVector64Native.DeleteVector(_native);
                _native = null;
            }
        }
    }
}