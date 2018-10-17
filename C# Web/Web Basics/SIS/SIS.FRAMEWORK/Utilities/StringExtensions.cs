namespace SIS.FRAMEWORK.Utilities
{
    using System;

    public static class StringExtensions
    {
        public static string Capitalize(this string word)
        {
            return $"{Char.ToUpper(word[0])}{word.Substring(1).ToLower()}";
        }
    }
}