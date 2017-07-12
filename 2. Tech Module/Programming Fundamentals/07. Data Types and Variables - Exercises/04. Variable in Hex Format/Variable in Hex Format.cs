namespace _04.Variable_in_Hex_Format
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine();
            var output = Convert.ToInt32(input, 16);
            Console.WriteLine(output);
        }
    }
}
