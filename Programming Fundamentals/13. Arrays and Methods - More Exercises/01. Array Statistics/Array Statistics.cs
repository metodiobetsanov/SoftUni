namespace _01.Array_Statistics
{
    using System;
    using System.Linq;
    
    public static class Program
    {
        public static void Main()
        {
            var array = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            ArrayMin(array);
            ArrayMax(array);
            ArrayAverage(array);

        }

        private static void ArrayAverage(int[] array)
        {
            var sum = 0.0;

            for (int i = 0; i < array.Length; i++)
            {
                sum += array[i];
            }

            var average = sum / array.Length;

            Console.WriteLine("Sum = {0:f0}", sum);
            Console.WriteLine("Average = {0}", average);
        }

        private static void ArrayMax(int[] array)
        {
            var max = int.MinValue;

            for (int i = 0; i < array.Length; i++)
            {
                max = Math.Max(array[i], max);
            }

            Console.WriteLine("Max = {0}", max);
        }

        public static void ArrayMin(int[] array)
        {
            var min = int.MaxValue;

            for (int i = 0; i < array.Length; i++)
            {
                min = Math.Min(array[i], min);
            }

            Console.WriteLine("Min = {0}", min);
        }
    }
}
