// ReSharper disable UnusedMember.Global

// Some comments in this class are type definitions hints for the code generator Perl scripts
// ReSharper disable UnusedMemberInSuper.Global

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
        DataVector32 /*COMPLEX*/ ToComplex();
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
    }

    public interface ITimeDomainVectorOperations32
    {
        DataVector32 /*COMPLEXFREQ*/ PlainFft();
    }

    public interface IFrequencyDomainVectorOperations32
    {
        DataVector32 /*COMPLEXTIME*/ PlainIfft();
    }
}