using UnityEngine;
using FeTo.SOArchitecture;

public class BoolReferenceTest : MonoBehaviour
{
    public BoolReference boolRef;

    public BoolVariable variable;

    void Start()
    {
        if (boolRef) {
            Debug.Log("Reference is true");
        } else {
            Debug.Log("Reference is false");
        }

        if (variable.Value) {
            Debug.Log("Variable is true");
        } else {
            Debug.Log("Variable is false");
        }
    }
}
