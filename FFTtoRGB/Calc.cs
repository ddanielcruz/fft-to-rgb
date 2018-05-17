using System;
using System.Numerics;

namespace FFTtoRGB
{
    public static class Calc
    {
        /// <summary>
        /// Calculate the FFT
        /// </summary>
        /// <returns>FFT's double array</returns>
        public static double[] FFT(double[] data)
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

        /// <summary>
        /// Get the sub-array from data
        /// </summary>
        /// <param name="data">Source array</param>
        /// <param name="index">Starting position</param>
        /// <param name="length">New Array's length</param>
        /// <returns>Sub-array from data</returns>
        public static T[] SubArray<T>(T[] data, int index, int length)
        {
            T[] result = new T[length];
            Array.Copy(data, index, result, 0, length);

            return result;
        }

        /// <summary>
        /// Map method. Calculate the value in the range [from1, to1] in the new range [from2, to2]
        /// </summary>
        /// <param name="value">Value to be calculated</param>
        /// <param name="from1">Initial floor</param>
        /// <param name="to1">Initial ceiling</param>
        /// <param name="from2">Final floor</param>
        /// <param name="to2">Final ceiling</param>
        /// <returns>Mapped value</returns>
        public static double Map(this double value, double from1, double to1, double from2, double to2)
        {
            return (value - from1) / (to1 - from1) * (to2 - from2) + from2;
        }
    }
}
