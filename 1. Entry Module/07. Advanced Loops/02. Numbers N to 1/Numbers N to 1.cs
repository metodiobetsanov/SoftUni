using System;

namespace _02.Numbers_N_to_1
{
    class Program
    {
        static void Main()
        {
            var num = int.Parse(Console.ReadLine());
            for (int i = num; i >= 1; i--)
            {
                Console.WriteLine(i);
            }
        }
    }
}
