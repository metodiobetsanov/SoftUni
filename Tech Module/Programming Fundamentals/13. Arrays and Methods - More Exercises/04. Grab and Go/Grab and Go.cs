namespace _04.Grab_and_Go
{
    using System;
    using System.Linq;

    public static class Program
    {
        public static void Main()
        {
            var array = Console.ReadLine().Split(' ').Select(long.Parse).ToArray();
            long number = long.Parse(Console.ReadLine());
            long lastPosition = -1;
            long sum = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == number)
                {
                    lastPosition = i;
                }
            }

            if (lastPosition == -1)
            {
                Console.WriteLine("No occurrences were found!");
            }
            else
            {
                for (int i = 0; i < lastPosition; i++)
                {
                    sum += array[i];
                }

                Console.WriteLine(sum);
            }
        }
    }
}
