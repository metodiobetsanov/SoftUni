namespace _03.Immune_System
{
    using System;
    using System.Collections.Generic;

    public static class Program
    {
        public static void Main()
        {
            var immuneSystem = new Dictionary<string, string>();
            var immuneSystemHealth = int.Parse(Console.ReadLine());
            var originalHP = immuneSystemHealth;

            while (true)
            {
                var input = Console.ReadLine();
                var virusPower = 0.0;
                var timeToDefeat = 0;

                if (input == "end")
                {
                    break;
                }

                foreach (var letter in input)
                {
                    virusPower += letter;
                }

                virusPower = Math.Floor(virusPower / 3);

                timeToDefeat = (int)virusPower * input.Length;

                if (!immuneSystem.ContainsKey(input))
                {
                    immuneSystem[input] = "no";
                }
                else
                {
                    immuneSystem[input] = "yes";
                }

                if (immuneSystem[input] == "yes")
                {
                    foreach (var letter in input)
                    {
                        timeToDefeat = (int)virusPower * input.Length / 3;
                    }
                }

                var minutesSeconds = new int[2];

                GetMinutesSeconds(minutesSeconds, timeToDefeat);

                Console.WriteLine("Virus {0}: {1} => {2} seconds",
                    input,
                    virusPower,
                    timeToDefeat);

                immuneSystemHealth -= timeToDefeat;

                if (immuneSystemHealth > 0)
                {
                    Console.WriteLine("{0} defeated in {1}m {2}s.",
                        input,
                        minutesSeconds[0],
                        minutesSeconds[1]);

                    Console.WriteLine("Remaining health: {0}", 
                        immuneSystemHealth);

                    immuneSystemHealth = Math.Min(originalHP, immuneSystemHealth + (int)(immuneSystemHealth * 0.20));
                }
                else
                {
                    Console.WriteLine("Immune System Defeated.");
                    return;
                }
            }

            Console.WriteLine("Final Health: {0}", immuneSystemHealth);
        }

        private static void GetMinutesSeconds(int[] minutesSeconds, int timeToDefeat)
        {
            minutesSeconds[0] = timeToDefeat / 60;
            minutesSeconds[1] = timeToDefeat % 60;
        }
    }
}