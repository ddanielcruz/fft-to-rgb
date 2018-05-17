using System;

namespace FFTtoRGB.Color
{
    public class InvalidSettingsValueException : Exception
    {
        public override string Message => "Invalid value. The limit values must be between zero and one.";

        public InvalidSettingsValueException()
        {
        }
        public InvalidSettingsValueException(string message) : base(message)
        {
        }
        public InvalidSettingsValueException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
