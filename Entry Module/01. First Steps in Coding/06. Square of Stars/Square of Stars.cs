using System;

namespace _06.Square_of_Stars
{
    class Program
    {
        static void Main()
        {
            var number = int.Parse(Console.ReadLine());
            Console.WriteLine(new string('*', number));
            for (int i = 1; i <= number - 2; i++)
            {
                Console.Write("*");
                Console.Write(new string(' ', number - 2));
                Console.Write("*");
                Console.WriteLine();
            }
            Console.WriteLine(new string('*', number));
        }
    }
}
