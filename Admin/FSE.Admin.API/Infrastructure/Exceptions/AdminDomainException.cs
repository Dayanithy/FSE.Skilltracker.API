namespace FSE.Admin.API.Infrastructure.Exceptions
{
    public class AdminDomainException : Exception
    {
        public AdminDomainException()
        { }

        public AdminDomainException(string message)
            : base(message)
        { }

        public AdminDomainException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
