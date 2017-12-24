namespace _06.Prime_Checker
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var number = long.Parse(Console.ReadLine());
            Console.WriteLine(IsPrime(number));
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