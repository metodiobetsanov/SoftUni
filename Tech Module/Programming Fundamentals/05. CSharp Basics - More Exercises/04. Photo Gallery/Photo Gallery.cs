namespace _04.Photo_Gallery
{
    using System;
    using System.Globalization;

    public class Program
    {
        public static void Main(string[] args)
        {
            var number = int.Parse(Console.ReadLine());
            var day = int.Parse(Console.ReadLine());
            var month = int.Parse(Console.ReadLine());
            var year = int.Parse(Console.ReadLine());
            var hour = int.Parse(Console.ReadLine());
            var minute = int.Parse(Console.ReadLine());
            var picSize = long.Parse(Console.ReadLine());
            var width = int.Parse(Console.ReadLine());
            var height = int.Parse(Console.ReadLine());
            string orientation = null, type = null;
            var size = 0.0;

            DateTime date = new DateTime(year, month, day);
            TimeSpan time = new TimeSpan(hour, minute, 0);

            if (width > height)
            {
                orientation = "landscape";
            } 
            else if (width < height)
            {
                orientation = "portrait";
            }
            else
            {
                orientation = "square";
            }

            if (picSize < 1000)
            {
                size = picSize;
                type = "B";
            }
            else if (picSize < 1000000)
            {
                size = picSize / 1000.00;
                type = "KB";
            }
            else
            {
                size = Math.Round(picSize / 1000000.00, 1);
                type = "MB";
            }
        
            Console.WriteLine("Name: DSC_{0:D4}.jpg", number);
            Console.WriteLine("Date Taken: {0:dd/MM/yyyy} {1:hh\\:mm}", date, time);
            Console.WriteLine("Size: {0}{1}", size, type);
            Console.WriteLine("Resolution: {0}x{1} ({2})", width, height, orientation);
        }
    }
}
