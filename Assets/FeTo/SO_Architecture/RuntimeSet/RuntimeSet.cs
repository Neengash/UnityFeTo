using System.Collections.Generic;
using UnityEngine;

namespace FeTo.SOArchitecture
{
    public abstract class RuntimeSet<T> : ScriptableObject
    {
        public List<T> Items = new();

        public void Add(T thing)
        {
            if (!Items.Contains(thing))
                Items.Add(thing);
        }

        public void Remove(T thing)
        {
            if (Items.Contains(thing))
                Items.Remove(thing);
        }
    }
}
