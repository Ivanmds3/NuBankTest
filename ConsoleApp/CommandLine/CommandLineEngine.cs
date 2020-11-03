using ConsoleApp.CommandLine;

namespace ConsoleApp
{
    public static class CommandLineEngine
    {
        public static ICommand GetCommand(string commandLine)
        {
            if (string.IsNullOrWhiteSpace(commandLine))
                return new NoneCommand();
            else if (commandLine.ToLower() == "e")
                return new ExitCommand();
            else if (commandLine.ToLower().Contains("account"))
                return new AccountProcessCommand(commandLine);
            else if (commandLine.ToLower().Contains("transaction"))
                return new TransactionProcessCommand(commandLine);
            else
                return new NoneCommand();
        }
    }
}
