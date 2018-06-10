namespace WebServer.Server.Exceptions
{
    using System;

    public class BadRequestException : Exception
    {
        public BadRequestException()
            : base("Invalid Request lines")
        {
        }

        public BadRequestException(string text)
            : base(text)
        {
        }
    }
}