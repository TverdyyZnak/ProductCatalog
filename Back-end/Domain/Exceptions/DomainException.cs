namespace Domain.Exceptions
{
    public abstract class DomainException : Exception
    {
        public abstract System.Net.HttpStatusCode StatusCode { get; }

        protected DomainException(string message) : base(message) 
        {
        }
    }
}
