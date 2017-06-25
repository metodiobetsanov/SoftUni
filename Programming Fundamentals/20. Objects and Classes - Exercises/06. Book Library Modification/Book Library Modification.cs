namespace _06.Book_Library_Modification
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            Book[] Books = Book.Read();
            var filterDate = DateTime.ParseExact(Console.ReadLine(), "dd.MM.yyyy", CultureInfo.InvariantCulture);

            Dictionary<string, DateTime> bookList = new Dictionary<string, DateTime>();

            foreach (var book in Books)
            {
                var name = book.Title;
                var date = book.ReleaseDate;
                
                bookList[name] = date;
            }

            var sortedBooks = bookList.Where(b => b.Value > filterDate).OrderBy(b => b.Value).ThenBy(b => b.Key).ToList();

            foreach (var book in sortedBooks)
            {
                var name = book.Key;
                var date = book.Value;

                Console.WriteLine($"{name} -> {date:dd.MM.yyyy}");
            }
        }

        class Book
        {
            public string Title { get; set; }

            public string Author { get; set; }

            public string Publisher { get; set; }

            public DateTime ReleaseDate { get; set; }

            public int ISBN { get; set; }

            public double Price { get; set; }

            public static Book[] Read()
            {

                int n = int.Parse(Console.ReadLine());

                Book[] Books = new Book[n];

                for (int i = 0; i < n; i++)
                {
                    Books[i] = ReadBook();
                }

                return Books;
            }

            public static Book ReadBook()
            {
                var input = Console.ReadLine().Split(' ').ToList();

                Book b = new Book();

                b.Title = input[0];
                b.Author = input[1];
                b.Publisher = input[2];
                b.ReleaseDate = DateTime.ParseExact(input[3], "dd.MM.yyyy", CultureInfo.InvariantCulture);
                b.ISBN = int.Parse(input[4]);
                b.Price = double.Parse(input[5]);

                return b;
            }
        }
    }
}

