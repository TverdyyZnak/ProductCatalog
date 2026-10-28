
namespace Domain.Primitives
{
    public class Result<T>
    {
        public T? Value { get; }
        public IReadOnlyCollection<string> Error { get; }
        public bool IsSuccess => Error.Any();
        
        public Result(T? value, List<string> errors)
        {
            Value = value;
            Error = errors;
        }

        public static Result<T> Success(T value)
        {
            return new Result<T>(value, new List<string>());
        }

        public static Result<T> Fail(List<string> errors)
        {
            return new Result<T>(default, errors);
        }
    }
}
