using System;

namespace _04.Triangle_of_55_Stars
{
    class Program
    {
        static void Main()
        {
            for (int i = 1; i <= 10; i++)
            {
                for (int k = 1; k <= i; k++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
        }
    }
}
