using System.Runtime.Serialization;

namespace employee_crud_.Services
{
    [Serializable]
    internal class InvalidAgrumentException : Exception
    {
        public InvalidAgrumentException()
        {
        }

        public InvalidAgrumentException(string? message) : base(message)
        {
        }

        public InvalidAgrumentException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected InvalidAgrumentException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}