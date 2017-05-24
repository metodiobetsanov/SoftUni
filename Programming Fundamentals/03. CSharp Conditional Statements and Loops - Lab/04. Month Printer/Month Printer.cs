using System;

namespace _04.Month_Printer
{
    class Program
    {
        static void Main()
        {
            var selector = int.Parse(Console.ReadLine());
            string[] months = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.MonthNames;
            if (selector>0 && selector<=12)
            {
                Console.WriteLine("{0}", months[selector-1]);
            }
            else
            {
                Console.WriteLine("Error!");
            }
        }
    }
}
