namespace BashSoft.Exceptions
{
    using System;

    public class UnableToParseNumberException : Exception
    {
        private const string UnableToParseNumber = "The sequence you've written is not a valid number.";

        public UnableToParseNumberException()
            : base(UnableToParseNumber)
        {
        }

        public UnableToParseNumberException(string message)
            : base(message)
        {
        }
    }
}