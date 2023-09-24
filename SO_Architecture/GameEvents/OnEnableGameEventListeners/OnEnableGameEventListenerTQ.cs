using FeTo.SOArchitecture;
using UnityEngine.Events;

public abstract class OnEnableGameEventListener<T, Q> : GameEventListener<T, Q> where Q : UnityEvent<T>
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
