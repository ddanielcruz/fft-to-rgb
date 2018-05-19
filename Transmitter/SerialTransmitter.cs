using System;
using System.IO.Ports;

namespace Transmitter
{
    /// <summary>
    /// Class to send data to the arduino by serial
    /// </summary>
    public class SerialTransmitter
    {
        /// <summary>
        /// Serial Port to communicate
        /// </summary>
        private SerialPort Serial { get; set; }

        /// <summary>
        /// Whether the connection is open or not
        /// </summary>
        private bool IsOpen { get; set; } = false;

        public SerialTransmitter(string portName, int baudRate = 9600) => Serial = new SerialPort(portName, baudRate);

        /// <summary>
        /// Open connection
        /// </summary>
        public void Open()
        {
            try
            {
                Serial.Open();
                IsOpen = true;
            }
            catch (UnauthorizedAccessException e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Close connection
        /// </summary>
        public void Close()
        {
            Serial.Close();
            IsOpen = false;
        }

        /// <summary>
        /// Write value in the serial
        /// </summary>
        /// <param name="value">String to be written</param>
        public void Write(string value)
        {
            if (IsOpen)
            {
                try
                {
                    Serial.Write(value);
                }
                catch (InvalidOperationException e)
                {
                    throw e;
                }
            }
            else
                throw new Exception("The connection is closed.");
        }

        /// <summary>
        /// Write value in the serial
        /// </summary>
        /// <param name="value">Byte to be written</param>
        public void Write(byte value)
        {
            if (IsOpen)
            {
                try
                {
                    Serial.Write($"[{value}]");
                }
                catch (InvalidOperationException e)
                {
                    throw e;
                }
            }
            else
                throw new Exception("The connection is closed.");
        }
    }
}
