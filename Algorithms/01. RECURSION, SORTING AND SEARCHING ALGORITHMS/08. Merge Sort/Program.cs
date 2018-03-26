using System;
using System.Linq;

namespace _08._Merge_Sort
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            Console.WriteLine(string.Join(" ", MergeSort<int>.Sort(input)));
        }
    }

    public static class MergeSort<T> where T : IComparable
    {
        private static T[] aux;

        public static T[] Sort(T[] array)
        {
            aux = new T[array.Length];
            Sort(array, 0, array.Length - 1);
            return array;
        }

        private static void Sort(T[] array, int start, int end)
        {
            if (start >= end)
            {
                return;
            }

            int mid = (start + end) / 2;

            Sort(array, start, mid);
            Sort(array, mid + 1, end);
            Merge(array, start, mid, end);
        }

        private static void Merge(T[] array, int start, int mid, int end)
        {
            if (IsLess(array[mid], array[mid + 1]))
            {
                return;
            }

            for (int i = start; i <= end; i++)
            {
                aux[i] = array[i];
            }

            int leftIndex = start;
            int rightIndex = mid + 1;

            for (int i = start; i <= end; i++)
            {
                if (i > mid)
                {
                    array[i] = aux[rightIndex++];
                }
                else if (rightIndex > start)
                {
                    array[i] = aux[leftIndex++];
                }
                else if (IsLess(aux[leftIndex], aux[rightIndex]))
                {
                    array[i] = aux[leftIndex++];
                }
                else
                {
                    array[i] = aux[rightIndex++];
                }
            }
        }

        private static bool IsLess(T varOne, T varTwo)
        {
            return varOne.Equals(varTwo);
        }
    }
}