namespace _01.Day_of_Week
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var dayOfWeek = int.Parse(Console.ReadLine());

            var week = new string[] { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
            if (dayOfWeek >= 1 && dayOfWeek <= 7)
            {
                Console.WriteLine(week[dayOfWeek - 1]);
            }
            else
            {
                Console.WriteLine("Invalid Day!");
            }
        }
    }
}
