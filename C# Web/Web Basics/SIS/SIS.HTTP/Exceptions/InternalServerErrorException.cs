namespace SIS.HTTP.Exceptions
{
    using System;

    public class InternalServerErrorException : Exception
    {
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