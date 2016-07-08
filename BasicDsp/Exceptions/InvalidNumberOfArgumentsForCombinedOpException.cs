using System;
using System.Runtime.Serialization;

namespace BasicDsp
{
    [Serializable]
    public class InvalidNumberOfArgumentsForCombinedOpException : DataVectorException
    {
        public InvalidNumberOfArgumentsForCombinedOpException() : this("The number of arguments passed to a combined op is invalid")
        {
        }

        protected InvalidNumberOfArgumentsForCombinedOpException(string message)
            : base(message)
        {
        }

        protected InvalidNumberOfArgumentsForCombinedOpException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected InvalidNumberOfArgumentsForCombinedOpException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}