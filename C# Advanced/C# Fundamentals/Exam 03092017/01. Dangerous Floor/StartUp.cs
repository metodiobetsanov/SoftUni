using System;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        var board = new char[8, 8];

        for (var i = 0; i < 8; i++)
        {
            var row = Console.ReadLine()
                .Split(new[] {","}, StringSplitOptions.RemoveEmptyEntries)
                .Select(char.Parse)
                .ToArray();
            for (var j = 0; j < 8; j++) board[i, j] = row[j];
        }

        string moves;

        while ((moves = Console.ReadLine()) != "END")
        {
            var piece = moves[0];
            var currentRow = int.Parse(moves[1].ToString());
            var currentCol = int.Parse(moves[2].ToString());
            var destRow = int.Parse(moves[4].ToString());
            var destCol = int.Parse(moves[5].ToString());

            if (board[currentRow, currentCol] != piece)
            {
                Console.WriteLine("There is no such a piece!");
            }
            else if (destRow > 7 || destCol > 7)
            {
                Console.WriteLine("Move go out of board!");
            }
            else if (!ValidateMoves(board, piece, currentRow, currentCol, destRow, destCol))
            {
                Console.WriteLine("Invalid move!");
            }
            
            else
            {
                board[destRow, destCol] = board[currentRow, currentCol];
                board[currentRow, currentCol] = 'x';
            }
        }
    }

    private static bool ValidateMoves(char[,] board, char piece, int currentRow, int currentCol, int destRow,
        int destCol)
    {
        var moveIsValid = true;

        switch (piece)
        {
            case 'K':
                if (!(destRow - currentRow == 1 || destRow - currentRow == -1) 
                    && !(destCol - currentCol == 1 || destCol - currentCol == -1))
                {
                    return moveIsValid = false;
                }
                break;

            case 'R':
                if (destRow == currentRow)
                {
                    if (destCol > currentCol)
                    {
                        for (var i = currentCol + 1; i <= destCol; i++)
                        {
                            if (board[currentRow, i] != 'x')
                            {
                                return moveIsValid = false;
                            }
                        }
                    }
                    else
                    {
                        for (var i = currentCol - 1; i >= destCol; i--)
                        {
                            if (board[currentRow, i] != 'x')
                            {
                                return moveIsValid = false;
                            }
                        }
                    }
                }
                else if (destCol == currentCol)
                {
                    if (destRow > currentRow)
                    {
                        for (var i = currentRow + 1; i <= destRow; i++)
                        {
                            if (board[i, currentCol] != 'x')
                            {
                                return moveIsValid = false;
                            }
                        }
                    }
                    else
                    {
                        for (var i = currentRow - 1; i >= destRow; i--)
                        {
                            if (board[i, currentCol] != 'x')
                            {
                                return moveIsValid = false;
                            }
                        }
                    }
                }
                else
                {
                    return moveIsValid = false;
                }
                break;

            case 'B':
                if (destRow < currentRow && destCol < currentCol)
                {
                    for (var i = currentRow - 1; i >= destRow; i--)
                    {
                        for (var j = currentCol - 1; j >= destCol; j--)
                        {
                            if (board[currentRow, i] != 'x')
                            {
                                return moveIsValid = false;
                            }
                        }
                    }
                }
                else if (destRow < currentRow && destCol > currentCol)
                {
                    for (var i = currentRow; i <= destRow; i++)
                    {
                        for (var j = currentCol; j >= destCol; j--)
                        {
                            if (board[currentRow, i] != 'x')
                            {
                                return moveIsValid = false;
                            }
                        }
                    }
                }
                else if (destRow > currentRow && destCol > currentCol)
                {
                    for (var i = currentRow; i <= destRow; i++)
                    {
                        for (var j = currentCol; j <= destCol; j++)
                        {
                            if (board[currentRow, i] != 'x')
                            {
                                return moveIsValid = false;
                            }
                        }
                    }
                }
                else if (destRow > currentRow && destCol < currentCol)
                {
                    for (var i = currentRow; i <= destRow; i++)
                    {
                        for (var j = currentCol; j >= destCol; j--)
                        {
                            if (board[currentRow, i] != 'x')
                            {
                                return moveIsValid = false;
                            }
                        }
                    }
                }
                break;

            case 'Q':
                if (destRow == currentRow)
                {
                    if (destCol > currentCol)
                    {
                        {
                            for (var i = currentCol + 1; i <= destCol; i++)
                            {
                                if (board[currentRow, i] != 'x')
                                {
                                    return moveIsValid = false;
                                }
                            }
                        }
                    }
                    else
                    {
                        for (var i = currentCol + 1; i >= destCol; i--)
                        {
                            if (board[currentRow, i] != 'x')
                            {
                                return moveIsValid = false;
                            }
                        }
                    }
                }
                else if (destCol == currentCol)
                {
                    if (destRow > currentRow)
                    {
                        for (var i = currentRow + 1; i <= destRow; i++)
                        {
                            if (board[currentRow, i] != 'x')
                            {
                                return moveIsValid = false;
                            }
                        }
                    }
                    else
                    {
                        for (var i = currentRow - 1; i >= destRow; i--)
                        {
                            if (board[currentRow, i] != 'x')
                            {
                                return moveIsValid = false;
                            }
                        }
                    }
                }
                else if (destRow < currentRow && destCol < currentCol)
                {
                    for (var i = currentRow - 1; i >= destRow; i--)
                    {
                        for (var j = currentCol - 1; j >= destCol; j--)
                        {
                            if (board[i, j] != 'x')
                            {
                                return moveIsValid = false;
                            }
                        }
                    }
                }
                else if (destRow < currentRow && destCol > currentCol)
                {
                    for (var i = currentRow + 1; i <= destRow; i++)
                    {
                        for (var j = currentCol + 1; j >= destCol; j--)
                        {
                            if (board[i, j] != 'x')
                            {
                                return moveIsValid = false;
                            }
                        }
                    }
                }
                else if (destRow > currentRow && destCol > currentCol)
                {
                    for (var i = currentRow + 1; i <= destRow; i++)
                    {
                        for (var j = currentCol + 1; j <= destCol; j++)
                        {
                            if (board[i, j] != 'x')
                            {
                                return moveIsValid = false;
                            }
                        }
                    }
                }
                else if (destRow > currentRow && destCol < currentCol)
                {
                    for (var i = currentRow + 1; i <= destRow; i++)
                    {
                        for (var j = currentCol - 1; j >= destCol; j--)
                        {
                            if (board[i, j] != 'x')
                            {
                                return moveIsValid = false;
                            }
                        }
                    }
                }
                break;

            case 'P':
                if (destRow > currentRow || destCol != currentCol)
                    moveIsValid = false;
                break;
        }

        return moveIsValid;
    }
   
}