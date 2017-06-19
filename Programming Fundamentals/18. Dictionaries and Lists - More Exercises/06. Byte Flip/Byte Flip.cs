namespace _06.Byte_Flip
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split(' ').Where(x => x.Length == 2).ToList();
            
            FlipThem(input);

            var converted = input
                .Select(x => int.Parse(x, System.Globalization.NumberStyles.HexNumber))
                .Select(x => (char)x)
                .Reverse()
                .ToList();

            Console.WriteLine(string.Join("", converted));
        }

        private static void FlipThem(List<string> input)
        {
            for (int i = 0; i < input.Count; i++)
            {
                var fliped = string.Empty;
                var chars = input[i].ToCharArray();

                for (int j = chars.Length-1; j >=0; j--)
                {
                    fliped += chars[j];
                }

                input[i] = fliped;
            }
        }
    }
}
