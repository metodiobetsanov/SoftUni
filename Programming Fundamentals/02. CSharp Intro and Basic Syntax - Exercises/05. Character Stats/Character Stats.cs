namespace _05.Character_Stats
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var name = Console.ReadLine();
            var health = int.Parse(Console.ReadLine());
            var maxHealth = int.Parse(Console.ReadLine());
            var energy = int.Parse(Console.ReadLine());
            var maxEnergy = int.Parse(Console.ReadLine());

            Console.WriteLine("Name: {0}", name);

            Console.WriteLine(
                "Health: |{0}{1}|",
                new string('|', health),
                new string('.', maxHealth - health));

            Console.WriteLine(
                "Energy: |{0}{1}|",
                new string('|', energy),
                new string('.', maxEnergy - energy));
        }
    }
}
