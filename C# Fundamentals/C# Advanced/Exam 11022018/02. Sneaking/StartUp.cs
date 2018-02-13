using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.AccessControl;

public class StartUp
{
    public static char[][] room;
    public static int roomSize;
    public static bool isSamKilled = false;
    public static bool isNikoladzeKilled = false;

    public static void Main()
    {
        roomSize = int.Parse(Console.ReadLine());
        room = new char[roomSize][];
        for (int i = 0; i < roomSize; i++)
        {
            room[i] = Console.ReadLine().ToCharArray();
        }

        var moves = new Queue<char>(Console.ReadLine().ToCharArray());
        while (moves.Count != 0 && !isSamKilled && !isNikoladzeKilled)
        {
            var currentMove = moves.Dequeue();

            switch (currentMove)
            {
                case 'W':
                    Wait();
                    break;
                case 'U':
                    GoUp();
                    break;
                case 'D':
                    GoDown();
                    break;
                case 'L':
                    GoLeft();
                    break;
                case 'R':
                    GoRight();
                    break;
            }
        }

        for (int row = 0; row < roomSize; row++)
        {
            for (int col = 0; col < room[0].Length; col++)
            {
                Console.Write(room[row][col]);
            }

            Console.WriteLine();
        }
    }

    private static void GoRight()
    {
        Wait();

        for (int row = 0; row < roomSize; row++)
        {
            if (IsSamKilled(row))
            {
                isSamKilled = true;
                break;
            }
            else
            {
                for (int col = 0; col < room[row].Length; col++)
                {
                    if (room[row][col] == 'S')
                    {
                        room[row][col] = '.';
                        room[row][col + 1] = 'S';
                        if (IsSamKilled(row))
                        {
                            isSamKilled = true;
                            break;
                        }
                        break;
                    }
                }
            }
        }
    }

    private static void GoLeft()
    {
        Wait();

        for (int row = 0; row < roomSize; row++)
        {
            if (IsSamKilled(row))
            {
                isSamKilled = true;
                break;
            }
            else
            {
                for (int col = 0; col < room[row].Length; col++)
                {
                    if (room[row][col] == 'S')
                    {
                        room[row][col] = '.';
                        room[row][col - 1] = 'S';
                        if (IsSamKilled(row))
                        {
                            isSamKilled = true;
                            break;
                        }
                        break;
                    }
                }
            }
        }
    }

    private static void GoDown()
    {
        Wait();

        for (int row = 0; row < roomSize; row++)
        {
            bool moved = false;

            if (IsSamKilled(row))
            {
                isSamKilled = true;
                break;
            }
            else
            {
                for (int col = 0; col < room[row].Length; col++)
                {
                    if (room[row][col] == 'S')
                    {
                        room[row][col] = '.';
                        room[row + 1][col] = 'S';
                        IsNikoladzeKilled(row + 1);
                        if (IsSamKilled(row + 1))
                        {
                            isSamKilled = true;
                            break;
                        }
                        moved = true;

                    }
                }
            }

            if (moved)
            {
                break;
            }
        }
    }

    private static void GoUp()
    {
        Wait();

        for (int row = 0; row < roomSize; row++)
        {
            bool breaked = false;

                for (int col = 0; col < room[row].Length - 1; col++)
                {
                    if (room[row][col] == 'S')
                    {
                        room[row][col] = '.';
                        room[row - 1][col] = 'S';
                        IsNikoladzeKilled(row - 1);
                        if (IsSamKilled(row - 1))
                        {
                            isSamKilled = true;
                            breaked = true;
                        }
                        break;
                    }
                }

            if (breaked)
            {
                break;
            }
        }
    }

    private static void Wait()
    {
        for (int row = 0; row < roomSize; row++)
        {
            for (int col = 0; col < room[row].Length; col++)
            {
                bool moved = false;
                switch (room[row][col])
                {
                    case 'b':
                        if (col == (room[row].Length - 1))
                        {
                            room[row][col] = 'd';
                        }
                        else
                        {
                            room[row][col] = '.';
                            room[row][col + 1] = 'b';
                        }

                        moved = true;
                        break;

                    case 'd':
                        if (col == 0)
                        {
                            room[row][col] = 'b';
                        }
                        else
                        {
                            room[row][col] = '.';
                            room[row][col - 1] = 'd';
                        }

                        moved = true;
                        break;
                }

                if (moved)
                {
                    break;
                }
            }
        }
    }

    private static bool IsSamKilled(int row)
    {
        if (!room[row].Contains('S'))
        {
            return false;
        }

        int samCol = -1;
        int enemyCol = -1;
        char enemy = 'A';

        for (int col = 0; col < room[row].Length; col++)
        {
            if (room[row][col] == 'b' || room[row][col] == 'd')
            {
                enemyCol = col;
                enemy = room[row][col];
            }
            else if (room[row][col] == 'S')
            {
                samCol = col;
            }
        }

        switch (enemy)
        {
            case 'b':
                if (enemyCol < samCol && enemyCol != -1 && samCol != -1)
                {
                    room[row][samCol] = 'X';
                    Console.WriteLine($"Sam died at {row}, {samCol}");
                    return true;
                }
                else
                {
                    return false;
                }
            case 'd':
                if (enemyCol > samCol && enemyCol != -1 && samCol != -1)
                {
                    room[row][samCol] = 'X';
                    Console.WriteLine($"Sam died at {row}, {samCol}");
                    return true;
                }
                else
                {
                    return false;
                }

            default:
                return false;
        }
    }

    public static void IsNikoladzeKilled(int row)
    {
        if (room[row].Contains('S') && room[row].Contains('N'))
        {
            Console.WriteLine("Nikoladze killed!");

            isNikoladzeKilled = true;
            for (int col = 0; col < room[row].Length; col++)
            {
                if (room[row][col] == 'N')
                {
                    room[row][col] = 'X';
                }
            }
        }
    }
}