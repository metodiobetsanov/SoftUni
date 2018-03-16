using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

public class Chainblock : IChainblock
{
    private Dictionary<int, Transaction> byIds;

    public Chainblock()
    {
        byIds = new Dictionary<int, Transaction>();
    }

    public int Count => byIds.Count;

    public void Add(Transaction tx)
    {
        byIds.Add(tx.Id, tx);
    }

    public void ChangeTransactionStatus(int id, TransactionStatus newStatus)
    {
        if (!byIds.ContainsKey(id))
        {
            throw new ArgumentException();
        }
        byIds[id].Status = newStatus;
    }

    public bool Contains(Transaction tx)
    {
        if (byIds.ContainsKey(tx.Id))
        {
            return true;
        }

        return false;
    }

    public bool Contains(int id)
    {
        if (byIds.ContainsKey(id))
        {
            return true;
        }

        return false;
    }

    public IEnumerable<Transaction> GetAllInAmountRange(double lo, double hi)
    {
        var result = byIds.Where(x => x.Value.Amount >= lo && x.Value.Amount <= hi).Select(x => x.Value);

        return result;
    }

    public IEnumerable<Transaction> GetAllOrderedByAmountDescendingThenById()
    {
        return byIds.Select(x => x.Value).OrderByDescending(x => x.Amount).ThenBy(x => x.Id);
    }

    public IEnumerable<string> GetAllReceiversWithTransactionStatus(TransactionStatus status)
    {
        var result = byIds.Values.Where(t => t.Status == status);

        if (result.Count() == 0)
        {
            throw new InvalidOperationException();
        }

        return result.OrderByDescending(t => t.Amount).Select(t => t.To);
    }

    public IEnumerable<string> GetAllSendersWithTransactionStatus(TransactionStatus status)
    {
        var result = byIds.Values.Where(t => t.Status == status);

        if (result.Count() == 0)
        {
            throw new InvalidOperationException();
        }

        return result.OrderByDescending(t => t.Amount).Select(t => t.From);
    }

    public Transaction GetById(int id)
    {
        if (!byIds.ContainsKey(id))
        {
            throw new InvalidOperationException();
        }

        return byIds[id];
    }

    public IEnumerable<Transaction> GetByReceiverAndAmountRange(string receiver, double lo, double hi)
    {
        if (!byIds.Values.Any(x => x.To == receiver))
        {
            throw new InvalidOperationException();
        }

        var result = byIds.Values.Where(x => x.To == receiver && x.Amount >= lo && x.Amount < hi);

        return result.OrderByDescending(x => x.Amount).ThenBy(x => x.Id);
    }

    public IEnumerable<Transaction> GetByReceiverOrderedByAmountThenById(string receiver)
    {
        if (!byIds.Values.Any(x => x.To == receiver))
        {
            throw new InvalidOperationException();
        }

        var result = byIds.Values.Where(x => x.To == receiver).OrderByDescending(x => x.Amount).ThenBy(x => x.Id);

        return result;
    }

    public IEnumerable<Transaction> GetBySenderAndMinimumAmountDescending(string sender, double amount)
    {
        var result = byIds.Values.Where(t => t.From == sender);
        result =  result.Where(t => t.Amount > amount).OrderByDescending(x => x.Amount);
        if (result.Count() == 0)
        {
            throw new InvalidOperationException();
        }

        return result;
    }

    public IEnumerable<Transaction> GetBySenderOrderedByAmountDescending(string sender)
    {
        if (!byIds.Values.Any(x => x.From == sender))
        {
            throw new InvalidOperationException();
        }

        var result = byIds.Values.Where(x => x.From == sender).OrderByDescending(x => x.Amount);
        if (result.Count() == 0)
        {
            throw new InvalidOperationException();
        }

        return result;
    }

    public IEnumerable<Transaction> GetByTransactionStatus(TransactionStatus status)
    {
        if (!byIds.Values.Any(x => x.Status == status))
        {
            throw new InvalidOperationException();
        }
        var result = byIds.Values.Where(t => t.Status == status);
        if (result.Count() == 0)
        {
            throw new InvalidOperationException();
        }

        return result.OrderByDescending(x => x.Amount);

    }

    public IEnumerable<Transaction> GetByTransactionStatusAndMaximumAmount(TransactionStatus status, double amount)
    {
        var result = new List<Transaction>();
        if (!byIds.Values.Any(x => x.Status == status))
        {
            return result;
        }

        result = byIds.Values.Where(t => t.Status == status).Where(t => t.Amount <= amount).ToList();

        return result.OrderByDescending(x => x.Amount);
    }

    public IEnumerator<Transaction> GetEnumerator()
    {
        foreach (var ts in byIds.Values)
        {
            yield return ts;
        }
    }

    public void RemoveTransactionById(int id)
    {
        if (!byIds.ContainsKey(id))
        {
            throw new InvalidOperationException();
        }
        Transaction ts = byIds[id];
        byIds.Remove(id);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

