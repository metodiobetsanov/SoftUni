﻿using System;

public class Invader : IInvader
{
    public Invader(int damage, int distance)
    {
        this.Damage = damage;
        this.Distance = distance;
    }
    
    public int Damage { get; set; }
    public int Distance { get; set; }

    public int CompareTo(IInvader other)
    {
        int cmp = this.Distance.CompareTo(other.Distance);

        if (cmp == 0)
        {
            cmp = this.Damage.CompareTo(other.Damage);
        }

        return cmp;
    }
}
