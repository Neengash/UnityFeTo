using UnityEngine;
using UnityEngine.Events;

namespace FeTo.SOArchitecture
{
    [System.Serializable]
    public class BoolEvent : UnityEvent<bool> { }

    [HelpURL("https://github.com/Neengash/UnityFeTo/tree/FeTo/SO_Architecture/GameEvents#scriptable-object---gameevents")]
    [CreateAssetMenu(fileName = "BoolGameEvent", menuName = "FeTo/SO_Architecture/BoolGameEvent", order = 1)]
    public class BoolGameEvent : GameEvent<bool, BoolEvent> { }
}
