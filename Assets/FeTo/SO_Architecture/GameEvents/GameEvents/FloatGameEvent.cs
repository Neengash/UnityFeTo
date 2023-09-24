using UnityEngine;
using UnityEngine.Events;

namespace FeTo.SOArchitecture
{
    [System.Serializable]
    public class FloatEvent : UnityEvent<float> { }

    [CreateAssetMenu(fileName = "FloatGameEvent", menuName = "FeTo/SO_Architecture/FloatGameEvent", order = 3)]
    public class FloatGameEvent : GameEvent<float, FloatEvent> { }
}
