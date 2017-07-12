using System;

namespace _06.Number_in_Range__1_to_100_
{
    class Program
    {
        static void Main()
        {
            Console.Write("Еnter a number in the range [1...100]: ");
            var number = int.Parse(Console.ReadLine());
            while (1 > number || number > 100)
            {
                Console.WriteLine("invalid number!");
                number = int.Parse(Console.ReadLine());
            }
            Console.WriteLine("The number is: {0}", number);
        }
    }
}
