namespace _09.Reversed_chars
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var let1 = Console.ReadLine();
            var let2 = Console.ReadLine();
            var let3 = Console.ReadLine();

            Console.WriteLine("{2}{1}{0}", let1, let2, let3);
        }
    }
}
