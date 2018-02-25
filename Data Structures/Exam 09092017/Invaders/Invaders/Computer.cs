using System;
using System.Collections.Generic;

public class Computer : IComputer
{
    public Computer(int energy)
    {
        throw new NotImplementedException();
    }

    public int Energy
    {
        get
        {
            throw new NotImplementedException();
        }
    }

    public void Skip(int turns)
    {
        throw new NotImplementedException();
    }

    public void AddInvader(Invader invader)
    {
        throw new NotImplementedException();
    }

    public void DestroyHighestPriorityTargets(int count)
    {
        throw new NotImplementedException();
    }

    public void DestroyTargetsInRadius(int radius)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Invader> Invaders()
    {
        throw new NotImplementedException();
    }
}
