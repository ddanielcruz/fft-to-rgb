using System;
using NAudio.Wave;

namespace FFTtoRGB
{
    public class FFTProvider
    {
        private WaveIn WI { get; set; }
        private BufferedWaveProvider BWP { get; set; }

        private int Rate { get; set; } = 48000;
        private int Channels { get; set; } = 2;
        private int BufferSize { get; set; } = (int)Math.Pow(2, 11);

        public int SampleResolution { get; set; } = 16;

        public FFTProvider(int deviceNumber = 0)
        {
            InitWaveIn(deviceNumber);
            InitBufferedWaveProvider();
        }
        public FFTProvider(int deviceNumber, int rate, int channels, int bufferSize)
        {
            Rate = rate;
            Channels = channels;
            BufferSize = bufferSize;

            InitWaveIn(deviceNumber);
            InitBufferedWaveProvider();
        }

        private void InitWaveIn(int deviceNumber = 0)
        {
            WI = new WaveIn
            {
                DeviceNumber = deviceNumber,
                WaveFormat = new WaveFormat(Rate, Channels),
                BufferMilliseconds = (int)(BufferSize / (double)Rate * 1000)
            };
            WI.DataAvailable += OnDataAvailable;
        }
        private void OnDataAvailable(object sender, WaveInEventArgs e) => BWP.AddSamples(e.Buffer, 0, e.BytesRecorded);

        private void InitBufferedWaveProvider()
        {
            BWP = new BufferedWaveProvider(WI.WaveFormat)
            {
                BufferLength = BufferSize * 2,
                DiscardOnBufferOverflow = true
            };
        }

        public void StartRecording() => WI.StartRecording();
        public void StopRecording() => WI.StopRecording();
        public void Dispose() => WI.Dispose();

        /// <summary>
        /// Read the buffer and return the FFT
        /// </summary>
        /// <returns>FFT array</returns>
        public double[] Read()
        {
            int frameSize = BufferSize;
            var frames = new byte[frameSize];

            BWP.Read(frames, 0, frameSize);

            if (frames.Length == 0 || frames[frameSize - 2] == 0)
                throw new Exception("Invalid Data.");

            int BPP = SampleResolution / 8;   // Bytes per point
            int size = frames.Length / BPP;

            var data = new double[size];            

            for (int i = 0; i < size; i++)
            {
                byte hByte = frames[i * 2 + 1];
                byte lByte = frames[i * 2 + 0];

                data[i] = (short)((hByte << 8) | lByte);
            }

            return Calc.FFT(data);
        }

        /// <summary>
        /// Get frequencies array
        /// </summary>
        /// <returns>Frequencies array</returns>
        public double[] GetFreqArray()
        {
            int BPP = SampleResolution / 8;
            int size = BufferSize / BPP;

            var freq = new double[size];

            for (int i = 0; i < size; i++)
                freq[i] = (double)i / size * Rate / 1000.0; // kHz

            return freq;
        }
    }
}
