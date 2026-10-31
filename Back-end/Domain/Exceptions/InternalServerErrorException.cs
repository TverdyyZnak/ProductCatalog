using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class InternalServerErrorException : DomainException
    {
        public override HttpStatusCode StatusCode => HttpStatusCode.InternalServerError;

        public InternalServerErrorException(string message) : base(message)
        {
            
        }
    }
}
