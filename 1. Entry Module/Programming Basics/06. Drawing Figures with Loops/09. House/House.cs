using System;

namespace _09.House
{
    class House
    {
        static void Main(string[] args)
        {
            var num = int.Parse(Console.ReadLine());
            var stars = 1;
            if (num % 2 == 0) stars++;
            for (int i = 0; i < (num + 1) / 2; i++)
            {
                var padding = ((num - stars) / 2);
                Console.Write(new string('-', padding));
                Console.Write(new string('*', stars));
                Console.WriteLine(new string('-', padding));
                stars = stars + 2;
            }
            for (int i = 0; i < num / 2; i++)
            {
                Console.Write("|");
                Console.Write(new string('*', num - 2));
                Console.Write("|");
                Console.WriteLine();
            }
        }
    }
}
