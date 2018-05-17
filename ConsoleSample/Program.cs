using System;
using System.Threading;
using FFTtoRGB.FFT;
using FFTtoRGB;

namespace ConsoleSample
{
    class Program
    {
        static void Main(string[] args)
        {
            //var prov = new FFTProvider();
            //prov.StartRecording();

            //var freq = prov.GetFreqArray();

            //for (int i = 0; i < 50; i++)
            //{
            //    var FFT = prov.Read();

            //    Console.WriteLine($"[{FFT[0]}, {freq[0]}]");
            //    Console.WriteLine($"[{FFT[FFT.Length / 2]}, {freq[FFT.Length / 2]}]");
            //    Console.WriteLine($"[{FFT[FFT.Length - 1]}, {freq[FFT.Length - 1]}]\n");

            //    Thread.Sleep(500);
            //}

            //prov.Dispose();

            var array = new int[] { 0,1,2,3,4,5,6,7,8,9 };
            int length = array.Length - 4;

            var sub = Calc.SubArray(array, 4, length);

            for (int i = 0; i < length; i++)
            {
                Console.WriteLine(sub[i]);
            }

            Console.ReadKey(true);
        }
    }
}
