namespace _05.Hands_of_Cards
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class Program
    {
        public static void Main()
        {
            var playerCards = new Dictionary<string, List<int>>();

            while (true)
            {
                var token = Console.ReadLine().Split(':').ToList();
                
                if (token[0] == "JOKER")
                {
                    break;
                }

                var player = token[0];
                var card = token[1]
                    .Split(", ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                    .Select(GetScore)
                    .ToList();

                if (!playerCards.ContainsKey(player))
                {
                    playerCards[player] = new List<int>();
                }

                playerCards[player].AddRange(card);

            }

            foreach (var ncp in playerCards)
            {
                var name = ncp.Key;
                var cards = ncp.Value;
                var score = cards.Distinct().Sum();

                Console.WriteLine($"{name}: {score}");
            }
        }

        public static int GetScore(string token)
        {
            var cardPowers = new Dictionary<string, int>();
            cardPowers["J"] = 11;
            cardPowers["Q"] = 12;
            cardPowers["K"] = 13;
            cardPowers["A"] = 14;

            for (int i = 2; i <= 10; i++)
            {
                cardPowers[i.ToString()] = i;
            }

            var cardTypes = new Dictionary<string, int>();
            cardTypes["S"] = 4;
            cardTypes["H"] = 3;
            cardTypes["D"] = 2;
            cardTypes["C"] = 1;

            var power = token.Substring(0, token.Length - 1);
            var type = token.Last().ToString();

            var score = cardPowers[power] * cardTypes[type];

            return score;
        }
    }
}
