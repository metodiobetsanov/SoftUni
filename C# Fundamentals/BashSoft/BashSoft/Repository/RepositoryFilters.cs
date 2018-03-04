using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

public static class RepositoryFilters
{
    public static void FilterAndTake(Dictionary<string, List<int>> wantedData, string wantedFilter, int studentsToTake)
    {
        wantedFilter = wantedFilter.ToLower();

        if (wantedFilter == "excellent")
        {
            FilterAndTake(wantedData, x => 5 >= x, studentsToTake);
        }
        else if (wantedFilter == "average")
        {
            FilterAndTake(wantedData, x => x < 5 && x >= 3.5, studentsToTake);
        }
        else if (wantedFilter == "poor")
        {
            FilterAndTake(wantedData, x => x < 3.5, studentsToTake);
        }
        else
        {
            OutputWriter.DisplayException(ExceptionMessages.InvalidStudentFilter);
        }
    }

    private static void FilterAndTake(Dictionary<string, List<int>> wantedData, Predicate<double> givenFilter, int studentsToTake)
    {
        int counterForPrinted = 0;
        foreach (var studentPoints in wantedData)
        {
            if (counterForPrinted == studentsToTake)
            {
                break;
            }

            double averageScore = studentPoints.Value.Average();
            var percentageOfFullfilment = averageScore / 100;
            var averageMark = percentageOfFullfilment * 4 + 2;

            if (givenFilter(averageMark))
            {
                OutputWriter.PrintStudent(studentPoints);
                counterForPrinted++;
            }
        }
    }
}
