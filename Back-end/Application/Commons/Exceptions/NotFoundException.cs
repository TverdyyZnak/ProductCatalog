using System.Net;

namespace Application.Commons.Exceptions
{
    public class NotFoundException : BaseException
    {
        public override HttpStatusCode StatusCode => HttpStatusCode.NotFound;

        public NotFoundException(string message) : base(message)
        {

        }
    }
}
