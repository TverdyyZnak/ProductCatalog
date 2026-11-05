using System.Net;

namespace Application.Commons.Exceptions
{
    public class UnprocessableEntityException : BaseException
    {
        public override HttpStatusCode StatusCode => HttpStatusCode.UnprocessableEntity;

        public UnprocessableEntityException(string message) : base(message)
        {

        }
    }
}
