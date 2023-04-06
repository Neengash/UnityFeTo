using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FeTo.SOArchitecture
{
    [HelpURL("https://github.com/Neengash/UnityFeTo/tree/FeTo/SO_Architecture#scriptable-variables-and-references")]
    public abstract class ScriptableVariable<T> : ScriptableObject
    {
#if UNITY_EDITOR
        [Multiline]
        public string DeveloperDescription = "";
#endif

        [SerializeField]
        protected T value;

        public T GetValue() {
            return value;
        }

        public void SetValue(T value) => this.value = value;
        public void SetValue(ScriptableVariable<T> variable) => this.value = variable.GetValue();

        public abstract void ApplyChange(T value);
        public abstract void ApplyChange(ScriptableVariable<T> variable);
    }
}
