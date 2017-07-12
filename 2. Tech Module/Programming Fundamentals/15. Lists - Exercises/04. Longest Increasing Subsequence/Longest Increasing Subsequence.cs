namespace _04.Longest_Increasing_Subsequence
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class Program
    {
        public static void Main()
        {
            var numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var length = new int[numbers.Length];
            var previous = new int[numbers.Length];
            var bestLength = 0;
            var lastIndex = -1;

            for (int anchor = 0; anchor < numbers.Length; anchor++)
            {
                length[anchor] = 1;
                previous[anchor] = -1;

                var anchorNum = numbers[anchor];

                for (int i = 0; i < anchor; i++)
                {
                    var currentNum = numbers[i];

                    if (currentNum < anchorNum && length[i] + 1 > length[anchor])
                    {
                        length[anchor] = length[i] + 1;
                        previous[anchor] = i;
                    }
                }

                if (length[anchor] > bestLength)
                {
                    bestLength = length[anchor];
                    lastIndex = anchor;
                }
            }

            var LIS = new List<int>();

            while (lastIndex != -1)
            {
                LIS.Add(numbers[lastIndex]);
                lastIndex = previous[lastIndex];
            }

            LIS.Reverse();

            Console.WriteLine(string.Join(" ", LIS));
        }
    }
}
