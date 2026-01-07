using UnityEngine;

namespace Utilitas {
    public static class GameObjectExtensions {
        public static bool HasParent(this GameObject go) => go.transform.parent != null;
    }
}