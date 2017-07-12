using System;

namespace _03.Even_or_Odd
{
    class Program
    {
        static void Main()
        {
            var num = int.Parse(Console.ReadLine());
            var result = (num % 2);
            if (result == 0)
            {
                Console.WriteLine("even");
            }
            else
            {
                Console.WriteLine("odd");
            }
        }
    }
}
