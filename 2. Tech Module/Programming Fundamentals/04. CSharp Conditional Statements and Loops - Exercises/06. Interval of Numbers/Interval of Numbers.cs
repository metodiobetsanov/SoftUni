namespace _06.Interval_of_Numbers
{
    using System;

    public class Program
    {
        public static void Main()
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
