using System;

namespace _11.Enter_Even_Number
{
    class Program
    {
        static void Main()
        {
        start:
            try
            {
                var number = int.Parse(Console.ReadLine());
                while (number % 2 != 0)
                {
                    Console.WriteLine("The number is not even.");
                    number = int.Parse(Console.ReadLine());
                }
                Console.WriteLine("Even number entered: {0}", number);
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid number.");
                goto start;
            }
        }
    }
}
