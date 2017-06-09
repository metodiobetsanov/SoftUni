namespace _07.Max_Sequence_of_Increasing_Elements
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

            for (int i = 0; i < array.Length-1; i++)
            {
                var len = 0;
                var seq = array[i];
                var nextNum = array[i] + 1;

                for (int j = i + 1; j < array.Length; j++)
                {
                    if (nextNum == array[j])
                    {
                        len++;
                        nextNum++;
                    }
                    else
                    {
                        break;
                    }
                }

                if (len > bestlen)
                {
                    bestSeq = seq;
                    bestlen = len;
                }
            }

            for (int i = bestSeq; i <= bestlen + bestSeq; i++)
            {
                Console.Write("{0} ", i);
            }

            Console.WriteLine();
        }
    }
}
