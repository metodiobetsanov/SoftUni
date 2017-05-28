namespace _03.Miles_to_Kilometers
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var miles = float.Parse(Console.ReadLine());
            var result = miles * 1.60934;

            Console.WriteLine("{0:F2}", result);
        }
    }
}
