namespace _08.Logs_Aggregator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class Program
    {
        public static void Main()
        {
            var namesLog = new SortedDictionary<string, SortedDictionary<string, int>>();
            var lines = int.Parse(Console.ReadLine());

            for (int i = 0; i < lines; i++)
            {
                var token = Console.ReadLine().Split(' ').ToList();
                var name = token[1];
                var ip = token[0];
                var duration = int.Parse(token[2]);

                if (!namesLog.ContainsKey(name))
                {
                    namesLog[name] = new SortedDictionary<string, int>();
                }

                if (!namesLog[name].ContainsKey(ip))
                {
                    namesLog[name][ip] = 0;
                }

                namesLog[name][ip] += duration;
            }

            foreach (var user in namesLog)
            {
                var name = user.Key;
                var ipsLog = user.Value;
                var dirationSum = ipsLog.Sum(x => x.Value);
                var ip = ipsLog.Select(x => x.Key).ToList();

                Console.WriteLine($"{name}: {dirationSum} [{string.Join(", ", ip)}]");
            }
        }
    }
}
