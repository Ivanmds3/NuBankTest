using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            Console.WriteLine("Hi you it's executing project test to software engineer NuBank, type 'E' when you wanna to exit.");
            while(true)
            {
                var commandLine = Console.ReadLine();
                CommandLineEngine.GetCommand(commandLine).Do();
            }
        }
    }
}
