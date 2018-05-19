using System;
using FFTtoRGB;
using FFTtoRGB.Color;
using Transmitter;

namespace ConsoleSample
{
    class Program
    {
        static RGBGenerator Generator;
        static SerialTransmitter Transmitter;

        static void Main(string[] args)
        {
            Generator = new RGBGenerator();
            Generator.ColorGenerated += OnColorGenerated;

            Transmitter = new SerialTransmitter("COM8");
            try
            {
                Transmitter.Open();
                Console.WriteLine("Connection is open.");

                Generator.Run();
                Console.WriteLine("Generating colors...\n");
            }
            catch (UnauthorizedAccessException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine("Press any key to leave...");
            Console.ReadKey(true);

            Generator.Stop();
            Transmitter.Clear();
            Transmitter.Close();
        }

        private static void OnColorGenerated(object sender, GenericEventArgs<RGB> e)
        {
            Transmitter.Write((byte)e.Data.Red);
            Transmitter.Write((byte)e.Data.Green);
            Transmitter.Write((byte)e.Data.Blue);

            System.Diagnostics.Debug.WriteLine(e.Data);
        }
    }
}
