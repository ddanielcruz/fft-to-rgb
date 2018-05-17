using System;

namespace FFTtoRGB
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

        /// <summary>
        /// Size of the BufferedWaveProvider. It must be a multiple of 2
        /// </summary>
        public int BufferSize { get; set; } = (int)Math.Pow(2, 11);

        /// <summary>
        /// Audio's sample resolution
        /// </summary>
        public int SampleResolution { get; set; } = 16;

        private double _sampleTake = 0.5;
        /// <summary>
        /// Desired percentage of the full FFT and Frequencies arrays to be returned.
        /// This value must be higher than zero and lesser or equal than one.
        /// </summary>
        public double SampleTake
        {
            get => _sampleTake;
            set
            {
                if (value > 0 && value <= 1)
                    _sampleTake = value;
                else
                    throw new Exception("Invalid value. The Sample Take must be higher than zero and lesser or equal than one.");
            }
        }
    }
}
