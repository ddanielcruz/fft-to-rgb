using System;
using FFTtoRGB;
using FFTtoRGB.FFT;

namespace ConsoleSample
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = new FFTProviderConfig();
            var generator = new RGBGenerator(config);
            
            generator.Run();                        

            Console.ReadKey(true);
            generator.Stop();
        }
    }
}
