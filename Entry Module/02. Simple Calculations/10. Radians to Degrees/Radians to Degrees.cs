using System;

namespace _10.Radians_to_Degrees
{
    class Program
    {
        static void Main()
        {
            var radius = double.Parse(Console.ReadLine());
            var degrees = radius * (180.0 / Math.PI);

            Console.WriteLine(Math.Round(degrees, 0));
        }
    }
}
