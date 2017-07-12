namespace _10.Centuries_to_Nanoseconds
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var centuries = decimal.Parse(Console.ReadLine());
            var years = centuries * 100;
            var days = Math.Floor(years * 365.2422m);
            var hours = days * 24;
            var minutes = hours * 60;
            var seconds = minutes * 60;
            var milliseconds = seconds * 1000;
            var microseconds = milliseconds * 1000;
            var nanoseconds = microseconds * 1000;
            
            Console.WriteLine(
                "{0} centuries = {1} years = {2} days = {3} " +
                "hours = {4} minutes = {5} seconds = {6} " +
                "milliseconds = {7} microseconds = {8} nanoseconds",
                centuries, 
                years, 
                days, 
                hours, 
                minutes, 
                seconds, 
                milliseconds, 
                microseconds, 
                nanoseconds);
        }
    }
}
