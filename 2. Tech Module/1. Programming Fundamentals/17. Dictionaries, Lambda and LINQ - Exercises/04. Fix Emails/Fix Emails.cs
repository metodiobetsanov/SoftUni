namespace _04.Fix_Emails
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            var counter = 0;
            var log = new Dictionary<string, string>();
            var last = string.Empty;

            while (true)
            {
                var input = Console.ReadLine();
                counter++;

                if (input == "stop")
                {
                    break;
                }

                if (counter % 2 == 0)
                {
                    log[last] = input;
                }
                else
                {
                    last = input;
                    if (!log.ContainsKey(input))
                    {
                        log.Add(input, string.Empty);
                    }
                }
            }

            foreach (var key in log.Keys.ToList())
            {
                if (log[key].ToLower().EndsWith("us"))
                {
                    log.Remove(key);
                }
            }

            foreach (var key in log.Keys)
            {
                Console.WriteLine("{0} -> {1}", key, log[key]);
            }
        }
    }
}
