using System;
using System.Runtime.Serialization;

namespace BasicDsp
{
    [Serializable]
    public class VectorMustNotBeEmptyException : DataVectorException
    {
        public VectorMustNotBeEmptyException() : this("Vector must not be empty")
        {
        }

        protected VectorMustNotBeEmptyException(string message)
            : base(message)
        {
        }

        protected VectorMustNotBeEmptyException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected VectorMustNotBeEmptyException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}