using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

public class StartUp
{
    public static void Main()
    {
        var firstPlayerDeck = new Queue<string>(Console.ReadLine().Split());
        var secondPlayerDeck = new Queue<string>(Console.ReadLine().Split());

        var turnCounter = 0;
        var result = string.Empty;
        bool gameOver = false;

        while (turnCounter < 1000000 && firstPlayerDeck.Count > 0 && secondPlayerDeck.Count > 0 && !gameOver)
        {
            turnCounter++;

            var firstPlayerCard = firstPlayerDeck.Dequeue();
            var secondPlayerCard = secondPlayerDeck.Dequeue();

            if (GetPower(firstPlayerCard) > GetPower(secondPlayerCard))
            {
                firstPlayerDeck.Enqueue(firstPlayerCard);
                firstPlayerDeck.Enqueue(secondPlayerCard);
            }
            else if (GetPower(firstPlayerCard) < GetPower(secondPlayerCard))
            {
                secondPlayerDeck.Enqueue(secondPlayerCard);
                secondPlayerDeck.Enqueue(firstPlayerCard);
            }
            else
            {
                var tableCards = new List<string> { firstPlayerCard, secondPlayerCard };

                while (!gameOver)
                {
                    if (firstPlayerDeck.Count >= 3 && secondPlayerDeck.Count >= 3)
                    {
                        int firstPlayerSum = 0;
                        int seconPlayerSum = 0;

                        for (int i = 0; i < 3; i++)
                        {
                            var firstCard = firstPlayerDeck.Dequeue();
                            var secondCard = secondPlayerDeck.Dequeue();
                            firstPlayerSum += GetChar(firstCard);
                            seconPlayerSum += GetChar(secondCard);
                            tableCards.Add(firstCard);
                            tableCards.Add(secondCard);
                        }

                        if (firstPlayerSum > seconPlayerSum)
                        {
                            AddToWinnerDeck(tableCards, firstPlayerDeck);
                            break;
                        }
                        else if (firstPlayerSum < seconPlayerSum)
                        {
                            AddToWinnerDeck(tableCards, secondPlayerDeck);
                            break;
                        }
                    }
                    else
                    {
                        gameOver = true;
                    }
                }
            }

        }

        if (firstPlayerDeck.Count == secondPlayerDeck.Count)
        {
            result = "Draw";
        }
        else if (firstPlayerDeck.Count > secondPlayerDeck.Count)
        {
            result = "First player wins";
        }
        else if (firstPlayerDeck.Count < secondPlayerDeck.Count)
        {
            result = "Second player wins";
        }

        Console.WriteLine($"{result} after {turnCounter} turns");
    }

    private static void AddToWinnerDeck(List<string> tableCards, Queue<string> playerDeck)
    {
        foreach (var card in tableCards.OrderByDescending(c => GetPower(c)).ThenByDescending(c => GetChar(c)))
        {
            playerDeck.Enqueue(card);
        }
    }
    
    public static int GetPower(string card)
    {
        return int.Parse(card.Substring(0, card.Length - 1));
    }

    public static char GetChar(string card)
    {
        return card[card.Length - 1];
    }
}
 