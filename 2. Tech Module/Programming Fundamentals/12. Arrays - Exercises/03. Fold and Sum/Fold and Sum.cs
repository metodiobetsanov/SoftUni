namespace _03.Fold_and_Sum
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            int[] arrayOriginal = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            var k = arrayOriginal.Length / 4;
            int[] topRow = new int[2 * k];
            int[] botRow = new int[2 * k];
            int[] arraySum = new int[2 * k];
            int placeHolderBot = 0;
            int placeHolderTopLeft = k-1;
            int placeHolderTopRight = arrayOriginal.Length - 1;

            for (int i = 0; i < topRow.Length; i++)
            {
                if (i < k )
                {
                    topRow[i] = arrayOriginal[placeHolderTopLeft];
                    placeHolderTopLeft--;
                }
                else
                {
                    topRow[i] = arrayOriginal[placeHolderTopRight];
                    placeHolderTopRight--;
                }
            }

            for (int i = k; i < arrayOriginal.Length - k; i++)
            {
                botRow[placeHolderBot] = arrayOriginal[i];
                placeHolderBot++;
            }

            ArraySum(topRow, botRow, arraySum);
            Console.WriteLine(string.Join(" ", arraySum));
        }

        private static void ArraySum(int[] arrayOne, int[] arrayTwo, int[] arraySum)
        {
            for (int i = 0; i < arrayOne.Length; i++)
            {
                arraySum[i] = arrayOne[i] + arrayTwo[i];
            }
        }
    }
}
