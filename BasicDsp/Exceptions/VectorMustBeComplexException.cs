using System;
using System.Runtime.Serialization;

namespace BasicDsp
{
    [Serializable]
    public class VectorMustBeComplexException : DataVectorException
    {
        public VectorMustBeComplexException() : this("Vector must be complex")
        {
        }

        protected VectorMustBeComplexException(string message)
            : base(message)
        {
        }

        protected VectorMustBeComplexException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected VectorMustBeComplexException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}