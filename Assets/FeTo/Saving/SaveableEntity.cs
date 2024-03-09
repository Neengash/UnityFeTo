using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using UnityEditor;
using UnityEngine;

namespace FeTo.Saving
{
    [ExecuteAlways]
    public class SaveableEntity : MonoBehaviour
    {
        [SerializeField] string uniqueIdentifier = "";

        private static Dictionary<string, SaveableEntity> _globalLookup = new();
        private List<ISaveable> saveables = new();

        private void Awake() {
            saveables = GetComponents<ISaveable>().ToList();
            SavingWrapper.SaveableEntities.Add(this);
        }

        public string GetUniqueIdentifier() => uniqueIdentifier;

        public JToken CaptureAsJToken() {
            var state = new JObject();
            IDictionary<string, JToken> stateDict = state;

            foreach (var saveable in saveables) {
                var token = saveable.CaptureAsJToken();
                var component = saveable.GetType().ToString();
                stateDict[component] = token;
            }

            return state;
        }

        public void RestoreFromJToken(JToken s) {
            var state = s.ToObject<JObject>();
            IDictionary<string, JToken> stateDict = state;

            foreach (var saveable in saveables) {
                var component = saveable.GetType().ToString();
                if (stateDict.ContainsKey(component)) {
                    saveable.RestoreFromJToken(stateDict[component]);
                }
            }
        }

#if UNITY_EDITOR

        private void Update()
        {
            if (Application.IsPlaying(gameObject)) return; // If game is playing
            if (string.IsNullOrEmpty(gameObject.scene.path)) return; // If in prefab scene

            var serializedObject = new SerializedObject(this);
            var property = serializedObject.FindProperty("uniqueIdentifier");

            if (!IsValid(property.stringValue))
            {
                property.stringValue = Guid.NewGuid().ToString();
                serializedObject.ApplyModifiedProperties();
            }

            _globalLookup[property.stringValue] = this;
        }

#endif

        private bool IsValid(string candidate) {
            if (string.IsNullOrEmpty(candidate) || !IsUnique(candidate))
                return false;

            return true;
        }

        private bool IsUnique(string candidate) {
            if (!_globalLookup.ContainsKey(candidate)) return true;
            if (_globalLookup[candidate] == this) return true;

            if (_globalLookup[candidate] == null) {
                _globalLookup.Remove(candidate);
                return true;
            }

            if (_globalLookup[candidate].GetUniqueIdentifier() != candidate) {
                _globalLookup.Remove(candidate);
                return true;
            }

            return false;
        }
    }
}