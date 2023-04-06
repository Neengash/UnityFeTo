using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace FeTo.SOArchitecture
{
    public abstract class GameEvent<T, Q> : ScriptableObject where Q : UnityEvent<T>
    {
        /// <summary>
        /// The list of listeners that this event will notify if it is raised.
        /// </summary>
        private readonly List<GameEventListener<T, Q>> eventListeners =
            new List<GameEventListener<T, Q>>();

        public System.Type GetEventType() {
            return typeof(T);
        }

        public void Raise(T value) {
            for (int i = eventListeners.Count - 1; i >= 0; i--)
                eventListeners[i].OnEventRaised(value);
        }

        public void RegisterListener(GameEventListener<T, Q> listener) {
            if (!eventListeners.Contains(listener))
                eventListeners.Add(listener);
        }

        public void UnregisterListener(GameEventListener<T, Q> listener) {
            if (eventListeners.Contains(listener))
                eventListeners.Remove(listener);
        }
    }
}
