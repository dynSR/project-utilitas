using UnityEngine;

namespace Utilitas {
    public static class TransformExtensions {
        public static void Unparent(this Transform trs, bool debug = false) {
            if (debug) {
                Debug.Log($"Unparent() called on {trs.gameObject.name}");
            }

            trs.SetParent(null);
        }

        public static bool HasChild(this Transform trs) => trs.childCount >= 1;
    }
}