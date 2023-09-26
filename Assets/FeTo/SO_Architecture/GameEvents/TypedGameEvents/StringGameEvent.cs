using UnityEngine;
using UnityEngine.Events;

namespace FeTo.SOArchitecture
{
    [System.Serializable]
    public class StringEvent : UnityEvent<string> { }

    [HelpURL("https://github.com/Neengash/UnityFeTo/tree/FeTo/SO_Architecture/GameEvents#scriptable-object---gameevents")]
    [CreateAssetMenu(fileName = "StringGameEvent", menuName = "FeTo/SO_Architecture/StringGameEvent", order = 4)]
    public class StringGameEvent : GameEvent<string, StringEvent> { }
}
