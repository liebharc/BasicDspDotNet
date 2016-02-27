using System;
using System.Runtime.Serialization;

namespace BasicDsp
{
    [Serializable]
    public class VectorMustHaveTheSameSizeException : DataVectorException
    {
        public VectorMustHaveTheSameSizeException() : this("Data vectors must have the same size")
        {
        }

        protected VectorMustHaveTheSameSizeException(string message)
            : base(message)
        {
        }

        protected VectorMustHaveTheSameSizeException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected VectorMustHaveTheSameSizeException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}