using UnityEngine;

namespace FeTo.Singleton
{
    [DefaultExecutionOrder(-1)]
    [HelpURL("https://github.com/Neengash/UnityFeTo/tree/FeTo/Singleton#singleton")]
    public class Singleton<T> : MonoBehaviour where T : Component
    {
        private static bool quitting = false;
        private static T _instance;

        public static T Instance
        {
            get
            {
                if (_instance == null && !quitting)
                {
                    GameObject go = new()
                    {
                        name = typeof(T).Name + "_Generated",
                    };
                    _instance = go.AddComponent<T>();
                }
                return _instance;
            }
        }

        protected virtual void Awake()
        {
            if (_instance == null)
            {
                _instance = this as T;
            }
            else if (_instance != this)
            {
                Destroy(gameObject);
            }
        }

        protected virtual void OnDestroy()
        {
            if (_instance == this)
            {
                _instance = null;
            }
        }

        protected void OnApplicationQuit()
        {
            quitting = true;
        }
    }
}