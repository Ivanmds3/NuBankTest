using ConsoleApp.Services;
using ConsoleApp.Wraps;
using System;
using System.Text.Json;

namespace ConsoleApp.CommandLine
{
    public class AccountProcessCommand : BaseCommand, ICommand
    {
        public AccountProcessCommand(string commandLine) : base(commandLine) { }
        public void Do()
        {
            var jsonOpt = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

            var wrap = JsonSerializer.Deserialize<AccountWrap>(CommandLine, jsonOpt);

            var accountService = new AccountService();
            var result = accountService.Create(wrap.Account);

            wrap.Violations = result.Errors;

            Console.WriteLine($"{JsonSerializer.Serialize(wrap, jsonOpt)}\n");
        }
    }
}
