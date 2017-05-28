namespace _07.Cake_Ingredients
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var count = 0;

            while (count <= 20)
            {
                var ingredient = Console.ReadLine();
                if (ingredient == "Bake!")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Adding ingredient {0}.", ingredient);
                    count++;
                }
            }

            Console.WriteLine("Preparing cake with {0} ingredients.", count);
        }
    }
}
