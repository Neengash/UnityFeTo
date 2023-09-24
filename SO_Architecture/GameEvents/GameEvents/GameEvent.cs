using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace FeTo.SOArchitecture
{
    [CreateAssetMenu(fileName = "GameEvent", menuName = "FeTo/SO_Architecture/GameEvent", order = 0)]
    public class GameEvent : ScriptableObject
    {
        /// <summary>
        /// The list of listeners that this event will notify if it is raised.
        /// </summary>
        private readonly List<GameEventListener> eventListeners = new();

        public void UIRaise()
        {
#if UNITY_EDITOR
            Debug.Log($"FeTo: {this.name} Raised By UI");
#endif
            DoRaise();
        }

        public void Raise([CallerMemberName] string callerName = "")
        {
#if UNITY_EDITOR
            Debug.Log($"FeTo: {this.name} Raised By {callerName}");
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
                eventListeners.Add(listener);
        }

        public void UnregisterListener(GameEventListener listener)
        {
            if (eventListeners.Contains(listener))
                eventListeners.Remove(listener);
        }
    }
}

