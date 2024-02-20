using System.Collections.Generic;
using UnityEngine;

namespace FeTo.Saving
{
    public class SavingWrapper : MonoBehaviour
    {
        [SerializeField] SavingSystem savingSystem;

        public static List<SaveableEntity> SaveableEntities = new();

        private const string _defaultSaveFile = "save";

        private void Start() => savingSystem.Load(_defaultSaveFile);

        private void Save() {
            savingSystem.Save(_defaultSaveFile);
        }

        private void Load() {
            savingSystem.Load(_defaultSaveFile);
        }

        private void DeleteSave() => savingSystem.DeleteSaveFile(_defaultSaveFile);
    }
}