using System;
using System.Linq;
using FFTtoRGB.FFT;
using FFTtoRGB.Color;
using System.Threading.Tasks;
using System.Threading;

namespace FFTtoRGB
{
    /// <summary>
    /// Generates the RGB using the FFTProvider
    /// </summary>
    public class RGBGenerator
    {
        /// <summary>
        /// Color generated event
        /// </summary>
        public event EventHandler<GenericEventArgs<RGB>> ColorGenerated;

        /// <summary>
        /// FFT Provider
        /// </summary>
        private FFTProvider FFTProvider { get; set; }

        /// <summary>
        /// FFT Provider's config
        /// </summary>
        private FFTProviderConfig FFTProviderSettings { get; set; }

        /// <summary>
        /// Frequencies array
        /// </summary>
        private double[] Frequencies { get; set; }

        /// <summary>
        /// Boolean to stop more than one running thread
        /// </summary>
        private bool IsRunning { get; set; } = false;

        /// <summary>
        /// RGB colors distribution 
        /// </summary>
        public ColorSettings Settings { get; set; }

        public RGBGenerator() => InitGenerator(new FFTProviderConfig());
        public RGBGenerator(FFTProviderConfig config) => InitGenerator(config);

        private void InitGenerator(FFTProviderConfig config)
        {
            FFTProvider = new FFTProvider(config);
            FFTProviderSettings = config;
            Settings = new ColorSettings();

            Frequencies = FFTProvider.GetFreqArray();
        }

        /// <summary>
        /// Normalize the FFT array, making all values positive, adding the abs of the min value to all the others.
        /// The reason is that some values of the FFT may be negative, what prejudices the RGB generating.
        /// </summary>
        /// <param name="data">FFT Array</param>
        /// <returns>Normalized Array</returns>
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

        /// <summary>
        /// Calculate the RGB color based on the FFT array
        /// </summary>
        /// <param name="FFT">FFT double array</param>
        /// <returns>Generated RGB color</returns>
        public RGB GenerateColor(double[] FFT)
        {
            int pX = (int)Math.Floor(FFT.Length * Settings.X);
            int pY = (int)Math.Floor(FFT.Length * Settings.Y);

            // Sub arrays sum
            var X = Calc.SubArray(FFT, 0, pX).Sum();
            var Y = Calc.SubArray(FFT, pX, pY - pX).Sum();
            var Z = Calc.SubArray(FFT, pY, FFT.Length - pY).Sum();

            // Get max value
            var max = new double[] { X, Y, Z }.Max();

            var mX = (int)Math.Ceiling(X.Map(0, max, 0, 255));
            var mY = (int)Math.Ceiling(Y.Map(0, max, 0, 255));
            var mZ = (int)Math.Ceiling(Z.Map(0, max, 0, 255));

            return new RGB(mX, mY, mZ, Settings.Order);
        }

        /// <summary>
        /// CancellationTokenSource to control the task
        /// </summary>
        private CancellationTokenSource TokenSource { get; set; }

        /// <summary>
        /// Start generating the colors and sending them to the Arduino
        /// </summary>
        public void Run()
        {
            if (!IsRunning)
            {
                TokenSource = new CancellationTokenSource();

                var RunningTask = new Task(() =>
                {
                    IsRunning = true;
                    FFTProvider.StartRecording();
                    var time = 50;

                    while (!TokenSource.IsCancellationRequested)
                    {
                        var NRM = NormalizeArray(FFTProvider.Read());

                        if (double.IsInfinity(NRM[0]) || double.IsNaN(NRM[0]))
                            continue;

                        var color = GenerateColor(NRM);
                        ColorGenerated?.Invoke(this, new GenericEventArgs<RGB>(color));

                        Thread.Sleep(time);
                    }

                    IsRunning = false;
                    FFTProvider.StopRecording();
                }, TokenSource.Token);
                RunningTask.Start();
            }
        }

        /// <summary>
        /// Stop generating colors
        /// </summary>
        public void Stop() => TokenSource.Cancel();
    }
}
