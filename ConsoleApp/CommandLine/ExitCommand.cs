using System;

namespace ConsoleApp.CommandLine
{
    public class ExitCommand : ICommand
    {
        public void Do()
        {
            Environment.Exit(0);
        }
    }
}
