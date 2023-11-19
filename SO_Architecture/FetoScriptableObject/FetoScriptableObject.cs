using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace FeTo.SOArchitecture
{
    public abstract class FeToScriptableObject : ScriptableObject
    {
#if UNITY_EDITOR
        [Tooltip("If active, scriptable object's value is reset when play mode ends")]
        [SerializeField] private bool resetValue = true;
        private string _startingValues = string.Empty;

        private void OnEnable()
        {
            EditorApplication.playModeStateChanged += OnPlayModeStateChanged;
        }

        private void OnDisable()
        {
            EditorApplication.playModeStateChanged -= OnPlayModeStateChanged;
        }

        private void OnPlayModeStateChanged(PlayModeStateChange playModeState)
        {
            switch (playModeState)
            {
                case PlayModeStateChange.EnteredPlayMode:
                    _startingValues = EditorJsonUtility.ToJson(this);
                    break;

                case PlayModeStateChange.ExitingPlayMode:
                    // Make sure to unsubscribe
                    EditorApplication.playModeStateChanged -= OnPlayModeStateChanged;
                    if (resetValue)
                        EditorJsonUtility.FromJsonOverwrite(_startingValues, this);
                    break;
            }
        }
#endif
    }
}
