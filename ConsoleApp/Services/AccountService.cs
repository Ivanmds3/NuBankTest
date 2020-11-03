using ConsoleApp.Dtos;

namespace ConsoleApp.Services
{
    public class AccountService
    {
        private static Account _account;

        public Result Create(Account account)
        {
            if(_account is null)
            {
                _account = account;
                return Result.Ok();
            }

            return Result.Fail("account-alreadyinitialized");
        }

        public Account Get() => _account;

        public Result Debit(long amount)
        {
            var result = Validate(amount);

            if (result.Success == false) return result;

            _account.AvailableLimit -= amount;
            return Result.Ok();
        }


        private Result Validate(long amount)
        {
            if (_account is null) return Result.Fail("account-not-initialized");

            if (_account.AvailableLimit < amount) return Result.Fail("insufficient-limit");

            if (_account.ActiveCard == false) return Result.Fail("card-not-active");

            return Result.Ok();
        }
    }
}
