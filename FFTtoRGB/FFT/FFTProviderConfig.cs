using System;

namespace FFTtoRGB.FFT
{
    /// <summary>
    /// FFT Provider's config.
    /// </summary>
    public class FFTProviderConfig
    {
        /// <summary>
        /// The device number to use in the WaveInEvent
        /// </summary>
        public int DeviceNumber { get; set; } = 0;

        /// <summary>
        /// Device's rate
        /// </summary>
        public int Rate { get; set; } = 48000;

        /// <summary>
        /// Device's number of channels
        /// </summary>
        public int Channels { get; set; } = 2;

        private int _bufferSize = (int)Math.Pow(2, 11);
        /// <summary>
        /// Size of the BufferedWaveProvider. It must be a power of 2
        /// </summary
        public int BufferSize
        {
            get => _bufferSize;
            set
            {
                // TODO Check if value is a power of 2
                if (IsPowerOfTwo(value))
                    _bufferSize = value;
                else
                    throw new Exception("Invalid value. The value must be a power of 2.");
            }
        }

        /// <summary>
        /// Check if value is a power of 2
        /// </summary>
        /// <param name="value">Number to be checked</param>
        /// <returns>Whether the value is a power of two</returns>
        bool IsPowerOfTwo(int value) => (value != 0) && ((value & (value - 1)) == 0);

        /// <summary>
        /// Audio's sample resolution
        /// </summary>
        public int SampleResolution { get; set; } = 16;

        /// <summary>
        /// Desired percentage of the full FFT and Frequencies arrays to be returned.
        /// </summary>
        public SampleTakeMeasure SampleTake { get; set; } = SampleTakeMeasure.Half;
    }
}
