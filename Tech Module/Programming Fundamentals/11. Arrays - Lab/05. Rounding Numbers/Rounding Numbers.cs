namespace _05.Rounding_Numbers
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var arrayOriginal = Console.ReadLine()
                .Trim()
                .Split(' ')
                .Select(double.Parse)
                .ToArray();

            var arrayCopy = new int[arrayOriginal.Length];

            for (int i = 0; i < arrayOriginal.Length; i++)
            {
                arrayCopy[i] = (int)Math.Round(arrayOriginal[i], MidpointRounding.AwayFromZero);
            }

            for (int i = 0; i < arrayOriginal.Length; i++)
            {
                Console.WriteLine("{0} => {1}", arrayOriginal[i], arrayCopy[i]);
            }
        }
    }
}
