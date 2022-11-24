using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FeTo.SOArchitecture;

public class FloatReferenceTest : MonoBehaviour
{
    public FloatVariable floatVar;

    public void IncreaseValue() {
        floatVar.ApplyChange(1);
        Debug.Log("New value" + floatVar);
    }

}
