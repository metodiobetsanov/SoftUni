namespace _03.Last_K_Numbers_Sums
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var arraySize = int.Parse(Console.ReadLine());
            var seq = new long[arraySize];
            seq[0] = 1;
            var sumElements = int.Parse(Console.ReadLine());

            for (long i = 1; i < seq.Length; i++)
            {
                long sum = 0;

                for (long k = i-1; k >= 0; k--)
                {
                    if (k >= i - sumElements)
                    {
                        sum += seq[k];
                    }
                }

                seq[i] = sum;
            }

            Console.WriteLine(string.Join(" ", seq));
        }
    }
}
