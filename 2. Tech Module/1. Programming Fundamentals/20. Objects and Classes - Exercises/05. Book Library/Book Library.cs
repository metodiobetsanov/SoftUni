namespace _05.Book_Library
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

            Dictionary<string, double> bookList = new Dictionary<string, double>();

            foreach (var book in Books)
            {
                var name = book.Author;
                var price = book.Price;

                if (!bookList.ContainsKey(name))
                {
                    bookList[name] = 0;
                }

                bookList[name] += price;
            }

            var sortedBooks = bookList.OrderByDescending(b => b.Value).ThenBy(b => b.Key).ToList();

            foreach (var book in sortedBooks)
            {
                var name = book.Key;
                var price = book.Value;

                Console.WriteLine($"{name} -> {price:f2}");
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

