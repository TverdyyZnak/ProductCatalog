using System.Net;

namespace Domain.Exceptions
{
    public class LoginAlreadyTakenException : DomainException
    {
        public override HttpStatusCode StatusCode => HttpStatusCode.Conflict;

        public LoginAlreadyTakenException(string message) : base(message)
        {
            
        }
    }
}
