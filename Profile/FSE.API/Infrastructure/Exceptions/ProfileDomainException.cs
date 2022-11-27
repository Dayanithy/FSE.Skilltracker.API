namespace FSE.API.Infrastructure.Exceptions
{
    public class ProfileDomainException : Exception
    {
        public ProfileDomainException()
        {

        }

        public ProfileDomainException(string message) : base(message)
        {

        }

        public ProfileDomainException(string message, Exception exception) : base(message, exception)
        {

        }
    }
}
