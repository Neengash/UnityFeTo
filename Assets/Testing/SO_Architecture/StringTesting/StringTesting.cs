using UnityEngine;
using FeTo.SOArchitecture;

public class StringTesting : MonoBehaviour
{
    public StringReference stringReference;
    public StringVariable stringVariable;

    void Start()
    {
        Debug.Log($"stringReference = {stringReference}");
        Debug.Log($"stringVariable = {stringVariable.GetValue()}");
    }

    public void stringEventRaised(string value) {
        stringVariable.SetValue(value);
        Debug.Log($"stringVariable = {stringVariable.GetValue()}");
    }
}
