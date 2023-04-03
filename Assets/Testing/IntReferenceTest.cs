using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FeTo.SOArchitecture;

public class IntReferenceTest : MonoBehaviour
{
    public IntVariable intVar;

    public IntReference intRef;

    private void Start() {
        Debug.Log("Reference value: " + intRef);
    }

    public void IncreaseValue() {
        intVar.ApplyChange(1);
        Debug.Log("New Value " + intVar.Value);
    }
}
