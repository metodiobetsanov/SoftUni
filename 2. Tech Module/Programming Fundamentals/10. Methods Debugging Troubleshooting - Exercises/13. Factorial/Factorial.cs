using System.Numerics;

namespace _13.Factorial
{
    using System;

    public class Program
    {
        static void Main()
        {
            var number = int.Parse(Console.ReadLine());
            
            Factorial(number);
        }

        public static void Factorial(int number)
        {
            BigInteger factorial = number;

            for (BigInteger i = 1; i < number; i++)
            {
                factorial *= i;
            }

            Console.WriteLine(factorial);
        }
    }
}
