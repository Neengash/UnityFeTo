using UnityEngine;

namespace Feto {
    public class Singleton <T> : MonoBehaviour where T : Component
    {
        private static bool quitting = false;
        private static T _instance;

        public static T Instance {
            get{
                if (_instance == null && !quitting) {
                    GameObject go = new GameObject();
                    go.name = typeof(T).Name; // Can remove if next sentence is uncommented
                    //go.hideFlags = HideFlags.HideAndDontSave; // Hide in hierarchy
                    _instance = go.AddComponent<T>();
                }
                return _instance;
            }
        }

        protected virtual void Awake() {
            if (_instance == null) {
                _instance = this as T;
            } else if (_instance != this) {
                Destroy(gameObject);
            }
        }

        protected virtual void OnDestroy() {
            if (_instance == this) {
                _instance = null;
            }
        }

        protected void OnApplicationQuit() {
            quitting = true;
        }
    }


    public class SingletonPersistent <T> : MonoBehaviour where T : Component
    {
        private static bool quitting = false;
        private static T _instance;

        public static T Instance {
            get{
                if (_instance == null && !quitting) {
                    GameObject go = new GameObject();
                    go.name = typeof(T).Name; // Can remove if next sentence is uncommented
                    //go.hideFlags = HideFlags.HideAndDontSave; // Hide in hierarchy
                    _instance = go.AddComponent<T>();
                }
                return _instance;
            }
        }

        protected virtual void Awake() {
            if (_instance == null) {
                _instance = this as T;
                DontDestroyOnLoad(gameObject);
            } else if (_instance != this) {
                Destroy(gameObject);
            }
        }

        protected virtual void OnDestroy() {
            if (_instance == this) {
                _instance = null;
            }
        }

        protected void OnApplicationQuit() {
            quitting = true;
        }
    }
}