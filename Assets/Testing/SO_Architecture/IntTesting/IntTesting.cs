using FeTo.SOArchitecture;
using UnityEngine;

public class IntTesting : MonoBehaviour
{
    public IntReference intReference;
    public IntVariable intVariable;

    void Start()
    {
        Debug.Log($"intReference = {intReference}");
        Debug.Log($"intVariable = {intVariable.GetValue()}");
    }

    public void IntEventRaised(int i)
    {
        intVariable.ApplyChange(i);
        Debug.Log($"intVariable = {intVariable.GetValue()}");
    }
}
