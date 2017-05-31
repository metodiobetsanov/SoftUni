namespace _14.Integer_to_Hex_and_Binary
{
    using System;

    public class Integer_to_Hex_and_Binary
    {
        public static void Main()
        {
            var input = int.Parse(Console.ReadLine());
            var hex = Convert.ToString(input, 16);
            var bi = Convert.ToString(input, 2);

            Console.WriteLine(hex.ToUpper());
            Console.WriteLine(bi);
        }
    }
}
