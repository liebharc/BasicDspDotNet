using System;
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
        public struct BinaryVectorResult32
        {
            public readonly int resultCode;
            public readonly DataVector32Struct* vector1;
            public readonly DataVector32Struct* vector2;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public struct FloatResult
        {
            public readonly int resultCode;
            public readonly float result;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public struct ComplexResult
        {
            public readonly int resultCode;
            public readonly Complex32 result;
        }

        /// <summary>
        /// This class is a placeholder, use <see cref="DataVector32Native"/> methods to talk to it.
        /// </summary>
        public struct DataVector32Struct
        {
        }

        /// <summary>
        /// This class is a placeholder, use <see cref="DataVector32Native"/> methods to talk to it.
        /// </summary>
        public struct PreparedOps1F32Struct
        {
        }

        /// <summary>
        /// This class is a placeholder, use <see cref="DataVector32Native"/> methods to talk to it.
        /// </summary>
        public struct PreparedOps2F32Struct
        {
        }

        private const CallingConvention RustConvention = CallingConvention.Cdecl;

        private const string DllName = "basic_dsp.dll";

        [DllImport(DllName,
            EntryPoint = "new32",
            CallingConvention = RustConvention)]
        public static extern DataVector32Struct* New(int isComplex, int domain, float initValue, ulong length, float delta);

        [DllImport(DllName,
            EntryPoint = "new_with_performance_options32",
            CallingConvention = RustConvention)]
        public static extern DataVector32Struct* New(int isComplex, int domain, float initValue, ulong length, float delta, ulong coreLimit, bool earlyTempAllocation);

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
            EntryPoint = "add_smaller_vector32",
            CallingConvention = RustConvention)]
        public static extern VectorResult32 AddSmallerVector(DataVector32Struct* vector, DataVector32Struct* operand);

        [DllImport(DllName,
            EntryPoint = "subtract_smaller_vector32",
            CallingConvention = RustConvention)]
        public static extern VectorResult32 SubtractSmallerVector(DataVector32Struct* vector, DataVector32Struct* operand);

        [DllImport(DllName,
            EntryPoint = "multiply_smaller_vector32",
            CallingConvention = RustConvention)]
        public static extern VectorResult32 MultiplySmallerVector(DataVector32Struct* vector, DataVector32Struct* operand);

        [DllImport(DllName,
            EntryPoint = "divide_smaller_vector32",
            CallingConvention = RustConvention)]
        public static extern VectorResult32 DivideSmallerVector(DataVector32Struct* vector, DataVector32Struct* operand);

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
            EntryPoint = "powf32",
            CallingConvention = RustConvention)]
        public static extern VectorResult32 Powf(DataVector32Struct* vector, float value);

        [DllImport(DllName,
            EntryPoint = "ln32",
            CallingConvention = RustConvention)]
        public static extern VectorResult32 Ln(DataVector32Struct* vector);

        [DllImport(DllName,
            EntryPoint = "exp32",
            CallingConvention = RustConvention)]
        public static extern VectorResult32 Expf(DataVector32Struct* vector);

        [DllImport(DllName,
            EntryPoint = "log32",
            CallingConvention = RustConvention)]
        public static extern VectorResult32 Log(DataVector32Struct* vector, float value);

        [DllImport(DllName,
            EntryPoint = "expf32",
            CallingConvention = RustConvention)]
        public static extern VectorResult32 Expf(DataVector32Struct* vector, float value);

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
            EntryPoint = "conj32",
            CallingConvention = RustConvention)]
        public static extern VectorResult32 Complex(DataVector32Struct* vector);

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
            EntryPoint = "fft32",
            CallingConvention = RustConvention)]
        public static extern VectorResult32 FFt(DataVector32Struct* vector);

        [DllImport(DllName,
            EntryPoint = "sfft32",
            CallingConvention = RustConvention)]
        public static extern VectorResult32 SFft(DataVector32Struct* vector);

        [DllImport(DllName,
            EntryPoint = "ifft32",
            CallingConvention = RustConvention)]
        public static extern VectorResult32 IFft(DataVector32Struct* vector);

        [DllImport(DllName,
            EntryPoint = "plain_sifft32",
            CallingConvention = RustConvention)]
        public static extern VectorResult32 PlainSifft(DataVector32Struct* vector);

        [DllImport(DllName,
            EntryPoint = "sifft32",
            CallingConvention = RustConvention)]
        public static extern VectorResult32 Sifft(DataVector32Struct* vector);

        [DllImport(DllName,
            EntryPoint = "mirror32",
            CallingConvention = RustConvention)]
        public static extern VectorResult32 Mirror(DataVector32Struct* vector);

        [DllImport(DllName,
            EntryPoint = "fft_shift32",
            CallingConvention = RustConvention)]
        public static extern VectorResult32 FftShift(DataVector32Struct* vector);

        [DllImport(DllName,
            EntryPoint = "ifft_shift32",
            CallingConvention = RustConvention)]
        public static extern VectorResult32 IFftShift(DataVector32Struct* vector);

        [DllImport(DllName,
            EntryPoint = "real_dot_product32",
            CallingConvention = RustConvention)]
        public static extern FloatResult RealDotProduct(DataVector32Struct* vector, DataVector32Struct* operand);

        [DllImport(DllName,
            EntryPoint = "complex_dot_product32",
            CallingConvention = RustConvention)]
        public static extern ComplexResult ComplexDotProduct(DataVector32Struct* vector, DataVector32Struct* operand);

        [DllImport(DllName,
            EntryPoint = "real_statistics32",
            CallingConvention = RustConvention)]
        public static extern RealStatistics32 RealStatistics(DataVector32Struct* vector);

        [DllImport(DllName,
            EntryPoint = "complex_statistics32",
            CallingConvention = RustConvention)]
        public static extern ComplexStatistics32 ComplexStatistics(DataVector32Struct* vector);

        [DllImport(DllName,
            EntryPoint = "tan32",
            CallingConvention = RustConvention)]
        public static extern VectorResult32 Tan(DataVector32Struct* vector);

        [DllImport(DllName,
            EntryPoint = "asin32",
            CallingConvention = RustConvention)]
        public static extern VectorResult32 ASin(DataVector32Struct* vector);

        [DllImport(DllName,
            EntryPoint = "acos32",
            CallingConvention = RustConvention)]
        public static extern VectorResult32 ACos(DataVector32Struct* vector);

        [DllImport(DllName,
            EntryPoint = "atan32",
            CallingConvention = RustConvention)]
        public static extern VectorResult32 ATan(DataVector32Struct* vector);
        [DllImport(DllName,
            EntryPoint = "sinh32",
            CallingConvention = RustConvention)]
        public static extern VectorResult32 Sinh(DataVector32Struct* vector);

        [DllImport(DllName,
            EntryPoint = "cosh32",
            CallingConvention = RustConvention)]
        public static extern VectorResult32 Cosh(DataVector32Struct* vector);

        [DllImport(DllName,
            EntryPoint = "tanh32",
            CallingConvention = RustConvention)]
        public static extern VectorResult32 Tanh(DataVector32Struct* vector);

        [DllImport(DllName,
            EntryPoint = "asinh32",
            CallingConvention = RustConvention)]
        public static extern VectorResult32 ASinh(DataVector32Struct* vector);

        [DllImport(DllName,
            EntryPoint = "acosh32",
            CallingConvention = RustConvention)]
        public static extern VectorResult32 ACosh(DataVector32Struct* vector);

        [DllImport(DllName,
            EntryPoint = "atanh32",
            CallingConvention = RustConvention)]
        public static extern VectorResult32 ATanh(DataVector32Struct* vector);

        [DllImport(DllName,
            EntryPoint = "plain_sfft32",
            CallingConvention = RustConvention)]
        public static extern VectorResult32 PlainSfft(DataVector32Struct* vector);

        [DllImport(DllName,
            EntryPoint = "clone32",
            CallingConvention = RustConvention)]
        public static extern DataVector32Struct* Clone(DataVector32Struct* vector);

        [DllImport(DllName,
            EntryPoint = "multiply_complex_exponential32",
            CallingConvention = RustConvention)]
        public static extern VectorResult32 MultiplyComplexExponential(DataVector32Struct* vector, float a, float b);

        [DllImport(DllName,
            EntryPoint = "get_real_imag32",
            CallingConvention = RustConvention)]
        public static extern int GetRealImag(DataVector32Struct* vector, DataVector32Struct* dest1, DataVector32Struct* dest2);

        [DllImport(DllName,
            EntryPoint = "get_mag_phase32",
            CallingConvention = RustConvention)]
        public static extern int GetMagPhase(DataVector32Struct* vector, DataVector32Struct* dest1, DataVector32Struct* dest2);

        [DllImport(DllName,
            EntryPoint = "set_real_imag32",
            CallingConvention = RustConvention)]
        public static extern VectorResult32 SetRealImag(DataVector32Struct* vector, DataVector32Struct* src1, DataVector32Struct* src2);

        [DllImport(DllName,
            EntryPoint = "set_mag_phase32",
            CallingConvention = RustConvention)]
        public static extern VectorResult32 SetMagPhase(DataVector32Struct* vector, DataVector32Struct* src1, DataVector32Struct* src2);

        [DllImport(DllName,
            EntryPoint = "split_into32",
            CallingConvention = RustConvention)]
        public static extern int SplitInto(DataVector32Struct* vector, IntPtr targets, ulong len);

        [DllImport(DllName,
            EntryPoint = "merge32",
            CallingConvention = RustConvention)]
        public static extern VectorResult32 Merge(DataVector32Struct* vector, IntPtr sources, ulong len);

        [DllImport(DllName,
            EntryPoint = "override_data32",
            CallingConvention = RustConvention)]
        public static extern VectorResult32 OverrideData(DataVector32Struct* vector, IntPtr data, ulong len);

        [DllImport(DllName,
            EntryPoint = "set_len32",
            CallingConvention = RustConvention)]
        public static extern VectorResult32 SetLen(DataVector32Struct* vector, ulong len);

        [DllImport(DllName,
            EntryPoint = "real_statistics_splitted32",
            CallingConvention = RustConvention)]
        public static extern int RealStatisticsSplitted(DataVector32Struct* vector, IntPtr targets, ulong len);

        [DllImport(DllName,
            EntryPoint = "complex_statistics_splitted32",
            CallingConvention = RustConvention)]
        public static extern int ComplexStatisticsSplitted(DataVector32Struct* vector, IntPtr targets, ulong len);

        [DllImport(DllName,
            EntryPoint = "reverse32",
            CallingConvention = RustConvention)]
        public static extern VectorResult32 Reverse(DataVector32Struct* vector);

        [DllImport(DllName,
           EntryPoint = "decimatei32",
           CallingConvention = RustConvention)]
        public static extern VectorResult32 Decimatei(DataVector32Struct* vector, uint factor, uint delay);

        public delegate float CustomWindow(object data, ulong n, ulong length);

        [DllImport(DllName,
           EntryPoint = "apply_window32",
           CallingConvention = RustConvention)]
        public static extern VectorResult32 ApplyWindow(DataVector32Struct* vector, int window);

        [DllImport(DllName,
           EntryPoint = "unapply_window32",
           CallingConvention = RustConvention)]
        public static extern VectorResult32 UnapplyWindow(DataVector32Struct* vector, int window);

        [DllImport(DllName,
           EntryPoint = "windowed_fft32",
           CallingConvention = RustConvention)]
        public static extern VectorResult32 WindowedFft(DataVector32Struct* vector, int window);

        [DllImport(DllName,
           EntryPoint = "windowed_sfft32",
           CallingConvention = RustConvention)]
        public static extern VectorResult32 WindowedSfft(DataVector32Struct* vector, int window);

        [DllImport(DllName,
           EntryPoint = "windowed_ifft32",
           CallingConvention = RustConvention)]
        public static extern VectorResult32 WindowedIfft(DataVector32Struct* vector, int window);

        [DllImport(DllName,
           EntryPoint = "windowed_sifft32",
           CallingConvention = RustConvention)]
        public static extern VectorResult32 WindowedSifft(DataVector32Struct* vector, int window);

        [DllImport(DllName,
           EntryPoint = "apply_custom_window32",
           CallingConvention = RustConvention)]
        public static extern VectorResult32 ApplyCustomWindow(DataVector32Struct* vector, CustomWindow window, object data, bool isSymmetric);

        [DllImport(DllName,
           EntryPoint = "unapply_custom_window32",
           CallingConvention = RustConvention)]
        public static extern VectorResult32 UnpplyCustomWindow(DataVector32Struct* vector, CustomWindow window, object data, bool isSymmetric);

        [DllImport(DllName,
            EntryPoint = "windowed_custom_fft32",
            CallingConvention = RustConvention)]
        public static extern VectorResult32 WindowedCustomFft(DataVector32Struct* vector, CustomWindow window, object data, bool isSymmetric);

            [DllImport(DllName,
           EntryPoint = "windowed_custom_sfft32",
           CallingConvention = RustConvention)]
        public static extern VectorResult32 WindowedCustomSfft(DataVector32Struct* vector, CustomWindow window, object data, bool isSymmetric);

        [DllImport(DllName,
           EntryPoint = "windowed_custom_ifft32",
           CallingConvention = RustConvention)]
        public static extern VectorResult32 WindowedCustomIfft(DataVector32Struct* vector, CustomWindow window, object data, bool isSymmetric);

        [DllImport(DllName,
           EntryPoint = "windowed_custom_sifft32",
           CallingConvention = RustConvention)]
        public static extern VectorResult32 WindowedCustomSifft(DataVector32Struct* vector, CustomWindow window, object data, bool isSymmetric);

        [DllImport(DllName,
           EntryPoint = "prepare_argument32",
           CallingConvention = RustConvention)]
        public static extern VectorResult32 PrepareArgument(DataVector32Struct* vector);

        [DllImport(DllName,
           EntryPoint = "prepare_argument_padded32",
           CallingConvention = RustConvention)]
        public static extern VectorResult32 PrepareArgumentPadded(DataVector32Struct* vector);

        [DllImport(DllName,
           EntryPoint = "correlate32",
           CallingConvention = RustConvention)]
        public static extern VectorResult32 Correlate(DataVector32Struct* vector, DataVector32Struct* other);

        [DllImport(DllName,
           EntryPoint = "convolve_vector32",
           CallingConvention = RustConvention)]
        public static extern VectorResult32 ConvolveVector(DataVector32Struct* vector, DataVector32Struct* other);

        [DllImport(DllName,
           EntryPoint = "convolve32",
           CallingConvention = RustConvention)]
        public static extern VectorResult32 ConvolveFunction(DataVector32Struct* vector, int impulseResponse, float rollOff, float ratio, ulong length);

        [DllImport(DllName,
           EntryPoint = "multiply_frequency_response32",
           CallingConvention = RustConvention)]
        public static extern VectorResult32 MultiplyFrequencyResponse(DataVector32Struct* vector, int frequencyResponse, float rollOff, float ratio);

        public delegate float RealConfOrFreqFunction(object data, float x);

        [DllImport(DllName,
           EntryPoint = "convolve_real32",
           CallingConvention = RustConvention)]
        public static extern VectorResult32 ConvolveRealFunction(DataVector32Struct* vector, RealConfOrFreqFunction window, object data, bool isSymmetric, float ratio, ulong length);

        [DllImport(DllName,
           EntryPoint = "multiply_frequency_response_real32",
           CallingConvention = RustConvention)]
        public static extern VectorResult32 MultiplyRealFrequencyResponse(DataVector32Struct* vector, RealConfOrFreqFunction window, object data, bool isSymmetric, float ratio);

        public delegate Complex32 ComplexConfOrFreqFunction(object data, float x);

        [DllImport(DllName,
           EntryPoint = "convolve_complex32",
           CallingConvention = RustConvention)]
        public static extern VectorResult32 ConvolveComplexFunction(DataVector32Struct* vector, ComplexConfOrFreqFunction window, object data, bool isSymmetric, float ratio, ulong length);

        [DllImport(DllName,
           EntryPoint = "multiply_frequency_response_complex32",
           CallingConvention = RustConvention)]
        public static extern VectorResult32 MultiplyComplexFrequencyResponse(DataVector32Struct* vector, ComplexConfOrFreqFunction window, object data, bool isSymmetric, float ratio);

        [DllImport(DllName,
            EntryPoint = "interpolatef_custom32",
            CallingConvention = RustConvention)]
        public static extern VectorResult32 Interpolatef(DataVector32Struct* vector, RealConfOrFreqFunction function, object data, bool isSymmetric, float interpolationFactor, float delay, ulong length);

        [DllImport(DllName,
            EntryPoint = "interpolatef32",
            CallingConvention = RustConvention)]
        public static extern VectorResult32 Interpolatef(DataVector32Struct* vector, int impulseResponse, float rollOFf, float interpolationFactor, float delay, ulong length);

        [DllImport(DllName,
            EntryPoint = "interpolatei_custom32",
            CallingConvention = RustConvention)]
        public static extern VectorResult32 Interpolatei(DataVector32Struct* vector, RealConfOrFreqFunction function, object data, bool isSymmetric, int interpolationFactor);

        [DllImport(DllName,
            EntryPoint = "interpolatei32",
            CallingConvention = RustConvention)]
        public static extern VectorResult32 Interpolatei(DataVector32Struct* vector, int frequencyResponse, float rollOFf, int interpolationFactor);

        [DllImport(DllName,
            EntryPoint = "interpolate_lin32",
            CallingConvention = RustConvention)]
        public static extern VectorResult32 InterpolateLin(DataVector32Struct* vector, float interpolationFactor, float delay);

        [DllImport(DllName,
            EntryPoint = "interpolate_hermite32",
            CallingConvention = RustConvention)]
        public static extern VectorResult32 InterpolateHermite(DataVector32Struct* vector, float interpolationFactor, float delay);

        [DllImport(DllName,
            EntryPoint = "extend_prepared_ops1_f32",
            CallingConvention = RustConvention)]
        public static extern PreparedOps2F32Struct* ExtendPrepare1To2(PreparedOps1F32Struct* ops);

        [DllImport(DllName,
            EntryPoint = "prepared_ops1_f32",
            CallingConvention = RustConvention)]
        public static extern PreparedOps1F32Struct* Prepare1();

        [DllImport(DllName,
            EntryPoint = "exec_prepared_ops1_f32",
            CallingConvention = RustConvention)]
        public static extern VectorResult32 Exec(PreparedOps1F32Struct* ops, DataVector32Struct* vector);

        [DllImport(DllName,
            EntryPoint = "delete_ops1_f32",
            CallingConvention = RustConvention)]
        public static extern void DeletePreparedOps(PreparedOps1F32Struct* vector);

        [DllImport(DllName,
            EntryPoint = "prepared_ops2_f32",
            CallingConvention = RustConvention)]
        public static extern PreparedOps2F32Struct* Prepare2();

        [DllImport(DllName,
            EntryPoint = "exec_prepared_ops2_f32",
            CallingConvention = RustConvention)]
        public static extern BinaryVectorResult32 Exec(PreparedOps2F32Struct* ops, DataVector32Struct* vector1, DataVector32Struct* vector2);

        [DllImport(DllName,
            EntryPoint = "delete_ops2_f32",
            CallingConvention = RustConvention)]
        public static extern void DeletePreparedOps(PreparedOps2F32Struct* vector);

        //----------------------------------------------
        // PreparedOp12F32
        //----------------------------------------------
        [DllImport(DllName,
            EntryPoint = "add_real_ops1_f32",
            CallingConvention = RustConvention)]
        public static extern void AddReal(PreparedOps1F32Struct* ops, ulong arg, float value);

        [DllImport(DllName,
            EntryPoint = "multiply_real_ops1_f32",
            CallingConvention = RustConvention)]
        public static extern void MultiplyReal(PreparedOps1F32Struct* ops, ulong arg, float value);

        [DllImport(DllName,
            EntryPoint = "abs_ops1_f32",
            CallingConvention = RustConvention)]
        public static extern void Abs(PreparedOps1F32Struct* ops, ulong arg);

        [DllImport(DllName,
            EntryPoint = "to_complex_ops1_f32",
            CallingConvention = RustConvention)]
        public static extern void ToComplex(PreparedOps1F32Struct* ops, ulong arg);

        [DllImport(DllName,
            EntryPoint = "add_complex_ops1_f32",
            CallingConvention = RustConvention)]
        public static extern void ToComplex(PreparedOps1F32Struct* ops, ulong arg, float value);

        [DllImport(DllName,
            EntryPoint = "multiply_real_ops1_f32",
            CallingConvention = RustConvention)]
        public static extern void AddComplex(PreparedOps1F32Struct* ops, ulong arg, float re, float im);

        [DllImport(DllName,
            EntryPoint = "multiply_complex_ops1_f32",
            CallingConvention = RustConvention)]
        public static extern void MultiplyComplex(PreparedOps1F32Struct* ops, ulong arg, float re, float im);

        [DllImport(DllName,
            EntryPoint = "magnitude_ops1_f32",
            CallingConvention = RustConvention)]
        public static extern void Magnitude(PreparedOps1F32Struct* ops, ulong arg);

        [DllImport(DllName,
            EntryPoint = "magnitude_squared_ops1_f32",
            CallingConvention = RustConvention)]
        public static extern void MagnitudeSquared(PreparedOps1F32Struct* ops, ulong arg);

        [DllImport(DllName,
            EntryPoint = "complex_conj_ops1_f32",
            CallingConvention = RustConvention)]
        public static extern void ComplexConj(PreparedOps1F32Struct* ops, ulong arg);

        [DllImport(DllName,
            EntryPoint = "to_real_ops1_f32",
            CallingConvention = RustConvention)]
        public static extern void ToReal(PreparedOps1F32Struct* ops, ulong arg);

        [DllImport(DllName,
            EntryPoint = "to_imag_ops1_f32",
            CallingConvention = RustConvention)]
        public static extern void ToImag(PreparedOps1F32Struct* ops, ulong arg);

        [DllImport(DllName,
            EntryPoint = "phase_ops1_f32",
            CallingConvention = RustConvention)]
        public static extern void Phase(PreparedOps1F32Struct* ops, ulong arg);

        [DllImport(DllName,
            EntryPoint = "multiply_complex_exponential_ops1_f32",
            CallingConvention = RustConvention)]
        public static extern void MultiplyComplexExponential(PreparedOps1F32Struct* ops, ulong arg, float a, float b);

        [DllImport(DllName,
            EntryPoint = "add_vector_ops1_f32",
            CallingConvention = RustConvention)]
        public static extern void AddVector(PreparedOps1F32Struct* ops, ulong arg, ulong other);

        [DllImport(DllName,
            EntryPoint = "mul_vector_ops1_f32",
            CallingConvention = RustConvention)]
        public static extern void MulVector(PreparedOps1F32Struct* ops, ulong arg, ulong other);

        [DllImport(DllName,
            EntryPoint = "sub_vector_ops1_f32",
            CallingConvention = RustConvention)]
        public static extern void SubVector(PreparedOps1F32Struct* ops, ulong arg, ulong other);

        [DllImport(DllName,
            EntryPoint = "div_vector_ops1_f32",
            CallingConvention = RustConvention)]
        public static extern void DivVector(PreparedOps1F32Struct* ops, ulong arg, ulong other);

        [DllImport(DllName,
            EntryPoint = "square_ops1_f32",
            CallingConvention = RustConvention)]
        public static extern void Square(PreparedOps1F32Struct* ops, ulong arg);

        [DllImport(DllName,
            EntryPoint = "sqrt_ops1_f32",
            CallingConvention = RustConvention)]
        public static extern void Sqrt(PreparedOps1F32Struct* ops, ulong arg);

        [DllImport(DllName,
            EntryPoint = "root_ops1_f32",
            CallingConvention = RustConvention)]
        public static extern void Root(PreparedOps1F32Struct* ops, ulong arg, float value);

        [DllImport(DllName,
            EntryPoint = "powf_ops1_f32",
            CallingConvention = RustConvention)]
        public static extern void Powf(PreparedOps1F32Struct* ops, ulong arg, float value);

        [DllImport(DllName,
            EntryPoint = "ln_ops1_f32",
            CallingConvention = RustConvention)]
        public static extern void Ln(PreparedOps1F32Struct* ops, ulong arg);

        [DllImport(DllName,
            EntryPoint = "exp_ops1_f32",
            CallingConvention = RustConvention)]
        public static extern void Exp(PreparedOps1F32Struct* ops, ulong arg);
        [DllImport(DllName,
            EntryPoint = "log_ops1_f32",
            CallingConvention = RustConvention)]
        public static extern void Log(PreparedOps1F32Struct* ops, ulong arg, float value);
        [DllImport(DllName,
            EntryPoint = "expf_ops1_f32",
            CallingConvention = RustConvention)]
        public static extern void Expf(PreparedOps1F32Struct* ops, ulong arg, float value);

        [DllImport(DllName,
            EntryPoint = "sin_ops1_f32",
            CallingConvention = RustConvention)]
        public static extern void Sin(PreparedOps1F32Struct* ops, ulong arg);

        [DllImport(DllName,
            EntryPoint = "cos_ops1_f32",
            CallingConvention = RustConvention)]
        public static extern void Cos(PreparedOps1F32Struct* ops, ulong arg);

        [DllImport(DllName,
            EntryPoint = "tan_ops1_f32",
            CallingConvention = RustConvention)]
        public static extern void Tan(PreparedOps1F32Struct* ops, ulong arg);

        [DllImport(DllName,
            EntryPoint = "asin_ops1_f32",
            CallingConvention = RustConvention)]
        public static extern void ASin(PreparedOps1F32Struct* ops, ulong arg);

        [DllImport(DllName,
            EntryPoint = "acos_ops1_f32",
            CallingConvention = RustConvention)]
        public static extern void ACos(PreparedOps1F32Struct* ops, ulong arg);

        [DllImport(DllName,
            EntryPoint = "atan_ops1_f32",
            CallingConvention = RustConvention)]
        public static extern void ATan(PreparedOps1F32Struct* ops, ulong arg);

        [DllImport(DllName,
            EntryPoint = "sinh_ops1_f32",
            CallingConvention = RustConvention)]
        public static extern void Sinh(PreparedOps1F32Struct* ops, ulong arg);

        [DllImport(DllName,
            EntryPoint = "cosh_ops1_f32",
            CallingConvention = RustConvention)]
        public static extern void Cosh(PreparedOps1F32Struct* ops, ulong arg);

        [DllImport(DllName,
            EntryPoint = "tanh_ops1_f32",
            CallingConvention = RustConvention)]
        public static extern void Tanh(PreparedOps1F32Struct* ops, ulong arg);

        [DllImport(DllName,
            EntryPoint = "asinh_ops1_f32",
            CallingConvention = RustConvention)]
        public static extern void ASinh(PreparedOps1F32Struct* ops, ulong arg);

        [DllImport(DllName,
            EntryPoint = "acosh_ops1_f32",
            CallingConvention = RustConvention)]
        public static extern void ACosh(PreparedOps1F32Struct* ops, ulong arg);

        [DllImport(DllName,
            EntryPoint = "atanh_ops1_f32",
            CallingConvention = RustConvention)]
        public static extern void ATanh(PreparedOps1F32Struct* ops, ulong arg);

        [DllImport(DllName,
            EntryPoint = "clone_from_ops1_f32",
            CallingConvention = RustConvention)]
        public static extern void CloneFrom(PreparedOps1F32Struct* ops, ulong arg, ulong source);

        [DllImport(DllName,
            EntryPoint = "add_points_ops1_f32",
            CallingConvention = RustConvention)]
        public static extern void AddPoints(PreparedOps1F32Struct* ops, ulong arg);

        [DllImport(DllName,
            EntryPoint = "sub_points_ops1_f32",
            CallingConvention = RustConvention)]
        public static extern void SubPoints(PreparedOps1F32Struct* ops, ulong arg);

        [DllImport(DllName,
            EntryPoint = "mul_points_ops1_f32",
            CallingConvention = RustConvention)]
        public static extern void MulPoints(PreparedOps1F32Struct* ops, ulong arg);

        [DllImport(DllName,
            EntryPoint = "div_points_ops1_f32",
            CallingConvention = RustConvention)]
        public static extern void DivPoints(PreparedOps1F32Struct* ops, ulong arg);

        //----------------------------------------------
        // PreparedOp1F32
        //----------------------------------------------
        [DllImport(DllName,
            EntryPoint = "add_real_ops2_f32",
            CallingConvention = RustConvention)]
        public static extern void AddReal(PreparedOps2F32Struct* ops, ulong arg, float value);

        [DllImport(DllName,
            EntryPoint = "multiply_real_ops2_f32",
            CallingConvention = RustConvention)]
        public static extern void MultiplyReal(PreparedOps2F32Struct* ops, ulong arg, float value);

        [DllImport(DllName,
            EntryPoint = "abs_ops2_f32",
            CallingConvention = RustConvention)]
        public static extern void Abs(PreparedOps2F32Struct* ops, ulong arg);

        [DllImport(DllName,
            EntryPoint = "to_complex_ops2_f32",
            CallingConvention = RustConvention)]
        public static extern void ToComplex(PreparedOps2F32Struct* ops, ulong arg);

        [DllImport(DllName,
            EntryPoint = "add_complex_ops2_f32",
            CallingConvention = RustConvention)]
        public static extern void ToComplex(PreparedOps2F32Struct* ops, ulong arg, float value);

        [DllImport(DllName,
            EntryPoint = "multiply_real_ops2_f32",
            CallingConvention = RustConvention)]
        public static extern void AddComplex(PreparedOps2F32Struct* ops, ulong arg, float re, float im);

        [DllImport(DllName,
            EntryPoint = "multiply_complex_ops2_f32",
            CallingConvention = RustConvention)]
        public static extern void MultiplyComplex(PreparedOps2F32Struct* ops, ulong arg, float re, float im);

        [DllImport(DllName,
            EntryPoint = "magnitude_ops2_f32",
            CallingConvention = RustConvention)]
        public static extern void Magnitude(PreparedOps2F32Struct* ops, ulong arg);

        [DllImport(DllName,
            EntryPoint = "magnitude_squared_ops2_f32",
            CallingConvention = RustConvention)]
        public static extern void MagnitudeSquared(PreparedOps2F32Struct* ops, ulong arg);

        [DllImport(DllName,
            EntryPoint = "complex_conj_ops2_f32",
            CallingConvention = RustConvention)]
        public static extern void ComplexConj(PreparedOps2F32Struct* ops, ulong arg);

        [DllImport(DllName,
            EntryPoint = "to_real_ops2_f32",
            CallingConvention = RustConvention)]
        public static extern void ToReal(PreparedOps2F32Struct* ops, ulong arg);

        [DllImport(DllName,
            EntryPoint = "to_imag_ops2_f32",
            CallingConvention = RustConvention)]
        public static extern void ToImag(PreparedOps2F32Struct* ops, ulong arg);

        [DllImport(DllName,
            EntryPoint = "phase_ops2_f32",
            CallingConvention = RustConvention)]
        public static extern void Phase(PreparedOps2F32Struct* ops, ulong arg);

        [DllImport(DllName,
            EntryPoint = "multiply_complex_exponential_ops2_f32",
            CallingConvention = RustConvention)]
        public static extern void MultiplyComplexExponential(PreparedOps2F32Struct* ops, ulong arg, float a, float b);

        [DllImport(DllName,
            EntryPoint = "add_vector_ops2_f32",
            CallingConvention = RustConvention)]
        public static extern void AddVector(PreparedOps2F32Struct* ops, ulong arg, ulong other);

        [DllImport(DllName,
            EntryPoint = "mul_vector_ops2_f32",
            CallingConvention = RustConvention)]
        public static extern void MulVector(PreparedOps2F32Struct* ops, ulong arg, ulong other);

        [DllImport(DllName,
            EntryPoint = "sub_vector_ops2_f32",
            CallingConvention = RustConvention)]
        public static extern void SubVector(PreparedOps2F32Struct* ops, ulong arg, ulong other);

        [DllImport(DllName,
            EntryPoint = "div_vector_ops2_f32",
            CallingConvention = RustConvention)]
        public static extern void DivVector(PreparedOps2F32Struct* ops, ulong arg, ulong other);

        [DllImport(DllName,
            EntryPoint = "square_ops2_f32",
            CallingConvention = RustConvention)]
        public static extern void Square(PreparedOps2F32Struct* ops, ulong arg);

        [DllImport(DllName,
            EntryPoint = "sqrt_ops2_f32",
            CallingConvention = RustConvention)]
        public static extern void Sqrt(PreparedOps2F32Struct* ops, ulong arg);

        [DllImport(DllName,
            EntryPoint = "root_ops2_f32",
            CallingConvention = RustConvention)]
        public static extern void Root(PreparedOps2F32Struct* ops, ulong arg, float value);

        [DllImport(DllName,
            EntryPoint = "powf_ops2_f32",
            CallingConvention = RustConvention)]
        public static extern void Powf(PreparedOps2F32Struct* ops, ulong arg, float value);

        [DllImport(DllName,
            EntryPoint = "ln_ops2_f32",
            CallingConvention = RustConvention)]
        public static extern void Ln(PreparedOps2F32Struct* ops, ulong arg);

        [DllImport(DllName,
            EntryPoint = "exp_ops2_f32",
            CallingConvention = RustConvention)]
        public static extern void Exp(PreparedOps2F32Struct* ops, ulong arg);
        [DllImport(DllName,
            EntryPoint = "log_ops2_f32",
            CallingConvention = RustConvention)]
        public static extern void Log(PreparedOps2F32Struct* ops, ulong arg, float value);
        [DllImport(DllName,
            EntryPoint = "expf_ops2_f32",
            CallingConvention = RustConvention)]
        public static extern void Expf(PreparedOps2F32Struct* ops, ulong arg, float value);

        [DllImport(DllName,
            EntryPoint = "sin_ops2_f32",
            CallingConvention = RustConvention)]
        public static extern void Sin(PreparedOps2F32Struct* ops, ulong arg);

        [DllImport(DllName,
            EntryPoint = "cos_ops2_f32",
            CallingConvention = RustConvention)]
        public static extern void Cos(PreparedOps2F32Struct* ops, ulong arg);

        [DllImport(DllName,
            EntryPoint = "tan_ops2_f32",
            CallingConvention = RustConvention)]
        public static extern void Tan(PreparedOps2F32Struct* ops, ulong arg);

        [DllImport(DllName,
            EntryPoint = "asin_ops2_f32",
            CallingConvention = RustConvention)]
        public static extern void ASin(PreparedOps2F32Struct* ops, ulong arg);

        [DllImport(DllName,
            EntryPoint = "acos_ops2_f32",
            CallingConvention = RustConvention)]
        public static extern void ACos(PreparedOps2F32Struct* ops, ulong arg);

        [DllImport(DllName,
            EntryPoint = "atan_ops2_f32",
            CallingConvention = RustConvention)]
        public static extern void ATan(PreparedOps2F32Struct* ops, ulong arg);

        [DllImport(DllName,
            EntryPoint = "sinh_ops2_f32",
            CallingConvention = RustConvention)]
        public static extern void Sinh(PreparedOps2F32Struct* ops, ulong arg);

        [DllImport(DllName,
            EntryPoint = "cosh_ops2_f32",
            CallingConvention = RustConvention)]
        public static extern void Cosh(PreparedOps2F32Struct* ops, ulong arg);

        [DllImport(DllName,
            EntryPoint = "tanh_ops2_f32",
            CallingConvention = RustConvention)]
        public static extern void Tanh(PreparedOps2F32Struct* ops, ulong arg);

        [DllImport(DllName,
            EntryPoint = "asinh_ops2_f32",
            CallingConvention = RustConvention)]
        public static extern void ASinh(PreparedOps2F32Struct* ops, ulong arg);

        [DllImport(DllName,
            EntryPoint = "acosh_ops2_f32",
            CallingConvention = RustConvention)]
        public static extern void ACosh(PreparedOps2F32Struct* ops, ulong arg);

        [DllImport(DllName,
            EntryPoint = "atanh_ops2_f32",
            CallingConvention = RustConvention)]
        public static extern void ATanh(PreparedOps2F32Struct* ops, ulong arg);

        [DllImport(DllName,
            EntryPoint = "clone_from_ops2_f32",
            CallingConvention = RustConvention)]
        public static extern void CloneFrom(PreparedOps2F32Struct* ops, ulong arg, ulong source);

        [DllImport(DllName,
            EntryPoint = "add_points_ops2_f32",
            CallingConvention = RustConvention)]
        public static extern void AddPoints(PreparedOps2F32Struct* ops, ulong arg);

        [DllImport(DllName,
            EntryPoint = "sub_points_ops2_f32",
            CallingConvention = RustConvention)]
        public static extern void SubPoints(PreparedOps2F32Struct* ops, ulong arg);

        [DllImport(DllName,
            EntryPoint = "mul_points_ops2_f32",
            CallingConvention = RustConvention)]
        public static extern void MulPoints(PreparedOps2F32Struct* ops, ulong arg);

        [DllImport(DllName,
            EntryPoint = "div_points_ops2_f32",
            CallingConvention = RustConvention)]
        public static extern void DivPoints(PreparedOps2F32Struct* ops, ulong arg);
    }
}