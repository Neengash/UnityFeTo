using UnityEditor;
using UnityEngine;

namespace FeTo.Saving
{
    public class KeySavingStrategyEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            KeySavingStrategy keySaving = (KeySavingStrategy)target;
            base.OnInspectorGUI();
            EditorGUILayout.HelpBox("Use below button to generate a random key. " +
                 "Once you've set this key, don't touch the field again. " +
                 "It's as secure as it's going to get, and the key MUST match" +
                 " with saved file to use the saved file again!", MessageType.Warning);
            if (GUILayout.Button("Generate key"))
            {
                GenerateKey(keySaving);
            }

        }
#if UNITY_EDITOR
        private void GenerateKey(KeySavingStrategy strategy)
        {
            SerializedObject serializedObject = new SerializedObject(strategy);
            SerializedProperty property = serializedObject.FindProperty("key");
            property.stringValue = System.Guid.NewGuid().ToString();
            serializedObject.ApplyModifiedProperties();
        }

#endif
    }

}
