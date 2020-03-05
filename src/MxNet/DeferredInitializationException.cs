using System;
using System.Runtime.Serialization;

namespace MxNet
{
    public class DeferredInitializationException : Exception
    {
        public DeferredInitializationException()
        {
        }

        public DeferredInitializationException(string message) : base(message)
        {
        }

        public DeferredInitializationException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected DeferredInitializationException(SerializationInfo info, StreamingContext context) : base(info,
            context)
        {
        }
    }
}