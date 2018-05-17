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
            
            //var fft = prov.Read();
            //prov.StopRecording();

            var freq = prov.GetFreqArray();

            //Console.WriteLine(fft.Length);
            //Console.WriteLine(freq.Length);

            //for (int i = 0; i < freq.Length; i += 8)
            //{
            //    Console.WriteLine($"[{fft[i]}, {freq[i]}]");
            //}

            for (int i = 0; i < 50; i++)
            {
                var FFT = prov.Read();
                Console.WriteLine(FFT[0]);

                Thread.Sleep(500);
            }

            prov.Dispose();
            Console.ReadKey(true);
        }
    }
}
