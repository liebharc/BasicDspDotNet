// Some comments in this class are type definitions hints for the code generator Perl scripts

// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedMemberInSuper.Global
// ReSharper disable UnassignedGetOnlyAutoProperty

using System;
using System.Runtime.InteropServices;

namespace BasicDsp
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public struct Complex32
    {
        public Complex32(float real, float imag)
        {
            Real = real;
            Imag = imag;
        }

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

    public abstract class WindowFunction32
    {
        public abstract bool IsSymmetric { get; }

        public abstract float Calculate(ulong n, ulong length);
    }

    public abstract class RealImpulseResponse32
    {
        public abstract bool IsSymmetric { get; }

        public abstract float Calculate(float x);
    }

    public abstract class ComplexImpulseResponse32
    {
        public abstract bool IsSymmetric { get; }

        public abstract Complex32 Calculate(float x);
    }

    public abstract class RealFrequencyResponse32
    {
        public abstract bool IsSymmetric { get; }

        public abstract float Calculate(float x);
    }

    public abstract class ComplexFrequencyResponse32
    {
        public abstract bool IsSymmetric { get; }

        public abstract Complex32 Calculate(float x);
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

        DataVector32 OverrideData(float[] data);

        void ForceLen(int length);
    }

    public interface IGenericVectorOperations32
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
        DataVector32 ZeroInterleave(int factor);
        DataVector32 Diff();
        DataVector32 DiffWithStart();
        DataVector32 CumSum();
        void SplitInto(DataVector32[] targets);
        DataVector32 Merge(DataVector32[] sources);
        DataVector32 Mirror();
        DataVector32 Interpolatef(StandardImpulseResponse impulseResponse, float rollOFf, float interpolationFactor, float delay, int length);
        DataVector32 Interpolatef(RealImpulseResponse32 impulseResponse, float interpolationFactor, float delay, int length);
        DataVector32 Interpolatei(StandardFrequencyResponse frequencyResponse, float rollOff, int interpolationFactor);
        DataVector32 Interpolatei(RealFrequencyResponse32 frequencyResponse, int interpolationFactor);
        DataVector32 InterpolateLin(float interpolationFactor, float delay);
        DataVector32 InterpolateHermite(float interpolationFactor, float delay);
    }

    public interface IRealVectorOperations32
    {
        DataVector32 Abs();
        DataVector32 Sqrt();
        DataVector32 Square();
        DataVector32 Root(float value);
        DataVector32 Powf(float value);
        DataVector32 Ln();
        DataVector32 Exp();
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
        DataVector32 MapInplace(Func<float, ulong, float> map);
        T MapAggregate<T>(Func<float, ulong, T> map, Func<T, T, T> aggregate);
        float RealDotProduct(DataVector32 vector);
        RealStatistics32 RealStatistics();
        RealStatistics32[] RealStatisticsSplitted(int length);
        float RealSum();
        float RealSumSquared();
    }

    public interface IComplexVectorOperations32
    {
        DataVector32 Add(float real, float imag);
        DataVector32 Subtract(float real, float imag);
        DataVector32 Multiply(float real, float imag);
        DataVector32 Divide(float real, float imag);
        DataVector32 MapInplace(Func<Complex32, ulong, Complex32> map);
        T MapAggregate<T>(Func<Complex32, ulong, T> map, Func<T, T, T> aggregate);
        DataVector32 /*REAL*/ Magnitude();
        void GetMagnitude(DataVector32 /*REAL*/ destination);
        DataVector32 /*REAL*/ MagnitudeSquared();
        DataVector32 Conj();
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
        
        ComplexStatistics32[] ComplexStatisticsSplitted(int length);
        Complex32 ComplexSum();
        Complex32 ComplexSumSquared();
        DataVector32 Reverse();
        DataVector32 Decimatei(int factor, int delay);
        DataVector32 PrepareArgument();
        DataVector32 PrepareArgumentPadded();
        DataVector32 Correlate(DataVector32 other);
    }

    public interface ITimeDomainVectorOperations32
    {
        DataVector32 /*COMPLEXFREQ*/ PlainFft();

        DataVector32 /*COMPLEXFREQ*/ PlainSfft();

        DataVector32 /*COMPLEXFREQ*/ Fft();

        DataVector32 /*COMPLEXFREQ*/ Sfft();

        DataVector32 ApplyWindow(StandardWindowFunction window);

        DataVector32 ApplyWindow(WindowFunction32 window);

        DataVector32 UnapplyWindow(StandardWindowFunction window);

        DataVector32 UnapplyWindow(WindowFunction32 window);

        DataVector32 /*COMPLEXFREQ*/ Fft(StandardWindowFunction window);

        DataVector32 /*COMPLEXFREQ*/ Fft(WindowFunction32 window);

        DataVector32 /*COMPLEXFREQ*/ Sfft(StandardWindowFunction window);

        DataVector32 /*COMPLEXFREQ*/ Sfft(WindowFunction32 window);

        DataVector32 Convolve(DataVector32 impulseResponse);

        DataVector32 Convolve(StandardImpulseResponse impulseResponse, float rollOff, float ratio, int length);

        DataVector32 Convolve(RealImpulseResponse32 impulseResponse, float ratio, int length);
        
    }

    public interface IComplexTimeVectorOperations32
    {
        DataVector32 Convolve(ComplexImpulseResponse32 impulseResponse, float ratio, int length);
    }

    public interface IFrequencyDomainVectorOperations32
    {
        DataVector32 /*COMPLEXTIME*/ PlainIfft();

        DataVector32 /*COMPLEXTIME*/ Ifft();

        DataVector32 /*REALTIME*/ PlainSifft();

        DataVector32 /*REALTIME*/ Sifft();

        DataVector32 FftShift();

        DataVector32 IfftShift();

        DataVector32 /*COMPLEXTIME*/ Ifft(StandardWindowFunction window);

        DataVector32 /*COMPLEXTIME*/ Ifft(WindowFunction32 window);

        DataVector32 /*REALTIME*/ Sifft(StandardWindowFunction window);

        DataVector32 /*REALTIME*/ Sifft(WindowFunction32 window);

        DataVector32 MultiplyFrequencyResponse(StandardFrequencyResponse frequencyResponse, float rollOff, float ratio);

        DataVector32 MultiplyFrequencyResponse(RealImpulseResponse32 frequencyResponse, float ratio);
        
    }

    public interface IComplexFrequencyVectorOperations32
    {
        DataVector32 MultiplyFrequencyResponse(ComplexImpulseResponse32 frequencyResponse, float ratio);
    }
}