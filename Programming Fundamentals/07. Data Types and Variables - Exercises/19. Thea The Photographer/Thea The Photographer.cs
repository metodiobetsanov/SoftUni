namespace _19.Thea_The_Photographer
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var pictures = int.Parse(Console.ReadLine());
            var filterTimer = int.Parse(Console.ReadLine());
            var filterFactor = int.Parse(Console.ReadLine());
            var uploadTime = int.Parse(Console.ReadLine());
            var pictureFilrerTime = (long)pictures * filterTimer;
            var pictureFiltered = (long)Math.Ceiling(pictures  * (filterFactor / 100d));
            var pictureUploadTime = pictureFiltered * uploadTime;
            var totalTime = pictureUploadTime + pictureFilrerTime;
            TimeSpan time = TimeSpan.FromSeconds(totalTime);

            Console.WriteLine(time.ToString(@"d\:hh\:mm\:ss"));
        }
    }
}
