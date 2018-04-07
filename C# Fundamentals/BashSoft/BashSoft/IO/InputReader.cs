namespace BashSoft.IO
{
    using Interfaces;
    using Static;
    using System;

    public class InputReader : IReader
    {
        private const string EndCommand = "quit";

        private IInterpreter interpreter;

        public InputReader(IInterpreter commandInterpreter)
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