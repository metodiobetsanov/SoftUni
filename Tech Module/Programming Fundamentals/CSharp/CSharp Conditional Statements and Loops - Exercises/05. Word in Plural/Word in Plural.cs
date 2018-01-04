namespace _05.Word_in_Plural
{
    using System;

    public class Program
    {
        public static void Main()
        {
            string word = Console.ReadLine();

            if (word != null)
            {
                if (word.EndsWith("y"))
                {
                    word = word.Remove(word.Length - 1) + "ies";
                }
                else if (word.EndsWith("o") || word.EndsWith("ch") || word.EndsWith("s") || word.EndsWith("sh")
                         || word.EndsWith("x") || word.EndsWith("z"))
                {
                    word += "es";
                }
                else
                {
                    word += "s";
                }
            }
            Console.WriteLine(word);
        }
    }
}
