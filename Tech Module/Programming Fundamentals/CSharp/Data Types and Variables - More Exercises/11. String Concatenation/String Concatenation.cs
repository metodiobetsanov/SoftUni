namespace _11.String_Concatenation
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var delimiter = char.Parse(Console.ReadLine());
            var evenOrOdd = Console.ReadLine().ToLower();
            var lines = int.Parse(Console.ReadLine());
            string result = string.Empty;

            for (int i = 1; i < lines; i++)
            {
                var tmp = Console.ReadLine();

                if (i % 2 == 0 && evenOrOdd == "even")
                {
                    result = String.Concat(result, delimiter, tmp);
                }
                else if (i % 2 != 0 && evenOrOdd == "odd")
                {
                    result = String.Concat(result, delimiter, tmp);
                }
            }

            result = result.Remove(0, 1);
            Console.WriteLine(result);
        }
    }
}
