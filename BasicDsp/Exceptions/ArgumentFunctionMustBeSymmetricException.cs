using System;
using System.Runtime.Serialization;

namespace BasicDsp
{
    [Serializable]
    public class ArgumentFunctionMustBeSymmetricException : DataVectorException
    {
        public ArgumentFunctionMustBeSymmetricException() : this("The function must be symmetric")
        {
        }

        protected ArgumentFunctionMustBeSymmetricException(string message)
            : base(message)
        {
        }

        protected ArgumentFunctionMustBeSymmetricException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected ArgumentFunctionMustBeSymmetricException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}