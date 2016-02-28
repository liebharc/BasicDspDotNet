// Auto generated code, change GenericInterfaces32.cs and run create_specialized_interfaces.pl.pl
using System;
// ReSharper disable UnusedMember.Global
namespace BasicDsp
{
   public interface IRealTimeDomainVector32 : IDataVector32, IDisposable
      {

        IRealTimeDomainVector32 Add(float value);
        IRealTimeDomainVector32 Add(IRealTimeDomainVector32 vector);
        IRealTimeDomainVector32 Subtract(float value);
        IRealTimeDomainVector32 Subtract(IRealTimeDomainVector32 vector);
        IRealTimeDomainVector32 Multiply(float value);
        IRealTimeDomainVector32 Multiply(IRealTimeDomainVector32 vector);
        IRealTimeDomainVector32 Divide(float value);
        IRealTimeDomainVector32 Divide(IRealTimeDomainVector32 vector);
        IRealTimeDomainVector32 ZeroPad(int points, PaddingOption paddingOption);
        IRealTimeDomainVector32 ZeroInterleave(int factor = 2);
        IRealTimeDomainVector32 Diff();
        IRealTimeDomainVector32 DiffWithStart();
        IRealTimeDomainVector32 CumSum();
        IRealTimeDomainVector32 Abs();
        IRealTimeDomainVector32 Sqrt();
        IRealTimeDomainVector32 Square();
        IRealTimeDomainVector32 Root(float value);
        IRealTimeDomainVector32 Power(float value);
        IRealTimeDomainVector32 Logn();
        IRealTimeDomainVector32 Expn();
        IRealTimeDomainVector32 Exp(float value);
        IRealTimeDomainVector32 Log(float value);
        IRealTimeDomainVector32 Sin();
        IRealTimeDomainVector32 Cos();
        IComplexTimeDomainVector32/*COMPLEX*/ ToComplex();
        IRealTimeDomainVector32 Wrap(float value);
        IRealTimeDomainVector32 Unwrap(float value);
        IComplexFrequencyDomainVector32/*COMPLEXFREQ*/ PlainFft();
      }
   public interface IComplexTimeDomainVector32 : IDataVector32, IDisposable
      {
        IComplexTimeDomainVector32 Add(float real, float imag);
        IComplexTimeDomainVector32 Add(IComplexTimeDomainVector32 vector);
        IComplexTimeDomainVector32 Subtract(float real, float imag);
        IComplexTimeDomainVector32 Subtract(IComplexTimeDomainVector32 vector);
        IComplexTimeDomainVector32 Multiply(float real, float imag);
        IComplexTimeDomainVector32 Multiply(IComplexTimeDomainVector32 vector);
        IComplexTimeDomainVector32 Divide(float real, float imag);
        IComplexTimeDomainVector32 Divide(IComplexTimeDomainVector32 vector);
        IRealTimeDomainVector32/*REAL*/ Magnitude();
        void GetComplexAbs(IRealTimeDomainVector32/*REAL*/ destination);
        IRealTimeDomainVector32/*REAL*/ ComplexAbsSquared();
        IComplexTimeDomainVector32 ComplexConj();
        IRealTimeDomainVector32/*REAL*/ ToReal();
        IRealTimeDomainVector32/*REAL*/ ToImag();
        void GetReal(IRealTimeDomainVector32/*REAL*/ destination);
        void GetImag(IRealTimeDomainVector32/*REAL*/ destination);
        IRealTimeDomainVector32/*REAL*/ Phase();
        void GetPhase(IRealTimeDomainVector32/*REAL*/ destination);
        IComplexFrequencyDomainVector32/*COMPLEXFREQ*/ PlainFft();
      }
   public interface IRealFrequencyDomainVector32 : IDataVector32, IDisposable
      {

        IRealFrequencyDomainVector32 Add(float value);
        IRealFrequencyDomainVector32 Add(IRealFrequencyDomainVector32 vector);
        IRealFrequencyDomainVector32 Subtract(float value);
        IRealFrequencyDomainVector32 Subtract(IRealFrequencyDomainVector32 vector);
        IRealFrequencyDomainVector32 Multiply(float value);
        IRealFrequencyDomainVector32 Multiply(IRealFrequencyDomainVector32 vector);
        IRealFrequencyDomainVector32 Divide(float value);
        IRealFrequencyDomainVector32 Divide(IRealFrequencyDomainVector32 vector);
        IRealFrequencyDomainVector32 ZeroPad(int points, PaddingOption paddingOption);
        IRealFrequencyDomainVector32 ZeroInterleave(int factor = 2);
        IRealFrequencyDomainVector32 Diff();
        IRealFrequencyDomainVector32 DiffWithStart();
        IRealFrequencyDomainVector32 CumSum();
        IRealFrequencyDomainVector32 Abs();
        IRealFrequencyDomainVector32 Sqrt();
        IRealFrequencyDomainVector32 Square();
        IRealFrequencyDomainVector32 Root(float value);
        IRealFrequencyDomainVector32 Power(float value);
        IRealFrequencyDomainVector32 Logn();
        IRealFrequencyDomainVector32 Expn();
        IRealFrequencyDomainVector32 Exp(float value);
        IRealFrequencyDomainVector32 Log(float value);
        IRealFrequencyDomainVector32 Sin();
        IRealFrequencyDomainVector32 Cos();
        IComplexFrequencyDomainVector32/*COMPLEX*/ ToComplex();
        IRealFrequencyDomainVector32 Wrap(float value);
        IRealFrequencyDomainVector32 Unwrap(float value);
        IComplexTimeDomainVector32/*COMPLEXTIME*/ PlainIfft();
      }
   public interface IComplexFrequencyDomainVector32 : IDataVector32, IDisposable
      {
        IComplexFrequencyDomainVector32 Add(float real, float imag);
        IComplexFrequencyDomainVector32 Add(IComplexFrequencyDomainVector32 vector);
        IComplexFrequencyDomainVector32 Subtract(float real, float imag);
        IComplexFrequencyDomainVector32 Subtract(IComplexFrequencyDomainVector32 vector);
        IComplexFrequencyDomainVector32 Multiply(float real, float imag);
        IComplexFrequencyDomainVector32 Multiply(IComplexFrequencyDomainVector32 vector);
        IComplexFrequencyDomainVector32 Divide(float real, float imag);
        IComplexFrequencyDomainVector32 Divide(IComplexFrequencyDomainVector32 vector);
        IRealFrequencyDomainVector32/*REAL*/ Magnitude();
        void GetComplexAbs(IRealFrequencyDomainVector32/*REAL*/ destination);
        IRealFrequencyDomainVector32/*REAL*/ ComplexAbsSquared();
        IComplexFrequencyDomainVector32 ComplexConj();
        IRealFrequencyDomainVector32/*REAL*/ ToReal();
        IRealFrequencyDomainVector32/*REAL*/ ToImag();
        void GetReal(IRealFrequencyDomainVector32/*REAL*/ destination);
        void GetImag(IRealFrequencyDomainVector32/*REAL*/ destination);
        IRealFrequencyDomainVector32/*REAL*/ Phase();
        void GetPhase(IRealFrequencyDomainVector32/*REAL*/ destination);
        IComplexTimeDomainVector32/*COMPLEXTIME*/ PlainIfft();
      }
}
