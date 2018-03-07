// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InputReader.cs" company="MetodiObetsanov@SoftUni">
//   Copyright (c) MetodiObetsanov@SoftUni. All rights reserved.
// </copyright>
// <summary>
//   Defines the InputReader type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BashSoft.IO
{
    using System;
    using Static;

    /// <summary>
    /// InputReader Class
    /// </summary>
    public class InputReader
    {
        /// <summary>
        /// Termination command.
        /// </summary>
        private const string EndCommand = "quit";

        /// <summary>
        /// CommandInterpreter instance.
        /// </summary>
        private CommandInterpreter interpreter;

        /// <summary>
        /// Initializes a new instance of the <see cref="InputReader"/> class.
        /// </summary>
        /// <param name="commandInterpreter">
        /// The command interpreter.
        /// </param>
        public InputReader(CommandInterpreter commandInterpreter)
        {
            this.interpreter = commandInterpreter;
        }

        /// <summary>
        /// Start reading commands and pass it to the command interpreter.
        /// </summary>
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

