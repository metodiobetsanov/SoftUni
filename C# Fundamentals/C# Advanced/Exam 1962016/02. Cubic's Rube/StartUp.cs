using System;
using System.Linq;

class StartUp
{
    static void Main()
    {
        long size = long.Parse(Console.ReadLine());

        long[,,] rube = new long[size, size, size];
        long notChangedCells = size * size * size;
        long sumOfChangedValues = 0;
        string input = String.Empty;

        while ((input = Console.ReadLine()) != "Analyze")
        {
            long[] tokkens = input
                .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(long.Parse)
                .ToArray();

            long x = tokkens[0];
            long y = tokkens[1];
            long z = tokkens[2];
            long value = tokkens[3];

            if (CellExists(x, y, z, size) && value != 0)
            {
                if (BeenChanged(x, y, z, rube))
                {
                    rube[x, y, z] += value;
                    sumOfChangedValues += value;
                    notChangedCells--;
                }
            }
        }

        Console.WriteLine(sumOfChangedValues);
        Console.WriteLine(notChangedCells);
    }

    private static bool BeenChanged(long x, long y, long z, long[,,] rube)
    {
        return rube[x, y, z] == 0;
    }

    private static bool CellExists(long x, long y, long z, long size)
    {
        bool xExists = x >= 0 && x < size;
        bool yExists = y >= 0 && y < size;
        bool zExists = z >= 0 && z < size;

        return xExists && zExists && yExists;
    }
}

