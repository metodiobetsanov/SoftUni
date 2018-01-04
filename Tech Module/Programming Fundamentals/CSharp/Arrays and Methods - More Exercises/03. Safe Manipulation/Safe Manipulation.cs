namespace _03.Safe_Manipulation
{
    using System;
    using System.Linq;

    public static class Program
    {
        public static void Main()
        {
            var array = Console.ReadLine().Split(' ').ToArray();

            while (true)
            {
                var command = Console.ReadLine().Split(' ').ToArray();
                if (command[0] == "END")
                {
                    break;
                }
                switch (command[0])
                {
                    case "Reverse":
                        Array.Reverse(array);
                        break;
                    case "Replace":
                        ReplaceArray(array, command);
                        break;
                    case "Distinct":
                        array = array.Distinct().ToArray();
                        break;
                    default: Console.WriteLine("Invalid input!");
                        break;
                }
            }

            Console.WriteLine(string.Join(", ", array));

        }

        private static void ReplaceArray(string[] array, string[] command)
        {
            var index = int.Parse(command[1]);
            var value = command[2];

            if (index < 0 || index >= array.Length)
            {
                Console.WriteLine("Invalid input!");
            }
            else
            {
                array[index] = value;
            }
        }
    }
}
