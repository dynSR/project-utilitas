using System;
using System.Collections.Generic;
using System.Linq;

namespace Utilitas {
    public static class ListExtensions {
        /// <summary>
        /// Determines whether a collection is null or has no elements
        /// without having to enumerate the entire collection to get a count.
        /// </summary>
        /// <param name="list">List to evaluate</param>
        public static bool IsNullOrEmpty<T>(this IList<T> list) {
            return list == null || list.IsEmpty();
        }

        public static bool IsEmpty<T>(this IList<T> list) {
            return list.Count == 0;
        }

        public static void AddMultiple<T>(
            this List<T> list,
            params T[] elements
        ) {
            // Ensures that the list has sufficient capacity to accommodate
            // all new elements at once, in order to avoid
            // repeated internal reallocations and copies during calls to Add().
            list.Capacity = Math.Max(list.Capacity, list.Count + elements.Length);

            foreach (T element in elements) {
                list.Add(element);
            }
        }

        /// <summary>
        /// Swaps two elements in the list at the specified indices.
        /// </summary>
        /// <param name="list">The list.</param>
        /// <param name="indexA">The index of the first element.</param>
        /// <param name="indexB">The index of the second element.</param>
        public static void Swap<T>(this IList<T> list, int indexA, int indexB) {
            (list[indexA], list[indexB]) = (list[indexB], list[indexA]);
        }

        /// <summary>
        /// Filters a collection based on a predicate and returns a new list
        /// containing the elements that match the specified condition.
        /// </summary>
        /// <param name="source">The collection to filter.</param>
        /// <param name="predicate">The condition that each element is tested against.</param>
        /// <returns>A new list containing elements that satisfy the predicate.</returns>
        public static IList<T> Filter<T>(this IList<T> source, Predicate<T> predicate) {
            var list = new List<T>();
            foreach (T item in source) {
                if (predicate(item)) {
                    list.Add(item);
                }
            }

            return list;
        }
    }
}