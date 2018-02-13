
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml.Linq;

public class StartUp
{
    public static void Main()
    {
        List<Region> regions = new List<Region>();
        string input = String.Empty;

        while ((input = Console.ReadLine()) != "Count em all")
        {
            var tokkens = input
                .Split(new[] {" -> "}, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            var region = tokkens[0];
            var meteorType = tokkens[1];
            var meteorQty = int.Parse(tokkens[2]);

            if (!regions.Any(x => x.Name == region))
            {
                regions.Add(new Region()
                {
                    Name = region,
                    Meteors = new Dictionary<string, long>()
                    {
                        {"Black", 0L},
                        {"Red", 0L},
                        {"Green", 0L}
                    }
                });
            }

            var currentRegion = regions.FirstOrDefault(r => r.Name == region);
            currentRegion.Meteors[meteorType] += meteorQty;
        }

        foreach (var reg in regions)
        {
            while (reg.Meteors["Green"] >= 1000000)
            {
                reg.Meteors["Green"] -= 1000000;
                reg.Meteors["Red"]++;
            }

            while (reg.Meteors["Red"] >= 1000000)
            {
                reg.Meteors["Red"] -= 1000000;
                reg.Meteors["Black"]++;
            }
        }

        foreach (var printRegion in regions.OrderByDescending(r => r.Meteors.FirstOrDefault(f => f.Key == "Black").Value).ThenBy(n => n.Name.Length).ThenBy(a => a.Name))
            {
                Console.WriteLine(printRegion.Name);

                foreach (var printMeteor in printRegion.Meteors.OrderByDescending(m => m.Value).ThenBy(a => a.Key))
                {
                    Console.WriteLine($"-> {printMeteor.Key} : {printMeteor.Value}");
                }
            }
        
    }

    public class Region
    {
        public string Name { get; set; }
        public Dictionary<string, long> Meteors { get; set; }
    }
}