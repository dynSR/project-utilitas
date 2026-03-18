using System.Collections.Generic;

namespace Utilitas {
    public static class CollectionExtensions {
        /// <summary>
        /// Determines whether a collection is null or has no elements
        /// without having to enumerate the entire collection to get a count.
        /// </summary>
        /// <param name="list">List to evaluate</param>
        public static bool IsNullOrEmpty<T>(this ICollection<T> list) {
            return list == null || list.IsEmpty();
        }

        public static bool IsEmpty<T>(this ICollection<T> list) {
            return list.Count == 0;
        }

        public static void Add<T>(this ICollection<T> collection, T item) {
            collection.Add(item);
        }

        public static void AddRange<T>(this ICollection<T> collection, IEnumerable<T> items) {
            foreach (T item in items) collection.Add(item);
        }

        public static bool Any<T>(this ICollection<T> collection) => collection.Count >= 1;
    }
}