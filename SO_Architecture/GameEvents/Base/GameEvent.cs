using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using Logger = FeTo.Logging.Logger;

namespace FeTo.SOArchitecture
{
    [HelpURL("https://github.com/Neengash/UnityFeTo/tree/FeTo/SO_Architecture/GameEvents#scriptable-object---gameevents")]
    [CreateAssetMenu(fileName = "GameEvent", menuName = "FeTo/SO_Architecture/GameEvent", order = 0)]
    public class GameEvent : FeToScriptableObject
    {
        /// <summary>
        /// The list of listeners that this event will notify if it is raised.
        /// </summary>
        private readonly List<GameEventListener> eventListeners = new();

#if UNITY_EDITOR
        [SerializeField]
        private bool _logEvents = false;
        public bool LogEvents { get => _logEvents; }
#endif

        public void UIRaise()
        {
#if UNITY_EDITOR
            Logger.FeToInfo(LogEvents, $"FeTo: {name} Raised By UI", this);
#endif
            DoRaise();
        }

        public void Raise([CallerMemberName] string callerName = "")
        {
#if UNITY_EDITOR
            Logger.FeToInfo(LogEvents, $"FeTo: {name} Raised By {callerName}", this);
#endif
            DoRaise();
        }

        private void DoRaise()
        {
            for (int i = eventListeners.Count - 1; i >= 0; i--)
                eventListeners[i].OnEventRaised();
        }

        public void RegisterListener(GameEventListener listener)
        {
            if (!eventListeners.Contains(listener))
            {
#if UNITY_EDITOR
                Logger.FeToInfo(LogEvents, $"FeTo: {listener.name} now listening to {this.name}", listener);
#endif
                eventListeners.Add(listener);
            }
        }

        public void UnregisterListener(GameEventListener listener)
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

