using UnityEngine;
using UnityEngine.Events;

namespace FeTo.SOArchitecture
{
    public class GameEventListener : MonoBehaviour
    {
        [Tooltip("Event to register with.")]
        public GameEvent Event;

        [Tooltip("Response to invoke when Event is raised.")]
        public UnityEvent Response;

        protected void OnEnable()
        {
            Event.RegisterListener(this);
        }

        protected void OnDisable()
        {
            Event.UnregisterListener(this);
        }

        public void OnEventRaised()
        {
#if UNITY_EDITOR
            Debug.Log($"FeTo: Event {Event.name} catched by {gameObject.name}");
#endif
            Response.Invoke();
        }
    }
}
