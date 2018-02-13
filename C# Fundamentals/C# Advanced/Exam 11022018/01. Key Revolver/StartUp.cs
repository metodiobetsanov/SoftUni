using System;
using System.Collections.Generic;
using System.Linq;

class StartUp
{
    static void Main()
    {
        var bulletPrize = int.Parse(Console.ReadLine());
        var sizeOfGunBarrel = int.Parse(Console.ReadLine());
        var bullets = new Stack<int>(Console.ReadLine()
            .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse));
        var locks = new Queue<int>(Console.ReadLine()
            .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse));
        var valueOfIntelligence = int.Parse(Console.ReadLine());
        int bulletsUsed = 0;

        while (bullets.Count > 0 && locks.Count > 0)
        {
            int currentBullet = bullets.Pop();
            var currentLock = locks.Peek();

            

            if (currentBullet <= currentLock)
            {
                Console.WriteLine("Bang!");
                locks.Dequeue();
            }
            else
            {
                Console.WriteLine("Ping!");
            }

            bulletsUsed++;

            if (bulletsUsed % sizeOfGunBarrel == 0 && bulletsUsed != 0 && bullets.Count > 0)
            {
                Console.WriteLine("Reloading!");
            }
        }

        if (bullets.Count < locks.Count)
        {
            Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
        }
        else
        {
            var prize = valueOfIntelligence - (bulletsUsed * bulletPrize);
            Console.WriteLine($"{bullets.Count} bullets left. Earned ${prize}");
        }
    }
}

