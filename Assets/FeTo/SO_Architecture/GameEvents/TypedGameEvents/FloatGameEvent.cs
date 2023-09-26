using UnityEngine;
using UnityEngine.Events;

namespace FeTo.SOArchitecture
{
    [System.Serializable]
    public class FloatEvent : UnityEvent<float> { }

    [HelpURL("https://github.com/Neengash/UnityFeTo/tree/FeTo/SO_Architecture/GameEvents#scriptable-object---gameevents")]
    [CreateAssetMenu(fileName = "FloatGameEvent", menuName = "FeTo/SO_Architecture/FloatGameEvent", order = 3)]
    public class FloatGameEvent : GameEvent<float, FloatEvent> { }
}
