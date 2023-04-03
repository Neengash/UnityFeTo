using System;
using UnityEngine;

namespace FeTo.SOArchitecture
{
    [Serializable]
    [HelpURL("https://github.com/Neengash/UnityFeTo/tree/FeTo/SO_Architecture#scriptable-variables-and-references")]
    public abstract class ScriptableReference<T>
    {
        public bool UseConstant = true;
        public T ConstantValue;
        public ScriptableVariable<T> Variable;

        public ScriptableReference() { }

        public ScriptableReference(T value) {
            UseConstant = true;
            ConstantValue = value;
        }

        public T Value {
            get { return UseConstant ? ConstantValue : Variable.GetValue(); }
        }

        public static implicit operator T (ScriptableReference<T> reference) {
            return reference.Value;
        }

        public override string ToString() => Value.ToString();
    }
}
