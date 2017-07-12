namespace _06.User_Logs
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class Program
    {
        public static void Main()
        {
            var userLog = new SortedDictionary<string, Dictionary<string, int>>();
            
            while (true)
            {
                var input = Console.ReadLine().Split(' ', '=').ToList();

                if (input[0] == "end")
                {
                    break;
                }

                if (!userLog.ContainsKey(input.Last()))
                {
                    userLog[input.Last()] = new Dictionary<string, int>();
                }

                if (!userLog[input.Last()].ContainsKey(input[1]))
                {
                    userLog[input.Last()][input[1]] = 0;
                }

                userLog[input.Last()][input[1]]++;
            }

            foreach (var user in userLog)
            {
                Console.WriteLine("{0}:", user.Key);

                foreach (var log in user.Value)
                {
                    var thing = log.Key;
                    if (log.Key != user.Value.Keys.Last()) Console.Write($"{log.Key} => {log.Value}, ");
                    else Console.WriteLine($"{log.Key} => {log.Value}.");
                }
            }
        }
    }
}
