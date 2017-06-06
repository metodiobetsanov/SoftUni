namespace _13.Decrypting_Message
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var key = int.Parse(Console.ReadLine());
            var lines = int.Parse(Console.ReadLine());
            string text = string.Empty;

            for (int i = 0; i < lines; i++)
            {
                char tmp = char.Parse(Console.ReadLine());
                var decode = tmp + key;
                text = string.Concat(text, (char)decode);
            }

            Console.WriteLine(text);
        }
    }
}
