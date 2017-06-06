namespace _14.Boat_Simulator
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var boatOne = char.Parse(Console.ReadLine());
            var boatTwo = char.Parse(Console.ReadLine());
            var lines = int.Parse(Console.ReadLine());
            var movesBoatOne = 0;
            var movesBoatTwo = 0;

            for (int i = 1; i <= lines; i++)
            {
                string tmp = Console.ReadLine();

                if (tmp == "UPGRADE")
                {
                    boatOne += (char)3;
                    boatTwo += (char)3;
                }
                else
                {
                    if (i % 2 != 0)
                    {
                        movesBoatOne += tmp.Length;
                        if (movesBoatOne >= 50)
                        {
                            break;
                        }
                    }
                    else
                    {
                        movesBoatTwo += tmp.Length;
                        if (movesBoatTwo >= 50)
                        {
                            break;
                        }
                    }
                }
            }

            Console.WriteLine(movesBoatOne > movesBoatTwo ? boatOne : boatTwo);
        }
    }
}
