using System.Runtime.Remoting.Messaging;

namespace _01.Sort_Times
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split(' ').Select(x => DateTime.ParseExact(x, "HH:mm", null)).ToList();
            input.Sort();

            var sortedTime = input.Select(x => x.ToString("HH:mm")).ToList();

            Console.WriteLine(string.Join(", ", sortedTime));
        }
    }
}
