using System;
namespace _03.Back_in_30_Minutes
{
    class Program
    {
        static void Main()
        {
            var hours = int.Parse(Console.ReadLine());
            var minutes = int.Parse(Console.ReadLine());
            TimeSpan time = new TimeSpan(hours, minutes, 00);
            time += TimeSpan.FromMinutes(30);
            Console.WriteLine("{0:h\\:mm}", time);
        }
    }
}
