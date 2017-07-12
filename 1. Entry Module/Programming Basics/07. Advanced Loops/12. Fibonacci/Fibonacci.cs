using System;

namespace _12.Fibonacci
{
    class Fibonacci
    {
        static void Main()
        {
            var number = int.Parse(Console.ReadLine());
            int f0 = 1, f1 = 1;
            var f2 = 0;
            if (number > 1)
            {
                for (int i = 1; i < number; i++)
                {
                    f2 = f0 + f1;
                    f0 = f1;
                    f1 = f2;
                }
                Console.WriteLine(f2);
            }
            else
            {
                Console.WriteLine("1");
            }
        }
    }
}
