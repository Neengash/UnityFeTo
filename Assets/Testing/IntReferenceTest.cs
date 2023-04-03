using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FeTo.SOArchitecture;

public class IntReferenceTest : MonoBehaviour
{
    public IntVariable intVar;

    public void IncreaseValue() {
        intVar.ApplyChange(1);
        Debug.Log("New Value " + intVar.Value);
    }
}
