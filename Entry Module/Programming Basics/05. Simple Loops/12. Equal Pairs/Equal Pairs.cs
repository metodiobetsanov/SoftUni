using System;

namespace _12.Equal_Pairs
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            double sumPairs = 0;
            double oldPairs = 0;
            double diff = 0;

            for (int i = 0; i < n; i++)
            {
                double numOne = double.Parse(Console.ReadLine());
                double numTwo = double.Parse(Console.ReadLine());
                sumPairs = numOne + numTwo;
                diff = Math.Abs(sumPairs - oldPairs);
                oldPairs = sumPairs;
            }

            if (n == 1)
            {
                Console.WriteLine("Yes, value={0}", sumPairs);
            }
            else
            {
                if (diff == 0)
                {
                    Console.WriteLine("Yes, value={0}", sumPairs);
                }
                else
                {
                    Console.WriteLine("No, maxdiff={0}", diff);
                }
            }
        }
    }
}
