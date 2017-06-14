namespace _03.Min__Max__Sum__Average
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class Program
    {
        public static void Main()
        {
            var arraySize = int.Parse(Console.ReadLine());
            int[] myArray = new int[arraySize];

            for (int i = 0; i < arraySize; i++)
            {
                myArray[i] = int.Parse(Console.ReadLine());
            }

            double average = myArray.Sum() / (double)arraySize;

            Console.WriteLine("Sum = {0}", myArray.Sum());
            Console.WriteLine("Min = {0}", myArray.Min());
            Console.WriteLine("Max = {0}", myArray.Max());
            Console.WriteLine("Average = {0}", average);
        }
    }
}
