using System;

public class LinkedStack<T>
{
    private class Node<T>
    {
        public T Value { get; private set; }
        public Node<T> NextNode { get; set; }

        public Node(T value, Node<T> nextNode = null)
        {
            this.Value = value;
            this.NextNode = nextNode;
        }
    }

    private Node<T> firstNode;
    public int Count { get; private set; }

    public LinkedStack()
    {
        this.Count = 0;
    }

    public void Push(T element)
    {
        if (this.Count == 0)
        {
            Node<T> newNode = new Node<T>(element);
            firstNode = newNode;
        }
        else
        {
            this.firstNode= new Node<T>(element, this.firstNode);
        }

        this.Count++;
    }

    public T Pop()
    {
        if (this.Count == 0)
        {
            throw new InvalidOperationException();
        }

        T result = firstNode.Value;
        this.firstNode = this.firstNode.NextNode;
        this.Count--;

        return result;
    }

    public T[] ToArray()
    {
        T[] array = new T[this.Count];
        int counter = 0;
        Node<T> currentNode = firstNode;

        while (currentNode != null)
        {
            array[counter++] = currentNode.Value;
            currentNode = currentNode.NextNode;
        }

        return array;
    }
    
}
