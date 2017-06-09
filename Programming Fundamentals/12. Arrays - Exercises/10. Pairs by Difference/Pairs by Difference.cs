namespace _10.Pairs_by_Difference
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            int[] array = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            int diffrence = int.Parse(Console.ReadLine());
            int counter = 0;

            for (int i = 0; i < array.Length; i++)
            {
                try
                {
                    for (int j = i + 1; j < array.Length; j++)
                    {
                        if (Math.Abs(array[i] - array[j]) == diffrence)
                        {
                            counter++;
                        }
                    }
                }
                catch (Exception)
                {

                }
            }

            Console.WriteLine(counter);
        }
    }
}
