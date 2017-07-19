namespace _16.Comparing_floats
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var numberOne = double.Parse(Console.ReadLine());
            var numbeTwo = double.Parse(Console.ReadLine());
            bool equal = Math.Abs(numberOne - numbeTwo) < 0.000001;

            Console.WriteLine(equal);
        }
    }
}
