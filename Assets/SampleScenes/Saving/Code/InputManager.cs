using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FeTo.SOArchitecture;

public class InputManager : MonoBehaviour
{
    [SerializeField] GameEvent save;
    [SerializeField] GameEvent load;
    [SerializeField] GameEvent delete;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            save.Raise();
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            load.Raise();
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            delete.Raise();
        }
    }
}
