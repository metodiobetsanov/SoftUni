// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RepositorySorter.cs" company="MetodiObetsanov@SoftUni">
//   Copyright (c) MetodiObetsanov@SoftUni. All rights reserved.
// </copyright>
// <summary>
//   Defines the RepositorySorter type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace BashSoft.Repository
{
    using System.Collections.Generic;
    using System.Linq;
    using BashSoft.IO;
    using BashSoft.Static;

    /// <summary>
    /// Collecton sorter class.
    /// </summary>
    public class RepositorySorter
    {
        /// <summary>
        /// Selects on of the order types, sort the collection and select the given amount.
        /// If no type is choosen prints a exception message
        /// </summary>
        /// <param name="studentsMark">
        /// The students mark.
        /// </param>
        /// <param name="comparison">
        /// The comparison.
        /// </param>
        /// <param name="studentsToTake">
        /// The students to take.
        /// </param>
        public void OrderAndTake(Dictionary<string, double> studentsMark, string comparison, int studentsToTake)
        {
            comparison = comparison.ToLower();

            if (comparison == "ascending")
            {
                this.PrintStudents(studentsMark.OrderBy(x => x.Value).Take(studentsToTake).ToDictionary(pair => pair.Key, pair => pair.Value));
            }
            else if (comparison == "descending")
            {
                this.PrintStudents(studentsMark.OrderByDescending(x => x.Value).Take(studentsToTake).ToDictionary(pair => pair.Key, pair => pair.Value));
            }
            else
            {
                OutputWriter.DisplayException(ExceptionMessages.InvalidComparisonQuery);
            }
        }

        /// <summary>
        /// Print the students from the given collection
        /// </summary>
        /// <param name="studentsSorted">
        /// Sorted students collection
        /// </param>
        private void PrintStudents(Dictionary<string, double> studentsSorted)
        {
            foreach (var student in studentsSorted)
            {
                OutputWriter.PrintStudent(student);
            }
        }

    }
}