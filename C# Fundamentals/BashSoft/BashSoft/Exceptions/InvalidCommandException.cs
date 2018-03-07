using System;

public class InvalidCommandException : Exception
{
    private const string InvalidCommand = "The command '{input}' is invalid";

    public InvalidCommandException()
        : base()
    {

    }

    public InvalidCommandException(string input)
        :base(string.Format(InvalidCommand, input))
    {

    }

    
}
