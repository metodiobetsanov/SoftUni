namespace _02.Sign_of_Integer_Number
{
    using System;

    public class Program
    {
        public static void CheckNumber(int number)
        {
            if (number > 0)
            {
                Console.WriteLine("The number {0} is positive", number);
            }
            else if (number < 0)
            {
                Console.WriteLine("The number {0} is negative.", number);
            }
            else
            {
                Console.WriteLine("The number {0} is zero.", number);
            }
        }
        public static void Main()
        {
            var number = int.Parse(Console.ReadLine());

            CheckNumber(number);
        }
    }
}
