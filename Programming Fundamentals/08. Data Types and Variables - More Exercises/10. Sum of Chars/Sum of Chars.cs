namespace _10.Sum_of_Chars
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var lines = int.Parse(Console.ReadLine());
            var sum = 0;
            for (int i = 0; i < lines; i++)
            {
                char letter = char.Parse(Console.ReadLine());
                sum += (int)letter;
            }

            Console.WriteLine($"The sum equals: {sum}");
        }
    }
}
