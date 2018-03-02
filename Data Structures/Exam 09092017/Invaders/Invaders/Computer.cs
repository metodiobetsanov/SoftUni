using System;
using System.Collections.Generic;
using Wintellect.PowerCollections;

public class Computer : IComputer
{
    private int energy;
    private LinkedList<Invader> invadersByInsert;
    private OrderedBag<Invader> invadersByPriority;

    public Computer(int energy)
    {
        this.Energy = energy;
        this.invadersByInsert = new LinkedList<Invader>();
        this.invadersByPriority = new OrderedBag<Invader>();
    }

    public int Energy
    {
        get
        {
            if (this.energy < 0)
            {
                return 0;
            }
            else
            {
                return this.energy;
            }
        }
        private set
        {
            if (value < 0)
            {
                throw new ArgumentException();
            }

            this.energy = value;
        }
    }

    public void Skip(int turns)
    {
        for (int i = 0; i < turns; i++)
        {
            SkipTurn();
        }
    }

    private void SkipTurn()
    {
        invadersByPriority.Clear();
        var currentInvader = invadersByInsert.First;

        while (currentInvader != null)
        {
            currentInvader.Value.Distance -= 1;
            if (currentInvader.Value.Distance == 0)
            {
                energy -= currentInvader.Value.Damage;
                var tmp = currentInvader;
                currentInvader = currentInvader.Next;
                invadersByInsert.Remove(tmp);
            }
            else
            {
                invadersByPriority.Add(currentInvader.Value);
                currentInvader = currentInvader.Next;
            }
        }
    }

    public void AddInvader(Invader invader)
    {
        this.invadersByInsert.AddLast(invader);
        this.invadersByPriority.Add(invader);
    }

    public void DestroyHighestPriorityTargets(int count)
    {
        var counter = 0;
        while (counter < count)
        {
            var currentInvaser = invadersByPriority.RemoveFirst();
            invadersByInsert.Remove(currentInvaser);
            counter++;
        }
    }

    public void DestroyTargetsInRadius(int radius)
    {
        this.invadersByPriority.Clear();
        var currentInvader = invadersByInsert.First;

        while (currentInvader != null)
        {
            if (currentInvader.Value.Distance <= radius)
            {
                var tmp = currentInvader;
                currentInvader = currentInvader.Next;
                invadersByInsert.Remove(tmp);
            }
            else
            {
                invadersByPriority.Add(currentInvader.Value);
                currentInvader = currentInvader.Next;
            }
        }
    }

    public IEnumerable<Invader> Invaders()
    {
        return invadersByInsert;
    }
}
