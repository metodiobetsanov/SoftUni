using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Game_of_Names
{
    class Program
    {
        static void Main(string[] args)
        {
            var numberOfPlayers = int.Parse(Console.ReadLine());
            var winner = string.Empty;
            var score = int.MinValue;

            for (int i = 0; i < numberOfPlayers; i++)
            {
                var playerName = Console.ReadLine();
                var initialScore = int.Parse(Console.ReadLine());

                foreach (var letter in playerName)
                {
                    var result = (int) letter;

                    if (result % 2 ==0 )
                    {
                        initialScore += result;
                    }
                    else
                    {
                        initialScore -= result;
                    }
                }

                if (initialScore > score)
                {
                    winner = playerName;
                    score = initialScore;
                }
            }

            Console.WriteLine("The winner is {0} - {1} points", winner, score);
        }
    }
}
