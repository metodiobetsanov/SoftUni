namespace _01.Type_Boundaries
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var dataType = Console.ReadLine().ToLower();
            switch (dataType)
            {
                case "sbyte":
                    Console.WriteLine(sbyte.MaxValue);
                    Console.WriteLine(sbyte.MinValue);
                    break;
                case "byte":
                    Console.WriteLine(byte.MaxValue);
                    Console.WriteLine(byte.MinValue);
                    break;
                case "int":
                    Console.WriteLine(int.MaxValue);
                    Console.WriteLine(int.MinValue);
                    break;
                case "uint":
                    Console.WriteLine(uint.MaxValue);
                    Console.WriteLine(uint.MinValue);
                    break;
                case "long":
                    Console.WriteLine(long.MaxValue);
                    Console.WriteLine(long.MinValue);
                    break;
                default: break;
            }
        }
    }
}
