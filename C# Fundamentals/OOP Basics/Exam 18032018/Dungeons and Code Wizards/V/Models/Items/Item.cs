using DungeonsAndCodeWizards.Models.Characters;
using System;
using DungeonsAndCodeWizards.GameManager;

namespace DungeonsAndCodeWizards.Models.Items
{
    public abstract class Item
    {
        private int weight;
        public int Weight => weight;

        protected Item(int weight)
        {
            this.weight = weight;
        }

        public virtual void AffectCharacter(Character character)
        {
            if (!character.IsAlive)
            {
                throw new InvalidOperationException(Output.MustBeAlive);
            }
        }
    }
}