using System;
using FFTtoRGB;

namespace ConsoleSample
{
    class Program
    {
        static void Main(string[] args)
        {
            
            var generator = new RGBGenerator();
            generator.Start();

            var FFT = generator.Read();

            var color = generator.GenerateColor(FFT);

            generator.Stop();
            generator.Dispose();
            Console.ReadKey(true);
        }
    }
}
