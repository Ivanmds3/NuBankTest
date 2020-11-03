using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hi, type 'E' when you wanna to exit.");
            while(true)
            {
                var commandLine = Console.ReadLine();
                CommandLineEngine.GetCommand(commandLine).Do();
            }
        }
    }
}
