namespace SIS.HTTP.Exceptions
{
    using SIS.HTTP.Enums;

    using System;

    public class BadRequestException : Exception
    {
        public const HttpStatusCode statusCode = HttpStatusCode.Badrequest;

        public BadRequestException()
            : base("The Request was malformed or contains unsupported elements.")
        {
        }

        public BadRequestException(string text)
            : base(text)
        {
        }
    }
}