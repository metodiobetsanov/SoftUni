namespace _02.SoftUni_Karaoke
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            var singers = Console.ReadLine()
                .Split(new string[] { ", " }, StringSplitOptions.None)
                .ToList();
            var songs = Console.ReadLine()
                .Split(new string[] { ", " }, StringSplitOptions.None)
                .ToList();

            Dictionary<string, List<string>> karaokeList = new Dictionary<string, List<string>>();

            while (true)
            {
                var input = Console.ReadLine();

                if (input == "dawn")
                {
                    break;
                }

                var token = input.Split(new string[] { ", " }, StringSplitOptions.None).ToList();
                var singer = token[0];
                var song = token[1];
                var award = token[2];

                if (singers.Contains(singer) && songs.Contains(song))
                {
                    if (!karaokeList.ContainsKey(singer))
                    {
                        karaokeList[singer] = new List<string>();
                    }

                    karaokeList[singer].Add(award);
                }
            }

            if (karaokeList.Keys.Count > 0)
            {
                foreach (var singer in karaokeList.OrderByDescending(x => x.Value.Distinct().Count()).ThenBy(x => x.Key))
                {
                    var name = singer.Key;
                    var awards = singer.Value.Distinct().ToList();

                    Console.WriteLine("{0}: {1} awards", name, awards.Count);

                    foreach (var award in awards.OrderBy(x => x))
                    {
                        Console.WriteLine("--{0}", award);
                    }
                }
            }
            else
            {
                Console.WriteLine("No awards");
            }
        }
    }
}
