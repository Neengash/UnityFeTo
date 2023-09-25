using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;
using Logger = FeTo.Logging.Logger;

namespace FeTo.SOArchitecture
{
    [HelpURL("https://github.com/Neengash/UnityFeTo/tree/FeTo/SO_Architecture/GameEvents#scriptable-object---gameevents")]
    public abstract class GameEvent<T, Q> : ScriptableObject where Q : UnityEvent<T>
    {
        /// <summary>
        /// The list of listeners that this event will notify if it is raised.
        /// </summary>
        private readonly List<GameEventListener<T, Q>> eventListeners = new();

#if UNITY_EDITOR
        [SerializeField]
        private bool _logEvents = false;
        public bool LogEvents { get => _logEvents; }
#endif 

        public System.Type GetEventType()
        {
            return typeof(T);
        }

        public void UIRaise(T value)
        {
#if UNITY_EDITOR
            Logger.FeToInfo(LogEvents, $"FeTo: {this.name} Raised By UI", this);
#endif
            DoRaise(value);
        }

        public void Raise(T value, [CallerMemberName] string callerName = "")
        {
#if UNITY_EDITOR
            Logger.FeToInfo(LogEvents, $"FeTo: {this.name} Raised By {callerName}", this);
#endif
            DoRaise(value);
        }

        private void DoRaise(T value)
        {
            for (int i = eventListeners.Count - 1; i >= 0; i--)
                eventListeners[i].OnEventRaised(value);
        }

        public void RegisterListener(GameEventListener<T, Q> listener)
        {
            if (!eventListeners.Contains(listener))
            {
#if UNITY_EDITOR
                Logger.FeToInfo(LogEvents, $"FeTo: {listener.name} now listening to {this.name}", listener);
#endif
                eventListeners.Add(listener);
            }
        }

        public void UnregisterListener(GameEventListener<T, Q> listener)
        {
            if (eventListeners.Contains(listener))
            {
#if UNITY_EDITOR
                Logger.FeToInfo(LogEvents, $"FeTo: {listener.name} stopped listening to {this.name}", listener);
#endif
                eventListeners.Remove(listener);
            }
        }
    }
}
