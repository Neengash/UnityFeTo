using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace FeTo.Saving
{
    [HelpURL("https://github.com/Neengash/UnityFeTo/tree/FeTo/Saving#feto-saver")]
    public class SavingSystem : MonoBehaviour
    {
        [SerializeField] private SavingStrategy strategy;


        public void Save(string saveFile)
        {
            JObject state = LoadJsonFromFile(saveFile);
            CaptureAsToken(state);
            SaveFileAsJson(saveFile, state);
        }

        public void Load(string saveFile)
        {
            var path = GetPathFromSaveFile(saveFile);
            RestoreFromToken(LoadJsonFromFile(saveFile));
        }

        public void DeleteSaveFile(string saveFile)
        {
            var path = GetPathFromSaveFile(saveFile);
            if (!File.Exists(path)) return;

            File.Delete(path);
        }

        private void SaveFileAsJson(string saveFile, JObject state)
        {
            strategy.SaveToFile(saveFile, state);
        }

        private JObject LoadJsonFromFile(string saveFile)
        {
            return strategy.LoadFromFile(saveFile);
        }

        private void CaptureAsToken(JObject state)
        {
            IDictionary<string, JToken> stateDict = state;
            foreach (var saveable in SavingWrapper.SaveableEntities)
            {
                if (saveable.Value != null)
                {
                    stateDict[saveable.Key] = saveable.Value.CaptureAsJToken();
                }
            }
        }

        private void RestoreFromToken(JObject state)
        {
            IDictionary<string, JToken> stateDict = state;
            foreach (var saveable in SavingWrapper.SaveableEntities)
            {
                if (saveable.Value != null)
                {
                    var id = saveable.Value.GetUniqueIdentifier();
                    if (stateDict.ContainsKey(id))
                        saveable.Value.RestoreFromJToken(stateDict[id]);

                }
            }
        }

        private string GetPathFromSaveFile(string saveFile)
        {
            return strategy.GetPathFromSaveFile(saveFile);
        }
    }
}