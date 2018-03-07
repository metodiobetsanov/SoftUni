// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CommandInterpreter.cs" company="MetodiObetsanov@SoftUni">
//   Copyright (c) MetodiObetsanov@SoftUni. All rights reserved.
// </copyright>
// <summary>
//   Defines the CommandInterpreter type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BashSoft.IO
{
    using System;
    using Commands;
    using Exceptions;
    using Judge;
    using Repository;

    /// <summary>
    /// CommandInterpreter Class.
    /// </summary>
    public class CommandInterpreter
    {
        /// <summary>
        /// Tester field.
        /// </summary>
        private Tester judge;

        /// <summary>
        /// StudentsRepository field.
        /// </summary>
        private StudentsRepository repository;

        /// <summary>
        /// IOManager field.
        /// </summary>
        private IOManager inputOutputManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandInterpreter"/> class.
        /// </summary>
        /// <param name="tester">
        /// Pass the <see cref="Tester"/> to this class.
        /// </param>
        /// <param name="data">
        /// Pass the <see cref="StudentsRepository"/> to this class.
        /// </param>
        /// <param name="manager">
        /// Pass the  <see cref="IOManager"/> to this class.
        /// </param>
        public CommandInterpreter(Tester tester, StudentsRepository data, IOManager manager)
        {
            this.judge = tester;
            this.repository = data;
            this.inputOutputManager = manager;
        }

        /// <summary>
        /// Take the command from the input and pass it to the ParseCommand method, then execute the command.
        /// </summary>
        /// <param name="input">
        /// The input.
        /// </param>
        public void InterpredCommand(string input)
        {
            string[] data = input.Split(' ');
            string commandName = data[0].ToLower();

            try
            {
                Command command = this.ParseCommand(input, data, commandName);
                command.Execute();
            }
            catch (Exception ex)
            {
                OutputWriter.DisplayException(ex.Message);
            }

        }

        /// <summary>
        /// The parse command.
        /// </summary>
        /// <param name="input">
        /// The input.
        /// </param>
        /// <param name="data">
        /// The data.
        /// </param>
        /// <param name="commandName">
        /// The command name.
        /// </param>
        /// <returns>
        /// Returns <see cref="Command"/>.
        /// </returns>
        /// <exception cref="InvalidCommandException">Throws an exception if there is no such command
        /// </exception>
        private Command ParseCommand(string input, string[] data, string commandName)
        {
            switch (commandName)
            {
                case "open":
                    return new OpenFileCommand(input, data, this.judge, this.repository, this.inputOutputManager);
                case "mkdir":
                    return new MakeDirectoryCommand(input, data, this.judge, this.repository, this.inputOutputManager);
                case "is":
                    return new TraverseFoldersCommand(input, data, this.judge, this.repository, this.inputOutputManager);
                case "cmp":
                    return new CompareFilesCommand(input, data, this.judge, this.repository, this.inputOutputManager);
                case "cdrel":
                    return new ChangeRelativePathCommand(input, data, this.judge, this.repository, this.inputOutputManager);
                case "cdabs":
                    return new ChangeAbsolutePathCommand(input, data, this.judge, this.repository, this.inputOutputManager);
                case "readdb":
                    return new ReadDatabaseCommand(input, data, this.judge, this.repository, this.inputOutputManager);
                case "dropdb":
                    return new DropDatabaseCommand(input, data, this.judge, this.repository, this.inputOutputManager);
                case "help":
                    return new GetHelpCommand(input, data, this.judge, this.repository, this.inputOutputManager);
                case "filter":
                    return new PrintFilteredStudentsCommand(input, data, this.judge, this.repository, this.inputOutputManager);
                case "order":
                    return new PrintOrderedStudentsCommand(input, data, this.judge, this.repository, this.inputOutputManager);
                //case "download": TO DO

                //case "downloadasync": TO DO

                case "show":
                    return new ShowCourseCommand(input, data, this.judge, this.repository, this.inputOutputManager);

                default:
                    throw new InvalidCommandException(input);
            }
        }
    }
}
