using System.Runtime.Serialization;

namespace FallingSand.Domain
{
    [Serializable]
    internal class PalhaxotaException : Exception
    {
        public PalhaxotaException()
        {
        }

        public PalhaxotaException(string? message) : base(message)
        {
        }

        public PalhaxotaException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected PalhaxotaException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}