using System;
using System.Runtime.Serialization;

namespace BasicDsp
{
    [Serializable]
    public abstract class NonRecoverableDataVectorException : DataVectorException
    {
        protected NonRecoverableDataVectorException()
        {
        }

        protected NonRecoverableDataVectorException(string message)
            : base(message)
        {
        }

        protected NonRecoverableDataVectorException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected NonRecoverableDataVectorException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}