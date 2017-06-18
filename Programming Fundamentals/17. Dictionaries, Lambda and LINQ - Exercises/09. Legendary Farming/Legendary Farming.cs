namespace _09.Legendary_Farming
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class Program
    {
        public static void Main()
        {
            var materialQuantity = new Dictionary<string, int>();
            materialQuantity["shards"] = 0;
            materialQuantity["fragments"] = 0;
            materialQuantity["motes"] = 0;

            var junkQuantity = new Dictionary<string, int>();

            var keyMaterials = new List<string>() { "shards", "fragments", "motes" };

            bool loop = true;

            var legendary = string.Empty;

            do
            {
                var token = Console.ReadLine().ToLower().Split(' ').ToList();
                
                for (int i = 0; i < token.Count; i += 2)
                {
                    var material = token[i + 1];
                    var quantity = int.Parse(token[i]);

                    if (materialQuantity.ContainsKey(material))
                    {
                        materialQuantity[material] += quantity;

                        if (materialQuantity[material] >= 250)
                        {
                            switch (material)
                            {
                                case "shards":
                                    legendary = "Shadowmourne";
                                    materialQuantity[material] -= 250;
                                    break;
                                case "fragments":
                                    legendary = "Valanyr";
                                    materialQuantity[material] -= 250;
                                    break;
                                case "motes":
                                    legendary = "Dragonwrath";
                                    materialQuantity[material] -= 250;
                                    break;

                                default: break;
                            }

                            loop = false;
                            break;
                        }
                    }
                    else
                    {
                        if (!junkQuantity.ContainsKey(material))
                        {
                            junkQuantity[material] = 0;
                        }

                        junkQuantity[material] += quantity;
                    }
                }
            }
            while (loop);

            Console.WriteLine("{0} obtained!", legendary);

            var sortedMaterials = materialQuantity.OrderByDescending(x => x.Value).ThenBy(x => x.Key).ToList();
            var sortedJunk = junkQuantity.OrderBy(x => x.Key).ToList();

            foreach (var pair in sortedMaterials)
            {
                var material = pair.Key;
                var quantity = pair.Value;

                Console.WriteLine("{0}: {1}", material, quantity);
            }

            foreach (var pair in sortedJunk)
            {
                var material = pair.Key;
                var quantity = pair.Value;

                Console.WriteLine("{0}: {1}", material, quantity);
            }
        }
    }
}
