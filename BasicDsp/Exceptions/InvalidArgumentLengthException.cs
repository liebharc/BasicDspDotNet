using System;
using System.Runtime.Serialization;

namespace BasicDsp
{
    [Serializable]
    public class InvalidArgumentLengthException : DataVectorException
    {
        public InvalidArgumentLengthException() : this("Invalid argument length")
        {
        }

        protected InvalidArgumentLengthException(string message)
            : base(message)
        {
        }

        protected InvalidArgumentLengthException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected InvalidArgumentLengthException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}