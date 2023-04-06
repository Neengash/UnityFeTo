using UnityEngine;

namespace FeTo.SOArchitecture
{
    [CreateAssetMenu(fileName = "BoolVariable", menuName = "FeTo/SO_Architecture/BoolVariable", order = 20)]
    public class BoolVariable : ScriptableVariable<bool>
    {
        public override void ApplyChange(bool value) {
            throw new System.NotImplementedException();
        }

        public override void ApplyChange(ScriptableVariable<bool> variable) {
            throw new System.NotImplementedException();
        }
    }
}
