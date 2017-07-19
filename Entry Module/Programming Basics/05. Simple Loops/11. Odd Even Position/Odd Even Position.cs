using System;
namespace _11.Odd_Even_Position
{
    class Program
    {
        static void Main()
        {
            var qty = int.Parse(Console.ReadLine());
            var oddSUM = 0.0;
            var oddMin = 100000000000.0;
            var oddMax = -100000000000.0;
            var evenSUM = 0.0;
            var evenMin = 100000000000.0;
            var evenMax = -100000000000.0;

            for (int i = 1; i <= qty; i++)
            {
                var num = double.Parse(Console.ReadLine());
                if (i % 2 == 0)
                {
                    evenSUM += num;
                    if (evenMax < num)
                    {
                        evenMax = num;
                    }
                    if (evenMin > num)
                    {
                        evenMin = num;
                    }
                }
                else
                {
                    oddSUM += num;
                    if (oddMax < num)
                    {
                        oddMax = num;
                    }
                    if (oddMin > num)
                    {
                        oddMin = num;
                    }
                }
            }
            Console.WriteLine("OddSum = {0},", oddSUM);
            if (oddMin == 100000000000.0)
            {
                Console.WriteLine("OddMin = No,");
            }
            else
            {
                Console.WriteLine("OddMin = {0},", oddMin);
            }
            if (oddMax == -100000000000.0)
            {
                Console.WriteLine("OddMax = No,");
            }
            else
            {
                Console.WriteLine("OddMax = {0},", oddMax);
            }
            Console.WriteLine("EvenSum = {0},", evenSUM);
            if (evenMin == 100000000000.0)
            {
                Console.WriteLine("EvenMin = No,");
            }
            else
            {
                Console.WriteLine("EvenMin = {0},", evenMin);
            }
            if (evenMax == -100000000000.0)
            {
                Console.WriteLine("EvenMax = No,");
            }
            else
            {
                Console.WriteLine("EvenMax = {0},", evenMax);
            }
        }
    }
}
