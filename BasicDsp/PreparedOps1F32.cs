using System;

namespace BasicDsp
{
    public sealed unsafe class GenericIdentifier32
    {
        private readonly PreparedOps1F32 _owner;
        private readonly ulong _arg;

        internal GenericIdentifier32(PreparedOps1F32 owner, ulong arg)
        {
            _owner = owner;
            _arg = arg;
        }

        public GenericIdentifier32 AddReal(float value)
        {
            DataVector32Native.AddReal(_owner.Native, _arg, value);
            return this;
        }

        public GenericIdentifier32 MultiplyReal(float value)
        {
            DataVector32Native.MultiplyReal(_owner.Native, _arg, value);
            return this; 
        }

        public GenericIdentifier32 Abs()
        {
            DataVector32Native.Abs(_owner.Native, _arg);
            return this;
        }

        public GenericIdentifier32 ToComplex()
        {
            DataVector32Native.ToComplex(_owner.Native, _arg);
            return this; 
        }

        public GenericIdentifier32 AddComplex(Complex32 value)
        {
            DataVector32Native.AddComplex(_owner.Native, _arg, value.Real, value.Imag);
            return this; 
        }

        public GenericIdentifier32 MultiplyComplex(Complex32 value)
        {
            DataVector32Native.MultiplyComplex(_owner.Native, _arg, value.Real, value.Imag);
            return this;
        }

        public GenericIdentifier32 Magnitude()
        {
            DataVector32Native.Magnitude(_owner.Native, _arg);
            return this;
        }

        public GenericIdentifier32 MagnitudeSquared()
        {
            DataVector32Native.MagnitudeSquared(_owner.Native, _arg);
            return this;
        }

        public GenericIdentifier32 Conj()
        {
            DataVector32Native.ComplexConj(_owner.Native, _arg);
            return this;
        }

        public GenericIdentifier32 ToReal()
        {
            DataVector32Native.ToReal(_owner.Native, _arg);
            return this;
        }

        public GenericIdentifier32 ToImag()
        {
            DataVector32Native.ToImag(_owner.Native, _arg);
            return this;
        }

        public GenericIdentifier32 Phase()
        {
            DataVector32Native.Phase(_owner.Native, _arg);
            return this;
        }

        public GenericIdentifier32 MultiplyComplexExponential(float a, float b)
        {
            DataVector32Native.MultiplyComplexExponential(_owner.Native, _arg, a, b);
            return this;
        }

        public GenericIdentifier32 AddVector(GenericIdentifier32 other)
        {
            DataVector32Native.AddVector(_owner.Native, _arg, other._arg);
            return this;
        }

        public GenericIdentifier32 SubVector(GenericIdentifier32 other)
        {
            DataVector32Native.SubVector(_owner.Native, _arg, other._arg);
            return this;
        }

        public GenericIdentifier32 MulVector(GenericIdentifier32 other)
        {
            DataVector32Native.MulVector(_owner.Native, _arg, other._arg);
            return this;
        }

        public GenericIdentifier32 DivVector(GenericIdentifier32 other)
        {
            DataVector32Native.DivVector(_owner.Native, _arg, other._arg);
            return this;
        }

        public GenericIdentifier32 Sqrt()
        {
            DataVector32Native.Sqrt(_owner.Native, _arg);
            return this;
        }

        public GenericIdentifier32 Square()
        {
            DataVector32Native.Square(_owner.Native, _arg);
            return this;
        }

        public GenericIdentifier32 Root(float value)
        {
            DataVector32Native.Root(_owner.Native, _arg, value);
            return this;
        }

        public GenericIdentifier32 Powf(float value)
        {
            DataVector32Native.Powf(_owner.Native, _arg, value);
            return this;
        }

        public GenericIdentifier32 Ln()
        {
            DataVector32Native.Ln(_owner.Native, _arg);
            return this;
        }

        public GenericIdentifier32 Exp()
        {
            DataVector32Native.Exp(_owner.Native, _arg);
            return this;
        }

        public GenericIdentifier32 Log(float value)
        {
            DataVector32Native.Log(_owner.Native, _arg, value);
            return this;
        }

        public GenericIdentifier32 Expf(float value)
        {
            DataVector32Native.Expf(_owner.Native, _arg, value);
            return this;
        }

        public GenericIdentifier32 Sin()
        {
            DataVector32Native.Sin(_owner.Native, _arg);
            return this;
        }

        public GenericIdentifier32 Cos()
        {
            DataVector32Native.Cos(_owner.Native, _arg);
            return this;
        }

        public GenericIdentifier32 Tan()
        {
            DataVector32Native.Tan(_owner.Native, _arg);
            return this;
        }

        public GenericIdentifier32 ASin()
        {
            DataVector32Native.ASin(_owner.Native, _arg);
            return this;
        }

        public GenericIdentifier32 ACos()
        {
            DataVector32Native.ACos(_owner.Native, _arg);
            return this;
        }

        public GenericIdentifier32 ATan()
        {
            DataVector32Native.ATan(_owner.Native, _arg);
            return this;
        }

        public GenericIdentifier32 Sinh()
        {
            DataVector32Native.Sinh(_owner.Native, _arg);
            return this;
        }

        public GenericIdentifier32 Cosh()
        {
            DataVector32Native.Cosh(_owner.Native, _arg);
            return this;
        }

        public GenericIdentifier32 Tanh()
        {
            DataVector32Native.Tanh(_owner.Native, _arg);
            return this;
        }

        public GenericIdentifier32 ASinh()
        {
            DataVector32Native.ASinh(_owner.Native, _arg);
            return this;
        }

        public GenericIdentifier32 ACosh()
        {
            DataVector32Native.ACosh(_owner.Native, _arg);
            return this;
        }

        public GenericIdentifier32 ATanh()
        {
            DataVector32Native.ATanh(_owner.Native, _arg);
            return this;
        }

        public GenericIdentifier32 CloneFrom(GenericIdentifier32 other)
        {
            DataVector32Native.CloneFrom(_owner.Native, _arg, other._arg);
            return this;
        }

        public GenericIdentifier32 AddPoints()
        {
            DataVector32Native.AddPoints(_owner.Native, _arg);
            return this;
        }

        public GenericIdentifier32 SubPoints()
        {
            DataVector32Native.SubPoints(_owner.Native, _arg);
            return this;
        }

        public GenericIdentifier32 MulPoints()
        {
            DataVector32Native.MulPoints(_owner.Native, _arg);
            return this;
        }

        public GenericIdentifier32 DivPoints()
        {
            DataVector32Native.DivPoints(_owner.Native, _arg);
            return this;
        }
    }

    public sealed unsafe class PreparedOps1F32 : IDisposable
    {
        private DataVector32Native.PreparedOps1F32Struct* _native = null;

        internal DataVector32Native.PreparedOps1F32Struct* Native
        {
            get { return _native; }
        }

        public PreparedOps1F32()
        {
            _native = DataVector32Native.Prepare1();
        }

        public void AddOps(Func<GenericIdentifier32, GenericIdentifier32> ops)
        {
            var identifier = new GenericIdentifier32(this, 0);
            var _ = ops(identifier);
        }

        public void Exec(DataVector32 vector)
        {
            var result = DataVector32Native.Exec(_native, vector.Native);
            vector.Native = result.vector;
            DataVector32.CheckResultCode(result.resultCode);
        }

        public void Dispose()
        {
            if (_native != null)
            {
                DataVector32Native.DeletePreparedOps(_native);
                _native = null;
            }
        }
    }
}
