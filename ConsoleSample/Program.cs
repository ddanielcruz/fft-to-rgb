using System;
using Transmitter;

namespace ConsoleSample
{
    class Program
    {
        static SerialTransmitter Transmitter;

        static void Main(string[] args)
        {
            Transmitter = new SerialTransmitter("COM8");

            try
            {
                Transmitter.Open();
                Console.WriteLine("Connection is open.");

                while (true)
                {
                    try
                    {
                        byte input = Convert.ToByte(Console.ReadLine());
                        if (input == 0)
                            break;

                        Transmitter.Write(input);
                    }
                    catch (OverflowException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    catch (FormatException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }

                Console.WriteLine("Saindo...");
            }
            catch (UnauthorizedAccessException e)
            {
                Console.WriteLine(e.Message);                
            }

            Console.ReadKey(true);
        }
    }
}
