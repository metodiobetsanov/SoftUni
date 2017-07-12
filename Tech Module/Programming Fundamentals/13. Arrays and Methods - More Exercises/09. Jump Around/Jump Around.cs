namespace _09.Jump_Around
{
    using System;
    using System.Linq;

    public static class Program
    {
        public static void Main()
        {
            var numbers = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            var curIndex = 0;
            var curValue = 0;
            var sum = 0;

            while (true)
            {
                curValue = numbers[curIndex];
                sum += curValue;
                
                if (curIndex + curValue >= numbers.Length)
                {
                    curIndex -= curValue;
                    if (curIndex < 0)
                    {
                        break;
                    }
                }
                else
                {
                    curIndex += curValue;
                }
            }

            Console.WriteLine(sum);
        }
    }
}
