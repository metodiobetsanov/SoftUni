namespace _05.Boolean_Variable
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine().ToLower();
            bool output = input == "true";
            if (output)
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No");
            }
        }
    }
}
