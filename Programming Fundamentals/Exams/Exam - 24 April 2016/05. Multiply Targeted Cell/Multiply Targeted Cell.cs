namespace _05.Multiply_Targeted_Cell
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            var matrixSize = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var R = matrixSize[0];
            var C = matrixSize[1];
            var matrix = new int[R, C];
            
            GetMatrix(R, C, matrix);

            GetValue(matrix);

            PrintMatrix(R, C, matrix);
        }

        private static void GetValue(int[,] matrix)
        {
            var targetCell = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var targetR = targetCell[0];
            var targetC = targetCell[1];
            var targetCellValue = matrix[targetR, targetC];
            var sum = 0;

            for (int i = targetR - 1; i <= targetR + 1; i++)
            {
                for (int j = targetC - 1; j <= targetC + 1; j++)
                {
                    if (!(i == targetR && j == targetC))
                    {
                        sum += matrix[i, j];
                        matrix[i, j] *= targetCellValue;
                    }
                }
            }

            matrix[targetR, targetC] *= sum;
        }

        private static void GetMatrix(int R, int C, int[,] matrix)
        {
            for (int i = 0; i < R; i++)
            {
                var input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

                for (int j = 0; j < C; j++)
                {
                    matrix[i, j] = input[j];
                }
            }
        }

        private static void PrintMatrix(int R, int C, int[,] matrix)
        {
            for (int i = 0; i < R; i++)
            {
                for (int j = 0; j < C; j++)
                {
                    Console.Write($"{matrix[i, j]} ");
                }

                Console.WriteLine();
            }
        }
    }
}
