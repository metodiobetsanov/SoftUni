namespace BashSoft.Commands
{
    using Attributes;
    using Exceptions;
    using Interfaces;
    using IO;
    using System;
    using System.Collections.Generic;

    [Alias("display")]
    public class DisplayCommand : Command
    {
        [Inject]
        private IDatabase repository;

        public DisplayCommand(string input, string[] data)
            : base(input, data)
        {
        }

        public override void Execute()
        {
            this.CommandExecution();
        }

        private void CommandExecution()
        {
            if (this.Data.Length != 3)
            {
                throw new InvalidCommandException(this.Input);
            }

            string entityToDisplay = this.Data[1];
            string sortType = this.Data[2];

            if (entityToDisplay.Equals("students", StringComparison.OrdinalIgnoreCase))
            {
                IComparer<IStudent> cmp = this.CreateStudentComparator(sortType);
                ISimpleOrderedBag<IStudent> students = this.repository.GetAllStudentsSorted(cmp);
                OutputWriter.WriteMessageOnNewLine(students.JoinWith(Environment.NewLine));
            }
            else if (entityToDisplay.Equals("courses", StringComparison.OrdinalIgnoreCase))
            {
                IComparer<ICourse> cmp = this.CreateCourseComparator(sortType);
                ISimpleOrderedBag<ICourse> courses = this.repository.GetAllCoursesSorted(cmp);
                OutputWriter.WriteMessageOnNewLine(courses.JoinWith(Environment.NewLine));
            }
            else
            {
                throw new InvalidCommandException(this.Input);
            }
        }

        private IComparer<ICourse> CreateCourseComparator(string sortType)
        {
            if (sortType.Equals("ascending", StringComparison.OrdinalIgnoreCase))
            {
                return Comparer<ICourse>.Create((courseOne, courseTwo) => courseOne.CompareTo(courseTwo));
            }

            if (sortType.Equals("descending", StringComparison.OrdinalIgnoreCase))
            {
                return Comparer<ICourse>.Create((courseOne, courseTwo) => courseTwo.CompareTo(courseOne));
            }

            throw new InvalidCommandException(this.Input);
        }

        private IComparer<IStudent> CreateStudentComparator(string sortType)
        {
            if (sortType.Equals("ascending", StringComparison.OrdinalIgnoreCase))
            {
                return Comparer<IStudent>.Create((studentOne, studentTwo) => studentOne.CompareTo(studentTwo));
            }

            if (sortType.Equals("descending", StringComparison.OrdinalIgnoreCase))
            {
                return Comparer<IStudent>.Create((studentOne, studentTwo) => studentTwo.CompareTo(studentOne));
            }

            throw new InvalidCommandException(this.Input);
        }
    }
}