using System;
using DungeonsAndCodeWizards.Models.Items;

namespace DungeonsAndCodeWizards.GameManager.Factories
{
    public class ItemFactory
    {
        public Item CreateItem(string itemName)
        {
            switch (itemName)
            {
                case "HealthPotion":
                    return new HealthPotion();

                case "ArmorRepairKit":
                    return new ArmorRepairKit();

                case "PoisonPotion":
                    return new PoisonPotion();

                default:
                    throw new ArgumentException(string.Format(Output.InvalidItemName, itemName));
            }
        }
    }
}