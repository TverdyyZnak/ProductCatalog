using System.Net;

namespace Application.Commons.Exceptions
{
    public class AlreadyTakenException : BaseException
    {
        public override HttpStatusCode StatusCode => HttpStatusCode.Conflict;

        public AlreadyTakenException(string message) : base(message)
        {

        }
    }
}
