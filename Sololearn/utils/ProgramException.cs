using System.Runtime.Serialization;

namespace Sololearn.utils
{
    [Serializable]
    internal class ProgramException : Exception
    {
        public ProgramException(string? message) : base(message)
        {
        }

        public ProgramException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected ProgramException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}