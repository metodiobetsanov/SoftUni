using System;
using System.Collections.Generic;
using System.Linq;

class StartUp
{
    static void Main()
    {
        int boardSize = int.Parse(Console.ReadLine());
        char[][] board = new char[boardSize][];
        int removed = 0;
        int maxAttacks = 0;
        int removeRow = 0;
        int removeCol = 0;

        for (int i = 0; i < boardSize; i++)
        {
            board[i] = Console.ReadLine().ToCharArray();
        }

        do
        {
            if (maxAttacks > 0)
            {
                board[removeRow][removeCol] = '0';
                maxAttacks = 0;
                removed++;
            }

            for (int row = 0; row < boardSize; row++)
            {
                for (int col = 0; col < boardSize; col++)
                {
                    if (board[row][col] == 'K')
                    {
                        var attacks = AttackCounter(row, col, board);

                        if (attacks > maxAttacks)
                        {
                            maxAttacks = attacks;
                            removeRow = row;
                            removeCol = col;
                        }
                    }
                }
            }

        } while (maxAttacks > 0);
        
        Console.WriteLine(removed);
    }

    private static int AttackCounter(int row, int col, char[][] board)
    {
        var attacks = 0;

        if (CanBeAttacked(row - 2, col + 1, board)) { attacks++; }
        if (CanBeAttacked(row - 2, col - 1, board)) { attacks++; }
        if (CanBeAttacked(row - 1, col + 2, board)) { attacks++; }
        if (CanBeAttacked(row - 1, col - 2, board)) { attacks++; }
        if (CanBeAttacked(row + 2, col + 1, board)) { attacks++; }
        if (CanBeAttacked(row + 2, col - 1, board)) { attacks++; }
        if (CanBeAttacked(row + 1, col + 2, board)) { attacks++; }
        if (CanBeAttacked(row + 1, col - 2, board)) { attacks++; }

        return attacks;
    }

    static bool CanBeAttacked(int row, int col, char[][] board)
    {
        return IsOnBoard(row, col, board[0].Length) && board[row][col] == 'K';
        
    }

    static bool IsOnBoard(int row, int col, int boardSize)
    {
        return row > 0 && row < boardSize && col > 0 && col < boardSize;
    }
}
