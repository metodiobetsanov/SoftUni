
    using System;
    using System.Collections.Generic;
    using System.Collections;
    using System.Linq;

    public class Hierarchy<T> : IHierarchy<T>
    {
        private Node root { get; set; }
        private Dictionary<T, Node> nodeByValue { get; set; }

        public Hierarchy(T root)
        {
            this.root = new Node(root);
            this.nodeByValue = new Dictionary<T, Node>();
            this.nodeByValue.Add(root, this.root);
        }

        public int Count
        {
            get { return nodeByValue.Count; }
        }

        public void Add(T parent, T child)
        {
            if (!this.nodeByValue.ContainsKey(parent))
            {
                throw new ArgumentException();
            }

            if (this.nodeByValue.ContainsKey(child))
            {
                throw new ArgumentException();
            }

            Node parentNode = nodeByValue[parent];
            Node childNode = new Node(child, parentNode);

            parentNode.Children.Add(childNode);
            this.nodeByValue.Add(child, childNode);
        }

        public void Remove(T element)
        {
            if (!this.nodeByValue.ContainsKey(element))
            {
                throw new ArgumentException();
            }

            Node curent = this.nodeByValue[element];

            if (curent.Parent == null)
            {
                throw new InvalidOperationException();
            }


            foreach (Node child in curent.Children)
            {
                child.Parent = curent.Parent;
                curent.Parent.Children.Add(child);
            }

            curent.Parent.Children.Remove(curent);
            nodeByValue.Remove(element);
        }

        public IEnumerable<T> GetChildren(T item)
        {
            if (!this.nodeByValue.ContainsKey(item))
            {
                throw new InvalidOperationException();
            }

            Node parent = this.nodeByValue[item];
            return parent.Children.Select(x => x.Value);
        }

        public T GetParent(T item)
        {
            if (!this.nodeByValue.ContainsKey(item))
            {
                throw new ArgumentException();
            }

            Node child = this.nodeByValue[item];

            return child.Parent != null ?
                child.Parent.Value : default(T);
        }

        public bool Contains(T value)
        {
            return this.nodeByValue.ContainsKey(value);
        }

        public IEnumerable<T> GetCommonElements(Hierarchy<T> other)
        {
            return new HashSet<T>(this.nodeByValue.Keys)
                .Intersect(new HashSet<T>(other.nodeByValue.Keys));
        } 

        public IEnumerator<T> GetEnumerator()
        {
            Queue<Node> queue = new Queue<Node>();

            Node current = this.root;
            queue.Enqueue(current);

            while (queue.Count > 0)
            {
                current = queue.Dequeue();
                yield return current.Value;

                foreach(Node child in current.Children)
                {
                    queue.Enqueue(child);
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
        
        private class Node
        {
            public T Value { get; set; }
            public Node Parent { get; set; }
            public List<Node> Children { get; set; }

            public Node(T value, Node parent = null)
            {
                this.Value = value;
                this.Parent = parent;
                this.Children = new List<Node>();
            }
        }
    }
