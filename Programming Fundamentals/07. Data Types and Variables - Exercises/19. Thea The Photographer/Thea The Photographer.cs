namespace _19.Thea_The_Photographer
{
    using System;

    public class Program
    {
        public static void Main()
        {
            //// to do
            var pictures = int.Parse(Console.ReadLine());
            var filterTimer = int.Parse(Console.ReadLine());
            var filterFactor = int.Parse(Console.ReadLine());
            var uploadTime = int.Parse(Console.ReadLine());
            var pictureFilrerTime = pictures * filterTimer;
            var pictureFiltered = (int)Math.Ceiling(pictures  * (filterFactor / 100.0));
            var pictureUploadTime = pictureFiltered * uploadTime;
            var totalTime = pictureUploadTime + pictureFilrerTime;
            TimeSpan time = TimeSpan.FromSeconds(totalTime);

            Console.WriteLine("{0}", time.ToString(@"d\:hh\:mm\:ss"));
        }
    }
}
