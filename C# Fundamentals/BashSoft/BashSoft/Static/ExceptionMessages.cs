// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ExceptionMessages.cs" company="MetodiObetsanov@SoftUni">
//   Copyright (c) MetodiObetsanov@SoftUni. All rights reserved.
// </copyright>
// <summary>
//   Exception Messages class of BashSoft, contains all the messages used
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BashSoft.Static
{
    /// <summary>
    /// Exception Messages class of BashSoft, contains all the messages used
    /// </summary>
    public static class ExceptionMessages
    {
        /// <summary>
        /// Output message
        /// </summary>
        public const string DataAlreadyInitializedException = "Data is already initialized!";

        /// <summary>
        /// Output message
        /// </summary>
        public const string DataNotInitializedExceptionMessage = "The data structure must be initialized first in order to make any operations with it.";

        /// <summary>
        /// Output message
        /// </summary>
        public const string InexistingCourseInDataBase = "The course you are trying to get does not exist in the data base!";

        /// <summary>
        /// Output message
        /// </summary>
        public const string InexistingStudentInDataBase = "The user name for the student you are trying to get does not exist!";

        /// <summary>
        /// Output message
        /// </summary>
        public const string InvalidPath = "The folder/file you are trying to access at the current address, does not exist.";

        /// <summary>
        /// Output message
        /// </summary>
        public const string UnauthorizedAccessException = "The folder/file you are trying to get access needs a higher level of rights than you currently have.";

        /// <summary>
        /// Output message
        /// </summary>
        public const string ComparisonOfFilesWithDifferentSizes = "Files not of equal size, certain mismatch.";

        /// <summary>
        /// Output message
        /// </summary>
        public const string ForbiddenSymbolsContainedInName = "The given name contains symbols that are not allowed to be used in names of files and folders.";

        /// <summary>
        /// Output message
        /// </summary>
        public const string UnableToGoHigherInPartitionHierarchy = "Unable to go higher in partition hierarchy";

        /// <summary>
        /// Output message
        /// </summary>
        public const string UnableToParseNumber = "The sequence you've written is not a valid number.";

        /// <summary>
        /// Output message
        /// </summary>
        public const string InvalidStudentFilter = "The given filter is not one of the following: excellent/average/poor";

        /// <summary>
        /// Output message
        /// </summary>
        public const string InvalidComparisonQuery = "The comparison query you want, does not exist in the context of the current program!";

        /// <summary>
        /// Output message
        /// </summary>
        public const string InvalidTakeQuantityParameter = "The take command expected does not match the format wanted!";

        /// <summary>
        /// Output message
        /// </summary>
        public const string StudentAlreadyEnrolledInGivenCourse = "The {0} already exists in {1}.";

        /// <summary>
        /// Output message
        /// </summary>
        public const string NotEnrolledInCourse = "Student must be enrolled in a course before you set his mark.";

        /// <summary>
        /// Output message
        /// </summary>
        public const string InvalidNumberOfScores = "The number of scores for the given course is greater than the possible.";

        /// <summary>
        /// Output message
        /// </summary>
        public const string InvalidScore = "The number for the score you've entered is not in the range of 0 - 100";

        /// <summary>
        /// Output message
        /// </summary>
        public const string NullOrEmptyValue = "The value of the variable CANNOT be null or empty!";

        /// <summary>
        /// Output message
        /// </summary>
        public const string InvalidDestination = "The destination is not valid";
    }
}