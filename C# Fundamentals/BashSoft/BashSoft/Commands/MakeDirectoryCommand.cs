// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MakeDirectoryCommand.cs" company="MetodiObetsanov@SoftUni">
//   Copyright (c) MetodiObetsanov@SoftUni. All rights reserved.
// </copyright>
// <summary>
//   Defines the MakeDirectoryCommand type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BashSoft.Commands
{
    using Exceptions;
    using IO;
    using Judge;
    using Repository;

    /// <summary>
    /// The make directory command.
    /// </summary>
    public class MakeDirectoryCommand : Command
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MakeDirectoryCommand"/> class.
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
        public MakeDirectoryCommand(string input, string[] data, Tester judge, StudentsRepository repository, IOManager inputOutputManager) : base(input, data, judge, repository, inputOutputManager)
        {
        }

        /// <summary>
        /// The execute.
        /// </summary>
        public override void Execute()
        {
            this.CommandExecution();
        }

        /// <summary>
        /// The command execution.
        /// </summary>
        /// <exception cref="InvalidCommandException">
        /// </exception>
        private void CommandExecution()
        {
            if (this.Data.Length != 2)
            {
                throw new InvalidCommandException(this.Input);
            }

            string foldereName = this.Data[1];
            this.InputOutputManager.CreateDirectoryInCurrentFolder(foldereName);
        }
    }
}
