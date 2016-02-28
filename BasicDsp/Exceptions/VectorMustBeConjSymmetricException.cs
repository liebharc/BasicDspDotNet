using System;
using System.Runtime.Serialization;

namespace BasicDsp
{
    [Serializable]
    public class VectorMustBeConjSymmetricException : DataVectorException
    {
        public VectorMustBeConjSymmetricException() : this("Vector must be complex conjungate symmetric")
        {
        }

        protected VectorMustBeConjSymmetricException(string message)
            : base(message)
        {
        }

        protected VectorMustBeConjSymmetricException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected VectorMustBeConjSymmetricException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}