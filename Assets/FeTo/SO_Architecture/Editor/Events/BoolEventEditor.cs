using UnityEditor;
using UnityEngine;

namespace FeTo.SOArchitecture
{
    [CustomEditor(typeof(BoolGameEvent))]
    public class BoolEventEditor : Editor
    {
        bool eventBoolValue = false;

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            GUI.enabled = Application.isPlaying;

            eventBoolValue = EditorGUILayout.Toggle(eventBoolValue);

            BoolGameEvent e = target as BoolGameEvent;
            if (GUILayout.Button("Raise"))
                e.Raise(eventBoolValue);
        }
    }
}
