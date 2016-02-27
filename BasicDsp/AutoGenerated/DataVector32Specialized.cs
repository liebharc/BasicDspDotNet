using System;
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedMember.Global

namespace BasicDsp
{
    partial class DataVector32 :
        IRealTimeDomainVector32,
        IRealFrequencyDomainVector32,
        IComplexTimeDomainVector32,
        IComplexFrequencyDomainVector32
    {
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
            return Subtract((DataVector32)vector);
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

        IRealFrequencyDomainVector32 IRealFrequencyDomainVector32.ZeroPad(int points, PaddingOption paddingOption)
        {
            return ZeroPad(points, paddingOption);
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
            return Add((DataVector32)vector);
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

        IRealTimeDomainVector32 IRealTimeDomainVector32.ZeroPad(int points, PaddingOption paddingOption)
        {
            return ZeroPad(points, paddingOption);
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

        public IComplexFrequencyDomainVector32 Add(IComplexFrequencyDomainVector32 vector)
        {
            return Add((DataVector32)vector);
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
            return ((DataVector32) this).SwapHalves();
        }

        IComplexTimeDomainVector32 IComplexTimeDomainVector32.SwapHalves()
        {
            return ((DataVector32)this).SwapHalves();
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
            return ((DataVector32)this).SwapHalves();
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
            return ((DataVector32)this).SwapHalves();
        }
    }
}
