namespace _02.Odd_Filter
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split(' ').Select(int.Parse).Where(x => x % 2 == 0).ToList();
            var average = input.Average();

            for (int i = 0; i < input.Count; i++)
            {
                if (input[i] > average)
                {
                    input[i] += 1;
                }
                else
                {
                    input[i] -= 1;
                }
            }

            Console.WriteLine(string.Join(" ", input));
        }
    }
}
