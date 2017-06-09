namespace _05.Compare_Char_Arrays
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            char[] textOne = Console.ReadLine().Split(' ').Select(char.Parse).ToArray();
            char[] textTwo = Console.ReadLine().Split(' ').Select(char.Parse).ToArray();
            sbyte result = 0;

            if (textOne.Length == textTwo.Length)
            {
                for (int i = 0; i < textOne.Length; i++)
                {
                    if (textOne[i] > textTwo[i])
                    {
                        result = 2;
                    }
                    else if (textOne[i] < textTwo[i])
                    {
                        result = 1;
                    }
                }
            }
            else
            {
                if (textOne.Length < textTwo.Length)
                {
                    result = 1;
                }
                else
                {
                    result = 2;
                }
            }

            if (result <= 1)
            {
                Console.WriteLine(string.Join("", textOne));
                Console.WriteLine(string.Join("", textTwo));
            }
            else
            {
                Console.WriteLine(string.Join("", textTwo));
                Console.WriteLine(string.Join("", textOne));
            }
        }
    }
}
