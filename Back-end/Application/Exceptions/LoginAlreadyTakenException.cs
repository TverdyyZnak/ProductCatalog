using System.Net;

namespace Domain.Exceptions
{
    public class LoginAlreadyTakenException : BaseException
    {
        public override HttpStatusCode StatusCode => HttpStatusCode.Conflict;

        public LoginAlreadyTakenException(string message) : base(message)
        {
            
        }
    }
}
