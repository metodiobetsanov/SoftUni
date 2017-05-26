using System;

namespace _13.Game_of_Numbers
{
    class Program
    {
        static void Main()
        {
            var numberOne = int.Parse(Console.ReadLine());
            var numberTwo = int.Parse(Console.ReadLine());
            var target = int.Parse(Console.ReadLine());
            var sum = 0;
            var counter = 0;
            for (int i = numberTwo; i >= numberOne; i--)
            {
                for (int j = numberTwo; j >= numberOne; j--)
                {
                    counter++;
                    sum = i + j;
                    if (sum == target)
                    {
                        Console.WriteLine("Number found! {0} + {1} = {2}",
                            i, j, target);
                        return;
                    }
                }
            }
            if (sum != target)
            {
                Console.WriteLine("{0} combinations - neither equals {1}",
                    counter, target);
            }
        }
    }
}
