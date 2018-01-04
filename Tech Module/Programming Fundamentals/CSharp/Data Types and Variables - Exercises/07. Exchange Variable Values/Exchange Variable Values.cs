namespace _07.Exchange_Variable_Values
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var a = 5;
            var b = 10;
            var tmp = 0;

            Console.WriteLine("Before:");
            Console.WriteLine("a = {0}", a);
            Console.WriteLine("b = {0}", b);

            tmp = a;
            a = b;
            b = tmp;

            Console.WriteLine("After:");
            Console.WriteLine("a = {0}", a);
            Console.WriteLine("b = {0}", b);
        }
    }
}
