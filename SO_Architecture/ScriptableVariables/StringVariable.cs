using UnityEngine;

namespace FeTo.SOArchitecture
{
    [CreateAssetMenu(fileName = "StringVariable", menuName = "FeTo/SO_Architecture/StringVariable", order = 23)]
    public class StringVariable : ScriptableVariable<string>
    {
        public override void ApplyChange(string value) {
            throw new System.NotImplementedException();
        }

        public override void ApplyChange(ScriptableVariable<string> variable) {
            throw new System.NotImplementedException();
        }
    }
}
