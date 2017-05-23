using System;

namespace _03.Miles_to_Kilometers
{
    class Program
    {
        static void Main()
        {
            var miles = float.Parse(Console.ReadLine());
            var result = miles * 1.60934;
            Console.WriteLine("{0:F2}", result);
        }
    }
}
