namespace _03.A_Miner_Task
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            var counter = 0;
            var log = new Dictionary<string, long>();
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
                    var qty = long.Parse(input);

                    log[last] += qty;
                }
                else
                {
                    last = input;
                    if (!log.ContainsKey(input))
                    {
                        log.Add(input, 0);
                    }
                }
            }

            foreach (var key in log.Keys)
            {
                Console.WriteLine("{0} -> {1}", key, log[key]);
            }
        }
    }
}
