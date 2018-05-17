using System;
using System.Linq;

namespace FFTtoRGB
{
    /// <summary>
    /// Generates the RGB using the FFTProvider
    /// </summary>
    public class RGBGenerator
    {
        /// <summary>
        /// FFT Provider
        /// </summary>
        private FFTProvider FFTProvider { get; set; }

        /// <summary>
        /// Frequencies array
        /// </summary>
        private double[] Frequencies { get; set; }

        public RGBGenerator()
        {
            FFTProvider = new FFTProvider();
            Frequencies = FFTProvider.GetFreqArray();
        }
        public RGBGenerator(FFTProviderConfig config)
        {
            FFTProvider = new FFTProvider(config);
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
    }
}
