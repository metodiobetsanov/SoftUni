namespace _02.Number_Checker
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var number = Console.ReadLine();
            long numberInt;
            decimal numberFloat;

            if (long.TryParse(number, out numberInt))
            {
                Console.WriteLine("integer");
            }
            else if (decimal.TryParse(number, out numberFloat))
            {
                Console.WriteLine("floating-point");
            }
        }
    }
}
