
using System;
using System.Collections.Generic;
using System.Linq;

class StartUp
{
    static void Main()
    {
        Queue<string> jediMasters = new Queue<string>();
        Queue<string> jediKnights = new Queue<string>();
        Queue<string> jediPadawan = new Queue<string>();
        Queue<string> myPeople = new Queue<string>();
        Queue<string> yoda = new Queue<string>();

        var lines = int.Parse(Console.ReadLine());

        for (int i = 0; i < lines; i++)
        {
            var input = Console.ReadLine()
                .Split(new []{" "}, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            foreach (var item in input)
            {

                switch (item[0])
                {
                    case 's':
                        myPeople.Enqueue(item);
                        break;
                    case 't':
                        myPeople.Enqueue(item);
                        break;
                    case 'm':
                        jediMasters.Enqueue(item);
                        break;
                    case 'k':
                        jediKnights.Enqueue(item);
                        break;
                    case 'p':
                        jediPadawan.Enqueue(item);
                        break;
                    case 'y':
                        yoda.Enqueue(item);
                        break;
                }
            }
        }

        if (yoda.Count == 0)
        {
            Console.Write(string.Join(" ", myPeople));
            Console.Write(" ");
            Console.Write(string.Join(" ", jediMasters));
            Console.Write(" ");
            Console.Write(string.Join(" ", jediKnights));
            Console.Write(" ");
            Console.Write(string.Join(" ", jediPadawan));
            Console.Write(" ");
        }
    }
}
