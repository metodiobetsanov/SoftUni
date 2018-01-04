using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Strawberry
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var leftRight = 0;
            var midTop = n;
            var midBot = 0;

            for (int i = 0; i < n / 2; i++)
            {
                Console.WriteLine("{0}\\{1}|{1}/{0}",
                    new string('-', leftRight),
                    new string('-', midTop));

                leftRight += 2;
                midTop = Math.Max(midTop - 2, 0);
            }

            leftRight += 1;

            for (int i = 0; i < n - n / 2; i++)
            {
                Console.WriteLine("{0}#{1}.{1}#{0}",
                    new string('-', leftRight),
                    new string('.', midBot));

                leftRight = Math.Max(leftRight - 2, 0);
                midBot = Math.Min(midBot + 2, n);
            }

            for (int i = 0; i < n + 1; i++)
            {
                Console.WriteLine("{0}#{1}.{1}#{0}",
                    new string('-', leftRight),
                    new string('.', midBot));

                leftRight += 1;
                midBot = Math.Max(midBot - 1, 0);
            }
        }
    }
}
