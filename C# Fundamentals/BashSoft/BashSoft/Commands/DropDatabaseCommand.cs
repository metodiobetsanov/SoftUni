// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DropDatabaseCommand.cs" company="MetodiObetsanov@SoftUni">
//   Copyright (c) MetodiObetsanov@SoftUni. All rights reserved.
// </copyright>
// <summary>
//   Defines the DropDatabaseCommand type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BashSoft.Commands
{
    using Exceptions;
    using IO;
    using Judge;
    using Repository;

    /// <summary>
    /// The drop database command.
    /// </summary>
    public class DropDatabaseCommand : Command
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DropDatabaseCommand"/> class.
        /// </summary>
        /// <param name="input">
        /// The input.
        /// </param>
        /// <param name="data">
        /// The data.
        /// </param>
        /// <param name="judge">
        /// The judge.
        /// </param>
        /// <param name="repository">
        /// The repository.
        /// </param>
        /// <param name="inputOutputManager">
        /// The input output manager.
        /// </param>
        public DropDatabaseCommand(string input, string[] data, Tester judge, StudentsRepository repository, IOManager inputOutputManager) : base(input, data, judge, repository, inputOutputManager)
        {
        }

        /// <summary>
        /// The execute.
        /// </summary>
        public override void Execute()
        {
            CommandExecution();
        }

        /// <summary>
        /// The command execution.
        /// </summary>
        /// <exception cref="InvalidCommandException">Throws an exception if there is no such command
        /// </exception>
        private void CommandExecution()
        {
            if (this.Data.Length != 1)
            {
                throw new InvalidCommandException(this.Input);
            }

            this.Repository.UnloadData();
            OutputWriter.WriteMessageOnNewLine("Database dropped!");
        }
    }
}
