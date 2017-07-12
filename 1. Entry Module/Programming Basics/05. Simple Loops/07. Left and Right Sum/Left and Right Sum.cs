using System;

namespace _07.Left_and_Right_Sum
{
    class Program
    {
        static void Main()
        {
            var qty = int.Parse(Console.ReadLine());
            var leftSum = 0;
            var rightSum = 0;
            var equal = -1;
            for (int i = 1; i <= qty; i++)
            {
                var num = int.Parse(Console.ReadLine());
                leftSum += num;
            }
            for (int i = 1; i <= qty; i++)
            {
                var num = int.Parse(Console.ReadLine());
                rightSum += num;
            }
            if (Math.Abs(leftSum - rightSum) == 0)
            {
                Console.WriteLine("Yes, sum = {0}", leftSum);
            }
            else
            {
                Console.WriteLine("No, diff = {0}", Math.Abs(leftSum - rightSum));
            }
        }
    }
}
