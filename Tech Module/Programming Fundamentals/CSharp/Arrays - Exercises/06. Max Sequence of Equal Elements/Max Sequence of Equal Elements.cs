namespace _06.Max_Sequence_of_Equal_Elements
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            int[] array = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            var bestlen = 0;
            var bestSeq = 0;

            for (int i = 0; i < array.Length; i++)
            {
                var len = 1;
                var seq = 0;

                for (int j = i+1; j < array.Length; j++)
                {
                    if (array[i] == array[j])
                    {
                        seq = array[i];
                        len++;
                    }
                    else
                    {
                        break;
                        i += j-1;
                    }
                }

                if (len > bestlen)
                {
                    bestSeq = seq;
                    bestlen = len;
                }
            }

            for (int i = 0; i < bestlen; i++)
            {
                Console.Write("{0} ", bestSeq);
            }

            Console.WriteLine();
        }
    }
}
