using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace FeTo.Saving
{
    [CustomEditor(typeof(KeySavingStrategy))]
    public class KeySavingStrategyEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            KeySavingStrategy keySaving = (KeySavingStrategy)target;
            base.OnInspectorGUI();
            if (GUILayout.Button("Generate key"))
            {
                keySaving.GenerateKey();
            }
        }
    }

}
