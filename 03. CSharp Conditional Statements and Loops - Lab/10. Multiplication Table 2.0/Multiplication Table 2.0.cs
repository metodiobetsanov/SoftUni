using System;

namespace _10.Multiplication_Table_2._0
{
    class Program
    {
        static void Main()
        {
            var number = int.Parse(Console.ReadLine());
            var start = int.Parse(Console.ReadLine());
            if (number <= 10)
            {
                for (int i = start; i <= 10; i++)
                {
                    Console.WriteLine("{0} X {1} = {2}",
                        number, i, number*i);
                }
            }
            else
            {
                Console.WriteLine("{0} X {1} = {2}",
                    number, start, number*start);
            }
        }
    }
}
