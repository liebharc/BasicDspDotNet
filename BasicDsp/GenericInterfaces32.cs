// ReSharper disable UnusedMember.Global

// Some comments in this class are type definitions hints for the code generator Perl scripts
// ReSharper disable UnusedMemberInSuper.Global

using System;
using System.Runtime.InteropServices;

namespace BasicDsp
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public struct Complex32
    {
        public float Imag { get; }
        public float Real { get; }
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public struct RealStatistics32
    {
        public float Sum { get; }
        public ulong Count { get; }
        public float Average { get; }
        public float RootMeanSquare { get; }
        public float Min { get; }
        public ulong MinIndex { get; }
        public float Max { get; }
        public ulong MaxIndex { get; }
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public struct ComplexStatistics32
    {
        public Complex32 Sum { get; }
        public ulong Count { get; }
        public Complex32 Average { get; }
        public Complex32 RootMeanSquare { get; }
        public Complex32 Min { get; }
        public ulong MinIndex { get; }
        public float Max { get; }
        public Complex32 MaxIndex { get; }
    }

    public interface IDataVector32 : ICloneable
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
        DataVector32 AddSmaller(DataVector32 vector);
        DataVector32 SubtractSmaller(DataVector32 vector);
        DataVector32 MultiplySmaller(DataVector32 vector);
        DataVector32 DivideSmaller(DataVector32 vector);
        DataVector32 ZeroPad(int points, PaddingOption paddingOption);
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
        DataVector32 Tan();
        DataVector32 ASin();
        DataVector32 ACos();
        DataVector32 ATan();
        DataVector32 Sinh();
        DataVector32 Cosh();
        DataVector32 Tanh();
        DataVector32 ASinh();
        DataVector32 ACosh();
        DataVector32 ATanh();
        DataVector32 /*COMPLEX*/ ToComplex();
        DataVector32 Wrap(float value);
        DataVector32 Unwrap(float value);
        float RealDotProduct(DataVector32 vector);
        RealStatistics32 RealStatistics();
        void SplitInto(DataVector32[] targets);
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
        DataVector32 AddSmaller(DataVector32 vector);
        DataVector32 SubtractSmaller(DataVector32 vector);
        DataVector32 MultiplySmaller(DataVector32 vector);
        DataVector32 DivideSmaller(DataVector32 vector);
        DataVector32 /*REAL*/ Magnitude();
        void GetMagnitude(DataVector32 /*REAL*/ destination);
        DataVector32 /*REAL*/ MagnitudeSquared();
        DataVector32 ComplexConj();
        DataVector32 /*REAL*/ ToReal();
        DataVector32 /*REAL*/ ToImag();
        void GetReal(DataVector32 /*REAL*/ destination);
        void GetImag(DataVector32 /*REAL*/ destination);
        DataVector32 /*REAL*/ Phase();
        void GetPhase(DataVector32 /*REAL*/ destination);
        Complex32 ComplexDotProduct(DataVector32 vector);
        ComplexStatistics32 ComplexStatistics();

        DataVector32 MultiplyComplexExponential(float a, float b);

        void GetRealImag(DataVector32 /*REAL*/ real, DataVector32 /*REAL*/ imag);

        void GetMagPhase(DataVector32 /*REAL*/ mag, DataVector32 /*REAL*/ phase);

        DataVector32 SetRealImag(DataVector32 /*REAL*/ real, DataVector32 /*REAL*/ imag);

        DataVector32 SetMagPhase(DataVector32 /*REAL*/ mag, DataVector32 /*REAL*/ phase);
        void SplitInto(DataVector32[] targets);
    }

    public interface ITimeDomainVectorOperations32
    {
        DataVector32 /*COMPLEXFREQ*/ PlainFft();

        DataVector32 /*COMPLEXFREQ*/ PlainSfft();
    }

    public interface IFrequencyDomainVectorOperations32
    {
        DataVector32 /*COMPLEXTIME*/ PlainIfft();
    }
}