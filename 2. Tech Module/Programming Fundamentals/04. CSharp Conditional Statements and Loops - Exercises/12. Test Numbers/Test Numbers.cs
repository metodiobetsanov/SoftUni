namespace _12.Test_Numbers
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var numberOne = int.Parse(Console.ReadLine());
            var numberTwo = int.Parse(Console.ReadLine());
            var maxSum = int.Parse(Console.ReadLine());
            var sum = 0;
            var counter = 0;

            for (int i = numberOne; i > 0; i--)
            {
                for (int j = 1; j <= numberTwo; j++)
                {
                    sum += i * j * 3;
                    counter++;

                    if (sum >= maxSum)
                    {
                        Console.WriteLine("{0} combinations", counter);
                        Console.WriteLine("Sum: {0} >= {1}", sum, maxSum);
                        return;
                    }
                }
            }

            if (sum < maxSum)
            {
                Console.WriteLine("{0} combinations", counter);
                Console.WriteLine("Sum: {0}", sum);
            }
        }
    }
}
