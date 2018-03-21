using System;
using System.Linq;

namespace DungeonsAndCodeWizards.GameManager
{
    public class Engine
    {
        private DungeonMaster dm;

        public Engine()
        {
            dm = new DungeonMaster();
        }

        public void Run()
        {
            string input;
            bool end;
            while (!(end = dm.IsGameOver()) && !string.IsNullOrWhiteSpace(input = Console.ReadLine()))
            {
                string[] tokkens = input.Split(' ');
                string command = tokkens[0];
                string[] args = tokkens.Skip(1).ToArray();
                try
                {
                    switch (command)
                    {
                        case "JoinParty":
                            Console.WriteLine(dm.JoinParty(args));
                            break;

                        case "AddItemToPool":
                            Console.WriteLine(dm.AddItemToPool(args));
                            break;

                        case "PickUpItem":
                            Console.WriteLine(dm.PickUpItem(args));
                            break;

                        case "UseItem":
                            Console.WriteLine(dm.UseItem(args));
                            break;

                        case "UseItemOn":
                            Console.WriteLine(dm.UseItemOn(args));
                            break;

                        case "GiveCharacterItem":
                            Console.WriteLine(dm.GiveCharacterItem(args));
                            break;

                        case "GetStats":
                            Console.Write(dm.GetStats());
                            break;

                        case "Attack":
                            Console.Write(dm.Attack(args));
                            break;

                        case "Heal":
                            Console.WriteLine(dm.Heal(args));
                            break;

                        case "EndTurn":
                            Console.Write(dm.EndTurn());
                            break;

                        case "IsGameOver":
                            Console.WriteLine(dm.IsGameOver());
                            break;
                    }
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine($"Parameter Error: {ae.Message}");
                }
                catch (InvalidOperationException ioe)
                {
                    Console.WriteLine($"Invalid Operation: {ioe.Message}");
                }
            }

            Console.WriteLine("Final stats:");
            Console.Write(dm.GetStats());
        }
    }
}