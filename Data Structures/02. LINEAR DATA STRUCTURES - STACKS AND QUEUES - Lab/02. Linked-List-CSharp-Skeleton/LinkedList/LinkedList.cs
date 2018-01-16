using System;
using System.Collections;
using System.Collections.Generic;

public class LinkedList<T> : IEnumerable<T>
{
    public int Count { get; private set; }
    public Node Head { get; set; }
    public Node Tail { get; set; }

    public void AddFirst(T item)
    {
        Node old = Head;

        this.Head = new Node(item);
        this.Head.Next = old;

        if (this.IsEmpty())
        {
            Tail = Head;
        }

        this.Count++;
    }

    public void AddLast(T item)
    {
        Node old = Tail;

        this.Tail = new Node(item);
        
        if (this.IsEmpty())
        {
            this.Head = this.Tail;
        }
        else
        {
            old.Next = this.Tail;
        }

        this.Count++;
    }
    
    public T RemoveFirst()
    {
        if (this.IsEmpty())
        {
            throw new InvalidOperationException();
        }

        T item = this.Head.Value;

        this.Head = this.Head.Next;

        this.Count--;

        if (this.IsEmpty())
        {
            this.Tail = Tail;
        }

        return item;
    }

    public T RemoveLast()
    {
        if (this.IsEmpty())
        {
            throw new InvalidOperationException();
        }

        T item = this.Tail.Value;
        
        if (this.Count == 1)
        {
            this.Head = this.Tail = null;
        }
        else
        {
            Node newTail = this.GetSecondToLast();
            newTail.Next = null;
            this.Tail = newTail;
        }

        this.Count--;

        return item;
    }

    private bool IsEmpty()
    {
        bool isEmpty = this.Count == 0;

        return isEmpty;
    }

    private Node GetSecondToLast()
    {
        Node current = this.Head;

        for (int i = 1; i < Count - 1; i++)
        {
            current = current.Next;
        }

        return current;
    }

    public IEnumerator<T> GetEnumerator()
    {
        Node current = this.Head;

        while (current != null)
        {
            yield return current.Value;
            current = current.Next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    

    public class Node
    {
        public Node(T value)
        {
            this.Value = value;
        }

        public T Value { get; set; }
        public Node Next { get; set; }
    }
}
