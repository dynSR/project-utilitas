using UnityEngine;

namespace Utilitas {
    public static class ComponentExtensions {
        public static void SetParent(this Component component, Transform parent) {
            component.transform.SetParent(parent);
        }
    }
}