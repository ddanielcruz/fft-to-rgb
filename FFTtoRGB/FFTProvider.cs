using System;
using System.Linq;
using System.Threading;
using NAudio.Wave;

namespace FFTtoRGB
{
    /// <summary>
    /// Provides the FFT array and its frequencies. For now, it's working with the WaveInEvent using
    /// the device number 0 (usually the microphone). Later, the idea is to get the audio direct of
    /// the Window's digital output.
    /// </summary>
    public class FFTProvider
    {
        /// <summary>
        /// Audio Input
        /// </summary>
        private WaveInEvent WI { get; set; }
        
        /// <summary>
        /// Buffer to store the WaveInEvent samples
        /// </summary>
        private BufferedWaveProvider BWP { get; set; }

        /// <summary>
        /// Device's rate
        /// </summary>
        public int Rate { get; private set; } = 48000;
        
        /// <summary>
        /// Device's number of channels
        /// </summary>
        public int Channels { get; private set; } = 2;

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

        public FFTProvider(int deviceNumber = 0)
        {
            InitWaveInEvent(deviceNumber);
            InitBufferedWaveProvider();
        }
        public FFTProvider(int deviceNumber, int rate, int channels, int bufferSize)
        {
            Rate = rate;
            Channels = channels;
            BufferSize = bufferSize;

            InitWaveInEvent(deviceNumber);
            InitBufferedWaveProvider();
        }

        /// <summary>
        /// Initialize the WaveInEvent
        /// </summary>
        /// <param name="deviceNumber">Device Number to be listen. Default value is zero.</param>
        private void InitWaveInEvent(int deviceNumber = 0)
        {
            WI = new WaveInEvent
            {
                DeviceNumber = deviceNumber,
                WaveFormat = new WaveFormat(Rate, Channels),
                BufferMilliseconds = (int)(BufferSize / (double)Rate * 1000)
            };
            WI.DataAvailable += OnDataAvailable;
        }

        /// <summary>
        /// EventHandler to add samples to the BufferedWaveProvider
        /// </summary>
        private void OnDataAvailable(object sender, WaveInEventArgs e) => BWP.AddSamples(e.Buffer, 0, e.BytesRecorded);

        /// <summary>
        /// Initialize the BufferedWaveProvider
        /// </summary>
        private void InitBufferedWaveProvider()
        {
            BWP = new BufferedWaveProvider(WI.WaveFormat)
            {
                BufferLength = BufferSize * 2,
                DiscardOnBufferOverflow = true
            };
        }

        public void StartRecording()
        {
            WI.StartRecording();
            Thread.Sleep(50);   // Wait few time to start recording. Otherwise the first values will be NaN
        }
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

            if (frames.Length == 0)
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

            // TODO Validate SampleTake feature. It would be more clever to set the size to the desired Take instead of calculating the FFT for the whole Buffer.
            return NormalizeArray(Calc.FFT(data)).Take(Math.Floor(size * SampleTake)).ToArray();
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

            // TODO The same of the FFT
            return freq.Take(Math.Floor(size * SampleTake)).ToArray();
        }

        /// <summary>
        /// Normalize the FFT array, making all values positive, 
        /// adding the abs of the min value to all the others
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private double[] NormalizeArray(double[] data)
        {
            var minValue = data.Min();

            if (minValue < 0)
            {
                var N = Math.Abs(minValue);
                for (int i = 0; i < data.Length; i++)
                    data[i] += N;
            }

            return data;
        }
    }
}
