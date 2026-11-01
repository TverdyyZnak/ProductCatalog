using System.Net;

namespace Domain.Exceptions
{
    public class UnprocessableEntityException : BaseException
    {
        public override HttpStatusCode StatusCode => HttpStatusCode.UnprocessableEntity;

        public UnprocessableEntityException(string message) : base(message)
        {
            
        }
    }
}
