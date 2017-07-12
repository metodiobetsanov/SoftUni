using System;

namespace _10.Diamond
{
    class Diamond
    {
        static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var sides = (n - 1) / 2;
            var mid = n- 2 * sides -2;
            var stars = n - 2 * sides;
            
            Console.WriteLine("{0}{1}{0}",
                new string('-',sides),
                new string('*', stars)
                );

           

            for (int i = 0; i < (n-2)/2; i++)
            {
                sides -= 1;
                mid += 2;
                Console.WriteLine("{0}*{1}*{0}",
                new string('-', sides),
                new string('-', mid)
                );

                
            }

            Console.WriteLine("{0}*{1}*{0}",
                new string('-', sides),
                new string('-', mid)
                );

            sides += 1;
            mid -= 2;

            for (int i = 0; i < (n - 2) / 2; i++)
            {
                Console.WriteLine("{0}*{1}*{0}",
                new string('-', sides),
                new string('-', mid)
                );

                sides += 1;
                mid -= 2;
            }

            Console.WriteLine("{0}{1}{0}",
               new string('-', sides),
               new string('*', stars)
               );
        }
    }
}
