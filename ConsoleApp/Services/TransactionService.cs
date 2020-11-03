using ConsoleApp.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp.Services
{
    public class TransactionService
    {
        private readonly AccountService _accountService;
        private static List<Transaction> _transactions;

        public TransactionService()
        {
            _accountService = new AccountService();

            if (_transactions is null)
                _transactions = new List<Transaction>();
        }

        public Result ToProcess(Transaction transaction)
        {
            var result = Validate(transaction);

            if (result.Success == false) return result;

            var resultAccount = _accountService.Debit(transaction.Amount);
            if (resultAccount.Success) _transactions.Add(transaction);

            return resultAccount;
        }


        private Result Validate(Transaction transaction)
        {
            var isDoubleTransaction = IsDoubleTransaction(transaction);
            if (isDoubleTransaction) return Result.Fail("doubled-transaction");

            var isHighFrequencyInASmallInterval = IsHighFrequencyInASmallInterval();
            if (isHighFrequencyInASmallInterval) return Result.Fail("high-frequency-small-interval");

            return Result.Ok();
        }

        private bool IsHighFrequencyInASmallInterval() => _transactions.Where(t => t.Time >= DateTime.Now.AddMinutes(-2)).Count() >= 2;

        private bool IsDoubleTransaction(Transaction transaction)
            => _transactions.Where(t =>
            t.Merchant == transaction.Merchant &&
            t.Amount == transaction.Amount &&
            t.Time >= DateTime.Now.AddMinutes(-2)).Count() >= 2;
    }
}
