using UnityEngine;
using FeTo.SOArchitecture;

public class FloatTesting : MonoBehaviour
{
    public FloatReference floatReference;
    public FloatVariable floatVariable;

    private void Start() {
        Debug.Log($"floatReference = {floatReference}");
        Debug.Log($"floatVariable = {floatVariable.GetValue()}");
    }

    public void floatEventRaised(float i) {
        floatVariable.ApplyChange(i);
        Debug.Log($"floatVariable = {floatVariable.GetValue()}");
    }
}
