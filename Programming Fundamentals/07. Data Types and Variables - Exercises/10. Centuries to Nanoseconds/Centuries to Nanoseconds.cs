namespace _10.Centuries_to_Nanoseconds
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var centuries = int.Parse(Console.ReadLine());
            var years = centuries * 100;
            var days = (int)(years * 365.2422);
            ulong hours = (ulong)(days * 24);
            ulong minutes = hours * 60;
            ulong seconds = minutes * 60;
            ulong milliseconds = seconds * 1000;
            ulong microseconds = milliseconds * 1000;
            ulong nanoseconds = microseconds * 1000;
            //to do
            Console.WriteLine("{0} centuries = {1} years = {2} days = {3} hours = {4} minutes = {5} seconds = {6} milliseconds = {7} microseconds = {8} nanoseconds",
                centuries, years, days, hours, minutes, seconds, milliseconds, microseconds, nanoseconds);
        }
    }
}
