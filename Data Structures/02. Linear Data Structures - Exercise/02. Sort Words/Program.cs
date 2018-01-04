namespace _02._Sort_Words
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            List<string> list = Console.ReadLine()
                .Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            Console.WriteLine(string.Join(" ", list.OrderBy(x => x).ToString()));
        }
    }
}
