namespace _08.Sum_of_Odd_Numbers
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var limit = int.Parse(Console.ReadLine());
            var tmp = 1;
            var sum = 0;

            for (int i = 1; i <= limit; i++)
            {
                Console.WriteLine(tmp);
                sum += tmp;
                tmp += 2;
            }

            Console.WriteLine("Sum: {0}", sum);
        }
    }
}
