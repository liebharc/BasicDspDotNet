using System;
using System.Runtime.Serialization;

namespace BasicDsp
{
    [Serializable]
    public class DataVectorLibraryIsInvalidOrMissingException : Exception
    {
        public DataVectorLibraryIsInvalidOrMissingException()
        {
        }

        protected DataVectorLibraryIsInvalidOrMissingException(string message)
            : base(message)
        {
        }

        protected DataVectorLibraryIsInvalidOrMissingException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected DataVectorLibraryIsInvalidOrMissingException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}