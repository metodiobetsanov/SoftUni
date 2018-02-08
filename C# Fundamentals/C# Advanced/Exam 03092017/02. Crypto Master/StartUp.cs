using System;
using System.Linq;

class StartUp
{
    static void Main()
    {
        var numbers = Console.ReadLine()
            .Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
            .Select(long.Parse)
            .ToList();

        var seqLenght = numbers.Count;
        long longestSeq = 0;

        for (int step = 1; step < seqLenght; step++)
        {
            for (int i = 0; i < seqLenght; i++)
            {
                var currentIndex = i;
                var nextIndex = (currentIndex + step) % seqLenght;
                long currentSeq = 1;

                while (numbers[currentIndex] > numbers[nextIndex])
                {
                    currentSeq += 1;
                    currentIndex = nextIndex;
                    nextIndex = (currentIndex + step) % seqLenght;
                }

                if (currentSeq > longestSeq)
                {
                    longestSeq = currentSeq;
                }
            }
        }

        Console.WriteLine(longestSeq);
    }
}

