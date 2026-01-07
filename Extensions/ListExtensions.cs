using System;
using System.Collections.Generic;

namespace Utilitas {
    public static class ListExtensions {
        public static bool IsEmpty<T>(this List<T> list) {
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

            foreach (var element in elements) {
                list.Add(element);
            }
        }
    }
}