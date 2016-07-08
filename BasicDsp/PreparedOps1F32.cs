using System;

namespace BasicDsp
{
    public sealed unsafe class GenericIdentifier
    {
        private readonly PreparedOps1F32 _owner;
        private readonly ulong _arg;

        internal GenericIdentifier(PreparedOps1F32 owner, ulong arg)
        {
            _owner = owner;
            _arg = arg;
        }

        public GenericIdentifier AddReal(float value)
        {
            DataVector32Native.AddReal(_owner.Native, _arg, value);
            return this;
        }

        public GenericIdentifier MultiplyReal(float value)
        {
            DataVector32Native.MultiplyReal(_owner.Native, _arg, value);
            return this; 
        }

        public GenericIdentifier Abs()
        {
            DataVector32Native.Abs(_owner.Native, _arg);
            return this;
        }

        public GenericIdentifier ToComplex()
        {
            DataVector32Native.ToComplex(_owner.Native, _arg);
            return this; 
        }

        public GenericIdentifier AddComplex(Complex32 value)
        {
            DataVector32Native.AddComplex(_owner.Native, _arg, value.Real, value.Imag);
            return this; 
        }

        public GenericIdentifier MultiplyComplex(Complex32 value)
        {
            DataVector32Native.MultiplyComplex(_owner.Native, _arg, value.Real, value.Imag);
            return this;
        }

        public GenericIdentifier Magnitude()
        {
            DataVector32Native.Magnitude(_owner.Native, _arg);
            return this;
        }

        public GenericIdentifier MagnitudeSquared()
        {
            DataVector32Native.MagnitudeSquared(_owner.Native, _arg);
            return this;
        }

        public GenericIdentifier Conj()
        {
            DataVector32Native.ComplexConj(_owner.Native, _arg);
            return this;
        }

        public GenericIdentifier ToReal()
        {
            DataVector32Native.ToReal(_owner.Native, _arg);
            return this;
        }

        public GenericIdentifier ToImag()
        {
            DataVector32Native.ToImag(_owner.Native, _arg);
            return this;
        }

        public GenericIdentifier Phase()
        {
            DataVector32Native.Phase(_owner.Native, _arg);
            return this;
        }

        public GenericIdentifier MultiplyComplexExponential(float a, float b)
        {
            DataVector32Native.MultiplyComplexExponential(_owner.Native, _arg, a, b);
            return this;
        }

        public GenericIdentifier AddVector(GenericIdentifier other)
        {
            DataVector32Native.AddVector(_owner.Native, _arg, other._arg);
            return this;
        }

        public GenericIdentifier SubVector(GenericIdentifier other)
        {
            DataVector32Native.SubVector(_owner.Native, _arg, other._arg);
            return this;
        }

        public GenericIdentifier MulVector(GenericIdentifier other)
        {
            DataVector32Native.MulVector(_owner.Native, _arg, other._arg);
            return this;
        }

        public GenericIdentifier DivVector(GenericIdentifier other)
        {
            DataVector32Native.DivVector(_owner.Native, _arg, other._arg);
            return this;
        }

        public GenericIdentifier Sqrt()
        {
            DataVector32Native.Sqrt(_owner.Native, _arg);
            return this;
        }

        public GenericIdentifier Square()
        {
            DataVector32Native.Square(_owner.Native, _arg);
            return this;
        }

        public GenericIdentifier Root(float value)
        {
            DataVector32Native.Root(_owner.Native, _arg, value);
            return this;
        }

        public GenericIdentifier Powf(float value)
        {
            DataVector32Native.Powf(_owner.Native, _arg, value);
            return this;
        }

        public GenericIdentifier Ln()
        {
            DataVector32Native.Ln(_owner.Native, _arg);
            return this;
        }

        public GenericIdentifier Exp()
        {
            DataVector32Native.Exp(_owner.Native, _arg);
            return this;
        }

        public GenericIdentifier Log(float value)
        {
            DataVector32Native.Log(_owner.Native, _arg, value);
            return this;
        }

        public GenericIdentifier Expf(float value)
        {
            DataVector32Native.Expf(_owner.Native, _arg, value);
            return this;
        }

        public GenericIdentifier Sin()
        {
            DataVector32Native.Sin(_owner.Native, _arg);
            return this;
        }

        public GenericIdentifier Cos()
        {
            DataVector32Native.Cos(_owner.Native, _arg);
            return this;
        }

        public GenericIdentifier Tan()
        {
            DataVector32Native.Tan(_owner.Native, _arg);
            return this;
        }

        public GenericIdentifier ASin()
        {
            DataVector32Native.ASin(_owner.Native, _arg);
            return this;
        }

        public GenericIdentifier ACos()
        {
            DataVector32Native.ACos(_owner.Native, _arg);
            return this;
        }

        public GenericIdentifier ATan()
        {
            DataVector32Native.ATan(_owner.Native, _arg);
            return this;
        }

        public GenericIdentifier Sinh()
        {
            DataVector32Native.Sinh(_owner.Native, _arg);
            return this;
        }

        public GenericIdentifier Cosh()
        {
            DataVector32Native.Cosh(_owner.Native, _arg);
            return this;
        }

        public GenericIdentifier Tanh()
        {
            DataVector32Native.Tanh(_owner.Native, _arg);
            return this;
        }

        public GenericIdentifier ASinh()
        {
            DataVector32Native.ASinh(_owner.Native, _arg);
            return this;
        }

        public GenericIdentifier ACosh()
        {
            DataVector32Native.ACosh(_owner.Native, _arg);
            return this;
        }

        public GenericIdentifier ATanh()
        {
            DataVector32Native.ATanh(_owner.Native, _arg);
            return this;
        }

        public GenericIdentifier CloneFrom(GenericIdentifier other)
        {
            DataVector32Native.CloneFrom(_owner.Native, _arg, other._arg);
            return this;
        }

        public GenericIdentifier AddPoints()
        {
            DataVector32Native.AddPoints(_owner.Native, _arg);
            return this;
        }

        public GenericIdentifier SubPoints()
        {
            DataVector32Native.SubPoints(_owner.Native, _arg);
            return this;
        }

        public GenericIdentifier MulPoints()
        {
            DataVector32Native.MulPoints(_owner.Native, _arg);
            return this;
        }

        public GenericIdentifier DivPoints()
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

        public void AddOps(Func<GenericIdentifier, GenericIdentifier> ops)
        {
            var identifier = new GenericIdentifier(this, 0);
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
