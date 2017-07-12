namespace _02.Randomize_Words
{
    using System;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            var input = Console.ReadLine().Split(' ').ToArray();
            Random random = new Random();

            for (int i = 0; i < input.Length; i++)
            {
                int index = random.Next(0, input.Length);
                string temp = input[i];
                input[i] = input[index];
                input[index] = temp;
            }

            Console.WriteLine(string.Join("\n", input));
        }
    }
}
