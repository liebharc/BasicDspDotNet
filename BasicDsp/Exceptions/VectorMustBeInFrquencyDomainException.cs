using System;
using System.Runtime.Serialization;

namespace BasicDsp
{
    [Serializable]
    public class VectorMustBeInFrquencyDomainException : DataVectorException
    {
        public VectorMustBeInFrquencyDomainException() : this("Vector must be in frequency domain")
        {
        }

        protected VectorMustBeInFrquencyDomainException(string message)
            : base(message)
        {
        }

        protected VectorMustBeInFrquencyDomainException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected VectorMustBeInFrquencyDomainException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}