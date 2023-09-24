using UnityEngine;

namespace FeTo.SOArchitecture
{
    [HelpURL("https://github.com/Neengash/UnityFeTo/tree/FeTo/SO_Architecture/ScriptableVariables#scriptable-variables")]
    [CreateAssetMenu(fileName = "IntVariable", menuName = "FeTo/SO_Architecture/IntVariable", order = 21)]
    public class IntVariable : ScriptableVariable<int>
    {
        public override void ApplyChange(int amount)
        {
            value += amount;
        }

        public override void ApplyChange(ScriptableVariable<int> amount)
        {
            value += amount.GetValue();
        }
    }
}
