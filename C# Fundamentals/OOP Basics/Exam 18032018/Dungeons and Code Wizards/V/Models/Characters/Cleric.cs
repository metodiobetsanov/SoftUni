using DungeonsAndCodeWizards.Models.Bags;
using DungeonsAndCodeWizards.Models.Contracts;
using System;
using DungeonsAndCodeWizards.GameManager;

namespace DungeonsAndCodeWizards.Models.Characters
{
    public class Cleric : Character, IHealable
    {
        public Cleric(string name, Faction faction)
            : base(name, 50, 25, 40, new Backpack(), faction)
        {
        }

        public override double RestHealMultiplier { get; } = 0.5d;

        public void Heal(Character character)
        {
            if (!this.IsAlive || !character.IsAlive)
            {
                throw new InvalidOperationException(Output.MustBeAlive);
            }

            if (this.Faction != character.Faction)
            {
                throw new InvalidOperationException(Output.CannotHealEnemy);
            }

            character.Health += AbilityPoints;
        }
    }
}