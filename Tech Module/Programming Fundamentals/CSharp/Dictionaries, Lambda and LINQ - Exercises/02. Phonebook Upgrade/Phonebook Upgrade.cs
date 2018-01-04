namespace _02.Phonebook_Upgrade
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class Program
    {
        public static void Main()
        {
            var phoneBook = new SortedDictionary<string, string>();

            while (true)
            {
                var command = Console.ReadLine().Split(' ').ToList();

                if (command[0] == "END")
                {
                    break;
                }

                switch (command[0])
                {
                    case "A":
                        AddToBook(phoneBook, command);
                        break;
                    case "S":
                        SearchInBook(phoneBook, command);
                        break;
                    case "ListAll": ListaAllPhonebook(phoneBook);
                        break;

                    default: break;
                }
            }
        }

        private static void ListaAllPhonebook(SortedDictionary<string, string> phoneBook)
        {
            foreach (var name in phoneBook.Keys)
            {
                Console.WriteLine("{0} -> {1}", name, phoneBook[name]);
            }
        }

        private static void SearchInBook(SortedDictionary<string, string> phoneBook, List<string> command)
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

        private static void AddToBook(SortedDictionary<string, string> phoneBook, List<string> command)
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
