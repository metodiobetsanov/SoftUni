namespace _07._Distance_in_Labyrinth
{
    using System;
    using System.Collections.Generic;

    internal class Program
    {
        private static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var lab = ReadLab(n);

            var visited = new bool[lab.GetLength(0), lab.GetLength(1)];

            var row = 0;
            var col = 0;

            var found = false;
            for (var i = 0; i < lab.GetLength(0); i++)
            for (var j = 0; j < lab.GetLength(1); j++)
            {
                if (lab[i, j] == "*")
                {
                    col = j;
                    row = i;
                    found = true;
                    break;
                }

                if (found) break;
            }


            Queue<Cell> queue = new Queue<Cell>();
            queue.Enqueue(new Cell(row, col, true, 0));

            //Loop
            while (queue.Count != 0)
            {
                Cell current = queue.Dequeue();
                visited[current.Row, current.Col] = true;

                row = current.Row;
                col = current.Col;
                if (lab[row, col] != "*") lab[row, col] = current.Moves.ToString();


                //Up
                if (row - 1 >= 0 && lab[row - 1, col] != "x" && !visited[row - 1, col])
                    queue.Enqueue(new Cell(row - 1, col, false, current.Moves + 1));

                //Right
                if (col + 1 < lab.GetLength(1) && lab[row, col + 1] != "x" && !visited[row, col + 1])
                    queue.Enqueue(new Cell(row, col + 1, false, current.Moves + 1));

                //Down
                if (row + 1 < lab.GetLength(0) && lab[row + 1, col] != "x" && !visited[row + 1, col])
                    queue.Enqueue(new Cell(row + 1, col, false, current.Moves + 1));

                //Left
                if (col - 1 >= 0 && lab[row, col - 1] != "x" && !visited[row, col - 1])
                    queue.Enqueue(new Cell(row, col - 1, false, current.Moves + 1));
            }

            PrintLab(lab);
        }

        private static string[,] ReadLab(int n)
        {
            var lab = new string[n, n];

            for (var i = 0; i < n; i++)
            {
                var line = Console.ReadLine().ToCharArray();
                for (var j = 0; j < n; j++) lab[i, j] = line[j].ToString();
            }

            return lab;
        }

        private static void PrintLab(string[,] lab)
        {
            for (var i = 0; i < lab.GetLength(0); i++)
            {
                for (var j = 0; j < lab.GetLength(1); j++)
                    if (lab[i, j] == "*")
                        Console.Write("*");
                    else if (lab[i, j] == "0")
                        Console.Write("u");
                    else
                        Console.Write(lab[i, j]);

                Console.WriteLine();
            }
        }
    }

    internal class Cell
    {
        public Cell(int row, int col, bool visited, int moves)
        {
            Row = row;
            Col = col;
            Visited = visited;
            Moves = moves;
        }

        public int Row { get; set; }
        public int Col { get; set; }
        public bool Visited { get; set; }
        public int Moves { get; set; }
    }
}