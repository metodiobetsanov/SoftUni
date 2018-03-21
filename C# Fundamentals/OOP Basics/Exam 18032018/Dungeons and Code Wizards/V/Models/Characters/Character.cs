using DungeonsAndCodeWizards.Models.Bags;
using DungeonsAndCodeWizards.Models.Items;
using System;
using DungeonsAndCodeWizards.GameManager;

namespace DungeonsAndCodeWizards.Models.Characters
{
    public abstract class Character
    {
        protected Character(string name, double health, double armor, double abilityPoints, Bag bag, Faction faction)
        {
            this.Name = name;
            this.BaseHealth = health;
            this.Health = health;
            this.BaseArmor = armor;
            this.Armor = armor;
            this.AbilityPoints = abilityPoints;
            this.Bag = bag;
            this.Faction = faction;
            IsAlive = true;
        }

        private string name;

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(Output.NameCannotBeNullOrWhitespace);
                }

                this.name = value;
            }
        }

        public double BaseHealth { get; }

        private double health;

        public double Health
        {
            get => health;
            set => health = Math.Max(0, Math.Min(BaseHealth, value));
        }

        public double BaseArmor { get; }

        private double armor;

        public double Armor
        {
            get => this.armor;
            set => this.armor = Math.Max(0, value);
        }

        public double AbilityPoints { get; private set; }

        public Bag Bag { get; set; }

        public Faction Faction { get; }

        private bool isAlive;

        public bool IsAlive
        {
            get => this.isAlive;
            set => this.isAlive = value;
        }

        protected double restHealMultiplier;

        public virtual double RestHealMultiplier { get; } = 0.2d;

        public void TakeDamage(double hitPoints)
        {
            if (!this.IsAlive)
            {
                throw new InvalidOperationException(Output.MustBeAlive);
            }

            if (this.Armor >= hitPoints)
            {
                Armor -= hitPoints;
            }
            else
            {
                hitPoints -= Armor;
                Armor = 0;
                if (Health - hitPoints <= 0)
                {
                    Health = 0;
                    isAlive = false;
                }
                else
                {
                    Health -= hitPoints;
                }
            }
        }

        public void Rest()
        {
            if (!this.IsAlive)
            {
                throw new InvalidOperationException(Output.MustBeAlive);
            }

            this.Health += (this.BaseHealth * this.RestHealMultiplier);
        }

        public void UseItem(Item item)
        {
            if (!this.IsAlive)
            {
                throw new InvalidOperationException(Output.MustBeAlive);
            }

            item.AffectCharacter(this);
        }

        public void UseItemOn(Item item, Character character)
        {
            if (!this.IsAlive || !character.IsAlive)
            {
                throw new InvalidOperationException(Output.MustBeAlive);
            }

            item.AffectCharacter(character);
        }

        public void GiveCharacterItem(Item item, Character character)
        {
            if (!this.IsAlive || !character.IsAlive)
            {
                throw new InvalidOperationException(Output.MustBeAlive);
            }

            character.ReceiveItem(item);
        }

        public void ReceiveItem(Item item)
        {
            if (!this.IsAlive)
            {
                throw new InvalidOperationException(Output.MustBeAlive);
            }

            Bag.AddItem(item);
        }
    }
}