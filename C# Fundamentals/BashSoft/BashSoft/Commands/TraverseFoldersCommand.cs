// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TraverseFoldersCommand.cs" company="MetodiObetsanov@SoftUni">
//   Copyright (c) MetodiObetsanov@SoftUni. All rights reserved.
// </copyright>
// <summary>
//   Defines the TraverseFoldersCommand type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BashSoft.Commands
{
    using Exceptions;
    using IO;
    using Judge;
    using Repository;

    /// <summary>
    /// The traverse folders command.
    /// </summary>
    public class TraverseFoldersCommand : Command
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TraverseFoldersCommand"/> class.
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
        public TraverseFoldersCommand(string input, string[] data, Tester judge, StudentsRepository repository, IOManager inputOutputManager) : base(input, data, judge, repository, inputOutputManager)
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
        /// <exception cref="UnableToParseNumberException">Throws an exception if the item can't be parsed to int
        /// </exception>
        /// <exception cref="InvalidCommandException">Throws an exception if there is no such command
        /// </exception>
        private void CommandExecution()
        {
            if (this.Data.Length == 1)
            {
                this.InputOutputManager.TraverseDirectory(0);
            }
            else if (this.Data.Length == 2)
            {
                int depth;
                if (int.TryParse(this.Data[1], out depth))
                {
                    this.InputOutputManager.TraverseDirectory(depth);
                }
                else
                {
                    throw new UnableToParseNumberException(this.Input);
                }
            }
            else
            {
                throw new InvalidCommandException(this.Input);
            }
        }
    }
}
