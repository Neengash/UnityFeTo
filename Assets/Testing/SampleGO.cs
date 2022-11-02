using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleGO : MonoBehaviour
{
    private SampleSingleton sample;
    void Start()
    {
        sample = SampleSingleton.Instance;
    }
}
