using ConsoleApp.Services;
using ConsoleApp.Wraps;
using System;
using System.Text.Json;

namespace ConsoleApp.CommandLine
{
    public class TransactionProcessCommand : BaseCommand, ICommand
    {
        public TransactionProcessCommand(string commandLine) : base(commandLine) { }

        public void Do()
        {
            var jsonOpt = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var wrap = JsonSerializer.Deserialize<TransactionWrap>(CommandLine, jsonOpt);

            var accountService = new AccountService();
            var transactionService = new TransactionService();
            var result = transactionService.ToProcess(wrap.Transaction);

            var accountWrap = new AccountWrap() { Account = accountService.Get(), Violations = result.Errors };

            Console.WriteLine($"{JsonSerializer.Serialize(accountWrap, jsonOpt)}\n");
        }
    }
}
