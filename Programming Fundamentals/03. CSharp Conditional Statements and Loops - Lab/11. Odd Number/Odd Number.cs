using System;

namespace _11.Odd_Number
{
    class Program
    {
        static void Main()
        {
            var number = int.Parse(Console.ReadLine());
            while (Math.Abs(number) % 2 == 0)
            {
                Console.WriteLine("Please write an odd number.");
                number = int.Parse(Console.ReadLine());
            }
            Console.WriteLine("The number is: {0}", Math.Abs(number));
        }
    }
}
