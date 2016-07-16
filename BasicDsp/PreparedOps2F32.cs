using System;

namespace BasicDsp
{
    public sealed unsafe class GenericIdentifierOps2F32
    {
        private readonly PreparedOps2F32 _owner;
        private readonly ulong _arg;

        internal GenericIdentifierOps2F32(PreparedOps2F32 owner, ulong arg)
        {
            _owner = owner;
            _arg = arg;
        }

        public void AddReal(float value)
        {
            DataVector32Native.AddReal(_owner.Native, _arg, value);
            
        }

        public void MultiplyReal(float value)
        {
            DataVector32Native.MultiplyReal(_owner.Native, _arg, value);
            
        }

        public void Abs()
        {
            DataVector32Native.Abs(_owner.Native, _arg);
            
        }

        public void ToComplex()
        {
            DataVector32Native.ToComplex(_owner.Native, _arg);
            
        }

        public void AddComplex(Complex32 value)
        {
            DataVector32Native.AddComplex(_owner.Native, _arg, value.Real, value.Imag);
            
        }

        public void MultiplyComplex(Complex32 value)
        {
            DataVector32Native.MultiplyComplex(_owner.Native, _arg, value.Real, value.Imag);
            
        }

        public void Magnitude()
        {
            DataVector32Native.Magnitude(_owner.Native, _arg);
            
        }

        public void MagnitudeSquared()
        {
            DataVector32Native.MagnitudeSquared(_owner.Native, _arg);
            
        }

        public void Conj()
        {
            DataVector32Native.ComplexConj(_owner.Native, _arg);
            
        }

        public void ToReal()
        {
            DataVector32Native.ToReal(_owner.Native, _arg);
            
        }

        public void ToImag()
        {
            DataVector32Native.ToImag(_owner.Native, _arg);
            
        }

        public void Phase()
        {
            DataVector32Native.Phase(_owner.Native, _arg);
            
        }

        public void MultiplyComplexExponential(float a, float b)
        {
            DataVector32Native.MultiplyComplexExponential(_owner.Native, _arg, a, b);
            
        }

        public void AddVector(GenericIdentifierOps2F32 other)
        {
            DataVector32Native.AddVector(_owner.Native, _arg, other._arg);
            
        }

        public void SubVector(GenericIdentifierOps2F32 other)
        {
            DataVector32Native.SubVector(_owner.Native, _arg, other._arg);
            
        }

        public void MulVector(GenericIdentifierOps2F32 other)
        {
            DataVector32Native.MulVector(_owner.Native, _arg, other._arg);
            
        }

        public void DivVector(GenericIdentifierOps2F32 other)
        {
            DataVector32Native.DivVector(_owner.Native, _arg, other._arg);
            
        }

        public void Sqrt()
        {
            DataVector32Native.Sqrt(_owner.Native, _arg);
            
        }

        public void Square()
        {
            DataVector32Native.Square(_owner.Native, _arg);
            
        }

        public void Root(float value)
        {
            DataVector32Native.Root(_owner.Native, _arg, value);
            
        }

        public void Powf(float value)
        {
            DataVector32Native.Powf(_owner.Native, _arg, value);
            
        }

        public void Ln()
        {
            DataVector32Native.Ln(_owner.Native, _arg);
            
        }

        public void Exp()
        {
            DataVector32Native.Exp(_owner.Native, _arg);
            
        }

        public void Log(float value)
        {
            DataVector32Native.Log(_owner.Native, _arg, value);
            
        }

        public void Expf(float value)
        {
            DataVector32Native.Expf(_owner.Native, _arg, value);
            
        }

        public void Sin()
        {
            DataVector32Native.Sin(_owner.Native, _arg);
            
        }

        public void Cos()
        {
            DataVector32Native.Cos(_owner.Native, _arg);
            
        }

        public void Tan()
        {
            DataVector32Native.Tan(_owner.Native, _arg);
            
        }

        public void ASin()
        {
            DataVector32Native.ASin(_owner.Native, _arg);
            
        }

        public void ACos()
        {
            DataVector32Native.ACos(_owner.Native, _arg);
            
        }

        public void ATan()
        {
            DataVector32Native.ATan(_owner.Native, _arg);
            
        }

        public void Sinh()
        {
            DataVector32Native.Sinh(_owner.Native, _arg);
            
        }

        public void Cosh()
        {
            DataVector32Native.Cosh(_owner.Native, _arg);
            
        }

        public void Tanh()
        {
            DataVector32Native.Tanh(_owner.Native, _arg);
            
        }

        public void ASinh()
        {
            DataVector32Native.ASinh(_owner.Native, _arg);
            
        }

        public void ACosh()
        {
            DataVector32Native.ACosh(_owner.Native, _arg);
            
        }

        public void ATanh()
        {
            DataVector32Native.ATanh(_owner.Native, _arg);
            
        }

        public void CloneFrom(GenericIdentifierOps2F32 other)
        {
            DataVector32Native.CloneFrom(_owner.Native, _arg, other._arg);
            
        }

        public void AddPoints()
        {
            DataVector32Native.AddPoints(_owner.Native, _arg);
            
        }

        public void SubPoints()
        {
            DataVector32Native.SubPoints(_owner.Native, _arg);
            
        }

        public void MulPoints()
        {
            DataVector32Native.MulPoints(_owner.Native, _arg);
            
        }

        public void DivPoints()
        {
            DataVector32Native.DivPoints(_owner.Native, _arg);
            
        }
    }

    public sealed unsafe class PreparedOps2F32 : IDisposable
    {
        private DataVector32Native.PreparedOps2F32Struct* _native = null;

        internal DataVector32Native.PreparedOps2F32Struct* Native
        {
            get { return _native; }
        }

        public PreparedOps2F32()
        {
            _native = DataVector32Native.Prepare2();
        }

        public void AddOps(Action<GenericIdentifierOps2F32, GenericIdentifierOps2F32> ops)
        {
            var identifier1 = new GenericIdentifierOps2F32(this, 0);
            var identifier2 = new GenericIdentifierOps2F32(this, 1);
            ops(identifier1, identifier2);
        }

        public void Exec(DataVector32 vector1, DataVector32 vector2)
        {
            var result = DataVector32Native.Exec(_native, vector1.Native, vector2.Native);
            vector1.Native = result.vector1;
            vector2.Native = result.vector2;
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