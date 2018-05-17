using System;
using System.Runtime.Serialization;

namespace FFTtoRGB.Color
{
    /// <summary>
    /// Invalid value for color exception
    /// </summary>
    public class InvalidColorValueException : Exception
    {
        public override string Message => "Invalid value. RGB colors must be between zero and 255.";

        public InvalidColorValueException()
        {
        }
        public InvalidColorValueException(string message) : base(message)
        {
        }
        public InvalidColorValueException(string message, Exception innerException) : base(message, innerException)
        {
        }
        protected InvalidColorValueException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
