using System;
using System.Runtime.Serialization;

namespace BasicDsp
{
    [Serializable]
    public class VectorMustBeRealException : DataVectorException
    {
        public VectorMustBeRealException() : this("Vector must be real")
        {
        }

        protected VectorMustBeRealException(string message)
            : base(message)
        {
        }

        protected VectorMustBeRealException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected VectorMustBeRealException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}