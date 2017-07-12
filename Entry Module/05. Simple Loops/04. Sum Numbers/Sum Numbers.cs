using System;

namespace _04.Sum_Numbers
{
    class Program
    {
        static void Main()
        {
            var num = int.Parse(Console.ReadLine());
            var sum = 0;

            for (int i = 1; i <= num; i++)
            {
                var number = int.Parse(Console.ReadLine());
                sum += number;
            }

            Console.WriteLine("{0}", sum);
        }
    }
}
