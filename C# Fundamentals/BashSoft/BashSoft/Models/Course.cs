// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Course.cs" company="MetodiObetsanov@SoftUni">
//   Copyright (c) MetodiObetsanov@SoftUni. All rights reserved.
// </copyright>
// <summary>
//   Defines the Course type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BashSoft.Models
{
    using System.Collections.Generic;
    using Exceptions;

    /// <summary>
    /// The course class.
    /// </summary>
    public class Course
    {
        /// <summary>
        /// The number of tasks on exam.
        /// </summary>
        public const int NumberOfTasksOnExam = 5;

        /// <summary>
        /// The max score on exam task.
        /// </summary>
        public const int MaxScoreOnExamTask = 100;

        /// <summary>
        /// The name of the course.
        /// </summary>
        private string name;

        /// <summary>
        /// All students enrolled for this course.
        /// </summary>
        private Dictionary<string, Student> studentsByName;

        /// <summary>
        /// Initializes a new instance of the <see cref="Course"/> class.
        /// </summary>
        /// <param name="courseName">
        /// Sets the course name.
        /// </param>
        public Course(string courseName)
        {
            this.Name = courseName;
            this.studentsByName = new Dictionary<string, Student>();
        }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <exception cref="InvalidStringException">Throw an exception if the value is null or empty
        /// </exception>
        public string Name
        {
            get => this.name;

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new InvalidStringException();
                }

                this.name = value;
            }
        }

        /// <summary>
        /// Get students by name.
        /// </summary>
        public IReadOnlyDictionary<string, Student> StudentsByName => this.studentsByName;

        /// <summary>
        /// Enroll student fot this course.
        /// </summary>
        /// <param name="student">
        /// The student.
        /// </param>
        /// <exception cref="DuplicateEntryInStructureException">Throws an exception if the students is already in the course
        /// </exception>
        public void EnrollStudent(Student student)
        {
            if (this.studentsByName.ContainsKey(student.UserName))
            {
                throw new DuplicateEntryInStructureException(student.UserName, this.Name);
            }

            this.studentsByName.Add(student.UserName, student);

        }
    }
}
