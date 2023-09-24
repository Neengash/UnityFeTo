using FeTo.SOArchitecture;
using UnityEngine;

public class FloatTesting : MonoBehaviour
{
    public FloatReference floatReference;
    public FloatVariable floatVariable;

    private void Start()
    {
        Debug.Log($"floatReference = {floatReference}");
        Debug.Log($"floatVariable = {floatVariable.GetValue()}");
    }

    public void FloatEventRaised(float i)
    {
        floatVariable.ApplyChange(i);
        Debug.Log($"floatVariable = {floatVariable.GetValue()}");
    }
}
