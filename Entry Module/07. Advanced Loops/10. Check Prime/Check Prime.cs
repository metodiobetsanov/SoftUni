using System;

namespace _10.Check_Prime
{
    class Program
    {
        static void Main()
        {
            var number = int.Parse(Console.ReadLine());
            bool notprime = true;
            if (number < 2)
                Console.WriteLine("Not prime");
            else
            {
                for (int i = 2; i <= Math.Sqrt(number); i++)
                {
                    if (number % i == 0)
                    {
                        Console.WriteLine("Not Prime");
                        notprime = false;
                        break;
                    }
                }
                if (notprime)
                {
                    Console.WriteLine("Prime");
                }

            }
        }
    }
}
