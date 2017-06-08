namespace _05.Fibonacci_Numbers
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var number = int.Parse(Console.ReadLine());
            FibonacciNumbers(number);
        }

        private static void FibonacciNumbers(int number)
        {
            var f1 = 1;
            var f2 = 1;
            var f = 0;
            if (number < 2)
            {
                Console.WriteLine(1);
            }
            else
            {
                for (int i = 2; i <= number; i++)
                {
                    f = f1 + f2;
                    f2 = f1;
                    f1 = f;
                }

                Console.WriteLine(f);
            }
        }
    }
}
