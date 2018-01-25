namespace _03._Longest_Subsequence
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class Program
    {
        private static void Main()
        {
            List<int> list = Console.ReadLine()
                .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => int.Parse(x))
                .ToList();

            var number = 0;
            var maxCount = 0;
            var counter = 1;

            for (var i = 0; i < list.Count - 1; i++)
            {
                if (list[i] == list[i + 1])
                {
                    counter++;
                }
                else
                {
                    counter = 1;
                }

                if (counter > maxCount)
                {
                    number = list[i];
                    maxCount = counter;
                }
            }

            for (int i = 0; i < maxCount; i++)
            {
                Console.Write(number + " ");
            }
            
        }
    }
}