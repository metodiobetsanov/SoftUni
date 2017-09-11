using System;

namespace _05.Sequence_2k_1
{
    class Program
    {
        static void Main()
        {
            var num = int.Parse(Console.ReadLine());
            for (int i = 1; i <= num; i = i * 2 + 1)
            {
                Console.WriteLine(i);
            }
        }
    }
}
