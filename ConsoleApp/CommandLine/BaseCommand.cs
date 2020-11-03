namespace ConsoleApp.CommandLine
{
    public abstract class BaseCommand
    {
        protected string CommandLine { get; private set; }
        public BaseCommand(string commandLine) => CommandLine = commandLine;
    }
}
