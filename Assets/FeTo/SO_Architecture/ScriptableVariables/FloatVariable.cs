using UnityEngine;

namespace FeTo.SOArchitecture
{
    [HelpURL("https://github.com/Neengash/UnityFeTo/tree/FeTo/SO_Architecture/ScriptableVariables#scriptable-variables")]
    [CreateAssetMenu(fileName = "FloatVariable", menuName = "FeTo/SO_Architecture/FloatVariable", order = 22)]
    public class FloatVariable : ScriptableVariable<float>
    {
        public override void ApplyChange(float amount)
        {
            value += amount;
        }

        public override void ApplyChange(ScriptableVariable<float> amount)
        {
            value += amount.GetValue();
        }
    }
}
