using System;

namespace _02.Vapor_Store
{
    class Program
    {
        static void Main(string[] args)
        {
            var money = double.Parse(Console.ReadLine());
            var ballance = money;
            do
            {
                var game = Console.ReadLine();
                var price = 0.0;

                if (game == "Game Time")
                {
                    Console.WriteLine("Total spent: ${0:f2}. Remaining: ${1:f2}",
                        money - ballance, ballance);
                    return;
                }

                switch (game)
                {
                    case "OutFall 4": price = 39.99; break;
                    case "CS: OG": price = 15.99; break;
                    case "Zplinter Zell": price = 19.99; break;
                    case "Honored 2": price = 59.99; break;
                    case "RoverWatch": price = 29.99; break;
                    case "RoverWatch Origins Edition": price = 39.99; break;
                    default: price = 0;
                        Console.WriteLine("Not Found");
                        break;
                }
                
                if (price != 0)
                {
                    if (price <= ballance)
                    {
                        ballance -= price;
                        Console.WriteLine("Bought {0}", game);
                    }
                    else
                    {
                        Console.WriteLine("Too Expensive");
                    }
                }

                if (ballance == 0)
                {
                    Console.WriteLine("Out of money!");
                    return;
                }
            } while (ballance>0);
        }
    }
}
