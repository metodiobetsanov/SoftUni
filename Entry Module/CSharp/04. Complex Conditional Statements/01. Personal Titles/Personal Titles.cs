using System;

namespace _01.Personal_Titles
{
    class Program
    {
        static void Main()
        {
            var age = double.Parse(Console.ReadLine());
            string gender = Console.ReadLine().ToLower();
            if (age < 16)
            {
                if (gender == "f")
                {
                    Console.WriteLine("Miss");
                }
                else
                {
                    Console.WriteLine("Master");
                }
            }
            else
            {
                if (gender == "f")
                {
                    Console.WriteLine("Ms.");
                }
                else
                {
                    Console.WriteLine("Mr.");
                }
            }
        }
    }
}
