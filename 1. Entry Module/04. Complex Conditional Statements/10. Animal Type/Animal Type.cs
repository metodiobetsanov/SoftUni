using System;

namespace _10.Animal_Type
{
    class Program
    {
        static void Main()
        {
            string animal = Console.ReadLine().ToLower();
            string m = "mammal";
            string r = "reptile";

            switch (animal)
            {
                case "dog": Console.WriteLine(m); break;
                case "crocodile": Console.WriteLine(r); break;
                case "tortoise": Console.WriteLine(r); break;
                case "snake": Console.WriteLine(r); break;
                default: Console.WriteLine("unknown"); break;
            }
        }
    }
}
