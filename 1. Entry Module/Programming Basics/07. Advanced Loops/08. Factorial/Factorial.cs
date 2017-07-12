using System;

namespace _08.Factorial
{
    class Factorial
    {
        static void Main()
        {
            var num = int.Parse(Console.ReadLine());
            var fakt = num;
            for (int i = 1; i < num; i++)
            {
                fakt *= i;
            }
            Console.WriteLine(fakt);
        }
    }
}
