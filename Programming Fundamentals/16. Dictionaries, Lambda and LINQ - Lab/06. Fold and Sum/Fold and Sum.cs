namespace _06.Fold_and_Sum
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class Program
    {
        public static void Main()
        {
            var myArray = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            var k = myArray.Length / 4;
            var rowTop = new int[2 * k];
            var rowBot = new int[2 * k];
            var rowTopIndex = 0;
            var rowBotIndex = 0;

            for (int i = k - 1; i >= 0; i--)
            {
                rowTop[rowTopIndex] = myArray[i];
                rowTopIndex++;
            }

            for (int i = myArray.Length-1; i > myArray.Length - 1 - k; i--)
            {
                rowTop[rowTopIndex] = myArray[i];
                rowTopIndex++;
            }

            for (int i = k ; i < 3 * k; i++)
            {
                rowBot[rowBotIndex] = myArray[i];
                rowBotIndex++;
            }

            var rowSum = rowTop.Select((x, index) => x + rowBot[index]);
            
            Console.WriteLine(string.Join(" ", rowSum));
        }
    }
}
