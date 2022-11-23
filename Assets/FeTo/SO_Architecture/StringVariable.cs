using UnityEngine;

namespace FeTo.soArchitecture
{
    [CreateAssetMenu(fileName = "StringVariable", menuName = "FeTo/SO_Architecture/StringVariable", order = 1)]
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
