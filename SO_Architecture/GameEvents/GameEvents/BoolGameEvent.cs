using UnityEngine;
using UnityEngine.Events;

namespace FeTo.SOArchitecture
{
    [System.Serializable]
    public class BoolEvent : UnityEvent<bool> { }

    [CreateAssetMenu(fileName = "BoolGameEvent", menuName = "FeTo/SO_Architecture/BoolGameEvent", order = 1)]
    public class BoolGameEvent : GameEvent<bool, BoolEvent> { }
}
