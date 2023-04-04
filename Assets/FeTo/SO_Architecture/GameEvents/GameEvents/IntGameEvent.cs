using UnityEngine;
using UnityEngine.Events;

namespace FeTo.SOArchitecture
{
    [System.Serializable]
    public class IntEvent : UnityEvent<int> { }
    [CreateAssetMenu(fileName = "IntGameEvent", menuName = "FeTo/SO_Architecture/IntGameEvent", order = 2)]
    public class IntGameEvent : GameEvent<int, IntEvent> { }
}
