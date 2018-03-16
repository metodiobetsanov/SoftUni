using System;
using System.Collections;
using System.Collections.Generic;
using Wintellect.PowerCollections;
using System.Linq;

public class Instock : IProductStock
{
    private Dictionary<string, Product> byLabels;
    private Dictionary<int, List<Product>> byqty;

    private OrderedSet<Product> products;
    private List<Product> byInsertaion;
    public Instock()
    {
        byLabels = new Dictionary<string, Product>();
        byqty = new Dictionary<int, List<Product>>();
        byInsertaion = new List<Product>();
        products = new OrderedSet<Product>();
    }

    public int Count => byInsertaion.Count;

    public void Add(Product product)
    {
        byLabels.Add(product.Label, product);
        byInsertaion.Add(product);
        products.Add(product);
        if (!byqty.ContainsKey(product.Quantity))
        {
            byqty.Add(product.Quantity, new List<Product>());
        }

        byqty[product.Quantity].Add(product);
    }

    public void ChangeQuantity(string product, int quantity)
    {
        if (!byLabels.ContainsKey(product))
        {
            throw new ArgumentException();
        }

        Product p = byLabels[product];
        byqty[p.Quantity].Remove(p);
        p.Quantity = quantity;
        if (!byqty.ContainsKey(quantity))
        {
            byqty.Add(quantity, new List<Product>());
        }
        byqty[quantity].Add(p);

        byLabels[product].Quantity = quantity;
    }

    public bool Contains(Product product)
    {
        if (byLabels.ContainsKey(product.Label))
        {
            return true;
        }

        return false;
    }

    public Product Find(int index)
    {
        if (index < 0 || index >= Count)
        {
            throw new IndexOutOfRangeException();
        }

        return byInsertaion[index];
    }

    public IEnumerable<Product> FindAllByPrice(double price)
    {
        var result = byInsertaion.Where(p => p.Price == price);
        return result;
    }

    public IEnumerable<Product> FindAllByQuantity(int quantity)
    {
        var result = new List<Product>();
        if (!byqty.ContainsKey(quantity))
        {
            return result;
        }

        return byqty[quantity];

    }

    public IEnumerable<Product> FindAllInRange(double lo, double hi)
    {
        var result = byLabels.Where(p => p.Value.Price > lo && p.Value.Price <= hi).Select(p => p.Value).OrderByDescending(p => p.Price);
        return result;
    }

    public Product FindByLabel(string label)
    {
        if (!byLabels.ContainsKey(label))
        {
            throw new ArgumentException();
        }
        return byLabels[label];
    }

    public IEnumerable<Product> FindFirstByAlphabeticalOrder(int count)
    {
        var result = products.Take(count);
        if (products.Count < count)
        {
            throw new ArgumentException();
        }
        return result;
    }

    public IEnumerable<Product> FindFirstMostExpensiveProducts(int count)
    {
        var result = byInsertaion.OrderByDescending(x => x.Price).Take(count);
        if (result.Count() < count)
        {
            throw new ArgumentException();
        }

        return result;
    }

    public IEnumerator<Product> GetEnumerator()
    {
        foreach (var item in byInsertaion)
        {
            yield return item;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
