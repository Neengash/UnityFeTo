using UnityEditor;
using UnityEngine;

namespace FeTo.SOArchitecture
{
    [CustomEditor(typeof(IntGameEvent))]
    public class IntEventEditor : Editor
    {
        int eventIntValue = 0;

        public override void OnInspectorGUI() {
            base.OnInspectorGUI();

            GUI.enabled = Application.isPlaying;

            eventIntValue = EditorGUILayout.IntField(eventIntValue);

            IntGameEvent e = target as IntGameEvent;
            if (GUILayout.Button("Raise"))
                e.Raise(eventIntValue);
        }
    }
}
