using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FeTo.SOArchitecture
{
    public abstract class ScriptableVariable<T> : ScriptableObject
    {
#if UNITY_EDITOR
        [Multiline]
        public string DeveloperDescription = "";
#endif

        public T Value;

        public void SetValue(T value) => Value = value;
        public void SetValue(ScriptableVariable<T> variable) => Value = variable.Value;

        public abstract void ApplyChange(T value);
        public abstract void ApplyChange(ScriptableVariable<T> variable);
    }
}
