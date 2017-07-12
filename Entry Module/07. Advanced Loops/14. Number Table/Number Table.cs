using System;

namespace _14.Number_Table
{
    class Program
    {
        static void Main()
        {
            var number = int.Parse(Console.ReadLine());
            var num = 0;
            for (int row = 0; row < number; row++)
            {
                for (int col = 0; col < number; col++)
                {
                    num = row + col + 1;
                    if (num > number)
                    {
                        num = number * 2 - num;
                        Console.Write("{0} ", num);
                    }
                    else
                    {
                        Console.Write("{0} ", num);
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
