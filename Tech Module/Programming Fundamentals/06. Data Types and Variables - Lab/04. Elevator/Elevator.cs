namespace _04.Elevator
{
    using System;

    public class Elevator
    {
        public static void Main()
        {
            int persons = int.Parse(Console.ReadLine());
            int limit = int.Parse(Console.ReadLine());
            int courses = (int)Math.Ceiling((double)persons / limit);

            Console.WriteLine(courses);
        }
    }
}
