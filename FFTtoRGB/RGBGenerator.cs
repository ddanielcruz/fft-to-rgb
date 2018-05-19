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

        public double Max { get; set; } = double.MinValue;
        public double Min { get; set; } = double.MaxValue;

        /// <summary>
        /// Calculate the RGB color based on the FFT array
        /// </summary>
        /// <param name="FFT">FFT double array</param>
        /// <returns>Generated RGB color</returns>
        public RGB GenerateColor(double[] FFT)
        {
            int pX = (int)Math.Floor(FFT.Length * Settings.X);
            int pY = (int)Math.Floor(FFT.Length * Settings.Y);

            // Sub Arrays
            var aX = Calc.SubArray(FFT, 0, pX);
            var aY = Calc.SubArray(FFT, pX, pY - pX);
            var aZ = Calc.SubArray(FFT, pY, FFT.Length - pY);

            // Sub Arrays Average
            double X = 0, Y = 0, Z = 0;
            double[] values = new double[3];

            if (aX.Length > 0)
            {
                X = aX.Sum();
                values[0] = X;
            }

            if (aY.Length > 0)
            {
                Y = aY.Sum();
                values[1] = Y;
            }

            if (aZ.Length > 0)
            {
                Z = aZ.Sum();
                values[2] = Z;
            }

            // Get min value
            var min = values.Min();
            if (min < Min)
                Min = min;
            
            // Get max value
            var max = values.Max();
            if (max > Max)
                Max = max;

            var mX = (aX.Length > 0) ? (int)Math.Ceiling(X.Map(Min, Max, 96, 255)) : 0;
            var mY = (aY.Length > 0) ? (int)Math.Ceiling(Y.Map(Min, Max, 96, 255)) : 0;
            var mZ = (aZ.Length > 0) ? (int)Math.Ceiling(Z.Map(Min, Max, 96, 255)) : 0;

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
                    var time = 80;

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
