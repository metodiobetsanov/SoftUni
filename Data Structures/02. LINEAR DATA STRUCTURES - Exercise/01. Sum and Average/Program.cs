using System.Linq;

namespace _01._Sum_and_Average
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main()
        {
            List<int> list = Console.ReadLine()
                .Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => int.Parse(x))
                .ToList();

            Console.WriteLine("Sum={0}; Average={1:f2}", list.Sum(), list.Average());
        }
    }
}
