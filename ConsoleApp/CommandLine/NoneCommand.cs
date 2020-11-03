using System;

namespace ConsoleApp.CommandLine
{
    public class NoneCommand : ICommand
    {
        public void Do()
        {
            Console.WriteLine("Please, try again!\n");
        }
    }
}
