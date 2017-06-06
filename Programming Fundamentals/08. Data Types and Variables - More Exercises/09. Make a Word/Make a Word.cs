namespace _09.Make_a_Word
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var lines = int.Parse(Console.ReadLine());
            string word = string.Empty;

            for (int i = 0; i < lines; i++)
            {
                var letter = Console.ReadLine();
                word = String.Concat(word, letter);
            }
            
            Console.WriteLine($"The word is: {word}");
        }
    }
}
