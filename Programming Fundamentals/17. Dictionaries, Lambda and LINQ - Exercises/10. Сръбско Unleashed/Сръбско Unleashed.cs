namespace _10.Сръбско_Unleashed
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class Program
    {
        public static void Main()
        {
            var concertsLog = new Dictionary<string, Dictionary<string, long>>();

            while (true)
            {
                    var input = Console.ReadLine().Split('@').ToArray();
                    
                    if (input[0] == "End")
                    {
                        break;
                    }

                    var token = input[1].Split(' ').ToArray();
                    var singerTest = input[0].Split(' ').ToArray();

                    if (token.Length > 2)
                    {

                        var singer = input[0].Trim();
                        var place = string.Empty;
                        var tickets = long.Parse(token[token.Length - 1]);
                        var price = long.Parse(token[token.Length - 2]);

                        for (int i = 0; i < token.Length - 2; i++)
                        {
                            place += token[i] + " ";
                        }

                        if (!concertsLog.ContainsKey(place))
                        {
                            concertsLog[place] = new Dictionary<string, long>();
                        }

                        if (!concertsLog[place].ContainsKey(singer))
                        {
                            concertsLog[place][singer] = 0;
                        }

                        concertsLog[place][singer] += price * tickets;
                    }
            }
            

            foreach (var venue in concertsLog)
            {
                var place = venue.Key;
                var singerLog = venue.Value;
                var sortedSingerLog = singerLog.OrderByDescending(x => x.Value).ThenBy();

                Console.WriteLine("{0}", place);

                foreach (var pair in sortedSingerLog)
                {
                    var singer = pair.Key;
                    var price = pair.Value;

                    Console.WriteLine("#  {0} -> {1}", singer, price);
                }
            }
        }
    }
}
