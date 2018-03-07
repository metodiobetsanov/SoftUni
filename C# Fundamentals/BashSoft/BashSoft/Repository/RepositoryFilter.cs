// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RepositoryFilter.cs" company="MetodiObetsanov@SoftUni">
//   Copyright (c) MetodiObetsanov@SoftUni. All rights reserved.
// </copyright>
// <summary>
//   The repository filter class.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace BashSoft.Repository
{
    using System;
    using System.Collections.Generic;
    using BashSoft.IO;
    using BashSoft.Static;

    /// <summary>
    /// Collection filter class.
    /// </summary>
    public class RepositoryFilter
    {
        /// <summary>
        /// Selects one of the filters, and pass the data to the private method.
        /// If no filter is choosen prints a exception message
        /// </summary>
        /// <param name="studentsWithMarks">
        /// The students with marks.
        /// </param>
        /// <param name="wantedFilter">
        /// The wanted filter.
        /// </param>
        /// <param name="studentsToTake">
        /// The students to take.
        /// </param>
        public void FilterAndTake(Dictionary<string, double> studentsWithMarks, string wantedFilter, int studentsToTake)
        {
            wantedFilter = wantedFilter.ToLower();

            if (wantedFilter == "excellent")
            {
                this.FilterAndTake(studentsWithMarks, x => x >= 5, studentsToTake);
            }
            else if (wantedFilter == "average")
            {
                this.FilterAndTake(studentsWithMarks, x => x < 5 && x >= 3.5, studentsToTake);
            }
            else if (wantedFilter == "poor")
            {
                this.FilterAndTake(studentsWithMarks, x => x < 3.5, studentsToTake);
            }
            else
            {
                OutputWriter.DisplayException(ExceptionMessages.InvalidStudentFilter);
            }
        }

        /// <summary>
        /// Apply filter to the collection, and select the given amount.
        /// </summary>
        /// <param name="studentsWhitMarks">
        /// The students whit marks.
        /// </param>
        /// <param name="givenFilter">
        /// The given filter.
        /// </param>
        /// <param name="studentsToTake">
        /// The students to take.
        /// </param>
        private void FilterAndTake(Dictionary<string, double> studentsWhitMarks, Predicate<double> givenFilter, int studentsToTake)
        {
            int counterForPrinted = 0;
            foreach (var studentMark in studentsWhitMarks)
            {
                if (counterForPrinted == studentsToTake)
                {
                    break;
                }
            
                if (givenFilter(studentMark.Value))
                {
                    OutputWriter.PrintStudent(studentMark);
                    counterForPrinted++;
                }
            }
        }
    }
}
