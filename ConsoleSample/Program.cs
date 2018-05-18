using System;
using FFTtoRGB;
using FFTtoRGB.Color;

namespace ConsoleSample
{
    class Program
    {
        static void Main(string[] args)
        {
            var generator = new RGBGenerator();
            generator.ColorGenerated += OnColorGenerated;
            
            generator.Run();                        

            Console.ReadKey(true);
            generator.Stop();
        }

        private static void OnColorGenerated(object sender, GenericEventArgs<RGB> e) => Console.WriteLine(e.Data);
    }
}
