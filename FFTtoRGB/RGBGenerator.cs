﻿using System;
using System.Linq;
using FFTtoRGB.FFT;
using FFTtoRGB.Color;

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

        /// <summary>
        /// RGB colors distribution 
        /// </summary>
        public ColorSettings Settings { get; set; }

        public RGBGenerator()
        {
            FFTProvider = new FFTProvider();
            Settings = new ColorSettings();

            Frequencies = FFTProvider.GetFreqArray();
        }
        public RGBGenerator(FFTProviderConfig config)
        {
            FFTProvider = new FFTProvider(config);
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
        public RGB GetColor(double[] FFT)
        {
            throw new NotImplementedException();
        }
    }
}