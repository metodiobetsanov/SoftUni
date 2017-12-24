using System.Globalization;
using System.Linq;

namespace _01.Count_Working_Days
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main()
        {
            var startDate = DateTime.ParseExact(Console.ReadLine(), "dd-MM-yyyy", CultureInfo.InvariantCulture);
            var endDate = DateTime.ParseExact(Console.ReadLine(), "dd-MM-yyyy", CultureInfo.InvariantCulture);
            var workDays = 0;
            DateTime[] holidays = new DateTime[12];

            holidays[0] = new DateTime(endDate.Year, 01, 01);
            holidays[1] = new DateTime(endDate.Year, 03, 03);
            holidays[2] = new DateTime(endDate.Year, 05, 01);
            holidays[3] = new DateTime(endDate.Year, 05, 06);
            holidays[4] = new DateTime(endDate.Year, 05, 24);
            holidays[5] = new DateTime(endDate.Year, 09, 06);
            holidays[6] = new DateTime(endDate.Year, 09, 22);
            holidays[7] = new DateTime(endDate.Year, 11, 01);
            holidays[8] = new DateTime(endDate.Year, 12, 24);
            holidays[10] = new DateTime(endDate.Year, 12, 25);
            holidays[11] = new DateTime(endDate.Year, 12, 26);

            for (DateTime i = startDate; i <= endDate; i = i.AddDays(1))
            {
                if (!holidays.Contains(i) && !(i.DayOfWeek == DayOfWeek.Sunday || i.DayOfWeek == DayOfWeek.Saturday) )
                {
                    workDays++;
                }
            }

            Console.WriteLine("{0}", workDays);
        }
    }
}
