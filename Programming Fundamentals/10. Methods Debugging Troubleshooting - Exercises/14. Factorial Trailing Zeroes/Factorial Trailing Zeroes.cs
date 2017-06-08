namespace _14.Factorial_Trailing_Zeroes
{
    using System;
    using System.Numerics;

    public class Factorial_Trailing_Zeroes
    {
        public static void Main()
        {
            var number = int.Parse(Console.ReadLine());
            var factorial = Factorial(number);
            var zeroes = CountZero(factorial);

            Console.WriteLine(zeroes);
        }

        private static int CountZero(BigInteger factorial)
        {
            int counter = 0;
            BigInteger number = factorial;
            BigInteger check = 0;

            do
            {
                check = number % 10;
                number = number / 10;

                if (check == 0)
                {
                    counter++;
                }

            } while (check == 0);

            return counter;
        }

        public static BigInteger Factorial(int number)
        {
            BigInteger factorial = number;

            for (BigInteger i = 1; i < number; i++)
            {
                factorial *= i;
            }

            return factorial;
        }
    }
}
