// Auto generated code, change Interfaces32.cs and run create_64bit_impl.pl.pl
﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicDsp
{
    public interface IDataVector64
    {
        float this[int index] { get; set; }
        VectorDomain Domain { get; }
        float Delta { get; }
        bool IsComplex { get; }
        int Length { get; }
        int AllocatedLength { get; }
        int Points { get; }
    }

    public interface IRealVectorOperations64
    {
        DataVector64 Add(float value);
        DataVector64 Add(DataVector64 vector);
        DataVector64 Subtract(float value);
        DataVector64 Subtract(DataVector64 vector);
        DataVector64 Multiply(float value);
        DataVector64 Multiply(DataVector64 vector);
        DataVector64 Divide(float value);
        DataVector64 Divide(DataVector64 vector);
        DataVector64 ZeroPad(int points);
        DataVector64 ZeroInterleave(int factor = 2);
        DataVector64 Diff();
        DataVector64 DiffWithStart();
        DataVector64 CumSum();
        DataVector64 Abs();
        DataVector64 Sqrt();
        DataVector64 Square();
        DataVector64 Root(float value);
        DataVector64 Power(float value);
        DataVector64 Logn();
        DataVector64 Expn();
        DataVector64 Exp(float value);
        DataVector64 Log(float value);
        DataVector64 Sin();
        DataVector64 Cos();
        DataVector64 ToComplex();
        DataVector64 Wrap(float value);
        DataVector64 Unwrap(float value);
    }

    public interface IComplexVectorOperations64
    {
        DataVector64 Add(float real, float imag);
        DataVector64 Add(DataVector64 vector);
        DataVector64 Subtract(float real, float imag);
        DataVector64 Subtract(DataVector64 vector);
        DataVector64 Multiply(float real, float imag);
        DataVector64 Multiply(DataVector64 vector);
        DataVector64 Divide(float real, float imag);
        DataVector64 Divide(DataVector64 vector);
        DataVector64 ComplexAbs();
        void GetComplexAbs(DataVector64 destination);
        DataVector64 ComplexAbsSquared();
        DataVector64 ComplexConj();
        DataVector64 ToReal();
        DataVector64 ToImag();
        void GetReal(DataVector64 destination);
        void GetImag(DataVector64 destination);
        DataVector64 Phase();
        void GetPhase(DataVector64 destination);
    }

    public interface ITimeDomainVectorOperations64
    {
        DataVector64 PlainFft();
    }

    public interface IFrequencyDomainVectorOperations64
    {
        DataVector64 PlainIfft();
    }

    public interface IRealTimeDomainVector64 : IDataVector64, IDisposable
    {
        IRealTimeDomainVector64 Add(float value);
        IRealTimeDomainVector64 Add(IRealTimeDomainVector64 vector);
        IRealTimeDomainVector64 Subtract(float value);
        IRealTimeDomainVector64 Subtract(IRealTimeDomainVector64 vector);
        IRealTimeDomainVector64 Multiply(float value);
        IRealTimeDomainVector64 Multiply(IRealTimeDomainVector64 vector);
        IRealTimeDomainVector64 Divide(float value);
        IRealTimeDomainVector64 Divide(IRealTimeDomainVector64 vector);
        IRealTimeDomainVector64 ZeroPad(int points);
        IRealTimeDomainVector64 ZeroInterleave(int factor = 2);
        IRealTimeDomainVector64 Diff();
        IRealTimeDomainVector64 DiffWithStart();
        IRealTimeDomainVector64 CumSum();
        IRealTimeDomainVector64 Abs();
        IRealTimeDomainVector64 Sqrt();
        IRealTimeDomainVector64 Square();
        IRealTimeDomainVector64 Root(float value);
        IRealTimeDomainVector64 Power(float value);
        IRealTimeDomainVector64 Logn();
        IRealTimeDomainVector64 Expn();
        IRealTimeDomainVector64 Exp(float value);
        IRealTimeDomainVector64 Log(float value);
        IRealTimeDomainVector64 Sin();
        IRealTimeDomainVector64 Cos();
        IRealTimeDomainVector64 SwapHalves();
        IComplexTimeDomainVector64 ToComplex();
        IRealTimeDomainVector64 Wrap(float value);
        IRealTimeDomainVector64 Unwrap(float value);
        IComplexFrequencyDomainVector64 PlainFft();
    }

    public interface IRealFrequencyDomainVector64 : IDataVector64, IDisposable
    {
        IRealFrequencyDomainVector64 Add(float value);
        IRealFrequencyDomainVector64 Add(IRealFrequencyDomainVector64 vector);
        IRealFrequencyDomainVector64 Subtract(float value);
        IRealFrequencyDomainVector64 Subtract(IRealFrequencyDomainVector64 vector);
        IRealFrequencyDomainVector64 Multiply(float value);
        IRealFrequencyDomainVector64 Multiply(IRealFrequencyDomainVector64 vector);
        IRealFrequencyDomainVector64 Divide(float value);
        IRealFrequencyDomainVector64 Divide(IRealFrequencyDomainVector64 vector);
        IRealFrequencyDomainVector64 ZeroPad(int points);
        IRealFrequencyDomainVector64 ZeroInterleave(int factor = 2);
        IRealFrequencyDomainVector64 Diff();
        IRealFrequencyDomainVector64 DiffWithStart();
        IRealFrequencyDomainVector64 CumSum();
        IRealFrequencyDomainVector64 Abs();
        IRealFrequencyDomainVector64 Sqrt();
        IRealFrequencyDomainVector64 Square();
        IRealFrequencyDomainVector64 Root(float value);
        IRealFrequencyDomainVector64 Power(float value);
        IRealFrequencyDomainVector64 Logn();
        IRealFrequencyDomainVector64 Expn();
        IRealFrequencyDomainVector64 Exp(float value);
        IRealFrequencyDomainVector64 Log(float value);
        IRealFrequencyDomainVector64 Sin();
        IRealFrequencyDomainVector64 Cos();
        IRealFrequencyDomainVector64 SwapHalves();
        IComplexFrequencyDomainVector64 ToComplex();
        IRealFrequencyDomainVector64 Wrap(float value);
        IRealFrequencyDomainVector64 Unwrap(float value);
        IComplexTimeDomainVector64 PlainIfft();
    }

    public interface IComplexTimeDomainVector64 : IDataVector64, IDisposable
    {
        IComplexTimeDomainVector64 Add(float real, float imag);
        IComplexTimeDomainVector64 Add(IComplexTimeDomainVector64 vector);
        IComplexTimeDomainVector64 Subtract(float real, float imag);
        IComplexTimeDomainVector64 Subtract(IComplexTimeDomainVector64 vector);
        IComplexTimeDomainVector64 Multiply(float real, float imag);
        IComplexTimeDomainVector64 Multiply(IComplexTimeDomainVector64 vector);
        IComplexTimeDomainVector64 Divide(float real, float imag);
        IComplexTimeDomainVector64 Divide(IComplexTimeDomainVector64 vector);
        IRealTimeDomainVector64 Abs();
        IComplexTimeDomainVector64 Sqrt();
        IComplexTimeDomainVector64 Square();
        IComplexTimeDomainVector64 Root(float value);
        IComplexTimeDomainVector64 Power(float value);
        IComplexTimeDomainVector64 Logn();
        IComplexTimeDomainVector64 Expn();
        IComplexTimeDomainVector64 Exp(float value);
        IComplexTimeDomainVector64 Log(float value);
        IComplexTimeDomainVector64 Sin();
        IComplexTimeDomainVector64 Cos();
        IComplexTimeDomainVector64 SwapHalves();
        void GetComplexAbs(IRealTimeDomainVector64 destination);
        IRealTimeDomainVector64 ComplexAbsSquared();
        IComplexTimeDomainVector64 ComplexConj();
        IRealTimeDomainVector64 ToReal();
        IRealTimeDomainVector64 ToImag();
        void GetReal(IRealTimeDomainVector64 destination);
        void GetImag(IRealTimeDomainVector64 destination);
        IRealTimeDomainVector64 Phase();
        void GetPhase(IRealTimeDomainVector64 destination);
        IComplexFrequencyDomainVector64 PlainFft();
    }

    public interface IComplexFrequencyDomainVector64 : IDataVector64, IDisposable
    {
        IComplexFrequencyDomainVector64 Add(float real, float imag);
        IComplexFrequencyDomainVector64 Add(IComplexFrequencyDomainVector64 vector);
        IComplexFrequencyDomainVector64 Subtract(float real, float imag);
        IComplexFrequencyDomainVector64 Subtract(IComplexFrequencyDomainVector64 vector);
        IComplexFrequencyDomainVector64 Multiply(float real, float imag);
        IComplexFrequencyDomainVector64 Multiply(IComplexFrequencyDomainVector64 vector);
        IComplexFrequencyDomainVector64 Divide(float real, float imag);
        IComplexFrequencyDomainVector64 Divide(IComplexFrequencyDomainVector64 vector);
        IRealFrequencyDomainVector64 Abs();
        IComplexFrequencyDomainVector64 Sqrt();
        IComplexFrequencyDomainVector64 Square();
        IComplexFrequencyDomainVector64 Root(float value);
        IComplexFrequencyDomainVector64 Power(float value);
        IComplexFrequencyDomainVector64 Logn();
        IComplexFrequencyDomainVector64 Expn();
        IComplexFrequencyDomainVector64 Exp(float value);
        IComplexFrequencyDomainVector64 Log(float value);
        IComplexFrequencyDomainVector64 Sin();
        IComplexFrequencyDomainVector64 Cos();
        IComplexFrequencyDomainVector64 SwapHalves();
        void GetComplexAbs(IRealFrequencyDomainVector64 destination);
        IRealFrequencyDomainVector64 ComplexAbsSquared();
        IComplexFrequencyDomainVector64 ComplexConj();
        IRealFrequencyDomainVector64 ToReal();
        IRealFrequencyDomainVector64 ToImag();
        void GetReal(IRealFrequencyDomainVector64 destination);
        void GetImag(IRealFrequencyDomainVector64 destination);
        IRealFrequencyDomainVector64 Phase();
        void GetPhase(IRealFrequencyDomainVector64 destination);
        IComplexTimeDomainVector64 PlainIfft();
    }
}
