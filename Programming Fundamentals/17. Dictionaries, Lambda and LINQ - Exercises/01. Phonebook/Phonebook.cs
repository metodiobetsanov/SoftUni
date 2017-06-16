namespace _01.Phonebook
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class Phonebook
    {
        public static void Main()
        {
            var phoneBook = new Dictionary<string, string>();

            while (true)
            {
                var command = Console.ReadLine().Split(' ').ToList();

                if (command[0] == "END")
                {
                    break;
                }

                switch (command[0])
                {
                    case "A": AddToBook(phoneBook, command);
                        break;
                    case "S": SearchInBook(phoneBook, command);
                        break;

                    default: break;
                }
            }
        }

        private static void SearchInBook(Dictionary<string, string> phoneBook, List<string> command)
        {
            if (phoneBook.ContainsKey(command[1]))
            {
                Console.WriteLine("{0} -> {1}", command[1], phoneBook[command[1]]);
            }
            else
            {
                Console.WriteLine("Contact {0} does not exist.", command[1]);
            }
        }

        private static void AddToBook(Dictionary<string, string> phoneBook, List<string> command)
        {
            if (phoneBook.ContainsKey(command[1]))
            {
                phoneBook[command[1]] = command[2];
            }
            else
            {
                phoneBook.Add(command[1], command[2]);
            }
        }
    }
}
