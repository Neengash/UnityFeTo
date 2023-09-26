using UnityEngine;

namespace FeTo.SOArchitecture
{
    [HelpURL("https://github.com/Neengash/UnityFeTo/tree/FeTo/SO_Architecture/GameEvents#scriptable-object---gameevents")]
    public class OnEnableFloatGameEventListener : FloatGameEventListener
    {
        protected void OnEnable()
        {
            Event.RegisterListener(this);
        }

        protected void OnDisable()
        {
            Event.UnregisterListener(this);
        }
    }
}
