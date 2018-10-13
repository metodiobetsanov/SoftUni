namespace SIS.HTTP.Exceptions
{
    using SIS.HTTP.Enums;

    using System;

    public class InternalServerErrorException : Exception
    {
        public const HttpStatusCode statusCode = HttpStatusCode.InternalServerError;

        public InternalServerErrorException()
            : base("The Server has encountered an error.")
        {
        }

        public InternalServerErrorException(string text)
            : base(text)
        {
        }
    }
}