namespace _11.Convert_Speed_Units
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var distance = float.Parse(Console.ReadLine());
            var hours = float.Parse(Console.ReadLine());
            var minutes = float.Parse(Console.ReadLine());
            var seconds = float.Parse(Console.ReadLine());
            var kmh = (distance / 1000) / (hours + (minutes / 60) + ((seconds / 60) / 60));
            var ms = distance / ((hours * 3600) + (minutes * 60) + seconds);
            var mh = (distance / 1609f) / (hours + (minutes / 60) + (seconds /3600));

            Console.WriteLine("{0}\n{1}\n{2}", ms, kmh, mh);
        }
    }
}
