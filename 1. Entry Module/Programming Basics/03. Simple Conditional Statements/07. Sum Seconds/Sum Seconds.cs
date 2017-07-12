using System;

namespace _07.Sum_Seconds
{
    class Program
    {
        static void Main()
        {
            var secOne = int.Parse(Console.ReadLine());
            var secTwo = int.Parse(Console.ReadLine());
            var secThree = int.Parse(Console.ReadLine());
            var sec = secOne + secTwo + secThree;
            var min = 0;
            for (min = 0; sec > 59; min++)
            {
                sec -= 60;
            }
            if (sec < 10)
            {
                Console.WriteLine(min + ":" + "0" + sec);
            }
            else
                Console.WriteLine(min + ":" + sec);
        }
    }
}
