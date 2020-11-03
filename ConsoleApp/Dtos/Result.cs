using System.Linq;

namespace ConsoleApp.Dtos
{
    public class Result
    {
        private Result() { }
        public string[] Errors { get; private set; } = new string[] { };
        public bool Success => Errors.Any() == false;

        public static Result Ok() => new Result();
        public static Result Fail(params string[] errors) => new Result
        {
            Errors = errors
        };
    }
}
