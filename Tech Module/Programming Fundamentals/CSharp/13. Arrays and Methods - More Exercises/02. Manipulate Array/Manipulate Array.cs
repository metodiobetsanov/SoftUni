namespace _02.Manipulate_Array
{
    using System;
    using System.Linq;

    public static class Program
    {
        public static void Main()
        {
            var array = Console.ReadLine().Split(' ').ToArray();
            var numberOfCommands = int.Parse(Console.ReadLine());
            
            for (int i = 0; i < numberOfCommands; i++)
            {
                var command = Console.ReadLine().Split(' ').ToArray();

                switch (command[0])
                {
                    case "Reverse": Array.Reverse(array);
                        break;
                    case "Replace": ReplaceArray(array, command);
                        break;
                    case "Distinct":
                        array = array.Distinct().ToArray();
                        break;
                    default: break;
                }
            }

            Console.WriteLine(string.Join(", ", array));

        }

        private static void ReplaceArray(string[] array, string[] command)
        {
            var index = int.Parse(command[1]);
            var value = command[2];

            array[index] = value;
        }
    }
}
