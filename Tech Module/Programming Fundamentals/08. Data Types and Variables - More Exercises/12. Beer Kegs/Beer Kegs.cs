namespace _12.Beer_Kegs
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var lines = int.Parse(Console.ReadLine());
            double tmp = double.MinValue;
            string name = string.Empty;
            
            for (int i = 0; i < lines; i++)
            {
                var model = Console.ReadLine();
                var r = double.Parse(Console.ReadLine());
                var h = int.Parse(Console.ReadLine());
                var volume = Math.PI * (r * r) * h;

                if (tmp < volume)
                {
                    tmp = volume;
                    name = model;
                }
            }

            Console.WriteLine(name);
        }
    }
}
