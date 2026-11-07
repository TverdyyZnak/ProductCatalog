using System.Net;

namespace Application.Commons.Exceptions
{
    public class InternalServerErrorException : BaseException
    {
        public override HttpStatusCode StatusCode => HttpStatusCode.InternalServerError;

        public InternalServerErrorException(string message) : base(message)
        {

        }
    }
}
