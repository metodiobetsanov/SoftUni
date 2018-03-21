using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Recursive_Factorial
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var number = long.Parse(Console.ReadLine());

            Console.WriteLine(Factorial(number));
        }

        private static long Factorial(long number)
        {
            if (number == 1)
            {
                return 1;
            }

            return number * Factorial(number - 1);
        }
    }
}