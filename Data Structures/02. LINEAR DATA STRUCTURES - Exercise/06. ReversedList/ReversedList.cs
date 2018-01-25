using System;
using System.Collections;
using System.Collections.Generic;

public class ReversedList<T> : IEnumerable<T>
{
    private const int DefaultCapacity = 2;
    public ReversedList(int size = DefaultCapacity)
    {
        this.data = new T[size];
        this.Count = 0;
        this.Capacity = this.data.Length;
    }

    private T[] data { get; set; }
    public int Count { get; private set; }
    public int Capacity  { get; private set; }

    public T this[int index]
    {
        get
        {
            if (index < 0 || index >= this.Count)
            {
                throw new ArgumentOutOfRangeException();
            }
            return this.data[(this.Count - 1) - index];
        }

        set
        {
            if (index < 0 || index >= this.Count)
            {
                throw new ArgumentOutOfRangeException();
            }

            this.data[(this.Count - 1) - index] = value;
        }
    }

    public void Add(T item)
    {
        if (this.data.Length <= this.Count)
        {
            this.Resize();
        }

        this.data[this.Count++] = item;
    }

    public T RemoveAt(int index)
    {
        if (index < 0 || index >= this.Count)
        {
            throw new ArgumentOutOfRangeException();
        }

        T item = this.data[(this.Count - 1) - index];

        for (int i = (this.Count - 1) - index; i < this.Count - 1; i++)
        {
            this.data[i] = this.data[i + 1];
        }

        this.Count--;

        if (this.Count <= this.data.Length / 3)
        {
            this.Shrink();
        }

        return item;
    }

    private void Resize()
    {
        T[] newArray = new T[this.Count * 2];

        Array.Copy(this.data, newArray, this.Count);

        this.data = newArray;
        this.Capacity = newArray.Length;
    }

    private void Shrink()
    {
        T[] newArray = new T[this.data.Length / 2];

        Array.Copy(this.data, newArray, this.Count);

        this.data = newArray;
        this.Capacity = newArray.Length;
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = this.Count - 1; i >= 0; i--)
        {
            yield return data[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}