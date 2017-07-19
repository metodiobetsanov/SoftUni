namespace _06.Heists
{
    using System;
    using System.Linq;

    public static class Heists
    {
        public static void Main()
        {
            var prices = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var gold = prices[1];
            var juwel = prices[0];
            var loot = 0;
            var expenses = 0;

            while (true)
            {
                var command = Console.ReadLine().Split(' ').ToArray();
                if (command[0] == "Jail")
                {
                    break;
                }

                foreach (var symbol in command[0])
                {
                    if (symbol.Equals('%'))
                    {
                        loot += juwel;
                    }
                    else if (symbol.Equals('$'))
                    {
                        loot += gold;
                    }
                }

                expenses += int.Parse(command[1]);
            }

            if (loot >= expenses)
            {
                Console.WriteLine("Heists will continue. Total earnings: {0}.", loot - expenses);
            }
            else
            {
                Console.WriteLine("Have to find another job. Lost: {0}.", expenses - loot);
            }
        }
    }
}
