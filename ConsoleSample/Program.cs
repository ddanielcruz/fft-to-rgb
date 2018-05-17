using System;
using System.Threading;
using FFTtoRGB;

namespace ConsoleSample
{
    class Program
    {
        static void Main(string[] args)
        {
            var prov = new FFTProvider();
            prov.StartRecording();
            
            var freq = prov.GetFreqArray();

            for (int i = 0; i < 50; i++)
            {
                var FFT = prov.Read();

                Console.WriteLine($"[{FFT[0]}, {freq[0]}]");
                Console.WriteLine($"[{FFT[FFT.Length / 2]}, {freq[FFT.Length / 2]}]");
                Console.WriteLine($"[{FFT[FFT.Length - 1]}, {freq[FFT.Length - 1]}]\n");

                Thread.Sleep(500);
            }

            prov.Dispose();
            Console.ReadKey(true);
        }
    }
}
