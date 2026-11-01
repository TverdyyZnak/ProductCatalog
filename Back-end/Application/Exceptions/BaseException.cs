namespace Domain.Exceptions
{
    public abstract class BaseException : Exception
    {
        public abstract System.Net.HttpStatusCode StatusCode { get; }

        protected BaseException(string message) : base(message) 
        {
        }
    }
}
