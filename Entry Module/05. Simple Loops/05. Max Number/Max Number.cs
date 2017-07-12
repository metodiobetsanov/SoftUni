using System;

namespace _05.Max_Number
{
    class Program
    {
        static void Main()
        {
            var qty = int.Parse(Console.ReadLine());
            var max = -1000000000000000;
            for (int i = 1; i <= qty; i++)
            {
                var number = int.Parse(Console.ReadLine());
                var tmp = Math.Max(max, number);
                max = tmp;
            }
            Console.WriteLine("{0}",max);
        }
    }
}
