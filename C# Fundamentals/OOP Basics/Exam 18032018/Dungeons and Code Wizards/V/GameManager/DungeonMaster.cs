using DungeonsAndCodeWizards.Models.Characters;
using DungeonsAndCodeWizards.Models.Contracts;
using DungeonsAndCodeWizards.Models.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DungeonsAndCodeWizards.GameManager.Factories;

namespace DungeonsAndCodeWizards.GameManager
{
    public class DungeonMaster
    {
        private int lastSurRound = 0;

        private CharacterFactory characterFactory;
        private ItemFactory itemFactory;
        private Stack<Item> itemPool;
        private List<Character> characters;

        public DungeonMaster()
        {
            characterFactory = new CharacterFactory();
            itemFactory = new ItemFactory();
            itemPool = new Stack<Item>();
            characters = new List<Character>();
        }

        public string JoinParty(string[] args)
        {
            string faction = args[0];
            string type = args[1];
            string name = args[2];
            Character character = characterFactory.CreateCharacter(faction, type, name);

            characters.Add(character);
            return $"{character.Name} joined the party!";
        }

        public string AddItemToPool(string[] args)
        {
            string itemName = args[0];

            Item item = itemFactory.CreateItem(itemName);

            itemPool.Push(item);
            return $"{itemName} added to pool.";
        }

        public string PickUpItem(string[] args)
        {
            string charName = args[0];
            Character character = characters.FirstOrDefault(c => c.Name == charName);

            if (character == null)
            {
                throw new ArgumentException(string.Format(Output.CharNotFound, charName));
            }

            if (itemPool.Count == 0)
            {
                throw new InvalidOperationException(Output.PoolEmpty);
            }

            Item item = itemPool.Pop();
            character.ReceiveItem(item);

            return $"{charName} picked up {item.GetType().Name}!";
        }

        public string UseItem(string[] args)
        {
            string charName = args[0];
            string itemName = args[1];

            Character character = characters.FirstOrDefault(c => c.Name == charName);

            if (character == null)
            {
                throw new ArgumentException(string.Format(Output.CharNotFound, charName));
            }

            Item item = character.Bag.GetItem(itemName);

            character.UseItem(item);

            return $"{character.Name} used {itemName}.";
        }

        public string UseItemOn(string[] args)
        {
            string giverName = args[0];
            string receiverName = args[1];
            string itemName = args[2];

            Character giver = characters.FirstOrDefault(x => x.Name == giverName);
            Character receiver = characters.FirstOrDefault(x => x.Name == receiverName);

            if (giver == null)
            {
                throw new ArgumentException(string.Format(Output.CharNotFound, giverName));
            }

            if (receiver == null)
            {
                throw new ArgumentException(string.Format(Output.CharNotFound, receiverName));
            }

            Item item = giver.Bag.GetItem(itemName);

            giver.UseItemOn(item, receiver);
            return $"{giverName} used {itemName} on {receiverName}.";
        }

        public string GiveCharacterItem(string[] args)
        {
            string giverName = args[0];
            string receiverName = args[1];
            string itemName = args[2];

            Character giver = characters.FirstOrDefault(x => x.Name == giverName);
            Character receiver = characters.FirstOrDefault(x => x.Name == receiverName);

            if (giver == null)
            {
                throw new ArgumentException(string.Format(Output.CharNotFound, giverName));
            }

            if (receiver == null)
            {
                throw new ArgumentException(string.Format(Output.CharNotFound, receiverName));
            }

            Item item = giver.Bag.GetItem(itemName);

            giver.GiveCharacterItem(item, receiver);
            return $"{giverName} gave {receiverName} {itemName}.";
        }

        public string GetStats()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var character in characters.OrderByDescending(x => x.IsAlive).ThenByDescending(x => x.Health))
            {
                string deathOrAlive = character.IsAlive ? "Alive" : "Dead";
                sb.AppendLine($"{character.Name} - HP: {character.Health}/{character.BaseHealth}, AP: {character.Armor}/{character.BaseArmor}, Status: {deathOrAlive}");
            }

            return sb.ToString();
        }

        public string Attack(string[] args)
        {
            string attackerName = args[0];
            string receiverName = args[1];

            Character attacker = characters.FirstOrDefault(x => x.Name == attackerName);
            Character receiver = characters.FirstOrDefault(x => x.Name == receiverName);

            if (attacker == null)
            {
                throw new ArgumentException(string.Format(Output.CharNotFound, attackerName));
            }

            if (receiver == null)
            {
                throw new ArgumentException(string.Format(Output.CharNotFound, receiverName));
            }

            if (!(attacker is IAttackable))
            {
                throw new ArgumentException(string.Format(Output.CannotAttack, attackerName));
            }

            Warrior warrior = (Warrior)attacker;
            warrior.Attack(receiver);
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{attackerName} attacks {receiverName} for {warrior.AbilityPoints} hit points! {receiver.Name} has {receiver.Health}/{receiver.BaseHealth} HP and {receiver.Armor}/{receiver.BaseArmor} AP left!");
            if (!receiver.IsAlive)
            {
                sb.AppendLine($"{receiver.Name} is dead!");
            }

            return sb.ToString();
        }

        public string Heal(string[] args)
        {
            string healerName = args[0];
            string receiverName = args[1];

            Character healer = characters.FirstOrDefault(x => x.Name == healerName);
            Character receiver = characters.FirstOrDefault(x => x.Name == receiverName);

            if (healer == null)
            {
                throw new ArgumentException(string.Format(Output.CharNotFound, healerName));
            }

            if (receiver == null)
            {
                throw new ArgumentException(string.Format(Output.CharNotFound, receiverName));
            }

            if (!(healer is IHealable))
            {
                throw new ArgumentException(string.Format(Output.CannotHeal, healerName));
            }

            Cleric cleric = (Cleric)healer;
            cleric.Heal(receiver);

            return $"{healer.Name} heals {receiver.Name} for {healer.AbilityPoints}! {receiver.Name} has {receiver.Health} health now!";
        }

        public string EndTurn()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var character in characters.Where(x => x.IsAlive == true))
            {
                var hpBefore = character.Health;
                character.Rest();
                sb.AppendLine($"{character.Name} rests ({hpBefore} => {character.Health})");
            }

            if (characters.Count(x => x.IsAlive == true) == 1)
            {
                lastSurRound++;
            }

            return sb.ToString();
        }

        public bool IsGameOver()
        {
            if (lastSurRound > 1)
            {
                return true;
            }

            return false;
        }
    }
}