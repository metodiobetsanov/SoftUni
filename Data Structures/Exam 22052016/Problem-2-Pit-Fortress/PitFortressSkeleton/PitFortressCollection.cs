using System;
using System.Linq;
using System.Collections.Generic;
using Classes;
using Interfaces;
using Wintellect.PowerCollections;

public class PitFortressCollection : IPitFortress
{
    private int minionId = 1;
    private int mineId = 1;

    private Dictionary<string, Player> players;
    private SortedSet<Player> playerScores;
    private OrderedDictionary<int, OrderedBag<Minion>> minions;
    private SortedSet<Mine> mines;

    public PitFortressCollection()
    {
        this.players = new Dictionary<string, Player>();
        this.playerScores = new SortedSet<Player>();
        this.minions = new OrderedDictionary<int, OrderedBag<Minion>>();
        this.mines = new SortedSet<Mine>();
    }

    public int PlayersCount { get { return this.players.Count;  } }

    public int MinionsCount { get { return this.minions.Sum(x => x.Value.Count); } }
     
    public int MinesCount { get { return this.mines.Count; } }

    public void AddPlayer(string name, int mineRadius)
    {
        if (this.players.ContainsKey(name))
        {
            throw new ArgumentException();
        }

        if (mineRadius < 0 )
        {
            throw new ArgumentException();
        }

        Player player = new Player(name, mineRadius);
        this.players.Add(name, player);
        this.playerScores.Add(player);
    }

    public void AddMinion(int xCoordinate)
    {
        if (xCoordinate < 0 || xCoordinate > 1000000)
        {
            throw new ArgumentException();
        }

        Minion minion = new Minion(this.minionId++, xCoordinate);

        if (!this.minions.ContainsKey(xCoordinate))
        {
            this.minions.Add(xCoordinate, new OrderedBag<Minion>());
        }

        this.minions[xCoordinate].Add(minion);
    }

    public void SetMine(string playerName, int xCoordinate, int delay, int damage)
    {
        if (!this.players.ContainsKey(playerName))
        {
            throw new ArgumentException();
        }

        if (xCoordinate < 0 || xCoordinate > 1000000)
        {
            throw new ArgumentException();
        }

        if (delay < 1 || delay > 10000)
        {
            throw new ArgumentException();
        }

        if (damage < 0 || damage > 100)
        {
            throw new ArgumentException();
        }

        var player = this.players[playerName];
        Mine mine = new Mine(mineId++, player, xCoordinate, delay, damage);
    }

    public IEnumerable<Minion> ReportMinions()
    {
        foreach (var set in this.minions.Values)
        {
            foreach (var minion in set)
            {
                yield return minion;
            }
        }
    }

    public IEnumerable<Player> Top3PlayersByScore()
    {
        if (this.players.Count < 3)
        {
            throw new ArgumentException();
        }

        return this.playerScores.Reverse().Take(3);
    }

    public IEnumerable<Player> Min3PlayersByScore()
    {
        if (this.players.Count < 3)
        {
            throw new ArgumentException();
        }

        return this.playerScores.Take(3);
    }

    public IEnumerable<Mine> GetMines()
    {
        return this.mines;
    }

    public void PlayTurn()
    {
        var minesToDetonate = new List<Mine>();

        foreach (var mine in this.mines)
        {
            mine.Delay--;

            if (mine.Delay <= 0)
            {
                minesToDetonate.Add(mine);
            }
        }

        foreach (var mine in minesToDetonate)
        {
            var start = mine.XCoordinate - mine.Player.Radius;
            var end = mine.XCoordinate + mine.Player.Radius;

            var player = mine.Player;

            var minionsToUpdate = this.minions.Range(start, true, end, true)
                .SelectMany(x => x.Value).ToList();

            foreach (var minion in minionsToUpdate)
            {
                minion.Health -= mine.Damage;

                if (minion.Health <= 0)
                {
                    this.playerScores.Remove(player);
                    player.Score++;                    
                    this.playerScores.Add(player);
                    this.minions[mine.XCoordinate].Remove(minion);
                }
            }
        }

        foreach (var mine in minesToDetonate)
        {
            this.mines.Remove(mine);
        }
    }
}
