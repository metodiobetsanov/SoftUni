namespace BashSoft.Models
{
    using Exceptions;
    using Interfaces;
    using Static;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Student : IStudent
    {
        private string userName;

        private Dictionary<string, ICourse> enrolledCourses;

        private Dictionary<string, double> marksByCourseName;

        public Student(string name)
        {
            this.UserName = name;
            this.enrolledCourses = new Dictionary<string, ICourse>();
            this.marksByCourseName = new Dictionary<string, double>();
        }

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

        public IReadOnlyDictionary<string, ICourse> EnrolledCourses => this.enrolledCourses;

        public IReadOnlyDictionary<string, double> MarksByCourseName => this.marksByCourseName;

        public int CompareTo(IStudent other) => this.UserName.CompareTo(other.UserName);

        public void EnrollInCourse(ICourse course)
        {
            if (this.enrolledCourses.ContainsKey(course.Name))
            {
                throw new DuplicateEntryInStructureException(this.UserName, course.Name);
            }

            this.enrolledCourses.Add(course.Name, course);
        }

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

        private double CalculateMark(int[] scores)
        {
            double percentageOfSolvedExam = scores.Sum() / (double)(Course.NumberOfTasksOnExam * Course.MaxScoreOnExamTask);
            double mark = (percentageOfSolvedExam * 4) + 2;
            return mark;
        }

        public override string ToString() => this.UserName;
    }
}