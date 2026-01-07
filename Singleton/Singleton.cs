using UnityEngine;

namespace Utilitas {
    public class Singleton<T> : MonoBehaviour where T : Component {
        public bool autoUnparentOnAwake = true;

        protected static T instance;

        public static T Instance {
            get {
                if (instance == null) {
                    instance = FindAnyObjectByType<T>();
                    if (instance == null) {
                        var go = new GameObject(typeof(T).Name + "Auto-Generated");
                        instance = go.AddComponent<T>();
                    }
                }

                return instance;
            }
        }

        protected Singleton() { }

        protected virtual void Awake() => Init();

        public virtual void Init() {
            if (!Application.isPlaying) return;

            if (autoUnparentOnAwake) transform.Unparent();

            if (instance == null) {
                instance = this as T;
                DontDestroyOnLoad(gameObject);
            }
            else {
                if (instance != this) {
                    Destroy(gameObject);
                }
            }
        }
    }
}