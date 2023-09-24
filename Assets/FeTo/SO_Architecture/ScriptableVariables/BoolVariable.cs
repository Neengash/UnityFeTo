using UnityEngine;

namespace FeTo.SOArchitecture
{
    [HelpURL("https://github.com/Neengash/UnityFeTo/tree/FeTo/SO_Architecture/ScriptableVariables#scriptable-variables")]
    [CreateAssetMenu(fileName = "BoolVariable", menuName = "FeTo/SO_Architecture/BoolVariable", order = 20)]
    public class BoolVariable : ScriptableVariable<bool>
    {
        public override void ApplyChange(bool value)
        {
            throw new System.NotImplementedException();
        }

        public override void ApplyChange(ScriptableVariable<bool> variable)
        {
            throw new System.NotImplementedException();
        }
    }
}
