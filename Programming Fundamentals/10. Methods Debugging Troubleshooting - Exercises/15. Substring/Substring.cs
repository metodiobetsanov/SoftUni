namespace _15.Substring
{
    using System;

    public class Substring
    {
        public static void Main()
        {
            string text = Console.ReadLine();
            int letterAdd = int.Parse(Console.ReadLine());
            
            const char Search = 'p';
            bool hasMatch = false;

            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == Search)
                {
                    hasMatch = true;
                    var endIndex = letterAdd;

                    if (endIndex > text.Length - i-1)
                    {
                        endIndex = text.Length - i;
                    }
                    else
                    {
                        endIndex = letterAdd + 1;
                    }

                    string matchedString = text.Substring(i, endIndex);
                    Console.WriteLine(matchedString);

                    i += letterAdd;
                }
            }

            if (!hasMatch)
            {
                Console.WriteLine("no");
            }
        }
    }
}
