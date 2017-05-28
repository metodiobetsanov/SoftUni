namespace _15.Neighbour_Wars
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var peshoDmg = int.Parse(Console.ReadLine());
            var goshoDmg = int.Parse(Console.ReadLine());
            var peshoHP = 100;
            var goshoHP = 100;
            var hp = 0;
            string attacker, attacked, attack;
            var counter = 0;
            while (peshoHP > 0 && goshoHP > 0)
            {
                counter++;
                if (counter % 2 != 0)
                {
                    goshoHP -= peshoDmg;
                    attacker = "Pesho";
                    attacked = "Gosho";
                    attack = "Roundhouse kick";
                    hp = goshoHP;
                }
                else
                {
                    peshoHP -= goshoDmg;
                    attacker = "Gosho";
                    attacked = "Pesho";
                    attack = "Thunderous fist";
                    hp = peshoHP;
                }

                if (goshoHP <= 0 || peshoHP <= 0)
                {
                    break; 
                }
                else
                {
                    Console.WriteLine("{0} used {1} and reduced {2} to {3} health.", attacker, attack, attacked, hp);
                }

                if (counter % 3 == 0)
                {
                    goshoHP += 10;
                    peshoHP += 10;
                }
            } 

            if (peshoHP <= 0)
            {
                Console.WriteLine("Gosho won in {0}th round.", counter);
            }

            if (goshoHP <= 0)
            {
                Console.WriteLine("Pesho won in {0}th round.", counter);
            }
        }
    }
}
