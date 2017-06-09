namespace _02.Rotate_and_Sum
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            int[] arrayOriginal = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            int shiftTimes = int.Parse(Console.ReadLine());
            int[] arraySum = new int[arrayOriginal.Length];

            for (int i = 0; i < shiftTimes; i++)
            {
                ArrayShiftRight(arrayOriginal);
                ArraySum(arrayOriginal, arraySum);
            }

            Console.WriteLine(string.Join(" ", arraySum));
        }

        private static void ArrayShiftRight(int[] array)
        {
            int movedPart = array[array.Length - 1];

            for (int i = array.Length - 1; i >= 1; i--)
            {
                array[i] = array[i - 1];
            }

            array[0] = movedPart;
        }

        private static void ArraySum(int[] arrayOne, int[] arrayTwo)
        {
            for (int i = 0; i < arrayOne.Length; i++)
            {
                arrayTwo[i] += arrayOne[i];
            }
        }
    }
}
