using System;
using System.Linq;

public class StartUp
{
    static char[][] board;

    public static void Main()
    {
        board = new char[8][];

        for (int row = 0; row < 8; row++)
        {
            board[row] = Console.ReadLine()
                .Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries)
                .Select(char.Parse)
                .ToArray();
        }

        string command = string.Empty;

        while ((command = Console.ReadLine()) != "END")
        {
            char figure = command[0];
            int startRow = int.Parse(command[1].ToString());
            int startCol = int.Parse(command[2].ToString());
            int targetRow = int.Parse(command[4].ToString());
            int targetCol = int.Parse(command[5].ToString());
            
            if (!FiureExiste(figure, startRow, startCol))
            {
                Console.WriteLine("There is no such a piece!");
                continue;
            }

            if (!IsMoveValid(figure, startRow, startCol, targetRow, targetCol))
            { 
                Console.WriteLine("Invalid move!");
                continue;
            }

            if (!IsOutOfBoard(targetRow, targetCol))
            {
                Console.WriteLine("Move go out of board!");
                continue;
            }

            board[targetRow][targetCol] = figure;
            board[startRow][startCol] = 'x';
            
        }
    }

    private static bool IsOutOfBoard(int targetRow, int targetCol)
    {
        bool validRow = targetRow >= 0 && targetRow < 8;
        bool validCol = targetCol >= 0 && targetCol < 8;

        return validRow && validCol;
    }

    private static bool IsMoveValid(char figure, int startRow, int startCol, int targetRow, int targetCol)
    {
        switch (figure)
        {
            case 'P':
                return ValidPawnMove(startRow, startCol, targetRow, targetCol);
                break;
            case 'R':
                return ValidStraightMove(startRow, startCol, targetRow, targetCol);
                break;
            case 'B':
                return ValidDiagonalMove(startRow, startCol, targetRow, targetCol);
                break;
            case 'Q':
                return ValidStraightMove(startRow, startCol, targetRow, targetCol) ||ValidDiagonalMove(startRow, startCol, targetRow, targetCol);
                break;
            case 'K':
                return ValidKingMove(startRow, startCol, targetRow, targetCol);
                break;
            default: throw new Exception();
        }
    }

    private static bool ValidKingMove(int startRow, int startCol, int targetRow, int targetCol)
    {
        bool validRow = Math.Abs(startRow - targetRow) == 1 || Math.Abs(startRow - targetRow) == 0;
        bool validCol = Math.Abs(startCol - targetCol) == 1 || Math.Abs(startCol - targetCol) == 0;

        return validRow && validCol;
    }

    private static bool ValidDiagonalMove(int startRow, int startCol, int targetRow, int targetCol)
    {
        return Math.Abs(startRow - targetRow) == Math.Abs(startCol - targetCol);
    }

    private static bool ValidStraightMove(int startRow, int startCol, int targetRow, int targetCol)
    {
        bool sameRow = startRow == targetRow;
        bool sameCol = startCol == targetCol;

        return sameRow || sameCol;
    }

    private static bool ValidPawnMove(int startRow, int startCol, int targetRow, int targetCol)
    {
        bool validRow = startRow - 1 == targetRow;
        bool validCol = startCol == targetCol;

        return validRow && validCol;
    }

    private static bool FiureExiste(char figure, int row, int col)
    {
        return board[row][col] == figure;
    }
}