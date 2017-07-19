namespace _02.Advertisement_Message
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            var numberOfMessage = int.Parse(Console.ReadLine());
            Random rndGen = new Random();
            string[] phrases = new string[]
            {
                "Excellent product.",
                "Such a great product.",
                "I always use that product.",
                "Best product of its category.",
                "Exceptional product.",
                "I can’t live without this product."
            };
            string[] events = new string[]
            {
                "Now I feel good.",
                "I have succeeded with this product.",
                "Makes miracles. I am happy of the results!",
                "I cannot believe but now I feel awesome.",
                "Try it yourself, I am very satisfied.",
                "I feel great!"
            };
            string[] authors = new string[]
            {
                "Diana",
                "Petya",
                "Stella",
                "Elena",
                "Katya",
                "Iva",
                "Annie",
                "Eva"
            };
            string[] cities = new string[]
            {
                "Burgas",
                "Sofia",
                "Plovdiv",
                "Varna",
                "Ruse"
            };

            for (int i = 0; i < numberOfMessage; i++)
            {
                var tmpPhrase = phrases[rndGen.Next(0, phrases.Length)];
                var tmpEvents = events[rndGen.Next(0, events.Length)];
                var tmpAuthor = authors[rndGen.Next(0, authors.Length)];
                var tmpCity = cities[rndGen.Next(0, cities.Length)];

                Console.WriteLine($"{tmpPhrase} {tmpEvents} {tmpAuthor} – {tmpCity}.");
            }
        }
    }
}