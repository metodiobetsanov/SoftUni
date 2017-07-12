using System;

namespace _12.Volleyball
{
    class Volleyball
    {
        static void Main()
        {
            string yearType = Console.ReadLine().ToLower();
            var holidays = int.Parse(Console.ReadLine());
            var weekEnds = int.Parse(Console.ReadLine());
            var weekEndsSofia = 48 - weekEnds;
            var gamesSofia = weekEndsSofia * (3.0 / 4);
            var gamesHDays = holidays * (2.0 / 3);
            var games = gamesSofia + weekEnds + gamesHDays;
            var res = 0.0;

            if (yearType == "leap")
            {
                res = games + (games * 0.15);
                Console.WriteLine(Math.Floor(res));
            }

            else if (yearType == "normal")
            {
                Console.WriteLine(Math.Floor(games));
            }

            else
            {
                Console.WriteLine("error");
            }
        }
    }
}
