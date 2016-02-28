// Auto generated code, change GenericInterfaces32.cs and run create_specialized_interfaces.pl.pl
using System;
// ReSharper disable UnusedMember.Global
// ReSharper disable MemberCanBePrivate.Global
namespace BasicDsp
{
    partial class DataVector32 :
        IRealTimeDomainVector32,
        IRealFrequencyDomainVector32,
        IComplexTimeDomainVector32,
        IComplexFrequencyDomainVector32
    {
        IRealTimeDomainVector32 IRealTimeDomainVector32.Add(float value)
        {
            return Add(value);
        }

        IRealTimeDomainVector32 IRealTimeDomainVector32.Add(IRealTimeDomainVector32 vector)
        {
            return Add((DataVector32)vector);
        }

        IRealTimeDomainVector32 IRealTimeDomainVector32.Subtract(float value)
        {
            return Subtract(value);
        }

        IRealTimeDomainVector32 IRealTimeDomainVector32.Subtract(IRealTimeDomainVector32 vector)
        {
            return Subtract((DataVector32)vector);
        }

        IRealTimeDomainVector32 IRealTimeDomainVector32.Multiply(float value)
        {
            return Multiply(value);
        }

        IRealTimeDomainVector32 IRealTimeDomainVector32.Multiply(IRealTimeDomainVector32 vector)
        {
            return Multiply((DataVector32)vector);
        }

        IRealTimeDomainVector32 IRealTimeDomainVector32.Divide(float value)
        {
            return Divide(value);
        }

        IRealTimeDomainVector32 IRealTimeDomainVector32.Divide(IRealTimeDomainVector32 vector)
        {
            return Divide((DataVector32)vector);
        }

        IRealTimeDomainVector32 IRealTimeDomainVector32.ZeroPad(int points, PaddingOption paddingOption)
        {
            return ZeroPad(points, paddingOption);
        }

        IRealTimeDomainVector32 IRealTimeDomainVector32.ZeroInterleave(int factor = 2)
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

        IComplexTimeDomainVector32/*COMPLEX*/ IRealTimeDomainVector32.ToComplex()
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

        IComplexFrequencyDomainVector32/*COMPLEXFREQ*/ IRealTimeDomainVector32.PlainFft()
        {
            return PlainFft();
        }

        IComplexTimeDomainVector32 IComplexTimeDomainVector32.Add(float real, float imag)
        {
            return Add(real, imag);
        }

        IComplexTimeDomainVector32 IComplexTimeDomainVector32.Add(IComplexTimeDomainVector32 vector)
        {
            return Add((DataVector32)vector);
        }

        IComplexTimeDomainVector32 IComplexTimeDomainVector32.Subtract(float real, float imag)
        {
            return Subtract(real, imag);
        }

        IComplexTimeDomainVector32 IComplexTimeDomainVector32.Subtract(IComplexTimeDomainVector32 vector)
        {
            return Subtract((DataVector32)vector);
        }

        IComplexTimeDomainVector32 IComplexTimeDomainVector32.Multiply(float real, float imag)
        {
            return Multiply(real, imag);
        }

        IComplexTimeDomainVector32 IComplexTimeDomainVector32.Multiply(IComplexTimeDomainVector32 vector)
        {
            return Multiply((DataVector32)vector);
        }

        IComplexTimeDomainVector32 IComplexTimeDomainVector32.Divide(float real, float imag)
        {
            return Divide(real, imag);
        }

        IComplexTimeDomainVector32 IComplexTimeDomainVector32.Divide(IComplexTimeDomainVector32 vector)
        {
            return Divide((DataVector32)vector);
        }

        IRealTimeDomainVector32/*REAL*/ IComplexTimeDomainVector32.Magnitude()
        {
            return Magnitude();
        }

        void IComplexTimeDomainVector32.GetComplexAbs(IRealTimeDomainVector32/*REAL*/ destination)
        {
            GetMagnitude((DataVector32)destination);
        }

        IRealTimeDomainVector32/*REAL*/ IComplexTimeDomainVector32.ComplexAbsSquared()
        {
            return MagnitudeSquared();
        }

        IComplexTimeDomainVector32 IComplexTimeDomainVector32.ComplexConj()
        {
            return ComplexConj();
        }

        IRealTimeDomainVector32/*REAL*/ IComplexTimeDomainVector32.ToReal()
        {
            return ToReal();
        }

        IRealTimeDomainVector32/*REAL*/ IComplexTimeDomainVector32.ToImag()
        {
            return ToImag();
        }

        void IComplexTimeDomainVector32.GetReal(IRealTimeDomainVector32/*REAL*/ destination)
        {
            GetReal((DataVector32)destination);
        }

        void IComplexTimeDomainVector32.GetImag(IRealTimeDomainVector32/*REAL*/ destination)
        {
            GetImag((DataVector32)destination);
        }

        IRealTimeDomainVector32/*REAL*/ IComplexTimeDomainVector32.Phase()
        {
            return Phase();
        }

        void IComplexTimeDomainVector32.GetPhase(IRealTimeDomainVector32/*REAL*/ destination)
        {
            GetPhase((DataVector32)destination);
        }

        IComplexFrequencyDomainVector32/*COMPLEXFREQ*/ IComplexTimeDomainVector32.PlainFft()
        {
            return PlainFft();
        }

        IRealFrequencyDomainVector32 IRealFrequencyDomainVector32.Add(float value)
        {
            return Add(value);
        }

        IRealFrequencyDomainVector32 IRealFrequencyDomainVector32.Add(IRealFrequencyDomainVector32 vector)
        {
            return Add((DataVector32)vector);
        }

        IRealFrequencyDomainVector32 IRealFrequencyDomainVector32.Subtract(float value)
        {
            return Subtract(value);
        }

        IRealFrequencyDomainVector32 IRealFrequencyDomainVector32.Subtract(IRealFrequencyDomainVector32 vector)
        {
            return Subtract((DataVector32)vector);
        }

        IRealFrequencyDomainVector32 IRealFrequencyDomainVector32.Multiply(float value)
        {
            return Multiply(value);
        }

        IRealFrequencyDomainVector32 IRealFrequencyDomainVector32.Multiply(IRealFrequencyDomainVector32 vector)
        {
            return Multiply((DataVector32)vector);
        }

        IRealFrequencyDomainVector32 IRealFrequencyDomainVector32.Divide(float value)
        {
            return Divide(value);
        }

        IRealFrequencyDomainVector32 IRealFrequencyDomainVector32.Divide(IRealFrequencyDomainVector32 vector)
        {
            return Divide((DataVector32)vector);
        }

        IRealFrequencyDomainVector32 IRealFrequencyDomainVector32.ZeroPad(int points, PaddingOption paddingOption)
        {
            return ZeroPad(points, paddingOption);
        }

        IRealFrequencyDomainVector32 IRealFrequencyDomainVector32.ZeroInterleave(int factor = 2)
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

        IRealFrequencyDomainVector32 IRealFrequencyDomainVector32.Sin()
        {
            return Sin();
        }

        IRealFrequencyDomainVector32 IRealFrequencyDomainVector32.Cos()
        {
            return Cos();
        }

        IComplexFrequencyDomainVector32/*COMPLEX*/ IRealFrequencyDomainVector32.ToComplex()
        {
            return ToComplex();
        }

        IRealFrequencyDomainVector32 IRealFrequencyDomainVector32.Wrap(float value)
        {
            return Wrap(value);
        }

        IRealFrequencyDomainVector32 IRealFrequencyDomainVector32.Unwrap(float value)
        {
            return Unwrap(value);
        }

        IComplexTimeDomainVector32/*COMPLEXTIME*/ IRealFrequencyDomainVector32.PlainIfft()
        {
            return PlainIfft();
        }

        IComplexFrequencyDomainVector32 IComplexFrequencyDomainVector32.Add(float real, float imag)
        {
            return Add(real, imag);
        }

        IComplexFrequencyDomainVector32 IComplexFrequencyDomainVector32.Add(IComplexFrequencyDomainVector32 vector)
        {
            return Add((DataVector32)vector);
        }

        IComplexFrequencyDomainVector32 IComplexFrequencyDomainVector32.Subtract(float real, float imag)
        {
            return Subtract(real, imag);
        }

        IComplexFrequencyDomainVector32 IComplexFrequencyDomainVector32.Subtract(IComplexFrequencyDomainVector32 vector)
        {
            return Subtract((DataVector32)vector);
        }

        IComplexFrequencyDomainVector32 IComplexFrequencyDomainVector32.Multiply(float real, float imag)
        {
            return Multiply(real, imag);
        }

        IComplexFrequencyDomainVector32 IComplexFrequencyDomainVector32.Multiply(IComplexFrequencyDomainVector32 vector)
        {
            return Multiply((DataVector32)vector);
        }

        IComplexFrequencyDomainVector32 IComplexFrequencyDomainVector32.Divide(float real, float imag)
        {
            return Divide(real, imag);
        }

        IComplexFrequencyDomainVector32 IComplexFrequencyDomainVector32.Divide(IComplexFrequencyDomainVector32 vector)
        {
            return Divide((DataVector32)vector);
        }

        IRealFrequencyDomainVector32/*REAL*/ IComplexFrequencyDomainVector32.Magnitude()
        {
            return Magnitude();
        }

        void IComplexFrequencyDomainVector32.GetComplexAbs(IRealFrequencyDomainVector32/*REAL*/ destination)
        {
            GetMagnitude((DataVector32)destination);
        }

        IRealFrequencyDomainVector32/*REAL*/ IComplexFrequencyDomainVector32.ComplexAbsSquared()
        {
            return MagnitudeSquared();
        }

        IComplexFrequencyDomainVector32 IComplexFrequencyDomainVector32.ComplexConj()
        {
            return ComplexConj();
        }

        IRealFrequencyDomainVector32/*REAL*/ IComplexFrequencyDomainVector32.ToReal()
        {
            return ToReal();
        }

        IRealFrequencyDomainVector32/*REAL*/ IComplexFrequencyDomainVector32.ToImag()
        {
            return ToImag();
        }

        void IComplexFrequencyDomainVector32.GetReal(IRealFrequencyDomainVector32/*REAL*/ destination)
        {
            GetReal((DataVector32)destination);
        }

        void IComplexFrequencyDomainVector32.GetImag(IRealFrequencyDomainVector32/*REAL*/ destination)
        {
            GetImag((DataVector32)destination);
        }

        IRealFrequencyDomainVector32/*REAL*/ IComplexFrequencyDomainVector32.Phase()
        {
            return Phase();
        }

        void IComplexFrequencyDomainVector32.GetPhase(IRealFrequencyDomainVector32/*REAL*/ destination)
        {
            GetPhase((DataVector32)destination);
        }

        IComplexTimeDomainVector32/*COMPLEXTIME*/ IComplexFrequencyDomainVector32.PlainIfft()
        {
            return PlainIfft();
        }

    }
}
