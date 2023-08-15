using UnityEngine;
using FeTo.SOArchitecture;

public class BoolTesting : MonoBehaviour
{
    public BoolReference boolReference;

    public BoolVariable boolVariable;

    private void Start() {
        Debug.Log($"boolReference = {boolReference}");
        Debug.Log($"boolVariable = {boolVariable.GetValue()}");
    }

    public void BoolEventRaised(bool value) {
        boolVariable.SetValue(value);
        Debug.Log($"boolVariable = {boolVariable.GetValue()}");
    }
}
