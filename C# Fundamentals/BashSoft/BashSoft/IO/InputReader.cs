using System;

public  class InputReader
{
    private const string endCommand = "quit";
    private CommandInterpreter interpreter;

    public InputReader(CommandInterpreter commandInterpreter)
    {
        this.interpreter = commandInterpreter;
    }

    public  void StartReadingCommands()
    {     
        while (true)
        {
            OutputWriter.WriteMessage($"{SessionData.currentPath}>");
            string input = Console.ReadLine();
            input = input.Trim();

            if (input == endCommand)
            {
                break;
            }

            this.interpreter.InterpredCommand(input);

        }
    }
}

