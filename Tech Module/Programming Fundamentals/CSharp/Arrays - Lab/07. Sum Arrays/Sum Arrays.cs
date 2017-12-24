namespace _07.Sum_Arrays
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var arrayOne = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            var arrayTwo = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            var length = Math.Max(arrayOne.Length, arrayTwo.Length);
            var array = new int[length];
            var index = 0;

            for (int i = 0; i < length; i++)
            {
                if (arrayOne.Length == arrayTwo.Length)
                {
                    array[i] = arrayOne[i] + arrayTwo[i];
                }
                else if (arrayOne.Length > arrayTwo.Length)
                {
                    array[i] = arrayOne[i] + arrayTwo[index];
                    if (index == arrayTwo.Length - 1)
                    {
                        index = 0;
                    }
                    else
                    {
                        index++;
                    }
                }
                else if (arrayOne.Length < arrayTwo.Length)
                {
                    array[i] = arrayOne[index] + arrayTwo[i];
                    if (index == arrayOne.Length - 1)
                    {
                        index = 0;
                    }
                    else
                    {
                        index++;
                    }
                }
            }

            Console.WriteLine(string.Join(" ", array));
        }
    }
}
