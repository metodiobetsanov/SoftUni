using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06._8_Queens_Puzzle
{
    public class Program
    {
        public static void Main()
        {
            EightQueens.PutQueens(0);
        }
    }

    internal static class EightQueens
    {
        private const int size = 8;
        public static int solutions = 0;
        private static bool[,] board = new bool[size, size];
        private static HashSet<int> attackedRows = new HashSet<int>();
        private static HashSet<int> attackedCols = new HashSet<int>();
        private static HashSet<int> attackedLeftDiag = new HashSet<int>();
        private static HashSet<int> attackedRightDiag = new HashSet<int>();

        public static void PutQueens(int row)
        {
            if (row == size)
            {
                PrintSolution();
            }
            else
            {
                for (int col = 0; col < size; col++)
                {
                    if (CanBePlaced(row, col))
                    {
                        MarkAllAttackedPositions(row, col);
                        PutQueens(row + 1);
                        UnmarkAllAttackedPositions(row, col);
                    }
                }
            }
        }

        private static void PrintSolution()
        {
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    Console.Write(board[row, col] ? '*' : '-');
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            solutions++;
        }

        private static void UnmarkAllAttackedPositions(int row, int col)
        {
            attackedRows.Remove(row);
            attackedCols.Remove(col);
            attackedLeftDiag.Remove(col - row);
            attackedRightDiag.Remove(row + col);
            board[row, col] = false;
        }

        private static void MarkAllAttackedPositions(int row, int col)
        {
            attackedRows.Add(row);
            attackedCols.Add(col);
            attackedLeftDiag.Add(col - row);
            attackedRightDiag.Add(row + col);
            board[row, col] = true;
        }

        private static bool CanBePlaced(int row, int col)
        {
            var attacked = attackedRows.Contains(row) || attackedCols.Contains(col) ||
                           attackedLeftDiag.Contains(col - row) || attackedRightDiag.Contains(row + col);

            return !attacked;
        }
    }
}