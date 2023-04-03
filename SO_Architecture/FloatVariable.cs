using UnityEngine;

namespace FeTo.SOArchitecture
{
    [CreateAssetMenu(fileName = "FloatVariable", menuName = "FeTo/SO_Architecture/FloatVariable")]
    public class FloatVariable : ScriptableVariable<float>
    {
        public override void ApplyChange(float amount) {
            value += amount;
        }

        public override void ApplyChange(ScriptableVariable<float> amount) {
            value += amount.GetValue();
        }
    }
}
