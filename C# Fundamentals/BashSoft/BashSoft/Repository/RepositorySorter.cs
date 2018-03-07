using System;
using System.Linq;
using System.Collections.Generic;

public class RepositorySorter
{
    public void OrderAndTake(Dictionary<string, double> studentsMark, string comparison, int studentsToTake)
    {
        comparison = comparison.ToLower();

        if (comparison == "ascending")
        {
            PrintStudents(studentsMark.OrderBy(x => x.Value).Take(studentsToTake).ToDictionary(pair => pair.Key, pair => pair.Value));
        }
        else if (comparison == "descending")
        {
            PrintStudents(studentsMark.OrderByDescending(x => x.Value).Take(studentsToTake).ToDictionary(pair => pair.Key, pair => pair.Value));
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