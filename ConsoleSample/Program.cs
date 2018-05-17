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
            var generator = new RGBGenerator(config)
            {
                Settings = new FFTtoRGB.Color.ColorSettings(FFTtoRGB.Color.Order.RBG, 0.5, 0.8)
            };
            
            generator.Run();                        

            Console.ReadKey(true);
            generator.Stop();
        }
    }
}
