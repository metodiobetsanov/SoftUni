// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ChangeAbsolutePathCommand.cs" company="MetodiObetsanov@SoftUni">
//   Copyright (c) MetodiObetsanov@SoftUni. All rights reserved.
// </copyright>
// <summary>
//   Defines the ChangeAbsolutePathCommand type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BashSoft.Commands
{
    using Exceptions;
    using IO;
    using Judge;
    using Repository;

    /// <summary>
    /// The change absolute path command.
    /// </summary>
    public class ChangeAbsolutePathCommand : Command
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ChangeAbsolutePathCommand"/> class.
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
        public ChangeAbsolutePathCommand(string input, string[] data, Tester judge, StudentsRepository repository, IOManager inputOutputManager) : base(input, data, judge, repository, inputOutputManager)
        {
        }

        /// <summary>
        /// Execute method.
        /// </summary>
        public override void Execute()
        {
            this.CommandExecution();
        }

        /// <summary>
        /// The command execution.
        /// </summary>
        /// <exception cref="InvalidCommandException">Throws an exception if the command is not valid
        /// </exception>
        private void CommandExecution()
        {
            if (this.Data.Length != 2)
            {
                throw new InvalidCommandException(this.Input);
            }

            string absPath = this.Data[1];
            this.InputOutputManager.ChangeCurrentDirectoryAbsolute(absPath);
        }
    }
}
