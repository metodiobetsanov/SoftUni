using System;

namespace _08.Odd_Even_Sum
{
    class Program
    {
        static void Main()
        {
            var qty = int.Parse(Console.ReadLine());
            var oddSUM = 0;
            var evenSUM = 0;
            for (int i = 1; i <= qty; i++)
            {
                var num = int.Parse(Console.ReadLine());
                if (i % 2 == 0)
                {
                    evenSUM += num;
                }
                else
                {
                    oddSUM += num;
                }
            }
            if (oddSUM - evenSUM == 0)
            {
                Console.WriteLine("Yes");
                Console.WriteLine("sum = {0}", evenSUM);
            }
            else
            {
                Console.WriteLine("No");
                Console.WriteLine("diff = {0}", Math.Abs(oddSUM - evenSUM));
            }
        }
    }
}
