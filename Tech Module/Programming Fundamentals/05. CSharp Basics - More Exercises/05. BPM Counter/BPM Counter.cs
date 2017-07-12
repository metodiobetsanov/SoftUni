namespace _05.BPM_Counter
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            var beatsPerMinute = int.Parse(Console.ReadLine());
            var beatsCount = double.Parse(Console.ReadLine());
            var bars = Math.Round(beatsCount / 4.0, 1);
            var time = (beatsCount / beatsPerMinute) * 60;
            var mins = (int)time / 60;
            var secs = (int)time % 60;

            Console.WriteLine("{0} bars - {1}m {2}s", bars, mins, secs);
        }
    }
}
