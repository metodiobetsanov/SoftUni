namespace _05.Short_Words_Sorted
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class Program
    {
        public static void Main()
        {
            var separators = new char[] {' ', '.', ',', ':', ';', '(', ')', '[', ']', '"', '\'', '\\', '/', '!', '?'};
            var myArray = Console.ReadLine().ToLower().Trim().Split(separators).Where(text => !string.IsNullOrEmpty(text)).ToArray();

            myArray = myArray.Distinct().Where(text => text.Length < 5).OrderBy(text => text).ToArray();

            Console.WriteLine(string.Join(", ", myArray));
        }
    }
}
