using System;

namespace _04.Triangle_of_Dollars
{
    class Program
    {
        static void Main()
        {
            var num = int.Parse(Console.ReadLine());
            for (int row = 1; row <= num; row++)
            {
                for (int col = 1; col <= row; col++)
                {
                    Console.Write("$ ");
                }
                Console.WriteLine();
            }
        }
    }
}
