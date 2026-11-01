namespace Domain.Primitives
{
    public class Result<T>
    {
        public T? Value { get; }
        public IReadOnlyCollection<ErrorObject> Error { get; }
        public bool IsSuccess => !Error.Any();
        
        public Result(T? value, List<ErrorObject> errors)
        {
            Value = value;
            Error = errors;
        }

        public static Result<T> Success(T value)
        {
            return new Result<T>(value, new List<ErrorObject>());
        }

        public static Result<T> Fail(List<ErrorObject> errors)
        {
            return new Result<T>(default, errors);
        }

        public static Result<T> Fail(ErrorObject error)
        {
            List<ErrorObject> errorList = new List<ErrorObject>();
            errorList.Add(error);
            return new Result<T>(default, errorList);
        }
    }
}
