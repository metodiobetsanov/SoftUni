using System;

namespace _03.Powers_of_Two
{
    class Program
    {
        static void Main()
        {
            var num = int.Parse(Console.ReadLine());
            for (int i = 0; i <= num; i++)
            {
                Console.WriteLine(Math.Pow(2, i));
            }
        }
    }
}
