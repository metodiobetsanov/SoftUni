namespace BashSoft.IO
{
    using Static;
    using System;

    public class InputReader
    {
        private const string EndCommand = "quit";

        private CommandInterpreter interpreter;

        public InputReader(CommandInterpreter commandInterpreter)
        {
            this.interpreter = commandInterpreter;
        }

        public void StartReadingCommands()
        {
            while (true)
            {
                OutputWriter.WriteMessage($"{SessionData.CurrentPath}>");
                string input = Console.ReadLine();
                input = input.Trim();

                if (input == EndCommand)
                {
                    break;
                }

                this.interpreter.InterpredCommand(input);
            }
        }
    }
}