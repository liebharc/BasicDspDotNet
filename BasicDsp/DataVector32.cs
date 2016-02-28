using System;
using System.Linq;
using System.Runtime.InteropServices;

// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedMember.Global

namespace BasicDsp
{
    public sealed unsafe partial class DataVector32 :
        IComplexVectorOperations32,
        IRealVectorOperations32,
        IFrequencyDomainVectorOperations32,
        ITimeDomainVectorOperations32
    {
        private class DisposableHandle : IDisposable
        {
            private GCHandle? _pinned;
            public DisposableHandle(GCHandle gcHandle)
            {
                _pinned = gcHandle;
            }

            public DisposableHandle() { }

            protected void SetHandle(GCHandle handle)
            {
                _pinned = handle;
            }

            public IntPtr IntPtr => _pinned.Value.AddrOfPinnedObject();

            public void Dispose()
            {
                if (_pinned.HasValue)
                {
                    _pinned.Value.Free();
                    _pinned = null;
                }
            }
        }

        private sealed class VectorArrayToIntPtr : DisposableHandle
        {
            public VectorArrayToIntPtr(DataVector32[] array)
            {
                var natives = new IntPtr[array.Length];
                for (int i = 0; i < array.Length; i++)
                {
                    natives[i] = (IntPtr)array[i]._native;
                }

                SetHandle(GCHandle.Alloc(natives, GCHandleType.Pinned));
            }
        }

        private DataVector32Native.DataVector32Struct* _native;

        private const int Complex = 1;

        private const int Real = 0;

        public static DataVector32 NewGenericVector(bool isComplex, VectorDomain domain, int length)
        {
            if (length < 0)
            {
                throw new ArgumentException("Vector length must be >= 0", nameof(length));
            }

            return
                new DataVector32(DataVector32Native.New(isComplex ? Complex : Real, (int) domain, 0.0f, (ulong) length,
                    1.0f));
        }

        public static DataVector32 NewGenericVector(bool isComplex, VectorDomain domain, float[] data)
        {
            var vector =
                new DataVector32(DataVector32Native.New(isComplex ? Complex : Real, (int) domain, 0.0f,
                    (ulong) data.Length, 1.0f));
            for (int i = 0; i < data.Length; i++)
            {
                vector[i] = data[i];
            }

            return vector;
        }

        public static IRealTimeDomainVector32 NewRealTimeVectorFromConstant(float constant, int length)
        {
            if (length < 0)
            {
                throw new ArgumentException("Vector length must be >= 0", nameof(length));
            }

            return
                new DataVector32(DataVector32Native.New(Real, (int) VectorDomain.Time, constant, (ulong) length, 1.0f));
        }

        public static IRealTimeDomainVector32 NewRealTimeVectorFromArray(float[] data)
        {
            var vector =
                new DataVector32(DataVector32Native.New(Real, (int) VectorDomain.Time, 0.0f, (ulong) data.Length, 1.0f));
            for (int i = 0; i < data.Length; i++)
            {
                vector[i] = data[i];
            }

            return vector;
        }

        public static IComplexTimeDomainVector32 NewComplexTimeVectorFromConstant(float constant, int length)
        {
            if (length < 0)
            {
                throw new ArgumentException("Vector length must be >= 0", nameof(length));
            }

            return
                new DataVector32(DataVector32Native.New(Complex, (int) VectorDomain.Time, constant, (ulong) length, 1.0f));
        }

        public static IComplexTimeDomainVector32 NewComplexTimeVectorFromInterleaved(float[] data)
        {
            var vector =
                new DataVector32(DataVector32Native.New(Real, (int) VectorDomain.Time, 0.0f, (ulong) data.Length, 1.0f));
            for (int i = 0; i < data.Length; i++)
            {
                vector[i] = data[i];
            }

            return vector;
        }

        private DataVector32(DataVector32Native.DataVector32Struct* native)
        {
            _native = native;
        }

        public float this[int index]
        {
            get
            {
                if (index < 0 || index >= Length)
                {
                    throw new IndexOutOfRangeException("Index must be >= 0 and < " + Length);
                }

                return DataVector32Native.GetValue(_native, (ulong) index);
            }

            set
            {
                if (index < 0 || index >= Length)
                {
                    throw new IndexOutOfRangeException("Index must be >= 0 and < " + Length);
                }

                DataVector32Native.SetValue(_native, (ulong) index, value);
            }
        }

        public DataVector32 Add(float value)
        {
            Unwrap(DataVector32Native.RealOffset(_native, value));
            return this;
        }

        public DataVector32 Add(float real, float imag)
        {
            Unwrap(DataVector32Native.ComplexOffset(_native, real, imag));
            return this;
        }

        public DataVector32 Add(DataVector32 vector)
        {
            Unwrap(DataVector32Native.AddVector(_native, vector._native));
            return this;
        }

        public DataVector32 Subtract(float value)
        {
            Unwrap(DataVector32Native.RealOffset(_native, -value));
            return this;
        }

        public DataVector32 Subtract(float real, float imag)
        {
            Unwrap(DataVector32Native.ComplexOffset(_native, -real, -imag));
            return this;
        }

        public DataVector32 Subtract(DataVector32 vector)
        {
            Unwrap(DataVector32Native.SubtractVector(_native, vector._native));
            return this;
        }

        public DataVector32 Multiply(float value)
        {
            Unwrap(DataVector32Native.RealScale(_native, value));
            return this;
        }

        public DataVector32 Multiply(float real, float imag)
        {
            Unwrap(DataVector32Native.ComplexScale(_native, real, imag));
            return this;
        }

        public DataVector32 Multiply(DataVector32 vector)
        {
            Unwrap(DataVector32Native.MultiplyVector(_native, vector._native));
            return this;
        }

        public DataVector32 Divide(float value)
        {
            Unwrap(DataVector32Native.RealScale(_native, 1/value));
            return this;
        }

        public DataVector32 Divide(float real, float imag)
        {
            Unwrap(DataVector32Native.ComplexDivide(_native, real, imag));
            return this;
        }

        public DataVector32 Divide(DataVector32 vector)
        {
            Unwrap(DataVector32Native.DivideVector(_native, vector._native));
            return this;
        }

        public DataVector32 AddSmaller(DataVector32 vector)
        {
            Unwrap(DataVector32Native.AddSmallerVector(_native, vector._native));
            return this;
        }

        public DataVector32 SubtractSmaller(DataVector32 vector)
        {
            Unwrap(DataVector32Native.SubtractSmallerVector(_native, vector._native));
            return this;
        }

        public DataVector32 MultiplySmaller(DataVector32 vector)
        {
            Unwrap(DataVector32Native.MultiplySmallerVector(_native, vector._native));
            return this;
        }

        public DataVector32 DivideSmaller(DataVector32 vector)
        {
            Unwrap(DataVector32Native.DivideSmallerVector(_native, vector._native));
            return this;
        }

        public DataVector32 ZeroPad(int points, PaddingOption paddingOption)
        {
            if (points < 0)
            {
                throw new IndexOutOfRangeException("Points must be >= 0");
            }

            Unwrap(DataVector32Native.ZeroPad(_native, (ulong) points, (int) paddingOption));
            return this;
        }

        public DataVector32 ZeroInterleave(int factor)
        {
            Unwrap(DataVector32Native.ZeroInterleave(_native, factor));
            return this;
        }

        public DataVector32 Diff()
        {
            Unwrap(DataVector32Native.Diff(_native));
            return this;
        }

        public DataVector32 DiffWithStart()
        {
            Unwrap(DataVector32Native.DiffWithStart(_native));
            return this;
        }

        public DataVector32 CumSum()
        {
            Unwrap(DataVector32Native.CumSum(_native));
            return this;
        }

        public DataVector32 Abs()
        {
            Unwrap(IsComplex ? DataVector32Native.ComplexAbs(_native) : DataVector32Native.RealAbs(_native));
            return this;
        }

        public DataVector32 Sqrt()
        {
            Unwrap(DataVector32Native.Sqrt(_native));
            return this;
        }

        public DataVector32 Square()
        {
            Unwrap(DataVector32Native.Square(_native));
            return this;
        }

        public DataVector32 Root(float value)
        {
            Unwrap(DataVector32Native.Root(_native, value));
            return this;
        }

        public DataVector32 Power(float value)
        {
            Unwrap(DataVector32Native.Power(_native, value));
            return this;
        }

        public DataVector32 Logn()
        {
            Unwrap(DataVector32Native.Logn(_native));
            return this;
        }

        public DataVector32 Expn()
        {
            Unwrap(DataVector32Native.Expn(_native));
            return this;
        }

        public DataVector32 Exp(float value)
        {
            Unwrap(DataVector32Native.Exp(_native, value));
            return this;
        }

        public DataVector32 Log(float value)
        {
            Unwrap(DataVector32Native.Log(_native, value));
            return this;
        }

        public DataVector32 ATanh()
        {
            Unwrap(DataVector32Native.ATanh(_native));
            return this;
        }

        public DataVector32 ToComplex()
        {
            Unwrap(DataVector32Native.ToComplex(_native));
            return this;
        }

        public DataVector32 Sin()
        {
            Unwrap(DataVector32Native.Sin(_native));
            return this;
        }

        public DataVector32 Cos()
        {
            Unwrap(DataVector32Native.Cos(_native));
            return this;
        }

        public DataVector32 Tan()
        {
            Unwrap(DataVector32Native.Tan(_native));
            return this;
        }

        public DataVector32 ASin()
        {
            Unwrap(DataVector32Native.ASin(_native));
            return this;
        }

        public DataVector32 ACos()
        {
            Unwrap(DataVector32Native.ACos(_native));
            return this;
        }

        public DataVector32 ATan()
        {
            Unwrap(DataVector32Native.ATan(_native));
            return this;
        }

        public DataVector32 Sinh()
        {
            Unwrap(DataVector32Native.Sinh(_native));
            return this;
        }

        public DataVector32 Cosh()
        {
            Unwrap(DataVector32Native.Cosh(_native));
            return this;
        }

        public DataVector32 Tanh()
        {
            Unwrap(DataVector32Native.Tanh(_native));
            return this;
        }

        public DataVector32 ASinh()
        {
            Unwrap(DataVector32Native.ASinh(_native));
            return this;
        }

        public DataVector32 ACosh()
        {
            Unwrap(DataVector32Native.ACosh(_native));
            return this;
        }

        public DataVector32 SwapHalves()
        {
            Unwrap(DataVector32Native.SwapHalves(_native));
            return this;
        }

        public DataVector32 Wrap(float value)
        {
            Unwrap(DataVector32Native.Wrap(_native, value));
            return this;
        }

        public DataVector32 Unwrap(float value)
        {
            Unwrap(DataVector32Native.Unwrap(_native, value));
            return this;
        }

        public DataVector32 Magnitude()
        {
            Unwrap(DataVector32Native.ComplexAbs(_native));
            return this;
        }

        public void GetMagnitude(DataVector32 destination)
        {
            CheckResultCode(DataVector32Native.GetComplexAbs(_native, destination._native));
        }

        public DataVector32 MagnitudeSquared()
        {
            Unwrap(DataVector32Native.ComplexAbsSquared(_native));
            return this;
        }

        public DataVector32 ComplexConj()
        {
            Unwrap(DataVector32Native.ComplexConj(_native));
            return this;
        }

        public DataVector32 ToReal()
        {
            Unwrap(DataVector32Native.ToReal(_native));
            return this;
        }

        public DataVector32 ToImag()
        {
            Unwrap(DataVector32Native.ToImag(_native));
            return this;
        }

        public void GetReal(DataVector32 destination)
        {
            CheckResultCode(DataVector32Native.GetReal(_native, destination._native));
        }

        public void GetImag(DataVector32 destination)
        {
            CheckResultCode(DataVector32Native.GetImag(_native, destination._native));
        }

        public DataVector32 Phase()
        {
            Unwrap(DataVector32Native.Phase(_native));
            return this;
        }

        public void GetPhase(DataVector32 destination)
        {
            CheckResultCode(DataVector32Native.GetPhase(_native, destination._native));
        }

        public DataVector32 PlainFft()
        {
            Unwrap(DataVector32Native.PlainFft(_native));
            return this;
        }

        public DataVector32 PlainSfft()
        {
            Unwrap(DataVector32Native.PlainSfft(_native));
            return this;
        }

        public DataVector32 PlainIfft()
        {
            Unwrap(DataVector32Native.PlainIfft(_native));
            return this;
        }

        public float RealDotProduct(DataVector32 vector)
        {
            var result = DataVector32Native.RealDotProduct(_native, vector._native);
            CheckResultCode(result.resultCode);
            return result.result;
        }

        public Complex32 ComplexDotProduct(DataVector32 vector)
        {
            var result = DataVector32Native.ComplexDotProduct(_native, vector._native);
            CheckResultCode(result.resultCode);
            return result.result;
        }

        public RealStatistics32 RealStatistics()
        {
            return DataVector32Native.RealStatistics(_native);
        }

        public ComplexStatistics32 ComplexStatistics()
        {
            return DataVector32Native.ComplexStatistics(_native);
        }

        public DataVector32 MultiplyComplexExponential(float a, float b)
        {
            Unwrap(DataVector32Native.MultiplyComplexExponential(_native, a, b));
            return this;
        }

        public void GetRealImag(DataVector32 real, DataVector32 imag)
        {
            var result = DataVector32Native.GetRealImag(_native, real._native, imag._native);
            CheckResultCode(result);
        }

        public void GetMagPhase(DataVector32 mag, DataVector32 phase)
        {
            var result = DataVector32Native.GetMagPhase(_native, mag._native, phase._native);
            CheckResultCode(result);
        }

        public DataVector32 SetRealImag(DataVector32 real, DataVector32 imag)
        {
            Unwrap(DataVector32Native.SetRealImag(_native, real._native, imag._native));
            return this;
        }

        public DataVector32 SetMagPhase(DataVector32 mag, DataVector32 phase)
        {
            Unwrap(DataVector32Native.SetMagPhase(_native, mag._native, phase._native));
            return this;
        }

        public void SplitInto(DataVector32[] targets)
        {
            using (var intPtr = new VectorArrayToIntPtr(targets))
            {
                var result = DataVector32Native.SplitInto(_native, intPtr.IntPtr, (ulong)targets.Length);
                CheckResultCode(result);
            }
        }

        public RealStatistics32[] RealStatisticsSplitted(int length)
        {
            var result = new RealStatistics32[length];
            using (var intPtr = new DisposableHandle(GCHandle.Alloc(result, GCHandleType.Pinned)))
            {
                var code = DataVector32Native.RealStatisticsSplitted(_native, intPtr.IntPtr, (ulong)length);
                CheckResultCode(code);
                return result;
            }
        }

        public DataVector32 Merge(DataVector32[] sources)
        {
            using (var intPtr = new VectorArrayToIntPtr(sources))
            {
                Unwrap(DataVector32Native.Merge(_native, intPtr.IntPtr, (ulong)sources.Length));
                return this;
            }
        }

        public ComplexStatistics32[] ComplexStatisticsSplitted(int length)
        {
            var result = new ComplexStatistics32[length];
            using (var intPtr = new DisposableHandle(GCHandle.Alloc(result, GCHandleType.Pinned)))
            {
                var code = DataVector32Native.ComplexStatisticsSplitted(_native, intPtr.IntPtr, (ulong)length);
                CheckResultCode(code);
                return result;
            }
        }

        private void Unwrap(DataVector32Native.VectorResult32 result)
        {
            _native = result.vector;
            CheckResultCode(result.resultCode);
        }

        private void CheckResultCode(int resultCode)
        {
            switch (resultCode)
            {
                case 0:
                    break;
                case 1:
                    throw new VectorMustHaveTheSameSizeException();
                default:
                    throw new UnknownResultCode();
            }
        }

        public VectorDomain Domain
            => DataVector32Native.GetDomain(_native) == 0 ? VectorDomain.Time : VectorDomain.Frequency;

        public float Delta => DataVector32Native.Delta(_native);

        public bool IsComplex => DataVector32Native.IsComplex(_native) != 0;

        public int Length => (int) DataVector32Native.GetLength(_native);

        public int AllocatedLength => (int) DataVector32Native.GetAllocatedLength(_native);

        public int Points => (int) DataVector32Native.GetPoints(_native);
        public DataVector32 OverrideData(float[] data)
        {
            using (var intPtr = new DisposableHandle(GCHandle.Alloc(data, GCHandleType.Pinned)))
            {
                Unwrap(DataVector32Native.OverrideData(_native, intPtr.IntPtr, (ulong)data.Length));
                return this;
            }
        }

        public void ForceLen(int length)
        {
            DataVector32Native.SetLen(_native, (ulong) length);
        }

        public void Dispose()
        {
            if (_native != null)
            {
                DataVector32Native.DeleteVector(_native);
                _native = null;
            }
        }

        public object Clone()
        {
            var nativeClone = DataVector32Native.Clone(_native);
            var clone = new DataVector32(nativeClone);
            return clone;
        }
    }
}