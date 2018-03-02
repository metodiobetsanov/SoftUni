using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public class HashTable<TKey, TValue> : IEnumerable<KeyValue<TKey, TValue>>
{
    private LinkedList<KeyValue<TKey, TValue>>[] data;
    private const float loadFactor = 0.7f;
    private const int defaultCapacity = 16;
    public int Count { get; private set; }

    public int Capacity => this.data.Length;

    public HashTable(int capacity = defaultCapacity)
    {
        this.data = new LinkedList<KeyValue<TKey, TValue>>[capacity];
        this.Count = 0;
    }

    public void Add(TKey key, TValue value)
    {
        this.GrowIfNeeded();

        int index = Math.Abs(key.GetHashCode()) % this.Capacity;

        if (this.data[index] == null)
        {
            this.data[index] = new LinkedList<KeyValue<TKey, TValue>>();
        }

        foreach (var item in this.data[index])
        {
            if (item.Key.Equals(key))
            {
                throw new ArgumentException($"Key already exists: {key}");
            }
        }

        KeyValue<TKey, TValue> kvp = new KeyValue<TKey, TValue>(key, value);
        this.data[index].AddLast(kvp);
        this.Count++;
    }

    private void GrowIfNeeded()
    {
        float currentLoadFactor = (float)(this.Count + 1) / this.Capacity;

        if (currentLoadFactor > loadFactor)
        {
            this.Grow();
        }
    }

    private void Grow()
    {
        var newData = new HashTable<TKey, TValue>(2 * this.Capacity);

        foreach (var item in this)
        {
            newData.Add(item.Key, item.Value);
        }

        this.data = newData.data;
        this.Count = newData.Count;
    }

    public bool AddOrReplace(TKey key, TValue value)
    {
        this.GrowIfNeeded();

        int index = Math.Abs(key.GetHashCode()) % this.Capacity;

        if (this.data[index] == null)
        {
            this.data[index] = new LinkedList<KeyValue<TKey, TValue>>();
        }

        foreach (var item in this.data[index])
        {
            if (item.Key.Equals(key))
            {
                item.Value = value;
                return false;
            }
        }

        KeyValue<TKey, TValue> kvp = new KeyValue<TKey, TValue>(key, value);
        this.data[index].AddLast(kvp);
        this.Count++;
        return true;
    }

    public TValue Get(TKey key)
    {
        KeyValue<TKey, TValue> kvp = this.Find(key);

        if (kvp == null)
        {
            throw new KeyNotFoundException();
        }

        return kvp.Value;
    }

    public TValue this[TKey key]
    {
        get
        {
            return this.Get(key);
        }
        set
        {
            this.AddOrReplace(key, value);
        }
    }

    public bool TryGetValue(TKey key, out TValue value)
    {
        KeyValue<TKey, TValue> kvp = this.Find(key);

        if (kvp == null)
        {
            value = default(TValue);
            return false;
        }

        value = kvp.Value;
        return true;
    }

    public KeyValue<TKey, TValue> Find(TKey key)
    {
        int index = Math.Abs(key.GetHashCode()) % this.Capacity;

        if (this.data[index] == null)
        {
            return null;
        }

        foreach (var item in this.data[index])
        {
            if (item.Key.Equals(key))
            {
                return item;
            }
        }

        return null;
    }

    public bool ContainsKey(TKey key)
    {
        return this.Find(key) != null;
    }

    public bool Remove(TKey key)
    {
        int index = Math.Abs(key.GetHashCode()) % this.Capacity;
        var elements = this.data[index];

        if (elements != null)
        {
            var currentElement = elements.First;
            while (currentElement != null)
            {
                if (currentElement.Value.Key.Equals(key))
                {
                    elements.Remove(currentElement);
                    this.Count--;
                    return true;
                }

                currentElement = currentElement.Next;
            }
        }

        return false;
    }

    public void Clear()
    {
        this.data = new LinkedList<KeyValue<TKey, TValue>>[defaultCapacity];
        this.Count = 0;
    }

    public IEnumerable<TKey> Keys
    {
        get
        {
            foreach (var kvp in this.data.Where(x => x != null))
            {
                foreach (var item in kvp)
                {
                    yield return item.Key;
                }
            }
        }
    }

    public IEnumerable<TValue> Values
    {
        get
        {
            foreach (var kvp in this.data.Where(x => x != null))
            {
                foreach (var item in kvp)
                {
                    yield return item.Value;
                }
            }
        }
    }

    public IEnumerator<KeyValue<TKey, TValue>> GetEnumerator()
    {
        foreach (var item in this.data.Where(x => x != null))
        {
            foreach (var kvp in item)
            {
                yield return kvp;
            }
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}
