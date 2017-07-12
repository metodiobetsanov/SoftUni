namespace _01.Hello__Name_
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var name = Console.ReadLine();
            SayHello(name);
        }

        private static void SayHello(string name)
        {
            Console.WriteLine("Hello, {0}!", name);
        }
    }
}
