using Domain.Primitives.Enums;

namespace Domain.Primitives
{
    public record ErrorObject
    {
        public ErrorType Type { get; }
        public string ErrorText { get; }

        public ErrorObject(ErrorType type, string errorText)
        {
            Type = type;
            ErrorText = errorText;
        }
    }
}
