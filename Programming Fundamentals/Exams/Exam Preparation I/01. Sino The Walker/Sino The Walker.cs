namespace _01.Sino_The_Walker
{
    using System;
    using System.Globalization;
    using System.Numerics;

    class Program
    {
        static void Main()
        {
            var leaveAt = DateTime.ParseExact(Console.ReadLine(), "HH:mm:ss", CultureInfo.InvariantCulture);
            var steps = int.Parse(Console.ReadLine()) % 86400;
            var secondsPerStep = int.Parse(Console.ReadLine()) % 86400;
            long totalSeconds = steps * secondsPerStep;

            leaveAt = leaveAt.AddSeconds(totalSeconds);

            Console.WriteLine("Time Arrival: {0:HH:mm:ss}", leaveAt);
        }
    }
}
