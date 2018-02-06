using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

class StartUp
{
    static void Main()
    {
        var playerOneHand = Console.ReadLine()
            .Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries)
            .ToList();
        var playerTwoHand = Console.ReadLine()
            .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
            .ToList();
        int turns = 0;
        string result = String.Empty;

        string cardPowerPattern = @"\d+";
        Regex cardsPower = new Regex(cardPowerPattern);

        while (turns <= 1000000)
        {
            turns++;

            var playerOneCard = playerOneHand[0];
            playerOneHand.RemoveAt(0);
            var playerTwoCard = playerTwoHand[0];
            playerTwoHand.RemoveAt(0);
            List<string> table = new List<string>();
            table.Add(playerOneCard);
            table.Add(playerTwoCard);
            table.OrderByDescending(x => x);

            int playerOneCardPower = int.Parse(cardsPower.Match(playerOneCard).Value);
            int playerTwoCardPower = int.Parse(cardsPower.Match(playerTwoCard).Value);

            if (playerOneCardPower > playerTwoCardPower)
            {
                playerOneHand.AddRange(table);
            }
            else if (playerOneCardPower < playerTwoCardPower)
            {
                playerTwoHand.AddRange(table);
            }
            else
            {
                int playerOneSum = 0;
                int playerTwoSum = 0;
                
                while (playerOneSum == playerTwoSum && playerOneHand.Count != 0 && playerTwoHand.Count != 0)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        table.Add(playerOneHand[0]);
                        playerOneSum += playerOneHand[0][playerOneHand[0].Length - 1];
                        playerOneHand.RemoveAt(0);
                        
                        table.Add(playerTwoHand[0]);
                        playerTwoSum += playerTwoHand[0][playerTwoHand[0].Length - 1];
                        playerTwoHand.RemoveAt(0);
                    }
                }

                table.OrderByDescending(x => x);

                if (playerOneSum > playerTwoSum)
                {
                    playerOneHand.AddRange(table);
                }
                else if (playerOneSum < playerTwoSum)
                {
                    playerTwoHand.AddRange(table);
                }

            }

            if (playerOneHand.Count == 0 && playerTwoHand.Count == 0)
            {
                result = "Draw";
                break;
            }
            else if (playerOneHand.Count == 0)
            {
                result = "Second player wins";
                break;
            }
            else if (playerTwoHand.Count == 0)
            {
                result = "First player wins";
                break;
            }
            else if (turns > 1000000)
            {
                if (playerOneHand.Count < playerTwoHand.Count)
                {
                    result = "Second player wins";
                    break;
                }
                else if (playerOneHand.Count > playerTwoHand.Count)
                {
                    result = "First player wins";
                    break;
                }
            }
        }

        Console.WriteLine($"{result} after {turns} turns");
    }
}
