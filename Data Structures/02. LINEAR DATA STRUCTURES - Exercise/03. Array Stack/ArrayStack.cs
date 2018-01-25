using System;
using System.Collections.Generic;

public class ArrayStack<T>
{
    private const int InitialCapacity = 16;

    private T[] data;
    public int Count { get; private set; }

    public ArrayStack(int capacity = InitialCapacity)
    {
        this.data = new T[capacity];
        this.Count = 0;
    }

    public void Push(T element)
    {
        if (this.Count == this.data.Length)
        {
            this.Grow();
        }

        this.data[this.Count] = element;

        this.Count++;
    }

    public T Pop()
    {
        if (this.Count == 0)
        {
            throw new InvalidOperationException();
        }

        this.Count--;

        return data[this.Count];
    }

    public T[] ToArray()
    {
        T[] array = new T[this.Count];
        var arrayCounter = 0;

        for (int i = this.Count - 1; i >= 0; i--)
        {
            array[arrayCounter] = this.data[i];
            arrayCounter++;
        }

        return array;
    }

    private void Grow()
    {
        T[] array = new T[this.data.Length * 2];

        Array.Copy(this.data, array, this.Count);
        
        this.data = array;
    }

}

