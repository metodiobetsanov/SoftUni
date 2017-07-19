using System;

namespace _03.Square_of_Stars
{
    class Program
    {
        static void Main()
        {
            var num = int.Parse(Console.ReadLine());
            for (int i = 1; i <= num; i++)
            {
                Console.Write("*");
                for (int col = 1; col < num; col++)
                {
                    Console.Write(" *", num - 1);
                }
                Console.WriteLine();
            }
        }
    }
}
