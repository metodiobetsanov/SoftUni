using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
    {
        public static void Main()
    { 
        HashSet<Person> persons = new HashSet<Person>();
            int lines = int.Parse(Console.ReadLine());
            for (int i = 0; i < lines; i++)
            {
                var args = Console.ReadLine().Split();
                Person person = new Person()
                {
                    Name = args[0],
                    Age = int.Parse(args[1])
                };
                persons.Add(person);
            }

        

        foreach (var r in persons.Where(p => p.Age > 30).OrderBy(p => p.Name).ToList())
        {
            Console.WriteLine($"{r.Name} - {r.Age}");
        }
    }
}

