namespace _01.Day_of_Week
{
    using System;
    using System.Globalization;

    class Program
    {
        public static void Main()
        {
            var date = DateTime.ParseExact(Console.ReadLine(), "d-M-yyyy", CultureInfo.InvariantCulture);

            Console.WriteLine(date.DayOfWeek);
        }
    }
}
