namespace _11.Convert_Speed_Units
{
    using System;

    public class Program
    {
        public static void Main()
        {
            // to do 
            var distance = double.Parse(Console.ReadLine());
            var hours = int.Parse(Console.ReadLine());
            var minutes = int.Parse(Console.ReadLine());
            var seconds = int.Parse(Console.ReadLine());
            double kmh = (distance / 1000) / (hours + (minutes / 60.0) + ((seconds / 60.0) / 60.0));
            double ms = distance / (((hours * 60) * 60) + (minutes * 60) + seconds);
            double mh = (distance / 1609) / (hours + (minutes / 60.0) + ((seconds / 60.0) / 60.0));

            Console.WriteLine("{0}\n{1}\n{2}", Math.Round(ms,6), Math.Round(kmh, 6), Math.Round(mh, 6));
        }
    }
}
