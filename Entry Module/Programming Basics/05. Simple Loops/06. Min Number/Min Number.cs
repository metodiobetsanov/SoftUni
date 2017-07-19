using System;

namespace _06.Min_Number
{
    class Program
    {
        static void Main()
        {
            var qty = int.Parse(Console.ReadLine());
            var min = 1000000000000000;
            for (int i = 1; i <= qty; i++)
            {
                var number = int.Parse(Console.ReadLine());
                var tmp = Math.Min(number, min);
                min = tmp;
            }
            Console.WriteLine("{0}", min);
        }
    }
}
