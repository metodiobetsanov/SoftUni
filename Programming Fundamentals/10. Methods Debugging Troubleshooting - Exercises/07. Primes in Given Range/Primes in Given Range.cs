namespace _07.Primes_in_Given_Range
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            var start = long.Parse(Console.ReadLine());
            var end = long.Parse(Console.ReadLine());

            PrintPrimes(start, end);
        }

        private static void PrintPrimes(long start, long end)
        {
            string primes = string.Empty;

            for (long number = start; number <= end; number++)
            {
                if (IsPrime(number))
                {
                    primes = string.Concat(primes,", ", number);
                }
            }

            primes = primes.Remove(0, 2);
            Console.WriteLine(primes);
        }

        public static bool IsPrime(long number)
        {
            bool prime = true;
            if (number < 2)
            {
                prime = false;
            }
            else
            {
                for (int i = 2; i <= Math.Sqrt(number); i++)
                {
                    if (number % i == 0)
                    {
                        prime = false;
                        break;
                    }
                }
            }

            return prime;
        }
    }
}
