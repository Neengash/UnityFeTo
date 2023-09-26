using UnityEditor;
using UnityEngine;

namespace FeTo.SOArchitecture
{
    [CustomEditor(typeof(StringGameEvent))]
    public class StringEventEditor : Editor
    {
        string stringEventValue = string.Empty;

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            GUI.enabled = Application.isPlaying;

            stringEventValue = EditorGUILayout.TextField(stringEventValue);

            StringGameEvent e = target as StringGameEvent;
            if (GUILayout.Button("Raise"))
                e.Raise(stringEventValue);
        }
    }
}
