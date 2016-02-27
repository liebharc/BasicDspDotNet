// Auto generated code, change DataVector32Native.cs and run create_64bit_impl.pl.pl
 using System.Runtime.InteropServices;

namespace BasicDsp
{
    internal static unsafe class DataVector64Native
    {
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public struct VectorResult64
        {
            public readonly int resultCode;
            public readonly DataVector64Struct* vector;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public struct ScalarResult<T>
        {
            public readonly int resultCode;
            public readonly T vector;
        }

        /// <summary>
        /// This class is a placeholder, use <see cref="DataVector64Native"/> methods to talk to it.
        /// </summary>
        public struct DataVector64Struct
        {         
        }

        private const CallingConvention RustConvention = CallingConvention.Cdecl;

        private const string DllName = "basic_dsp.dll";

        [DllImport(DllName,
            EntryPoint = "new64",
            CallingConvention = RustConvention)]
        public static extern DataVector64Struct* New(int isComplex, int domain, double initValue, ulong length, double delta);

        [DllImport(DllName,
            EntryPoint = "get_value64",
            CallingConvention = RustConvention)]
        public static extern double GetValue(DataVector64Struct* vector, ulong index);

        [DllImport(DllName,
            EntryPoint = "set_value64",
            CallingConvention = RustConvention)]
        public static extern void SetValue(DataVector64Struct* vector, ulong index, double value);

        [DllImport(DllName,
            EntryPoint = "delete_vector64",
            CallingConvention = RustConvention)]
        public static extern void DeleteVector(DataVector64Struct* vector);

        [DllImport(DllName,
            EntryPoint = "is_complex64",
            CallingConvention = RustConvention)]
        public static extern int IsComplex(DataVector64Struct* vector);

        [DllImport(DllName,
            EntryPoint = "get_domain64",
            CallingConvention = RustConvention)]
        public static extern int GetDomain(DataVector64Struct* vector);

        [DllImport(DllName,
            EntryPoint = "get_len64",
            CallingConvention = RustConvention)]
        public static extern ulong GetLength(DataVector64Struct* vector);

        [DllImport(DllName,
            EntryPoint = "get_points64",
            CallingConvention = RustConvention)]
        public static extern ulong GetPoints(DataVector64Struct* vector);

        [DllImport(DllName,
              EntryPoint = "get_delta64",
              CallingConvention = RustConvention)]
        public static extern double Delta(DataVector64Struct* vector);

        [DllImport(DllName,
            EntryPoint = "get_allocated_len64",
            CallingConvention = RustConvention)]
        public static extern ulong GetAllocatedLength(DataVector64Struct* vector);

        [DllImport(DllName,
            EntryPoint = "add_vector64",
            CallingConvention = RustConvention)]
        public static extern VectorResult64 AddVector(DataVector64Struct* vector, DataVector64Struct* operand);

        [DllImport(DllName,
            EntryPoint = "subtract_vector64",
            CallingConvention = RustConvention)]
        public static extern VectorResult64 SubtractVector(DataVector64Struct* vector, DataVector64Struct* operand);

        [DllImport(DllName,
            EntryPoint = "multiply_vector64",
            CallingConvention = RustConvention)]
        public static extern VectorResult64 MultiplyVector(DataVector64Struct* vector, DataVector64Struct* operand);

        [DllImport(DllName,
            EntryPoint = "divide_vector64",
            CallingConvention = RustConvention)]
        public static extern VectorResult64 DivideVector(DataVector64Struct* vector, DataVector64Struct* operand);

        [DllImport(DllName,
            EntryPoint = "zero_pad64",
            CallingConvention = RustConvention)]
        public static extern VectorResult64 ZeroPad(DataVector64Struct* vector, ulong points, int paddingOption);

        [DllImport(DllName,
            EntryPoint = "zero_interleave64",
            CallingConvention = RustConvention)]
        public static extern VectorResult64 ZeroInterleave(DataVector64Struct* vector, int factor);

        [DllImport(DllName,
            EntryPoint = "diff64",
            CallingConvention = RustConvention)]
        public static extern VectorResult64 Diff(DataVector64Struct* vector);

        [DllImport(DllName,
            EntryPoint = "diff_with_start64",
            CallingConvention = RustConvention)]
        public static extern VectorResult64 DiffWithStart(DataVector64Struct* vector);

        [DllImport(DllName,
            EntryPoint = "cum_sum64",
            CallingConvention = RustConvention)]
        public static extern VectorResult64 CumSum(DataVector64Struct* vector);

        [DllImport(DllName,
            EntryPoint = "real_offset64",
            CallingConvention = RustConvention)]
        public static extern VectorResult64 RealOffset(DataVector64Struct* vector, double value);

        [DllImport(DllName,
            EntryPoint = "real_scale64",
            CallingConvention = RustConvention)]
        public static extern VectorResult64 RealScale(DataVector64Struct* vector, double value);

        [DllImport(DllName,
            EntryPoint = "abs64",
            CallingConvention = RustConvention)]
        public static extern VectorResult64 RealAbs(DataVector64Struct* vector);

        [DllImport(DllName,
            EntryPoint = "sqrt64",
            CallingConvention = RustConvention)]
        public static extern VectorResult64 Sqrt(DataVector64Struct* vector);

        [DllImport(DllName,
            EntryPoint = "square64",
            CallingConvention = RustConvention)]
        public static extern VectorResult64 Square(DataVector64Struct* vector);

        [DllImport(DllName,
            EntryPoint = "root64",
            CallingConvention = RustConvention)]
        public static extern VectorResult64 Root(DataVector64Struct* vector, double value);

        [DllImport(DllName,
            EntryPoint = "power64",
            CallingConvention = RustConvention)]
        public static extern VectorResult64 Power(DataVector64Struct* vector, double value);

        [DllImport(DllName,
            EntryPoint = "logn64",
            CallingConvention = RustConvention)]
        public static extern VectorResult64 Logn(DataVector64Struct* vector);

        [DllImport(DllName,
            EntryPoint = "expn64",
            CallingConvention = RustConvention)]
        public static extern VectorResult64 Expn(DataVector64Struct* vector);

        [DllImport(DllName,
            EntryPoint = "log_base64",
            CallingConvention = RustConvention)]
        public static extern VectorResult64 Log(DataVector64Struct* vector, double value);

        [DllImport(DllName,
            EntryPoint = "exp_base64",
            CallingConvention = RustConvention)]
        public static extern VectorResult64 Exp(DataVector64Struct* vector, double value);

        [DllImport(DllName,
            EntryPoint = "to_complex64",
            CallingConvention = RustConvention)]
        public static extern VectorResult64 ToComplex(DataVector64Struct* vector);

        [DllImport(DllName,
            EntryPoint = "sin64",
            CallingConvention = RustConvention)]
        public static extern VectorResult64 Sin(DataVector64Struct* vector);

        [DllImport(DllName,
            EntryPoint = "cos64",
            CallingConvention = RustConvention)]
        public static extern VectorResult64 Cos(DataVector64Struct* vector);

        [DllImport(DllName,
              EntryPoint = "swap_halves64",
              CallingConvention = RustConvention)]
        public static extern VectorResult64 SwapHalves(DataVector64Struct* vector);

        [DllImport(DllName,
            EntryPoint = "wrap64",
            CallingConvention = RustConvention)]
        public static extern VectorResult64 Wrap(DataVector64Struct* vector, double value);

        [DllImport(DllName,
            EntryPoint = "unwrap64",
            CallingConvention = RustConvention)]
        public static extern VectorResult64 Unwrap(DataVector64Struct* vector, double value);

        [DllImport(DllName,
            EntryPoint = "complex_offset64",
            CallingConvention = RustConvention)]
        public static extern VectorResult64 ComplexOffset(DataVector64Struct* vector, double real, double imag);

        [DllImport(DllName,
            EntryPoint = "complex_scale64",
            CallingConvention = RustConvention)]
        public static extern VectorResult64 ComplexScale(DataVector64Struct* vector, double real, double imag);

        [DllImport(DllName,
            EntryPoint = "complex_divide64",
            CallingConvention = RustConvention)]
        public static extern VectorResult64 ComplexDivide(DataVector64Struct* vector, double real, double imag);

        [DllImport(DllName,
            EntryPoint = "magnitude64",
            CallingConvention = RustConvention)]
        public static extern VectorResult64 ComplexAbs(DataVector64Struct* vector);

        [DllImport(DllName,
            EntryPoint = "get_magnitude64",
            CallingConvention = RustConvention)]
        public static extern int GetComplexAbs(DataVector64Struct* vector, DataVector64Struct* destination);

        [DllImport(DllName,
            EntryPoint = "magnitude_squared64",
            CallingConvention = RustConvention)]
        public static extern VectorResult64 ComplexAbsSquared(DataVector64Struct* vector);

        [DllImport(DllName,
            EntryPoint = "complex_conj64",
            CallingConvention = RustConvention)]
        public static extern VectorResult64 ComplexConj(DataVector64Struct* vector);

        [DllImport(DllName,
            EntryPoint = "to_real64",
            CallingConvention = RustConvention)]
        public static extern VectorResult64 ToReal(DataVector64Struct* vector);

        [DllImport(DllName,
            EntryPoint = "to_imag64",
            CallingConvention = RustConvention)]
        public static extern VectorResult64 ToImag(DataVector64Struct* vector);

        [DllImport(DllName,
            EntryPoint = "get_real64",
            CallingConvention = RustConvention)]
        public static extern int GetReal(DataVector64Struct* vector, DataVector64Struct* destination);

        [DllImport(DllName,
            EntryPoint = "get_imag64",
            CallingConvention = RustConvention)]
        public static extern int GetImag(DataVector64Struct* vector, DataVector64Struct* destination);

        [DllImport(DllName,
            EntryPoint = "phase64",
            CallingConvention = RustConvention)]
        public static extern VectorResult64 Phase(DataVector64Struct* vector);

        [DllImport(DllName,
            EntryPoint = "get_phase64",
            CallingConvention = RustConvention)]
        public static extern int GetPhase(DataVector64Struct* vector, DataVector64Struct* destination);

        [DllImport(DllName,
            EntryPoint = "plain_fft64",
            CallingConvention = RustConvention)]
        public static extern VectorResult64 PlainFft(DataVector64Struct* vector);

        [DllImport(DllName,
            EntryPoint = "plain_ifft64",
            CallingConvention = RustConvention)]
        public static extern VectorResult64 PlainIfft(DataVector64Struct* vector);

        [DllImport(DllName,
           EntryPoint = "real_dot_product64",
           CallingConvention = RustConvention)]
        public static extern ScalarResult<double> RealDotProduct(DataVector64Struct* vector, DataVector64Struct* operand);
    }
}
