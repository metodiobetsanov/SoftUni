namespace _08.Most_Frequent_Number
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            int[] array = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            int bestlen = 0;
            int bestSeq = 0;

            for (int i = 0; i < array.Length; i++)
            {
                var len = 1;

                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[i] == array[j])
                    {
                        len++;
                    }
                }

                if (len > bestlen)
                {
                    bestSeq = array[i];
                    bestlen = len;
                }
            }

            Console.WriteLine(bestSeq);
        }
    }
}
