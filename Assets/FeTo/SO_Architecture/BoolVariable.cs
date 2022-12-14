using UnityEngine;

namespace FeTo.SOArchitecture
{
    [CreateAssetMenu(fileName = "BoolVariable", menuName = "FeTo/SO_Architecture/BoolVariable")]
    public class BoolVariable : ScriptableObject
    {
        public bool Value;
    }
}
