// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CourseNotFoundException.cs" company="MetodiObetsanov@SoftUni">
//   Copyright (c) MetodiObetsanov@SoftUni. All rights reserved.
// </copyright>
// <summary>
//   The course not found exception.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BashSoft.Exceptions
{
    using System;

    /// <summary>
    /// The course not found exception.
    /// </summary>
    public class CourseNotFoundException : Exception
    {
        /// <summary>
        /// Exception message.
        /// </summary>
        private const string NotEnrolledInCourse = "Student must be enrolled in a course before you set his mark.";

        /// <summary>
        /// Initializes a new instance of the <see cref="CourseNotFoundException"/> class.
        /// </summary>
        public CourseNotFoundException()
            : base(NotEnrolledInCourse)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CourseNotFoundException"/> class.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        public CourseNotFoundException(string message)
            : base(message)
        {
        }
    }
}
