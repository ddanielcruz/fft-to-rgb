using System;
using System.Numerics;
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
        /// <returns></returns>
        public double[] Read()
        {
            // TODO Implement Read method returning FFT(bufferData)
            throw new NotImplementedException();
        }
        
        /// <summary>
        /// Calculate FFT
        /// </summary>
        private double[] FFT(double[] data)
        {
            double[] fft = new double[data.Length];
            Complex[] fftComplex = new Complex[data.Length];

            for (int i = 0; i < data.Length; i++)
                fftComplex[i] = new Complex(data[i], 0.0);

            Accord.Math.FourierTransform.FFT(fftComplex, Accord.Math.FourierTransform.Direction.Forward);

            for (int i = 0; i < data.Length; i++)
                fft[i] = Math.Log10(fftComplex[i].Magnitude);            

            return fft;
        }
    }
}
