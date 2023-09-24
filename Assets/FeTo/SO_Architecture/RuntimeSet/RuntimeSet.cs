using System.Collections.Generic;
using UnityEngine;
using Logger = FeTo.Logging.Logger;

namespace FeTo.SOArchitecture
{
    public abstract class RuntimeSet<T> : ScriptableObject where T : Object
    {
        public List<T> Items = new();

#if UNITY_EDITOR
        [SerializeField]
        private bool _logEvents = false;
#endif

        public void Add(T thing)
        {
            if (!Items.Contains(thing))
            {
#if UNITY_EDITOR
                Logger.FeToInfo(_logEvents, $"Added {thing.name} to {this.name}");
#endif
                Items.Add(thing);
            }
        }

        public void Remove(T thing)
        {
            if (Items.Contains(thing))
            {
#if UNITY_EDITOR
                Logger.FeToInfo(_logEvents, $"Removed {thing.name} from {this.name}");
#endif
                Items.Remove(thing);
            }
        }
    }
}
