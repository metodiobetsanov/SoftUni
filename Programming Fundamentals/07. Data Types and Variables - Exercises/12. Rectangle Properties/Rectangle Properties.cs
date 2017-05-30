namespace _12.Rectangle_Properties
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var a = double.Parse(Console.ReadLine());
            var b = double.Parse(Console.ReadLine());

            var perimeter = 2 * (a + b);
            var area = a * b;
            var diagonal = Math.Sqrt(Math.Pow(a, 2) + Math.Pow(b, 2));

            Console.Write($"{perimeter}\n{area}\n{diagonal}");
        }
    }
}
