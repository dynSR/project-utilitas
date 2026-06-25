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

        public static bool TryEnable(this Behaviour behaviour)
        {
            behaviour.Enable();
            return behaviour.enabled;
        }

        public static bool TryDisable(this Behaviour behaviour)
        {
            behaviour.Disable();
            return !behaviour.enabled;
        }

        private static void Enable(this Behaviour behaviour) => behaviour.enabled = true;
        private static void Disable(this Behaviour behaviour) => behaviour.enabled = false;
    }
}