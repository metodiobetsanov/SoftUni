// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PrintOrderedStudentsCommand.cs" company="MetodiObetsanov@SoftUni">
//   Copyright (c) MetodiObetsanov@SoftUni. All rights reserved.
// </copyright>
// <summary>
//   Defines the PrintOrderedStudentsCommand type.
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
    /// The print ordered students command.
    /// </summary>
    public class PrintOrderedStudentsCommand : Command
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PrintOrderedStudentsCommand"/> class.
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
        public PrintOrderedStudentsCommand(string input, string[] data, Tester judge, StudentsRepository repository, IOManager inputOutputManager) : base(input, data, judge, repository, inputOutputManager)
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
            if (this.Data.Length != 5)
            {
                throw new InvalidCommandException(this.Input);
            }

            string courseName = this.Data[1];
            string comparison = this.Data[2].ToLower();
            string takeCommand = this.Data[3].ToLower();
            string takeQuantity = this.Data[4].ToLower();

            this.TryParseParametersForOrderAndTake(courseName, comparison, takeCommand, takeQuantity);
        }

        /// <summary>
        /// The try parse parameters for order and take.
        /// </summary>
        /// <param name="courseName">
        /// The course name.
        /// </param>
        /// <param name="comparison">
        /// The comparison.
        /// </param>
        /// <param name="takeCommand">
        /// The take command.
        /// </param>
        /// <param name="takeQuantity">
        /// The take quantity.
        /// </param>
        private void TryParseParametersForOrderAndTake(string courseName, string comparison, string takeCommand, string takeQuantity)
        {
            if (takeCommand == "take")
            {
                if (takeQuantity == "all")
                {
                    this.Repository.OrderAndTake(courseName, comparison);
                }
                else
                {
                    int studentsToTake;
                    bool hasParsed = int.TryParse(takeQuantity, out studentsToTake);

                    if (hasParsed)
                    {
                        this.Repository.OrderAndTake(courseName, comparison, studentsToTake);
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
