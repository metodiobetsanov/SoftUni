namespace _05.Hands_of_Cards
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class Program
    {
        public static void Main()
        {
            var results = new Dictionary<string, int>();
            while (true)
            {
                var token = Console.ReadLine().Split(' ', ',').ToArray();
                var score = 0;

                if (token[0] == "JOKER")
                {
                    break;
                }

                token = token.Distinct().ToArray();

                for (int i = 1; i < token.Length; i++)
                {
                    var power = 0;
                    var multiplier = 0;
                    
                    if (token[i]. StartsWith("1"))
                    { 
                        power = 1;
                    }
                    else if (token[i].StartsWith("2"))
                    {
                        power = 2;
                    }
                    else if (token[i].StartsWith("3"))
                    {
                        power = 3;
                    }
                    else if (token[i].StartsWith("4"))
                    {
                        power = 4;
                    }
                    else if (token[i].StartsWith("5"))
                    {
                        power = 5;
                    }
                    else if (token[i].StartsWith("6"))
                    {
                        power = 6;
                    }
                    else if (token[i].StartsWith("7"))
                    {
                        power = 7;
                    }
                    else if (token[i].StartsWith("8"))
                    {
                        power = 8;
                    }
                    else if (token[i].StartsWith("9"))
                    {
                        power = 9;
                    }
                    else if (token[i].StartsWith("10"))
                    {
                        power = 10;
                    }
                    else if (token[i].StartsWith("J"))
                    {
                        power = 11;
                    }
                    else if (token[i].StartsWith("Q"))
                    {
                        power = 12;
                    }
                    else if (token[i].StartsWith("K"))
                    {
                        power = 13;
                    }
                    else if (token[i].StartsWith("A"))
                    {
                        power = 14;
                    }

                    if (token[i].EndsWith("S"))
                    {
                        multiplier = 4;
                    }
                    else if(token[i].EndsWith("H"))
                    {
                        multiplier = 3;
                    }
                    else if (token[i].EndsWith("D"))
                    {
                        multiplier = 2;
                    }
                    else if (token[i].EndsWith("C"))
                    {
                        multiplier = 1;
                    }

                    score += power * multiplier;
                }

                if (results.ContainsKey(token[0]))
                {
                    results[token[0]] += score;
                }
                else
                {
                    results.Add(token[0], score);
                }
            }

            foreach (var key in results.Keys)
            {
                Console.WriteLine("{0} {1}", key, results[key]);
            }
        }
    }
}
