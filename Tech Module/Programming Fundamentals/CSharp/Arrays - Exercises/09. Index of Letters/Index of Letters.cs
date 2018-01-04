namespace _09.Index_of_Letters
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            char[] chars = new char[26];
            var ascipos = 97;
            for (int i = 0; i < chars.Length; i++)
            {
                chars[i] = (char)ascipos;
                ascipos++;
            }

            var text = Console.ReadLine().ToLower();

            foreach (char symbol in text)
            {
                for (int i = 0; i < chars.Length; i++)
                {
                    if (symbol == chars[i])
                    {
                        Console.WriteLine("{0} -> {1}", symbol, i);
                    }
                }
            }
        }
    }
}
