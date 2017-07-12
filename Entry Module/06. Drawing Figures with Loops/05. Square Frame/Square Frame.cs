using System;

namespace _05.Square_Frame
{
    class Program
    {
        static void Main()
        {
            var num = int.Parse(Console.ReadLine());
            Console.Write("+");
            for (int i = 0; i < num - 2; i++)
            {
                Console.Write(" ");
                Console.Write("-");
            }
            Console.Write(" +");
            Console.WriteLine();
            for (int row = 0; row < num - 2; row++)
            {
                Console.Write("|");
                for (int i = 0; i < num - 2; i++)
                {
                    Console.Write(" ");
                    Console.Write("-");
                }
                Console.Write(" |");
                Console.WriteLine();
            }
            Console.Write("+");
            for (int i = 0; i < num - 2; i++)
            {
                Console.Write(" ");
                Console.Write("-");
            }
            Console.Write(" +");
        }
    }
}
