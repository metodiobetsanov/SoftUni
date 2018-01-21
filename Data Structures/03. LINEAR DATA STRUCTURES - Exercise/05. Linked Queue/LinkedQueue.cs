
using System;

public class LinkedQueue<T>
{
    private class QueueNode
    {
        public T Value { get; private set; }
        public QueueNode NextNode { get; set; }
        public QueueNode PrevNode { get; set; }

        public QueueNode(T value)
        {
            this.Value = value;
        }
    }

    private QueueNode head;
    private QueueNode tail;
    public int Count { get; private set; }

    public LinkedQueue()
    {
        this.Count = 0;
    }

    public void Enqueue(T element)
    {
        if (this.Count == 0)
        {
            this.head = this.tail = new QueueNode(element);
        }
        else
        {
            var newHead = new QueueNode(element);
            newHead.NextNode = this.head;
            this.head.PrevNode = newHead;
            this.head = newHead;
        }

        this.Count++;
    }

    public T Dequeue()
    {
        if (this.Count == 0)
        {
            throw new InvalidOperationException();
        }

        var firstElement = this.head.Value;
        this.head = this.head.NextNode;

        if (this.head != null)
        {
            this.head.PrevNode = null;
        }
        else
        {
            this.tail = null;
        }

        this.Count--;
        return firstElement;
    }

    public T[] ToArray()
    {
        var curentNode = this.head;
        T[] array = new T[this.Count];
        var index = 0;

        while (curentNode != null)
        {
            array[index++] = curentNode.Value;
            curentNode = curentNode.NextNode;
        }

        return array;
    }
}