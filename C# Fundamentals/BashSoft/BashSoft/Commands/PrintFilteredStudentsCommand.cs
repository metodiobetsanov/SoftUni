// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PrintFilteredStudentsCommand.cs" company="MetodiObetsanov@SoftUni">
//   Copyright (c) MetodiObetsanov@SoftUni. All rights reserved.
// </copyright>
// <summary>
//   Defines the PrintFilteredStudentsCommand type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BashSoft.Commands
{
    using Exceptions;
    using IO;
    using Judge;
    using Repository;
    using Static;

    /// <summary>
    /// The print filtered students command.
    /// </summary>
    public class PrintFilteredStudentsCommand : Command
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PrintFilteredStudentsCommand"/> class.
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
        public PrintFilteredStudentsCommand(string input, string[] data, Tester judge, StudentsRepository repository, IOManager inputOutputManager) : base(input, data, judge, repository, inputOutputManager)
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
        /// <exception cref="InvalidCommandException">Throws an exception if there is no such command
        /// </exception>
        private void CommandExecution()
        {
            if (this.Data.Length != 5)
            {
                throw new InvalidCommandException(this.Input);
            }

            string courseName = this.Data[1];
            string filter = this.Data[2].ToLower();
            string takeCommand = this.Data[3].ToLower();
            string takeQuantity = this.Data[4].ToLower();

            this.TryParseParametersForFilterAndTake(courseName, filter, takeCommand, takeQuantity);
        }

        /// <summary>
        /// The try parse parameters for filter and take.
        /// </summary>
        /// <param name="courseName">
        /// The course name.
        /// </param>
        /// <param name="filter">
        /// The filter.
        /// </param>
        /// <param name="takeCommand">
        /// The take command.
        /// </param>
        /// <param name="takeQuantity">
        /// The take quantity.
        /// </param>
        private void TryParseParametersForFilterAndTake(string courseName, string filter, string takeCommand, string takeQuantity)
        {
            if (takeCommand == "take")
            {
                if (takeQuantity == "all")
                {
                    this.Repository.FilterAndTake(courseName, filter);
                }
                else
                {
                    int studentsToTake;
                    bool hasParsed = int.TryParse(takeQuantity, out studentsToTake);

                    if (hasParsed)
                    {
                        this.Repository.FilterAndTake(courseName, filter, studentsToTake);
                    }
                    else
                    {
                        OutputWriter.DisplayException(ExceptionMessages.InvalidTakeQuantityParameter);
                    }
                }
            }
            else
            {
                OutputWriter.DisplayException(ExceptionMessages.InvalidTakeQuantityParameter);
            }
        }
    }
}
