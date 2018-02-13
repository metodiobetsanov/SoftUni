using System;
using System.Collections.Generic;
using System.Linq;

class StartUp
{
    static void Main()
    {
        Dictionary<string, Dictionary<string, string>> infoBook = new Dictionary<string, Dictionary<string, string>>();

        int tagetInfoIndex = int.Parse(Console.ReadLine());
        string input = string.Empty;

        while ((input = Console.ReadLine()) != "end transmissions")
        {
            var tokkens = input
                .Split(new[] {";", "=", ":"}, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            var name = tokkens[0];
            if (!infoBook.ContainsKey(name))
            {
                infoBook.Add(name, new Dictionary<string, string>());
            }

            for (int i = 1; i < tokkens.Length - 1; i += 2)
            {
                var key = tokkens[i];
                var value = tokkens[i + 1];

                if (!infoBook[name].ContainsKey(key))
                {
                    infoBook[name].Add(key, string.Empty);
                }

                infoBook[name][key] = value;
            }
        }

        var killCommand = Console.ReadLine().Split().ToArray();
        string killName = killCommand[1];
        var infoIndex = 0;
        Console.WriteLine($"Info on {killName}:");
        foreach (var info in infoBook.FirstOrDefault(p => p.Key == killName).Value.OrderBy(i => i.Key))
        {
            Console.WriteLine($"---{info.Key}: {info.Value}");
            infoIndex += info.Key.Length + info.Value.Length;
        }
        Console.WriteLine($"Info index: {infoIndex}");
        Console.WriteLine((infoIndex>=tagetInfoIndex)? $"Proceed" : $"Need {tagetInfoIndex -infoIndex} more info.");
    }
}
