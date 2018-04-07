namespace BashSoft.Repository
{
    using Interfaces;
    using IO;
    using Static;
    using System.Collections.Generic;
    using System.Linq;

    public class RepositorySorter : IDataSorter
    {
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

        private void PrintStudents(Dictionary<string, double> studentsSorted)
        {
            foreach (var student in studentsSorted)
            {
                OutputWriter.PrintStudent(student);
            }
        }
    }
}