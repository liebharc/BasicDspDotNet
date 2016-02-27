using System;
using System.Runtime.Serialization;

namespace BasicDsp
{
    [Serializable]
    public class UnknownResultCode : NonRecoverableDataVectorException
    {
        public UnknownResultCode()
            : this("Unknown result code, please report a bug to the author")
        {
        }

        protected UnknownResultCode(string message)
            : base(message)
        {
        }

        protected UnknownResultCode(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected UnknownResultCode(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}