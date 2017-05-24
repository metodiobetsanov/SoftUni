using System;

namespace _01.Passed
{
    class Passed
    {
        static void Main()
        {
            var grade = double.Parse(Console.ReadLine());
            if (grade >= 3.00)
            {
                Console.WriteLine("Passed!");
            }
        }
    }
}
