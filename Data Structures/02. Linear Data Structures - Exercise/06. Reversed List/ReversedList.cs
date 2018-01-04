using System;
using System.Collections;
using System.Collections.Generic;

public class ReversedList<T> : IEnumerable<T>
{
    private T[] data;

    public ReversedList()
    {
        this.data = new T[2];
    }

    public int Count
    {
        get;

        private set;
    }

    public int Capacity
    {
        get { return this.data.Length; }

        set { this.Capacity = this.data.Length; }
    }

    public T this[int index]
    {
        get
        {
            if (index < 0 || index >= this.Count)
            {
                throw new ArgumentOutOfRangeException();
            }
            return this.data[this.Count - index - 1];
        }

        set
        {
            if (index < 0 || index >= this.Count)
            {
                throw new ArgumentOutOfRangeException();
            }

            this.data[index] = value;
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

        T item = this.data[this.Count - index - 1];

        for (int i = this.Count - index - 1; i < this.Count; i++)
        {
            this.data[i] = this.data[i + 1];
        }

        this.Count--;

        if (this.Count <= this.data.Length / 4)
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
    }

    private void Shrink()
    {
        T[] newArray = new T[this.data.Length / 2];

        Array.Copy(this.data, newArray, this.Count);

        this.data = newArray;
    }

    public IEnumerator<T> GetEnumerator()
    {
        return new MyEnumerator(this);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return new MyEnumerator(this);
    }

    public class MyEnumerator : IEnumerator<T>
    {
        private int position;
        private ReversedList<T> stack;

        public MyEnumerator(ReversedList<T> stack)
        {
            this.stack = stack;
            position = -1;
        }

        public void Dispose()
        {

        }

        public void Reset()
        {
            position = -1;
        }

        public bool MoveNext()
        {
            position++;
            return position < stack.Count;
        }

        Object IEnumerator.Current
        {
            get
            {
                return stack.data[position];
            }
        }
        public T Current
        {
            get
            {
                return stack.data[position];

            }
        }
    }
}
