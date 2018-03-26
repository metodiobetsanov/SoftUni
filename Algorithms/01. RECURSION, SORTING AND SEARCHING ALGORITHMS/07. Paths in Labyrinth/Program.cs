using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.Paths_in_Labyrinth
{
    public class Program
    {
        private static char[,] maze;
        private static List<char> path = new List<char>();

        public static void Main(string[] args)
        {
            ReadMaze();
            Solve(0, 0, 'S');
        }

        private static void Solve(int row, int col, char direction)
        {
            if (InBounds(row, col))
            {
                return;
            }

            path.Add(direction);

            if (IsExit(row, col))
            {
                PrintPath();
            }
            else if (CanStep(row, col))
            {
                Mark(row, col);

                Solve(row, col + 1, 'R');
                Solve(row + 1, col, 'D');
                Solve(row, col - 1, 'L');
                Solve(row - 1, col, 'U');

                Unmark(row, col);
            }

            path.RemoveAt(path.Count - 1);
        }

        private static void PrintPath()
        {
            Console.WriteLine(string.Join("", path.Skip(1)));
        }

        private static void Unmark(int row, int col)
        {
            maze[row, col] = '-';
        }

        private static void Mark(int row, int col)
        {
            maze[row, col] = 'x';
        }

        private static bool CanStep(int row, int col)
        {
            return maze[row, col] != '*' && maze[row, col] != 'x';
        }

        private static bool IsExit(int row, int col)
        {
            return maze[row, col] == 'e';
        }

        private static bool InBounds(int row, int col)
        {
            return row < 0
                   || row >= maze.GetLength(0)
                   || col < 0
                   || col >= maze.GetLength(1);
        }

        private static void ReadMaze()
        {
            var row = int.Parse(Console.ReadLine());
            var col = int.Parse(Console.ReadLine());

            maze = new char[row, col];

            for (int i = 0; i < row; i++)
            {
                var input = Console.ReadLine();
                for (int j = 0; j < col; j++)
                {
                    maze[i, j] = input[j];
                }
            }
        }
    }
}