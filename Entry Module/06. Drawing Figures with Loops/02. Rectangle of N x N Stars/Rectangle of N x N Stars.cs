using System;

namespace _02.Rectangle_of_N_x_N_Stars
{
    class Program
    {
        static void Main()
        {
            var num = int.Parse(Console.ReadLine());
            for (int i = 0; i < num; i++)
            {
                Console.WriteLine(new string('*', num));
            }
        }
    }
}
