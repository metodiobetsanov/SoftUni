using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Count_of_Occurrences
{
    internal class Program
    {
        private static void Main()
        {
            var list = Console.ReadLine()
                .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => int.Parse(x))
                .ToList();

            var result = new SortedDictionary<int, int>();

            for (var i = 0; i < list.Count; i++)
            {
                if (!result.ContainsKey(list[i]))
                {
                    result[list[i]] = 0;
                }

                result[list[i]] += 1;
            }

            foreach (var kvp in result)
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value} times");
            }
        }
    }
}