using System;
using System.Runtime.Serialization;

namespace BasicDsp
{
    [Serializable]
    public class VectorMetaDataMustAgreeException : DataVectorException
    {
        public VectorMetaDataMustAgreeException() : this("Vector meta data must agree")
        {
        }

        protected VectorMetaDataMustAgreeException(string message)
            : base(message)
        {
        }

        protected VectorMetaDataMustAgreeException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected VectorMetaDataMustAgreeException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}