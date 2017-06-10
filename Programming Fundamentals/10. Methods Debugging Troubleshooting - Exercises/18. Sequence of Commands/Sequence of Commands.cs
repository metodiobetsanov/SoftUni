namespace _18.Sequence_of_Commands
{
    using System;
    using System.Diagnostics;
    using System.Linq;

    public class Program
    {
        private const char ArgumentsDelimiter = ' ';

        public static void Main()
        {
            int.Parse(Console.ReadLine());

            long[] array = Console.ReadLine()
                .Split(ArgumentsDelimiter)
                .Select(long.Parse)
                .ToArray();

            var commandLine = Console.ReadLine();

            while (!commandLine.Equals("stop"))
            {
                string[] commandString = commandLine
                    .Split(ArgumentsDelimiter)
                    .ToArray();
                var args = new int[2];
                var command = commandString[0];

                if (command.Equals("add") || command.Equals("subtract") || command.Equals("multiply"))
                {
                    args[0] = int.Parse(commandString[1]);
                    args[1] = int.Parse(commandString[2]);
                }

                PerformAction(array, command, args);

                PrintArray(array);
                Console.WriteLine();

                commandLine = Console.ReadLine();
            }
        }

        private static void ArrayShiftLeft(long[] array)
        {
            long movedPart = array[0];

            for (int i = 0; i < array.Length - 1; i++)
            {
                array[i] = array[i + 1];
            }

            array[array.Length - 1] = movedPart;
        }

        private static void ArrayShiftRight(long[] array)
        {
            long movedPart = array[array.Length - 1];

            for (int i = array.Length - 1; i >= 1; i--)
            {
                array[i] = array[i - 1];
            }

            array[0] = movedPart;
        }

        private static void PerformAction(long[] array, string action, int[] args)
        {
            var pos = args[0]-1;
            var value = args[1];

            switch (action)
            {
                case "multiply":
                    array[pos] *= value;
                    break;
                case "add":
                    array[pos] += value;
                    break;
                case "subtract":
                    array[pos] -= value;
                    break;
                case "lshift":
                    ArrayShiftLeft(array);
                    break;
                case "rshift":
                    ArrayShiftRight(array);
                    break;
                default: break;
            }
        }

        private static void PrintArray(long[] array)
        {
            for (var i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }
        }
    }
}