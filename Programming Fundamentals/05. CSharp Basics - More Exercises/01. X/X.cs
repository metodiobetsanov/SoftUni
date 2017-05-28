namespace _01.X
{
    using System;

    public class X
    {
        public static void Main()
        {
            var number = int.Parse(Console.ReadLine());
            var loopSize = (number - 1) / 2;
            var dashesIn = number - 2;
            var dashesOut = 0;

            for (int i = 1; i <= loopSize; i++)
            {
                Console.WriteLine("{0}x{1}x{0}", new string(' ', dashesOut), new string(' ', dashesIn));
                dashesIn -= 2;
                dashesOut++;
            }

            Console.WriteLine("{0}x{0}", new string(' ', dashesOut));
            dashesIn += 2;
            dashesOut--;

            for (int i = 1; i <= loopSize; i++)
            {
                Console.WriteLine("{0}x{1}x{0}", new string(' ', dashesOut), new string(' ', dashesIn));
                dashesIn += 2;
                dashesOut--;
            }
        }
    }
}
