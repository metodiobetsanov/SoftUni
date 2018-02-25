using System;

public class Invader : IInvader
{
    public Invader(int damage, int distance)
    {
        throw new NotImplementedException();
    }
    
    public int Damage { get; set; }
    public int Distance { get; set; }

    public int CompareTo(IInvader other)
    {
        throw new NotImplementedException();
    }
}
