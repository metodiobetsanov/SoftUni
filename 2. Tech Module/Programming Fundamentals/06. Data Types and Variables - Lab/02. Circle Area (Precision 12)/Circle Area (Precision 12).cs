namespace _02.Circle_Area__Precision_12_
{
    using System;

    public class Program
    {
        public static void Main()
        {
            double r = double.Parse(Console.ReadLine());
            Console.WriteLine("{0:f12}", Math.PI * r * r);
        }
    }
}
