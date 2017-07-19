using System;

namespace _10.Number_100_to_200
{
    class Program
    {
        static void Main()
        {
            var num = int.Parse(Console.ReadLine());

            if (num > 200)
            {
                Console.WriteLine("Greater than 200");
            }
            else if (num < 100)
            {
                Console.WriteLine("Less than 100");
            }
            else
            {
                Console.WriteLine("Between 100 and 200");
            }

        }
    }
}
