using UnityEditor;
using UnityEngine;

namespace FeTo.SOArchitecture
{
    [CustomEditor(typeof(FloatGameEvent))]
    public class FloatEventEditor : Editor
    {
        float floatEventValue = 0;

        public override void OnInspectorGUI() {
            base.OnInspectorGUI();

            GUI.enabled = Application.isPlaying;

            floatEventValue = EditorGUILayout.FloatField(floatEventValue);

            FloatGameEvent e = target as FloatGameEvent;
            if (GUILayout.Button("Raise"))
                e.Raise(floatEventValue);
        }
    }
}
