using DungeonsAndCodeWizards.Models.Items;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using DungeonsAndCodeWizards.GameManager;

namespace DungeonsAndCodeWizards.Models.Bags
{
    public abstract class Bag
    {
        private int capacity;
        public int Capacity => capacity;

        public int Load => Items.Sum(x => x.Weight);

        private ICollection<Item> items { get; }
        public IReadOnlyCollection<Item> Items => new ReadOnlyCollection<Item>(new List<Item>(items));

        protected Bag(int capacity = 100)
        {
            this.capacity = capacity;
            this.items = new List<Item>();
        }

        public void AddItem(Item item)
        {
            if (Load + item.Weight > Capacity)
            {
                throw new InvalidOperationException(Output.BagIsFull);
            }

            items.Add(item);
        }

        public Item GetItem(string name)
        {
            if (items.Count == 0)
            {
                throw new InvalidOperationException(Output.BagIsEmpty);
            }

            if (items.All(x => x.GetType().Name != name))
            {
                throw new ArgumentException(string.Format(Output.ItemDoesNotExist, name));
            }

            Item toReturn = items.FirstOrDefault(x => x.GetType().Name == name);
            items.Remove(toReturn);
            return toReturn;
        }
    }
}