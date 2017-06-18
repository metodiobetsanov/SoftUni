namespace _11.Dragon_Army
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class Program
    {
        public static void Main()
        {
            var dragonType = new Dictionary<string, SortedDictionary<string, int[]>>();
            var lines = int.Parse(Console.ReadLine());

            for (int i = 0; i < lines; i++)
            {
                var token = Console.ReadLine().Split(' ').ToList();
                var type = token[0];
                var name = token[1];
                var damage = token[2] == "null" ? 45 : int.Parse(token[2]);
                var health = token[3] == "null" ? 250 : int.Parse(token[3]);
                var armor = token[4] == "null" ? 10 : int.Parse(token[4]);
               
                if (!dragonType.ContainsKey(type))
                {
                    dragonType[type] = new SortedDictionary<string, int[]>();
                }

                if (!dragonType[type].ContainsKey(name))
                {
                    dragonType[type][name] = new int[3];
                }

                dragonType[type][name][0] = damage;
                dragonType[type][name][1] = health;
                dragonType[type][name][2] = armor;
            }

            foreach (var pair in dragonType)
            {
                var type = pair.Key;
                var dragons = pair.Value;

                double[] stats = GetStats(dragons);

                Console.WriteLine($"{type}::({stats[0]:f2}/{stats[1]:f2}/{stats[2]:f2})");

                foreach (var dragon in dragons)
                {
                    var name = dragon.Key;
                    var damage = dragon.Value[0];
                    var health = dragon.Value[1];
                    var armor = dragon.Value[2];

                    Console.WriteLine($"-{name} -> damage: {damage}, health: {health}, armor: {armor}");
                }
            }
        }

        private static double[] GetStats(SortedDictionary<string, int[]> dragons)
        {
            double totalEntries = dragons.Count;
            var totalDamage = 0.0;
            var totalHealth = 0.0;
            var totalArmor = 0.0;

            foreach (var element in dragons)
            {
                totalDamage += element.Value[0];
                totalHealth += element.Value[1];
                totalArmor += element.Value[2];
            }

            return new[]
            {
                totalDamage / totalEntries,
                totalHealth / totalEntries,
                totalArmor / totalEntries
            };
        }
    }
}
