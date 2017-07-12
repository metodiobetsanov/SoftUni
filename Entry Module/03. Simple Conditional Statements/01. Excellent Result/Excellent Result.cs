using System;

namespace _01.Excellent_Result
{
    class Program
    {
        static void Main()
        {
            var grade = double.Parse(Console.ReadLine());
            if (grade > 5.49)
            {
                Console.WriteLine("Excellent!");
            }
        }
    }
}
