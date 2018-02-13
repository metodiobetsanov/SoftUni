
using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

class StartUp
{
    static void Main()
    {
        string pattern = @"(((?<open>\[)|{)\D*(?<digid>\d*)\D*(?(open)]|}))";
        StringBuilder massage = new StringBuilder();
        StringBuilder result = new StringBuilder();

        int lines = int.Parse(Console.ReadLine());
        for (int i = 0; i < lines; i++)
        {
            var input = Console.ReadLine();
            massage.Append(input);
        }

        var text = massage.ToString();

        foreach (Match item in Regex.Matches(text, pattern))
        {
            var digits = item.Groups["digid"].Value;
            var offset = item.Length;

            for (int i = 0; i < digits.Length; i += 3)
            {
                string letter = $"{digits[i]}{digits[i+1]}{digits[i+2]}";
                int charNumber = int.Parse(letter) - offset;
                result.Append((char) charNumber);
            }
        }

        Console.WriteLine(result.ToString());
    }
}
