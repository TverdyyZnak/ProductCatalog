using Application.Commons.Exceptions;
using Domain.Primitives;
using Domain.Primitives.Enums;

namespace Application.Commons
{
    public static class ExceptionAnalyst
    {
        public static void ThrowException(IReadOnlyCollection<ErrorObject> objects)
        {
            ErrorObject errorObject = objects.First();
            switch (errorObject.Type)
            {
                case ErrorType.Failure:
                    throw new InternalServerErrorException(errorObject.ErrorText);
                  
                case ErrorType.Validation:
                    throw new UnprocessableEntityException(errorObject.ErrorText);

                case ErrorType.NotFound:
                    throw new NotFoundException(errorObject.ErrorText);

                case ErrorType.Conflict:
                    throw new AlreadyTakenException(errorObject.ErrorText);

                default:
                    throw new InternalServerErrorException("Произошла необработанная ошибка");
                    
            }
        }
    }
}

/*
 public enum ErrorType
    {
        Failure = 0,
        Validation = 1,
        NotFound = 2,
        Conflict = 3,
        Unauthorized = 4,
        Forbidden = 5
    }
 
 */