using System;

namespace _09.Password_Guess
{
    class Program
    {
        static void Main()
        {
            string text = Console.ReadLine();
            string pass = "s3cr3t!P@ssw0rd";

            if (text == pass)
            {
                Console.WriteLine("Welcome");
            }
            else
            {
                Console.WriteLine("Wrong password!");
            }

        }
    }
}
