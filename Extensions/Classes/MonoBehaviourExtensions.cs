using UnityEngine;

namespace Utilitas
{
    public static class MonoBehaviourExtensions
    {
        public static bool TrySetParent(this MonoBehaviour monoBehaviour, Transform parent)
        {
            monoBehaviour.transform.SetParent(parent);
            return monoBehaviour.transform.IsChildOf(parent);
        }

        public static T GetOrAddComponent<T>(this MonoBehaviour monoBehaviour) where T : Component =>
            monoBehaviour.gameObject.GetOrAddComponent<T>();

        private static T GetOrAddComponent<T>(this GameObject gameObject) where T : Component
        {
            if (gameObject.TryGetComponent(out T comp)) return comp;
            return gameObject.AddComponent(typeof(T)) as T;
        }
    }
}