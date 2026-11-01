using System.Net;

namespace Domain.Exceptions
{
    public class InternalServerErrorException : BaseException
    {
        public override HttpStatusCode StatusCode => HttpStatusCode.InternalServerError;

        public InternalServerErrorException(string message) : base(message)
        {
            
        }
    }
}
