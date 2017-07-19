using System;

namespace _10.Half_Sum_Element
{
    class Program
    {
        static void Main()
        {
            var qty = int.Parse(Console.ReadLine());
            var sum = 0;
            var max = -1000000000;
            for (int i = 1; i <= qty; i++)
            {
                var number = int.Parse(Console.ReadLine());
                sum += number;
                var tmp = Math.Max(max, number);
                max = tmp;
            }
            sum = sum - max;
            if (sum == max)
            {
                Console.WriteLine("Yes");
                Console.WriteLine("Sum = {0}", sum);
            }
            else
            {
                Console.WriteLine("No");
                Console.WriteLine("Diff = {0}", Math.Abs(sum - max));
            }
        }
    }
}
