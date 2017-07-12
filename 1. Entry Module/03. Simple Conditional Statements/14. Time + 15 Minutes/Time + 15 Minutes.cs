using System;

namespace _14.Time___15_Minutes
{
    class Program
    {
        static void Main()
        {
            int hh = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            var mm = m + 15;

            if (mm > 59)
            {
                hh += 1;
                if (hh == 24)
                {
                    hh = 0;
                }
                mm -= 60;
                if (mm < 10)
                {
                    Console.WriteLine(hh + ":0" + mm);
                }
                else
                {
                    Console.WriteLine(hh + ":" + mm);
                }
            }
            else
            {
                Console.WriteLine(hh + ":" + mm);
            }
        }
    }
}
