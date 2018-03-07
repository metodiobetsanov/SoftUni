// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Student.cs" company="MetodiObetsanov@SoftUni">
//   Copyright (c) MetodiObetsanov@SoftUni. All rights reserved.
// </copyright>
// <summary>
//   Defines the Student type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace BashSoft.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using BashSoft.Exceptions;
    using BashSoft.Static;

    /// <summary>
    /// The student class.
    /// </summary>
    public class Student
    {
        /// <summary>
        /// The user name.
        /// </summary>
        private string userName;

        /// <summary>
        /// The enrolled courses.
        /// </summary>
        private Dictionary<string, Course> enrolledCourses;

        /// <summary>
        /// The marks by course name.
        /// </summary>
        private Dictionary<string, double> marksByCourseName;

        /// <summary>
        /// Initializes a new instance of the <see cref="Student"/> class.
        /// </summary>
        /// <param name="name">
        /// The name.
        /// </param>
        public Student(string name)
        {
            this.UserName = name;
            this.enrolledCourses = new Dictionary<string, Course>();
            this.marksByCourseName = new Dictionary<string, double>();
        }

        /// <summary>
        /// Gets or sets the user name.
        /// </summary>
        /// <exception cref="InvalidStringException">Throw an exception if the value is null or empty
        /// </exception>
        public string UserName
        {
            get => this.userName;

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new InvalidStringException();
                }

                this.userName = value;
            }
        }

        /// <summary>
        /// Gets enrolled courses.
        /// </summary>
        public IReadOnlyDictionary<string, Course> EnrolledCourses => this.enrolledCourses;

        /// <summary>
        /// Gets marks by course name.
        /// </summary>
        public IReadOnlyDictionary<string, double> MarksByCourseName => this.marksByCourseName;

        /// <summary>
        /// Enroll student in course.
        /// </summary>
        /// <param name="course">
        /// Course name.
        /// </param>
        /// <exception cref="DuplicateEntryInStructureException">Throws an exception if the students is already in the course
        /// </exception>
        public void EnrollInCourse(Course course)
        {
            if (this.enrolledCourses.ContainsKey(course.Name))
            {

                throw new DuplicateEntryInStructureException(this.UserName, course.Name);
            }

            this.enrolledCourses.Add(course.Name, course);
        }

        /// <summary>
        /// The set marks in course.
        /// </summary>
        /// <param name="courseName">
        /// The course name.
        /// </param>
        /// <param name="scores">
        /// The scores.
        /// </param>
        /// <exception cref="CourseNotFoundException">Throws an exception if the student is not enrolled for the given course
        /// </exception>
        /// <exception cref="ArgumentException">Throws an exception if the number of grades are more then the tasks in the exam
        /// </exception>
        public void SetMarksInCourse(string courseName, params int[] scores)
        {
            if (!this.enrolledCourses.ContainsKey(courseName))
            {
                throw new CourseNotFoundException();
            }

            if (scores.Length > Course.NumberOfTasksOnExam)
            {
                throw new ArgumentException(ExceptionMessages.InvalidNumberOfScores);
            }

            this.marksByCourseName.Add(courseName, this.CalculateMark(scores));
        }

        /// <summary>
        /// Calculate the score for the course
        /// </summary>
        /// <param name="scores">
        /// The scores.
        /// </param>
        /// <returns>
        /// Returns the score<see cref="double"/>.
        /// </returns>
        private double CalculateMark(int[] scores)
        {
            double percentageOfSolvedExam = scores.Sum() / (double)(Course.NumberOfTasksOnExam * Course.MaxScoreOnExamTask);
            double mark = (percentageOfSolvedExam * 4) + 2;
            return mark;
        }
    }
}
