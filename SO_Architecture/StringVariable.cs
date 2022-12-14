using UnityEngine;

namespace FeTo.SOArchitecture
{
    [CreateAssetMenu(fileName = "StringVariable", menuName = "FeTo/SO_Architecture/StringVariable")]
    public class StringVariable : ScriptableObject
    {
        [SerializeField]
        private string value = "";

        public string Value {
            get { return value; }
            set { this.value = value; }
        }
    }
}
