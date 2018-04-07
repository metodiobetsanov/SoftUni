namespace BashSoft.Interfaces
{
    using System;
    using System.Collections.Generic;

    public interface ISimpleOrderedBag<T> : IEnumerable<T> where T : IComparable<T>
    {
        void Add(T element);

        void AddAll(ICollection<T> collecton);

        int Count { get; }

        string JoinWith(string joiner);
    }
}