using System;
using System.Runtime.Serialization;

namespace BasicDsp
{
    [Serializable]
    public abstract class DataVectorException : Exception
    {
        protected DataVectorException()
        {
        }

        protected DataVectorException(string message)
            : base(message)
        {
        }

        protected DataVectorException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected DataVectorException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}