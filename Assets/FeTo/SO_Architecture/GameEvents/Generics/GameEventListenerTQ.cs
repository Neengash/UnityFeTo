using UnityEngine;
using UnityEngine.Events;
using Logger = FeTo.Logging.Logger;

namespace FeTo.SOArchitecture
{
    public abstract class GameEventListener<T, Q> : MonoBehaviour where Q : UnityEvent<T>
    {
        [Tooltip("Event to register with.")]
        public GameEvent<T, Q> Event;

        [Tooltip("Response to invoke when Event is raised.")]
        public Q Response;

        protected void OnEnable()
        {
            Event.RegisterListener(this);
        }

        protected void OnDisable()
        {
            Event.UnregisterListener(this);
        }

        public void OnEventRaised(T value)
        {
#if UNITY_EDITOR
            Logger.FeToInfo(Event.LogEvents, $"FeTo: Event {Event.name} catched by {gameObject.name}");
#endif
            Response.Invoke(value);
        }
    }
}
