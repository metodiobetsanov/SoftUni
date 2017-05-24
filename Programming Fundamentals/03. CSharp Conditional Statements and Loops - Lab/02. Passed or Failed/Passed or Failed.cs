using System;

namespace _02.Passed_or_Failed
{
    class Program
    {
        static void Main()
        {
            var grade = double.Parse(Console.ReadLine());
            if (grade > 2.99)
            {
                Console.WriteLine("Passed!");
            }
            else
            {
                Console.WriteLine("Failed!");
            }
        }
    }
}
