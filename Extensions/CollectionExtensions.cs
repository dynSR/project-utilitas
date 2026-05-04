using System.Collections.Generic;
using JetBrains.Annotations;

namespace Utilitas {
    public static class CollectionExtensions {
        /// <summary>
        /// Determines whether a collection is null or has no elements
        /// without having to enumerate the entire collection to get a count.
        /// </summary>
        /// <param name="list">List to evaluate</param>
        public static bool IsNullOrEmpty<T>(this ICollection<T> list) { return list == null || list.IsEmpty(); }

        public static bool IsEmpty<T>(this ICollection<T> list) { return list.Count == 0; }

        public static void AddRange<T>(this ICollection<T> collection, IEnumerable<T> items) {
            foreach (T item in items) collection.Add(item);
        }

        public static bool Any<T>(this ICollection<T> collection) => collection.Count >= 1;

        public static T First<T>(this ICollection<T> collection) {
            using IEnumerator<T> enumerator = collection.GetEnumerator();
            return enumerator.MoveNext() ? enumerator.Current : default;
        }

        public static T Last<T>(this ICollection<T> collection) {
            T lastItem;
            using IEnumerator<T> enumerator = collection.GetEnumerator();
            do {
                lastItem = enumerator.Current;
            } while (enumerator.MoveNext());

            return lastItem;
        }
    }
}