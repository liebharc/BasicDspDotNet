using System;
using System.Runtime.Serialization;

namespace BasicDsp
{
    [Serializable]
    public class VectorMustHaveAnOddLengthException : DataVectorException
    {
        public VectorMustHaveAnOddLengthException() : this("Vector must have an odd length")
        {
        }

        protected VectorMustHaveAnOddLengthException(string message)
            : base(message)
        {
        }

        protected VectorMustHaveAnOddLengthException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected VectorMustHaveAnOddLengthException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}