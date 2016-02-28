using System;
using System.Runtime.Serialization;

namespace BasicDsp
{
    [Serializable]
    public class VectorMustBeInTimeDomainException : DataVectorException
    {
        public VectorMustBeInTimeDomainException() : this("Vector must be in time domain")
        {
        }

        protected VectorMustBeInTimeDomainException(string message)
            : base(message)
        {
        }

        protected VectorMustBeInTimeDomainException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected VectorMustBeInTimeDomainException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}