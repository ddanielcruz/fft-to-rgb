using System;
using FFTtoRGB;

namespace ConsoleSample
{
    class Program
    {
        static void Main(string[] args)
        {
            
            var generator = new RGBGenerator();
            generator.Run();
                        
            Console.ReadKey(true);
        }
    }
}
