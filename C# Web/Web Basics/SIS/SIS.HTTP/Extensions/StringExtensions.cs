namespace SIS.HTTP.Extensions
{
    using SIS.HTTP.Common;

    using System;

    public static class StringExtensions
    {
        public static string Capitalize(this string word)
        {
            CoreValidator.ThrowIfNullOrEmpty(word, nameof(word));

            return Char.ToUpper(word[0]) + word.Substring(1).ToLower();
        }
    }
}