using System.Runtime.InteropServices;

namespace BasicDsp
{
    internal static unsafe class DataVector32Native
    {
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public struct VectorResult32
        {
            public readonly int resultCode;
            public readonly DataVector32Struct* vector;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public struct ScalarResult<T>
        {
            public readonly int resultCode;
            public readonly T vector;
        }

        /// <summary>
        /// This class is a placeholder, use <see cref="DataVector32Native"/> methods to talk to it.
        /// </summary>
        public struct DataVector32Struct
        {         
        }

        private const CallingConvention RustConvention = CallingConvention.Cdecl;

        private const string DllName = "basic_dsp.dll";

        [DllImport(DllName,
            EntryPoint = "new32",
            CallingConvention = RustConvention)]
        public static extern DataVector32Struct* New(int isComplex, int domain, float initValue, ulong length, float delta);

        [DllImport(DllName,
            EntryPoint = "get_value32",
            CallingConvention = RustConvention)]
        public static extern float GetValue(DataVector32Struct* vector, ulong index);

        [DllImport(DllName,
            EntryPoint = "set_value32",
            CallingConvention = RustConvention)]
        public static extern void SetValue(DataVector32Struct* vector, ulong index, float value);

        [DllImport(DllName,
            EntryPoint = "delete_vector32",
            CallingConvention = RustConvention)]
        public static extern void DeleteVector(DataVector32Struct* vector);

        [DllImport(DllName,
            EntryPoint = "is_complex32",
            CallingConvention = RustConvention)]
        public static extern int IsComplex(DataVector32Struct* vector);

        [DllImport(DllName,
            EntryPoint = "get_domain32",
            CallingConvention = RustConvention)]
        public static extern int GetDomain(DataVector32Struct* vector);

        [DllImport(DllName,
            EntryPoint = "get_len32",
            CallingConvention = RustConvention)]
        public static extern ulong GetLength(DataVector32Struct* vector);

        [DllImport(DllName,
            EntryPoint = "get_points32",
            CallingConvention = RustConvention)]
        public static extern ulong GetPoints(DataVector32Struct* vector);

        [DllImport(DllName,
              EntryPoint = "get_delta32",
              CallingConvention = RustConvention)]
        public static extern float Delta(DataVector32Struct* vector);

        [DllImport(DllName,
            EntryPoint = "get_allocated_len32",
            CallingConvention = RustConvention)]
        public static extern ulong GetAllocatedLength(DataVector32Struct* vector);

        [DllImport(DllName,
            EntryPoint = "add_vector32",
            CallingConvention = RustConvention)]
        public static extern VectorResult32 AddVector(DataVector32Struct* vector, DataVector32Struct* operand);

        [DllImport(DllName,
            EntryPoint = "subtract_vector32",
            CallingConvention = RustConvention)]
        public static extern VectorResult32 SubtractVector(DataVector32Struct* vector, DataVector32Struct* operand);

        [DllImport(DllName,
            EntryPoint = "multiply_vector32",
            CallingConvention = RustConvention)]
        public static extern VectorResult32 MultiplyVector(DataVector32Struct* vector, DataVector32Struct* operand);

        [DllImport(DllName,
            EntryPoint = "divide_vector32",
            CallingConvention = RustConvention)]
        public static extern VectorResult32 DivideVector(DataVector32Struct* vector, DataVector32Struct* operand);

        [DllImport(DllName,
            EntryPoint = "zero_pad32",
            CallingConvention = RustConvention)]
        public static extern VectorResult32 ZeroPad(DataVector32Struct* vector, ulong points, int paddingOption);

        [DllImport(DllName,
            EntryPoint = "zero_interleave32",
            CallingConvention = RustConvention)]
        public static extern VectorResult32 ZeroInterleave(DataVector32Struct* vector, int factor);

        [DllImport(DllName,
            EntryPoint = "diff32",
            CallingConvention = RustConvention)]
        public static extern VectorResult32 Diff(DataVector32Struct* vector);

        [DllImport(DllName,
            EntryPoint = "diff_with_start32",
            CallingConvention = RustConvention)]
        public static extern VectorResult32 DiffWithStart(DataVector32Struct* vector);

        [DllImport(DllName,
            EntryPoint = "cum_sum32",
            CallingConvention = RustConvention)]
        public static extern VectorResult32 CumSum(DataVector32Struct* vector);

        [DllImport(DllName,
            EntryPoint = "real_offset32",
            CallingConvention = RustConvention)]
        public static extern VectorResult32 RealOffset(DataVector32Struct* vector, float value);

        [DllImport(DllName,
            EntryPoint = "real_scale32",
            CallingConvention = RustConvention)]
        public static extern VectorResult32 RealScale(DataVector32Struct* vector, float value);

        [DllImport(DllName,
            EntryPoint = "abs32",
            CallingConvention = RustConvention)]
        public static extern VectorResult32 RealAbs(DataVector32Struct* vector);

        [DllImport(DllName,
            EntryPoint = "sqrt32",
            CallingConvention = RustConvention)]
        public static extern VectorResult32 Sqrt(DataVector32Struct* vector);

        [DllImport(DllName,
            EntryPoint = "square32",
            CallingConvention = RustConvention)]
        public static extern VectorResult32 Square(DataVector32Struct* vector);

        [DllImport(DllName,
            EntryPoint = "root32",
            CallingConvention = RustConvention)]
        public static extern VectorResult32 Root(DataVector32Struct* vector, float value);

        [DllImport(DllName,
            EntryPoint = "power32",
            CallingConvention = RustConvention)]
        public static extern VectorResult32 Power(DataVector32Struct* vector, float value);

        [DllImport(DllName,
            EntryPoint = "logn32",
            CallingConvention = RustConvention)]
        public static extern VectorResult32 Logn(DataVector32Struct* vector);

        [DllImport(DllName,
            EntryPoint = "expn32",
            CallingConvention = RustConvention)]
        public static extern VectorResult32 Expn(DataVector32Struct* vector);

        [DllImport(DllName,
            EntryPoint = "log_base32",
            CallingConvention = RustConvention)]
        public static extern VectorResult32 Log(DataVector32Struct* vector, float value);

        [DllImport(DllName,
            EntryPoint = "exp_base32",
            CallingConvention = RustConvention)]
        public static extern VectorResult32 Exp(DataVector32Struct* vector, float value);

        [DllImport(DllName,
            EntryPoint = "to_complex32",
            CallingConvention = RustConvention)]
        public static extern VectorResult32 ToComplex(DataVector32Struct* vector);

        [DllImport(DllName,
            EntryPoint = "sin32",
            CallingConvention = RustConvention)]
        public static extern VectorResult32 Sin(DataVector32Struct* vector);

        [DllImport(DllName,
            EntryPoint = "cos32",
            CallingConvention = RustConvention)]
        public static extern VectorResult32 Cos(DataVector32Struct* vector);

        [DllImport(DllName,
              EntryPoint = "swap_halves32",
              CallingConvention = RustConvention)]
        public static extern VectorResult32 SwapHalves(DataVector32Struct* vector);

        [DllImport(DllName,
            EntryPoint = "wrap32",
            CallingConvention = RustConvention)]
        public static extern VectorResult32 Wrap(DataVector32Struct* vector, float value);

        [DllImport(DllName,
            EntryPoint = "unwrap32",
            CallingConvention = RustConvention)]
        public static extern VectorResult32 Unwrap(DataVector32Struct* vector, float value);

        [DllImport(DllName,
            EntryPoint = "complex_offset32",
            CallingConvention = RustConvention)]
        public static extern VectorResult32 ComplexOffset(DataVector32Struct* vector, float real, float imag);

        [DllImport(DllName,
            EntryPoint = "complex_scale32",
            CallingConvention = RustConvention)]
        public static extern VectorResult32 ComplexScale(DataVector32Struct* vector, float real, float imag);

        [DllImport(DllName,
            EntryPoint = "complex_divide32",
            CallingConvention = RustConvention)]
        public static extern VectorResult32 ComplexDivide(DataVector32Struct* vector, float real, float imag);

        [DllImport(DllName,
            EntryPoint = "magnitude32",
            CallingConvention = RustConvention)]
        public static extern VectorResult32 ComplexAbs(DataVector32Struct* vector);

        [DllImport(DllName,
            EntryPoint = "get_magnitude32",
            CallingConvention = RustConvention)]
        public static extern int GetComplexAbs(DataVector32Struct* vector, DataVector32Struct* destination);

        [DllImport(DllName,
            EntryPoint = "magnitude_squared32",
            CallingConvention = RustConvention)]
        public static extern VectorResult32 ComplexAbsSquared(DataVector32Struct* vector);

        [DllImport(DllName,
            EntryPoint = "complex_conj32",
            CallingConvention = RustConvention)]
        public static extern VectorResult32 ComplexConj(DataVector32Struct* vector);

        [DllImport(DllName,
            EntryPoint = "to_real32",
            CallingConvention = RustConvention)]
        public static extern VectorResult32 ToReal(DataVector32Struct* vector);

        [DllImport(DllName,
            EntryPoint = "to_imag32",
            CallingConvention = RustConvention)]
        public static extern VectorResult32 ToImag(DataVector32Struct* vector);

        [DllImport(DllName,
            EntryPoint = "get_real32",
            CallingConvention = RustConvention)]
        public static extern int GetReal(DataVector32Struct* vector, DataVector32Struct* destination);

        [DllImport(DllName,
            EntryPoint = "get_imag32",
            CallingConvention = RustConvention)]
        public static extern int GetImag(DataVector32Struct* vector, DataVector32Struct* destination);

        [DllImport(DllName,
            EntryPoint = "phase32",
            CallingConvention = RustConvention)]
        public static extern VectorResult32 Phase(DataVector32Struct* vector);

        [DllImport(DllName,
            EntryPoint = "get_phase32",
            CallingConvention = RustConvention)]
        public static extern int GetPhase(DataVector32Struct* vector, DataVector32Struct* destination);

        [DllImport(DllName,
            EntryPoint = "plain_fft32",
            CallingConvention = RustConvention)]
        public static extern VectorResult32 PlainFft(DataVector32Struct* vector);

        [DllImport(DllName,
            EntryPoint = "plain_ifft32",
            CallingConvention = RustConvention)]
        public static extern VectorResult32 PlainIfft(DataVector32Struct* vector);

        [DllImport(DllName,
           EntryPoint = "real_dot_product32",
           CallingConvention = RustConvention)]
        public static extern ScalarResult<float> RealDotProduct(DataVector32Struct* vector, DataVector32Struct* operand);
    }
}