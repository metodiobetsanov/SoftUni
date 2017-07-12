namespace _05.Array_Manipulator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class Program
    {
        public static void Main()
        {
            var myArray = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            string[] commands;

            while (true)
            {
                commands = Console.ReadLine().Split(' ').ToArray();

                if (commands[0] == "print")
                {
                    break;
                }

                switch (commands[0])
                {
                    case "add": ArrayAdd(myArray, commands);
                        break;
                    case "addMany": ArrayAddMany(myArray, commands);
                        break;
                    case "contains": ArrayContains(myArray, commands);
                        break;
                    case "remove": ArrayRemove(myArray, commands);
                        break;
                    case "shift": ArrayShift(myArray, commands);
                        break;
                    case "sumPairs": ArraySumPairs(myArray, commands);
                        break;

                    default: break;
                }
            }

            PrintArray(myArray);
        }

        private static void ArraySumPairs(List<int> myArray, string[] commands)
        {
            var tempList = new List<int>(myArray);
            myArray.Clear();

            for (int i = 0; i < tempList.Count; i+=2)
            {
                var currentElement = tempList[i];
                var nextElement = 0;

                if (i < tempList.Count - 1)
                {
                    nextElement = tempList[i + 1];
                }

                var sum = currentElement + nextElement;
                myArray.Add(sum);
            }
        }

        private static void ArrayShift(List<int> myArray, string[] commands)
        {
            var shiftTimes = int.Parse(commands[1]) % myArray.Count;

            for (int i = 0; i < shiftTimes; i++)
            {
                myArray.Add(myArray[0]);
                myArray.RemoveAt(0);
            }
        }

        private static void ArrayRemove(List<int> myArray, string[] commands)
        {
            var index = int.Parse(commands[1]);
            myArray.RemoveAt(index);
        }

        private static void ArrayContains(List<int> myArray, string[] commands)
        {
            var index = -1;
            var searched = int.Parse(commands[1]);

            for (var i = 0; i < myArray.Count; i++)
            {
                if (myArray[i] == searched)
                {
                    index = i;
                    break;
                }
            }

            Console.WriteLine(index);
        }

        private static void ArrayAddMany(List<int> myArray, string[] commands)
        {
            var index = int.Parse(commands[1]);
            var elements = new List<int>();

            for (var i = 2; i < commands.Length; i++)
            {
                elements.Add(int.Parse(commands[i]));
            }

            myArray.InsertRange(index, elements);
        }

        private static void ArrayAdd(List<int> myArray, string[] commands)
        {
            var index = int.Parse(commands[1]);
            var element = int.Parse(commands[2]);

            myArray.Insert(index, element);
        }

        private static void PrintArray(List<int> myArray)
        {
            Console.WriteLine("[{0}]", string.Join(", ", myArray));
        }
    }
}
