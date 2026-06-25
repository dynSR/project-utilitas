using UnityEngine;

namespace Utilitas
{
    public static class ComponentExtensions
    {
        public static bool TrySetParent(this Component component, Transform parent)
        {
            component.transform.SetParent(parent);
            return component.transform.IsChildOf(parent);
        }
    }
}