using DungeonsAndCodeWizards.Models.Bags;
using DungeonsAndCodeWizards.Models.Contracts;
using System;
using DungeonsAndCodeWizards.GameManager;

namespace DungeonsAndCodeWizards.Models.Characters
{
    public class Warrior : Character, IAttackable
    {
        public Warrior(string name, Faction faction)
            : base(name, 100, 50, 40, new Satchel(), faction)
        {
        }

        public void Attack(Character character)
        {
            if (!this.IsAlive || !character.IsAlive)
            {
                throw new InvalidOperationException(Output.MustBeAlive);
            }

            if (this == character)
            {
                throw new InvalidOperationException(Output.CannotAttackSelf);
            }

            if (Faction == character.Faction)
            {
                throw new ArgumentException(string.Format(Output.CannotAttackFaction, Faction));
            }

            character.TakeDamage(AbilityPoints);
        }
    }
}