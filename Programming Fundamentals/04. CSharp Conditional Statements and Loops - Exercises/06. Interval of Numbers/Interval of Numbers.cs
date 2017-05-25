using System;

namespace _06.Interval_of_Numbers
{
    class Program
    {
        static void Main()
        {
            var numberOne = int.Parse(Console.ReadLine());
            var numberTwo = int.Parse(Console.ReadLine());
            var start = Math.Min(numberOne, numberTwo);
            var end = Math.Max(numberOne, numberTwo);
            for (int i = start; i <= end; i++)
            {
                Console.WriteLine(i);
            }
        }
    }
}
