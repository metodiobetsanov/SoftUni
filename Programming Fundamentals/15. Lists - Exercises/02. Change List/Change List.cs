namespace _02.Change_List
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class Program
    {
        public static void Main()
        {
            var myList = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            var command = new List<string>();

            while (true)
            {
                command = Console.ReadLine().Split(' ').ToList();

                if (command[0] == "Odd" || command[0] == "Even")
                {
                    break;
                }

                if (command[0] == "Delete")
                {
                    DeleteFromList(myList, command);
                }
                else if (command[0] == "Insert")
                {
                    InsertInLisr(myList, command);
                }
            }

            PrintResult(myList, command);
        }

        private static void PrintResult(List<int> myList, List<string> command)
        {
            for (int i = 0; i < myList.Count; i++)
            {
                if (command[0] == "Odd" && myList[i] % 2 != 0)
                {
                    Console.Write("{0} ", myList[i]);
                }
                else if (command[0] == "Even" && myList[i] % 2 == 0)
                {
                    Console.Write("{0} ", myList[i]);
                }
            }
        }

        private static void InsertInLisr(List<int> myList, List<string> command)
        {
            var insertItem = int.Parse(command[1]);
            var InsertPosition = int.Parse(command[2]);

            myList.Insert(InsertPosition, insertItem);
        }

        private static void DeleteFromList(List<int> myList, List<string> command)
        {
            var deleteItem = int.Parse(command[1]);

            myList.RemoveAll(item => item == deleteItem);
        }
    }
}