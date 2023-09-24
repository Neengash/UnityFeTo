using UnityEngine;
using UnityEngine.Events;
using Logger = FeTo.Logging.Logger;

namespace FeTo.SOArchitecture
{
    [HelpURL("https://github.com/Neengash/UnityFeTo/tree/FeTo/SO_Architecture/GameEvents#scriptable-object---gameevents")]
    public class GameEventListener : MonoBehaviour
    {
        [Tooltip("Event to register with.")]
        public GameEvent Event;

        [Tooltip("Response to invoke when Event is raised.")]
        public UnityEvent Response;

        public void OnEventRaised()
        {
#if UNITY_EDITOR
            Logger.FeToInfo(Event.LogEvents, $"FeTo: Event {Event.name} catched by {gameObject.name}");
#endif
            Response.Invoke();
        }
    }
}
