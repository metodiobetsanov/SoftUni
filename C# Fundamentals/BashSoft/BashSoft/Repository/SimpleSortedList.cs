namespace BashSoft.Repository
{
    using Interfaces;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Text;

    public class SimpleSortedList<T> : ISimpleOrderedBag<T> where T : IComparable<T>
    {
        private const int DefaultSize = 16;

        private IComparer<T> comparer;
        private int counter;
        private T[] data;

        public SimpleSortedList(IComparer<T> cmp, int capacity)
        {
            this.InitializeInnerCollection(capacity);
            this.comparer = cmp;
        }

        public SimpleSortedList(int capacity)
            : this(Comparer<T>.Create((x, y) => x.CompareTo(y)), capacity)
        {
        }

        public SimpleSortedList(IComparer<T> cmp)
            : this(cmp, DefaultSize)
        {
        }

        public SimpleSortedList()
            : this(Comparer<T>.Create((x, y) => x.CompareTo(y)), DefaultSize)
        {
        }

        public int Count => this.counter;

        public int Length => this.data.Length;

        public void Add(T element)
        {
            if (this.data.Length == counter)
            {
                this.Resize();
            }

            this.data[counter] = element;
            this.counter++;
            Array.Sort(this.data, 0, counter, comparer);
        }

        public void AddAll(ICollection<T> collection)
        {
            if (this.Count + collection.Count >= this.Length)
            {
                this.Resize(collection.Count);
            }

            foreach (T item in collection)
            {
                this.Add(item);
            }

            Array.Sort(this.data, 0, counter, comparer);
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.data.Length; i++)
            {
                yield return this.data[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public string JoinWith(string joiner)
        {
            StringBuilder sb = new StringBuilder();

            foreach (var element in this)
            {
                if (element != null)
                {
                    sb.Append(element);
                    sb.Append(joiner);
                }
            }

            sb.Remove(sb.Length - 1, 1);
            return sb.ToString();
        }

        private void InitializeInnerCollection(int capacity)
        {
            if (capacity < 0)
            {
                throw new ArgumentException("Capacity cannot be negative!");
            }

            this.data = new T[capacity];
        }

        private void Resize(int count = 0)
        {
            int newSize = this.data.Length + DefaultSize;
            while (newSize <= count + this.data.Length)
            {
                newSize += DefaultSize;
            }

            T[] newCollection = new T[newSize];
            Array.Copy(this.data, newCollection, this.Count);
            this.data = newCollection;
        }
    }
}