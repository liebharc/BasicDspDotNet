using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicDsp
{
    public interface IDataVector32
    {
        float this[int index] { get; set; }
        VectorDomain Domain { get; }
        float Delta { get; }
        bool IsComplex { get; }
        int Length { get; }
        int AllocatedLength { get; }
        int Points { get; }
    }

    public interface IRealVectorOperations32
    {
        DataVector32 Add(float value);
        DataVector32 Add(DataVector32 vector);
        DataVector32 Subtract(float value);
        DataVector32 Subtract(DataVector32 vector);
        DataVector32 Multiply(float value);
        DataVector32 Multiply(DataVector32 vector);
        DataVector32 Divide(float value);
        DataVector32 Divide(DataVector32 vector);
        DataVector32 ZeroPad(int points);
        DataVector32 ZeroInterleave(int factor = 2);
        DataVector32 Diff();
        DataVector32 DiffWithStart();
        DataVector32 CumSum();
        DataVector32 Abs();
        DataVector32 Sqrt();
        DataVector32 Square();
        DataVector32 Root(float value);
        DataVector32 Power(float value);
        DataVector32 Logn();
        DataVector32 Expn();
        DataVector32 Exp(float value);
        DataVector32 Log(float value);
        DataVector32 Sin();
        DataVector32 Cos();
        DataVector32 ToComplex();
        DataVector32 Wrap(float value);
        DataVector32 Unwrap(float value);
    }

    public interface IComplexVectorOperations32
    {
        DataVector32 Add(float real, float imag);
        DataVector32 Add(DataVector32 vector);
        DataVector32 Subtract(float real, float imag);
        DataVector32 Subtract(DataVector32 vector);
        DataVector32 Multiply(float real, float imag);
        DataVector32 Multiply(DataVector32 vector);
        DataVector32 Divide(float real, float imag);
        DataVector32 Divide(DataVector32 vector);
        DataVector32 ComplexAbs();
        void GetComplexAbs(DataVector32 destination);
        DataVector32 ComplexAbsSquared();
        DataVector32 ComplexConj();
        DataVector32 ToReal();
        DataVector32 ToImag();
        void GetReal(DataVector32 destination);
        void GetImag(DataVector32 destination);
        DataVector32 Phase();
        void GetPhase(DataVector32 destination);
    }

    public interface ITimeDomainVectorOperations32
    {
        DataVector32 PlainFft();
    }

    public interface IFrequencyDomainVectorOperations32
    {
        DataVector32 PlainIfft();
    }

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
        IRealTimeDomainVector32 ZeroPad(int points);
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
        IRealTimeDomainVector32 SwapHalves();
        IComplexTimeDomainVector32 ToComplex();
        IRealTimeDomainVector32 Wrap(float value);
        IRealTimeDomainVector32 Unwrap(float value);
        IComplexFrequencyDomainVector32 PlainFft();
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
        IRealFrequencyDomainVector32 ZeroPad(int points);
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
        IRealFrequencyDomainVector32 SwapHalves();
        IComplexFrequencyDomainVector32 ToComplex();
        IRealFrequencyDomainVector32 Wrap(float value);
        IRealFrequencyDomainVector32 Unwrap(float value);
        IComplexTimeDomainVector32 PlainIfft();
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
        IRealTimeDomainVector32 Abs();
        IComplexTimeDomainVector32 Sqrt();
        IComplexTimeDomainVector32 Square();
        IComplexTimeDomainVector32 Root(float value);
        IComplexTimeDomainVector32 Power(float value);
        IComplexTimeDomainVector32 Logn();
        IComplexTimeDomainVector32 Expn();
        IComplexTimeDomainVector32 Exp(float value);
        IComplexTimeDomainVector32 Log(float value);
        IComplexTimeDomainVector32 Sin();
        IComplexTimeDomainVector32 Cos();
        IComplexTimeDomainVector32 SwapHalves();
        void GetComplexAbs(IRealTimeDomainVector32 destination);
        IRealTimeDomainVector32 ComplexAbsSquared();
        IComplexTimeDomainVector32 ComplexConj();
        IRealTimeDomainVector32 ToReal();
        IRealTimeDomainVector32 ToImag();
        void GetReal(IRealTimeDomainVector32 destination);
        void GetImag(IRealTimeDomainVector32 destination);
        IRealTimeDomainVector32 Phase();
        void GetPhase(IRealTimeDomainVector32 destination);
        IComplexFrequencyDomainVector32 PlainFft();
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
        IRealFrequencyDomainVector32 Abs();
        IComplexFrequencyDomainVector32 Sqrt();
        IComplexFrequencyDomainVector32 Square();
        IComplexFrequencyDomainVector32 Root(float value);
        IComplexFrequencyDomainVector32 Power(float value);
        IComplexFrequencyDomainVector32 Logn();
        IComplexFrequencyDomainVector32 Expn();
        IComplexFrequencyDomainVector32 Exp(float value);
        IComplexFrequencyDomainVector32 Log(float value);
        IComplexFrequencyDomainVector32 Sin();
        IComplexFrequencyDomainVector32 Cos();
        IComplexFrequencyDomainVector32 SwapHalves();
        void GetComplexAbs(IRealFrequencyDomainVector32 destination);
        IRealFrequencyDomainVector32 ComplexAbsSquared();
        IComplexFrequencyDomainVector32 ComplexConj();
        IRealFrequencyDomainVector32 ToReal();
        IRealFrequencyDomainVector32 ToImag();
        void GetReal(IRealFrequencyDomainVector32 destination);
        void GetImag(IRealFrequencyDomainVector32 destination);
        IRealFrequencyDomainVector32 Phase();
        void GetPhase(IRealFrequencyDomainVector32 destination);
        IComplexTimeDomainVector32 PlainIfft();
    }
}
