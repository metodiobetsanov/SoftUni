namespace BashSoft.Models
{
    using Exceptions;
    using Interfaces;
    using System.Collections.Generic;

    public class Course : ICourse
    {
        public const int NumberOfTasksOnExam = 5;

        public const int MaxScoreOnExamTask = 100;

        private string name;

        private Dictionary<string, IStudent> studentsByName;

        public Course(string courseName)
        {
            this.Name = courseName;
            this.studentsByName = new Dictionary<string, IStudent>();
        }

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

        public IReadOnlyDictionary<string, IStudent> StudentsByName => this.studentsByName;

        public int CompareTo(ICourse other) => this.Name.CompareTo(other.Name);

        public void EnrollStudent(IStudent student)
        {
            if (this.studentsByName.ContainsKey(student.UserName))
            {
                throw new DuplicateEntryInStructureException(student.UserName, this.Name);
            }

            this.studentsByName.Add(student.UserName, student);
        }

        public override string ToString() => this.Name;
    }
}